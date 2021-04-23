using System.Diagnostics;
using System.IO;
using BostDB;
using BostDB.MiniSqlParser;
using System.Collections.Generic;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DataBase> dataBasesList = new List<DataBase>();
            bool exist;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double time=0.00;

            int index = 1;
            string[] lines = File.ReadAllLines("Input.txt");

            System.Console.WriteLine("# TEST " + index.ToString());
            string[] databaseString = lines[0].Split(',');
            
            DataBase dataBase = new DataBase(databaseString[0], databaseString[1], databaseString[2]);
            dataBasesList.Add(dataBase);

            System.Console.WriteLine(Messages.CreateDatabaseSuccess);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if(lines[i] != "")
                {
                    IQuery query = Parser.Parse(line);
                    if (query != null)
                    {
                        stopwatch.Restart();
                        System.Console.WriteLine(query.Run(dataBase) + "    (" + (stopwatch.Elapsed.TotalMilliseconds).ToString("0.0000 ms") + ")");
                        time += stopwatch.Elapsed.TotalMilliseconds;
                    }
                    else
                    {
                        System.Console.WriteLine(Messages.WrongSyntax + "    (" + (stopwatch.Elapsed.TotalMilliseconds).ToString("0.0000 ms") + ")");
                        time += stopwatch.Elapsed.TotalMilliseconds;
                    }
                }
                else 
                {
                    System.Console.WriteLine("TOTAL TIME: " + time.ToString("0.0000 ms"));
                    index++;
                    System.Console.WriteLine("");
                    System.Console.WriteLine("# TEST " + index.ToString());

                    i++;
                    databaseString = lines[i].Split(',');

                    exist = false;

                    foreach(DataBase db in dataBasesList)
                    {
                        if(db.GetName() == databaseString[0])
                        {
                            exist = true;
                            break;
                        }
                    }

                    if (exist)
                    {
                        System.Console.WriteLine(Messages.OpenDatabaseSuccess);
                    }
                    else
                    {
                        dataBase = new DataBase(databaseString[0], databaseString[1], databaseString[2]); ;
                        dataBasesList.Add(dataBase);
                        System.Console.WriteLine(Messages.CreateDatabaseSuccess);
                    }

                    time = 0.00;

                }

            }
            System.Console.WriteLine("TOTAL TIME: " + time.ToString("0.0000 ms"));
            stopwatch.Stop();
        }
    }
}
