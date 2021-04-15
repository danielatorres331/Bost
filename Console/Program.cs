using System.Diagnostics;
using System.IO;
using BostDB;
using BostDB.MiniSqlParser;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            double time=0.00;

            int index = 1;
            //Console.WriteLine("Hello World!");
            string[] lines = File.ReadAllLines("Input.txt");

            DataBase dataBase = new DataBase("DataBase" + index.ToString(), "Bost", "contraseña");
            System.Console.WriteLine("# TEST " + index.ToString());

            foreach(string line in lines)
            {
                if(line != "")
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
                    dataBase = new DataBase("DataBase" + index.ToString(), "Bost", "contraseña");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("# TEST " + index.ToString());
                    time = 0.00;
                }

            }
            System.Console.WriteLine("TOTAL TIME: " + time.ToString("0.0000 ms"));
            stopwatch.Stop();
        }
    }
}
