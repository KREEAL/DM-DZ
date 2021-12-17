using System;
using System.Collections.Generic;
using System.IO;

namespace Dm1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr1 = new StreamReader("graph1.txt");
            StreamReader sr2 = new StreamReader("graph2.txt");
            string gr1 = sr1.ReadToEnd();
            string gr2 = sr2.ReadToEnd();

            if (gr1 == gr2) Console.WriteLine("Изоморфны");
            else
                Console.WriteLine("Не изоморфны");


        }
    }
}
