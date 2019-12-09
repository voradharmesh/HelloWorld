using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmConsoleApp.CSharp
{
    public class SelectionSort<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] _items = null;

        public SelectionSort(T[] PcolInput)
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
            PerformSortDRV();
        }

        public void PerformSortDRV()
        {
            var LiSmallIndex = 0;
            var LiLargeIndex = _items.Count() - 1;

            for (var i = LiSmallIndex; i <= LiLargeIndex; i++)
            {
                var LobjSmallItem = _items[LiSmallIndex];
                var LobjLargeItem = _items[LiSmallIndex];
                var LiSmallItemCurrentLocation = LiSmallIndex;
                var LiLargeItemCurrentLocation = LiSmallIndex;

                for (var j = LiSmallIndex + 1; j <= LiLargeIndex; j++)
                {
                    if (LobjSmallItem.CompareTo(_items[j]) > 0)
                    {
                        LobjSmallItem = _items[j];
                        LiSmallItemCurrentLocation = j;
                    }
                    if (LobjLargeItem.CompareTo(_items[j]) < 0)
                    {
                        LobjLargeItem = _items[j];
                        LiLargeItemCurrentLocation = j;
                    }
                }
                _items[LiSmallItemCurrentLocation] = _items[LiSmallIndex];
                _items[LiLargeItemCurrentLocation] = _items[LiLargeIndex];
                _items[LiSmallIndex] = LobjSmallItem;
                _items[LiLargeIndex] = LobjLargeItem;
                LiSmallIndex++;
                LiLargeIndex--;
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
