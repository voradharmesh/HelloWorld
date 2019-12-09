using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmConsoleApp.CSharp
{
    public class BubbleSort<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] _items = null;

        public BubbleSort(T[] PcolInput)
        {
            _items = PcolInput;
        }


        /// <summary>
        /// Compare each array item to its RIGHT neighbor
        /// if its right neighbor is smaller value, Swap right and Left
        /// Repeat for the remaining array items.
        /// </summary>
        public void PerformSort()
        {
            var n = _items.Count();
            var swapped = false;
            do
            {
                swapped = false;
                for (var i = 1; i <= n - 1; i++)
                {
                    if (_items[i - 1].CompareTo(_items[i]) > 0)
                    {
                        var item = _items[i - 1];
                        _items[i - 1] = _items[i];
                        _items[i] = item;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
        }

        public void PerformSortDRV()
        {
            var LbSwapPerformed = false;
            for (var i = 0; i < _items.Count(); i++)
            {
                LbSwapPerformed = false;
                for (var j = 0; j < _items.Count() - 1; j++)
                {
                    var LiItem = _items[j];
                    if (LiItem.CompareTo(_items[j + 1]) <= 0) continue;
                    _items[j] = _items[j + 1];
                    _items[j + 1] = LiItem;
                    LbSwapPerformed = true;
                }
                if (LbSwapPerformed == false)
                    break;
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var index = 0; index < _items.Length; index++)
                yield return _items[index];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
