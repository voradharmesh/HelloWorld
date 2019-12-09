using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.CSharp
{
    public static class PrintHashTest
    {
        #region Hash
        public static void PrintHashes()
        {
            var input = string.Empty;

            while (!input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("HASH>");
                input = Console.ReadLine();
                Console.WriteLine("Additive: {0}", AdditiveHash(input));
                Console.WriteLine("Folding: {0}", FoldingHash(input));
                Console.WriteLine("DJB2: {0}", Djb2(input));
            }


        }

        //http://www.cse.yorku.ca/~oz/hash.html
        private static int Djb2(string input)
        {
            var hash = 5381;
            foreach (var c in input.ToCharArray())
            {
                unchecked
                {
                    hash = ((hash << 5) + hash) + c;
                }
            }
            return hash;
        }

        private static int FoldingHash(string input)
        {
            var hashValue = 0;
            var startIndex = 0;
            int currentFourBytes;
            do
            {
                currentFourBytes = GetNextBytes(startIndex, input);
                unchecked
                {
                    hashValue += currentFourBytes;
                }
                startIndex += 4;
            } while (currentFourBytes != 0);

            return hashValue;
        }

        private static int GetNextBytes(int startIndex, string str)
        {
            var currentFourBytes = 0;
            currentFourBytes += GetByte(str, startIndex);
            currentFourBytes += GetByte(str, startIndex + 1) << 8;
            currentFourBytes += GetByte(str, startIndex + 2) << 16;
            currentFourBytes += GetByte(str, startIndex + 3) << 24;
            return currentFourBytes;
        }

        private static int GetByte(string str, int index)
        {
            if (index < str.Length)
                return (int)str[index];
            return 0;
        }
        private static int AdditiveHash(string input)
        {
            int currentHastValue = 0;
            foreach (char c in input)
            {
                unchecked
                {
                    currentHastValue += (int)c;
                }
            }
            return currentHastValue;
        }
        #endregion Hash
    }
}
