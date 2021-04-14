using System.IO;
using BostDB;
using BostDB.MiniSqlParser;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            string[] lines = File.ReadAllLines("Input.txt");

            foreach(string line in lines)
            {
                if(line != "")
                {
                    //Parser parse; 
                }

            }
        }
    }
}
