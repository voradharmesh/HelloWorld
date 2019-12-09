using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.CSharp
{
    public class DRVDoubleLinkedlist<T>  :ICollection<T>
    {
        public LinkNode<T> Head { get; private set; }
        public LinkNode<T> Tail { get; private set; }
    
        //(3,5,null)-->(5,null,3)
        public void AddFirst(T PobjData)
        {
            if (Count == 0)
                Head = Tail = new LinkNode<T> {Data = PobjData, Next = Head, Prev = null};
            else
            {
                Head = new LinkNode<T> {Data = PobjData, Next = Head, Prev = null};
                Head.Next.Prev = Head;
            }
            Count++;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException("Empty link list!");

            //using (Head)
            //{
                Head = Head.Next;
                if (Head != null) Head.Prev = null;

            //}
            Count--;
        }

        public void AddLast(T PobjData)
        {
            if ( Count == 0)
                Head = Tail = new LinkNode<T> { Data = PobjData, Next = Head, Prev = null };
            else
            {
                Tail = new LinkNode<T> {Data = PobjData, Next = null, Prev = Tail};
                Tail.Prev.Next = Tail;
            }
            Count++;
        }

        public void RemoveLast()
        {
            if (Count == 0) throw new InvalidOperationException("Link list is empty!");
            //using (Tail)
            //{
                Tail = Tail.Prev;
                if(Tail !=null )Tail.Next = null;
            //}
            Count--;
        }

        public List<T> GetReverseItems()
        {
            if (Head == null) return new List<T>();
            var LcolItems = new List<T>();
            var LcurItem = Tail;
            while (LcurItem != null)
            {
                LcolItems.Add(LcurItem.Data);
                LcurItem = LcurItem.Prev;
            }
            return LcolItems;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var LcurItem = Head;
            while (LcurItem != null)
            {
                yield return LcurItem.Data;
                LcurItem = LcurItem.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #region ICollection methods
        public void Add(T item)
        {
           AddFirst(item);
        }

        public void Clear()
        {
            var LcurItem = Head;
            while (LcurItem != null)
            {
                var LremovePtrs = LcurItem;
                LcurItem = LcurItem.Next;
                LremovePtrs.Next = LremovePtrs.Prev = null;
            }
            Head = Tail = null;
            Count = 0;
        }

        private bool Contains(T item, out LinkNode<T> PobjItem)
        {
            PobjItem = Head;
            while (PobjItem != null)
            {
                if (PobjItem.Data.Equals(item))
                    return true;
             
                PobjItem = PobjItem.Next;
            }
            return false;
        }

        public bool Contains(T item)
        {
            LinkNode<T> LcurItem = null;
            return Contains(item, out LcurItem);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var LobjCurItem = Head;
            while (LobjCurItem != null)
            {
                array[arrayIndex] = LobjCurItem.Data;
                LobjCurItem = LobjCurItem.Next;
            }
        }

        public bool Remove(T item)
        {
            //remove first found.
            LinkNode<T> foundItem;
            var LbFound = Contains(item, out foundItem);
            if (!LbFound) return false;

            if (foundItem.Prev != null)
                foundItem.Prev.Next = foundItem.Next;
            else
                Head = foundItem.Next;

            if (foundItem.Next != null)
                foundItem.Next.Prev = foundItem.Prev;
            else
                Tail = foundItem.Prev;

            foundItem.Prev = foundItem.Next = null;
            Count --;
            return LbFound;
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get { return false; } }
        #endregion ICollection methods
    }

    public class LinkNode<T> : IDisposable
    {
        public T Data { get; set; }
        public LinkNode<T> Next { get; set; }
        public LinkNode<T> Prev { get; set; }


        public void Dispose()
        {
            //throw new NotImplementedException();
            if (!(Data is IDisposable)) return;
            using ((IDisposable) Data)
            {
            }
        }
    }
}
