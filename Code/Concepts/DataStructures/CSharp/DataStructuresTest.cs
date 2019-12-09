using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.CSharp;

namespace DataStructures.CSharp
{
    public static class DataStructuresTest
    {
        public static void TestDoubleLinkList()
        {
            var LobjDblLinkList = new DRVDoubleLinkedlist<int>();
            LobjDblLinkList.AddFirst(4);
            LobjDblLinkList.AddFirst(3);
            LobjDblLinkList.AddLast(5);
            LobjDblLinkList.AddLast(6);
            LobjDblLinkList.AddFirst(2);
            LobjDblLinkList.AddLast(7);
            LobjDblLinkList.AddLast(8);
            LobjDblLinkList.AddFirst(1);
            LobjDblLinkList.AddLast(9);
            LobjDblLinkList.AddLast(10);

            Console.WriteLine(LobjDblLinkList.Count);
            Console.WriteLine("First item {0}", LobjDblLinkList.Head.Data);
            Console.WriteLine("Last item {0}", LobjDblLinkList.Tail.Data);

            LobjDblLinkList.RemoveFirst();
            LobjDblLinkList.RemoveLast();

            Console.WriteLine("First item {0}", LobjDblLinkList.Head.Data);
            Console.WriteLine("Last item {0}", LobjDblLinkList.Tail.Data);

            LobjDblLinkList.Remove(5);

            Console.WriteLine("Traversing reverse!");
            var LcolReverseItems = LobjDblLinkList.GetReverseItems();
            foreach (var Item in LcolReverseItems)
                Console.WriteLine(Item);

            Console.WriteLine("Traversing forward!");
            foreach (var Item in LobjDblLinkList)
                Console.WriteLine(Item);

        }
        public static int TestPostfixCalculator(string[] args)
        {
            var values = new DRVStackByLinkList<int>();
            foreach (string token in args)
            {
                int value;
                if (int.TryParse(token, out value))
                    values.Push(value);
                else
                {
                    var rhs = values.Pop();
                    var lhs = values.Pop();
                    #region operate
                    switch (token)
                    {
                        case "+":
                            values.Push(lhs + rhs);
                            break;
                        case "-":
                            values.Push(lhs - rhs);
                            break;
                        case "*":
                            values.Push(lhs * rhs);
                            break;
                        case "/":
                            values.Push(lhs / rhs);
                            break;
                        case "%":
                            values.Push(lhs % rhs);
                            break;
                        default:
                            throw new ArgumentException(string.Format("Unrecognized token : {0}", token));
                    }
                    #endregion operate
                }
            }
            return values.Pop();
        }
        public static void WordSorter()
        {
            var tree = new DRVBinaryTree<string>();
            var input = string.Empty;
            while (!input.Equals("quit", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("STATEMENT> ");
                input = Console.ReadLine();
                var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                    tree.Add(word);

                Console.WriteLine("{0} words", tree.Count);
                foreach (var word in tree)
                    Console.Write("{0} ", word);

                Console.WriteLine();
                tree.Clear();
            }
        }
    }
}
