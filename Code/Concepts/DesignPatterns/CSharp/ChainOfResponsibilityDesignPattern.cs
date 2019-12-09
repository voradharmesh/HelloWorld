using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.ChainOfResponsibility;

namespace DesignPatterns.CSharp
{
    public static class ChainOfResponsibilityDesignPattern
    {
        public static void Execute()
        {
            IChain chainCalc1 = new AddNumbers();
            IChain chainCalc2 = new SubtractNumbers();
            IChain chainCalc3 = new MultiplyNumbers();
            IChain chainCalc4 = new DivideNumbers();

            // Here I tell each object where to forward the
            // data if it can't process the request

            chainCalc1.setNextChain(chainCalc2);
            chainCalc2.setNextChain(chainCalc3);
            chainCalc3.setNextChain(chainCalc4);

            // Define the data in the Numbers Object
            // and send it to the first Object in the chain

            Numbers request = new Numbers(4, 2, "add");
            chainCalc1.calculate(request);
            Numbers request2 = new Numbers(4, 2, "sub");
            chainCalc1.calculate(request2);
            Numbers request3 = new Numbers(4, 2, "mult");
            chainCalc1.calculate(request3);
            Numbers request4 = new Numbers(6, 2, "div");
            chainCalc1.calculate(request4);


        }
    }
}

namespace DesignPatterns.ChainOfResponsibility
{
    public interface IChain
    {
        void setNextChain(IChain nextChain);
        void calculate(Numbers request);
    }
    public class Numbers
    {
        int Number1;
        int Number2;
        string calculationWanted;
        public Numbers(int newNumber1, int newNumber2, string calcWanted)
        {
            Number1 = newNumber1;
            Number2 = newNumber2;
            calculationWanted = calcWanted;
        }
        public int getNumber1() { return Number1; }
        public int getNumber2() { return Number2;  }
        public string getCalcWanted() { return calculationWanted; }
    }
    public class AddNumbers : IChain
    {
        IChain nextInChain;
        public void setNextChain(IChain nextChain)
        {
            nextInChain = nextChain;
        }

        public void calculate(Numbers request)
        {
            if (request.getCalcWanted().ToLower() == "add")
            {
                Console.WriteLine(request.getNumber1() + " + " + request.getNumber2() + " = " + (request.getNumber1() + request.getNumber2()));
            }
            else
            {
                nextInChain.calculate(request);
            }
        }
    }
    public class SubtractNumbers : IChain
    {
        IChain nextInChain;
        public void setNextChain(IChain nextChain)
        {
            nextInChain = nextChain;
        }

        public void calculate(Numbers request)
        {
            if (request.getCalcWanted().ToLower() == "sub")
            {
                Console.WriteLine(request.getNumber1() + " - " + request.getNumber2() + " = " + (request.getNumber1() - request.getNumber2()));
            }
            else
            {
                nextInChain.calculate(request);
            }
        }
    }
    public class MultiplyNumbers : IChain
    {
        IChain nextInChain;
        public void setNextChain(IChain nextChain)
        {
            nextInChain = nextChain;
        }

        public void calculate(Numbers request)
        {
            if (request.getCalcWanted().ToLower() == "mult")
            {
                Console.WriteLine(request.getNumber1() + " * " + request.getNumber2() + " = " + (request.getNumber1() * request.getNumber2()));
            }
            else
            {
                nextInChain.calculate(request);
            }
        }
    }

    public class DivideNumbers : IChain
    {
        IChain nextInChain;
        public void setNextChain(IChain nextChain)
        {
            nextInChain = nextChain;
        }

        public void calculate(Numbers request)
        {
            if (request.getCalcWanted().ToLower() == "div")
            {
                Console.WriteLine(request.getNumber1() + " / " + request.getNumber2() + " = " + (request.getNumber1() / request.getNumber2()));
            }
            else
            {
                Console.WriteLine("Supported opperations Add, Sub, Mult & Div only");
            }
        }
    }

}

