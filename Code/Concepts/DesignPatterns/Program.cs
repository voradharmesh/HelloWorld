using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.CSharp;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //VisitorDesignPattern.Execute();
            //DecoratorDesignPattern.Execute();
            ChainOfResponsibilityDesignPattern.Execute();

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
