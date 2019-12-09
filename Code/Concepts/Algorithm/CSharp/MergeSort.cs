using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmConsoleApp.CSharp
{
    public class MergeSort<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] _items = null;

        public MergeSort(T[] PcolInput)
        {
            _items = PcolInput;
        }

        public void PerformSort()
        {
            TopDownMergeSort(_items, new T[_items.Count()], _items.Count());
        }

        public void PerformTopSort()
        {
            TopDownMergeSort(_items, new T[_items.Count()], _items.Count());
        }
        public void PerformBottomSort()
        {
            BottomUpMergeSort(_items, new T[_items.Count()], _items.Count());
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

        #region TopDownMergeSort

        private void TopDownMergeSort(T[] A, T[] B, int n)
        {
            TopDownSplitMerge(A, 0, n, B);
        }

        private void TopDownSplitMerge(T[] A, int iBegin, int iEnd, T[] B)
        {
            if (iEnd - iBegin < 2) return;
            int iMiddle = (iEnd + iBegin) / 2;
            TopDownSplitMerge(A, iBegin, iMiddle, B);
            TopDownSplitMerge(A, iMiddle, iEnd, B);
            TopDownMerge(A, iBegin, iMiddle, iEnd, B);
            CopyArray(B, iBegin, iEnd, A);
        }

        private void TopDownMerge(T[] A, int iBegin, int iMiddle, int iEnd, T[] B)
        {
            var i0 = iBegin;
            var i1 = iMiddle;
            for (var j = iBegin; j < iEnd; j++)
            {
                if (i0 < iMiddle && (i1 >= iEnd || A[i0].CompareTo(A[i1]) <= 0))
                {
                    B[j] = A[i0];
                    i0++;
                }
                else
                {
                    B[j] = A[i1];
                    i1++;
                }
            }
        }

        private void CopyArray(T[] B, int iBegin, int iEnd, T[] A)
        {
            for (var k = iBegin; k < iEnd; k++)
                A[k] = B[k];
        }
        #endregion TopDownMergeSort

        #region BottomUpMergeSort

        private void BottomUpMergeSort(T[] A, T[] B, int n)
        {
            for (var width = 1; width < n; width = 2 * width)
            {
                for (var i = 0; i < n; i = i + 2 * width)
                {
                    BottomUpMerge(A, i, Math.Min(i + width, n), Math.Min(i + 2 * width, n), B);
                }
                CopyArray(B, A, n);
            }
        }

        private void BottomUpMerge(T[] A, int iLeft, int iRight, int iEnd, T[] B)
        {
            var i0 = iLeft;
            var i1 = iRight;
            var j = 0;
            for (j = iLeft; j < iEnd; j++)
            {
                if (i0 < iRight && (i1 >= iEnd || A[i0].CompareTo(A[i1]) <= 0))
                {
                    B[j] = A[i0];
                    i0++;
                }
                else
                {
                    B[j] = A[i1];
                    i1++;
                }
            }
        }

        private void CopyArray(T[] B, T[] A, int n)
        {
            for (var i = 0; i < n; i++)
                A[i] = B[i];
        }

        #endregion BottomUpMergeSort


    }
}
