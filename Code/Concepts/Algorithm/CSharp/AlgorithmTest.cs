using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlgorithmConsoleApp.CSharp
{

    public static class AlgorithmTest
    {
        public static void TestSelectionSort()
        {
            Console.WriteLine("{0}Selection sort 1 on:  9, 8, 7, 6, 5, 4, 3, 2, 1, 0{0}", Environment.NewLine);
            var LobjSort = new SelectionSort<int>(new int[10] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });
            LobjSort.PerformSort();
            foreach (var item in LobjSort)
                Console.Write("{0} ", item);
            Console.WriteLine();

            Console.WriteLine("{0}Selection sort 2 on:1, 2, 3, 4, 5, 6, 7, 9, 8, 0{0}", Environment.NewLine);
            LobjSort = new SelectionSort<int>(new int[10] { 1, 2, 3, 4, 5, 6, 7, 9, 8, 0 });
            LobjSort.PerformSort();
            foreach (var item in LobjSort)
                Console.Write("{0} ", item);
            Console.WriteLine();

            Console.WriteLine("{0}Selection sort 3 on:13, 14, 12, 11, 17, 15, 18, 19, 10, 16{0}", Environment.NewLine);
            LobjSort = new SelectionSort<int>(new int[10] { 13, 14, 12, 11, 17, 15, 18, 19, 10, 16 });
            LobjSort.PerformSort();
            foreach (var item in LobjSort)
                Console.Write("{0} ", item);
            Console.WriteLine();
        }

        public static void TestMergeSort()
        {
            Console.WriteLine("{0}Top Merge sort 1 on: 9, 8, 7, 6, 5, 4, 3, 2, 1, 0{0}", Environment.NewLine);
            var LobjSort = new MergeSort<int>(new int[10] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 });
            LobjSort.PerformTopSort();
            foreach (var item in LobjSort)
                Console.Write("{0} ", item);
            Console.WriteLine();

            Console.WriteLine("{0}Bottom Merge sort 2 on:1, 2, 3, 4, 5, 6, 7, 9, 8, 0{0}", Environment.NewLine);
            LobjSort = new MergeSort<int>(new int[10] { 1, 2, 3, 4, 5, 6, 7, 9, 8, 0 });
            LobjSort.PerformBottomSort();
            foreach (var item in LobjSort)
                Console.Write("{0} ", item);
            Console.WriteLine();

            Console.WriteLine("{0}Merge sort 3: 3, 4, 2, 1, 7, 5, 8, 9, 0, 6 {0}", Environment.NewLine);
            LobjSort = new MergeSort<int>(new int[10] { 3, 4, 2, 1, 7, 5, 8, 9, 0, 6 });
            LobjSort.PerformSort();
            foreach (var item in LobjSort)
                Console.Write("{0} ", item);
            Console.WriteLine();
        }

        public static void TestBubbleSort()
        {
            Console.WriteLine("{0}Bubble sort 1 on:9, 8, 7, 6, 5, 4, 3, 2, 1{0}", Environment.NewLine);
            var LobjSort = new BubbleSort<int>(new int[9] { 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            LobjSort.PerformSort();
            foreach (var item in LobjSort)
                Console.Write("{0} ", item);
            Console.WriteLine();

            Console.WriteLine("{0}Bubble sort 2 on:1, 2, 3, 4, 5, 6, 7, 9, 8{0}", Environment.NewLine);
            LobjSort = new BubbleSort<int>(new int[9] { 1, 2, 3, 4, 5, 6, 7, 9, 8 });
            LobjSort.PerformSort();
            foreach (var item in LobjSort)
                Console.Write("{0} ", item);
            Console.WriteLine();
        }

        public static void TestInsertSort()
        {
            Console.WriteLine("{0}Insert sort 1 on:9, 8, 7, 6, 5, 4, 3, 2, 1{0}", Environment.NewLine);
            var LobjSort = new InsertionSort<int>(new int[9] { 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            LobjSort.PerformSort();
            foreach (var item in LobjSort)
                Console.Write("{0} ", item);
            Console.WriteLine();

            Console.WriteLine("{0}Insert sort 1 on:1, 2, 5, 8, 9, 6, 4, 3, 7{0}", Environment.NewLine);
            LobjSort = new InsertionSort<int>(new int[9] { 1, 2, 5, 8, 9, 6, 4, 3, 7 });
            LobjSort.PerformSort();
            foreach (var item in LobjSort)
                Console.Write("{0} ", item);
            Console.WriteLine();
        }
    }

}
