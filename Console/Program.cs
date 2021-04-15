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
                        System.Console.WriteLine(query.Run(dataBase) + "    (" + stopwatch.Elapsed.TotalSeconds.ToString("0.00 s") + ")");
                        time += stopwatch.Elapsed.TotalSeconds;
                    }
                    else
                    {
                        System.Console.WriteLine(Messages.WrongSyntax);
                    }

                }
                else 
                {
                    System.Console.WriteLine("TOTAL TIME: " + time.ToString("0.00 s"));
                    index++;
                    dataBase = new DataBase("DataBase" + index.ToString(), "Bost", "contraseña");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("# TEST " + index.ToString());
                    time = 0.00;
                }

            }
            System.Console.WriteLine("TOTAL TIME: " + time.ToString("0.00 s"));
            stopwatch.Stop();
        }
    }
}
