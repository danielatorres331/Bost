using System.IO;
using BostDB;
using BostDB.MiniSqlParser;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
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
                        System.Console.WriteLine(query.Run(dataBase));
                    else
                        System.Console.WriteLine(Messages.WrongSyntax);

                }
                else 
                {
                    index++;
                    dataBase = new DataBase("DataBase" + index.ToString(), "Bost", "contraseña");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("# TEST " + index.ToString());
                }

            }
        }
    }
}
