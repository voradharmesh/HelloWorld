using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSamples
{
    public class TestToptalComCSharpInterviewQuestions
    {
        static String location;
        static DateTime time;

        //https://www.toptal.com/c-sharp/interview-questions
        public static void StringDateTimeDefaultValueTest()
        {
            //Is the comparison of time and null in the if statement below valid or not? Why or why not?
            if (time == null)
            {
                //will neve execute as DateTime can never be null as its a value type.
                Console.WriteLine( "INITIALIZE DateTIme");
                time = DateTime.Now; 
            }
            //What is the output of the short program below? Explain your answer.
            Console.WriteLine(location == null ? "location is null" : location);
            Console.WriteLine(time == null ? "time is null" : time.ToString());
        }

        //Given an array of ints, write a C# method to total all the values that are even numbers
        public static void PrintTotalOfEvenArrayNumbers(int[] intArray)
        {
            var Total = intArray.Where(i => i % 2 == 0).Sum(i => (long)i);
            Console.WriteLine(Total + "- intArray.Where(i => i % 2 == 0).Sum(i => (long)i);");

            var Total2 = (from i in intArray where i % 2 == 0 select (long)i).Sum();
            Console.WriteLine(Total2 + " - (from i in intArray where i % 2 == 0 select (long)i).Sum();");
        }

    }
    public static class PrintTaskDealyVsThreadSleep
    {
        private static string result = "NOT INITIALIZED";
        private static string result2 = "NOT INITIALIZED2";

        //What is the output of the program below? Explain your answer
        public static void Print()
        {
            SaySomething();
            Console.WriteLine(result);
            SaySomething2();
            Console.WriteLine(result2);
        }


        static async Task<string> SaySomething()
        {
            await Task.Delay(5);
            result = "Hello world!";
            return "First Something Call";
        }
        static async Task<string> SaySomething2()
        {
            //await Task.Delay(5);
            System.Threading.Thread.Sleep(5);
            result2 = "SaySomething2!";
            return "Second Something call";
        }

    }
    public static class CircleTest
    {
        //write code to calculate the circumference of the circle, 
        //without modifying the Circle class itself.

        public static void CalculateCircumferenceOfCirleWithPrivateRadiusMemeber()
        {
            Console.WriteLine("One Way :" + new Circle().Calculate(r => 2 * Math.PI * r));
            var Lr = new Circle().Calculate(Pr => Pr);
            Console.WriteLine("Second way : " + 2 * Math.PI * Lr);
        }

        public sealed class Circle
        {
            private double radius = 5;

            public double Calculate(Func<double, double> op)
            {
                return op(radius);
            }
        }

    }
    public static class PrintDelegate
    {
        delegate void Printer();

        //What is the output of the program below? Explain your answer.
        public static void PrintDelegateTest()
        {
            List<Printer> printers = new List<Printer>();
            for (int i = 0; i < 10; i++)
            {
                printers.Add(delegate { Console.WriteLine(i); });
            }

            foreach (var printer in printers)
            {
                printer();
            }
        }
    }
}
