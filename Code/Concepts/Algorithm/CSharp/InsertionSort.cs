using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmConsoleApp.CSharp
{
    public class InsertionSort<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] _items = null;

        public InsertionSort(T[] PcolInput)
        {
            _items = PcolInput;
        }

        /// <summary>
        /// Sorts each item in the array as they are encountered
        /// As the current item works from left to right
        ///     everything left of the item is known to be sorted
        ///     everything to the right is unsorted
        /// the current item in "inserted" into place within the sorted section
        /// </summary>
        public void PerformSort()
        {
            for (var i = 1; i <= _items.Length - 1; i++)
            {
                var x = _items[i];
                var j = i;
                while (j > 0 && (_items[j - 1].CompareTo(x) > 0))
                {
                    _items[j] = _items[j - 1];
                    j = j - 1;
                }
                _items[j] = x;
            }
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
                    if (_items[j + 1].CompareTo(LiItem) > 0) continue;
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
