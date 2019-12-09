using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.CSharp;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {

            DataStructuresTest.TestDoubleLinkList();
            Console.WriteLine(DataStructuresTest.TestPostfixCalculator(new[] { "5", "6", "7", "*", "+", "1", "-" }));
            DataStructuresTest.WordSorter();
            PrintHashTest.PrintHashes();

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
