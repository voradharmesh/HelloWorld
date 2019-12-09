using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.CSharp
{
    public class DRVQueueByLinkList<T> : IEnumerable<T>
    {
        DRVDoubleLinkedlist<T> _items = new DRVDoubleLinkedlist<T>();

        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        public T Dequeue()
        {
            if (_items.Count == 0) throw new InvalidOperationException("The queue is empty!");

            var value = _items.Head.Data;
            _items.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_items.Count == 0) throw new InvalidOperationException("The queue is empty!");

            return _items.Head.Data;  
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return _items.GetEnumerator();
        }
    }

    public class DRVQueueByArray<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];
        private int _size = 0;
        private int _head = 0;
        private int _tail = -1;

        public void Enqueue(T item)
        {
            if (_items.Length == _size)
            {
                var newLength = (_size == 0) ? 4 : _size*2;
                var newArray = new T[newLength];

                #region copy old array to new array based on size.

                if (_size > 0)
                {
                    var targetIndex = 0;
                    if (_tail < _head)
                    {
                        for (var index = _head; index < _items.Length; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                        for (var index = 0; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        for (var index = _head; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }
                    _head = 0;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }

                #endregion copy old array to new array based on size.

                _items = newArray;
            }

            _tail = (_tail == _items.Length - 1) ? 0 : _tail + 1;
            _items[_tail] = item;
            _size++;

        }

        public T Dequeue()
        {
            if (_size == 0) throw new InvalidOperationException("The queue is empty!");

            T value = _items[_head];
            if (_head == _items.Length - 1)
                _head = 0;
            else
                _head++;

            _size--;
            return value;
        }

        public T Peek()
        {
            if (_size == 0) throw new InvalidOperationException("The queue is empty!");
            return _items[_head];
        }

        public int Count
        {
            get { return _size; }
        }

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size <= 0) yield break;
            if (_tail < _head)
            {
                for (var index = _head; index < _items.Length; index++)
                    yield return _items[index];

                for(var index = 0; index <= _tail; index++)
                    yield return _items[index];

            }
            else
            {
                for (var index = _head; index <= _tail; index++)
                    yield return _items[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class DRVPriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private LinkedList<T> _items = new LinkedList<T>();

        public void Enqueue(T item)
        {
            if(_items.Count == 0 )
                _items.AddLast(item);
            else
            {
                var current = _items.First;
                while (current != null && current.Value.CompareTo(item) > 0)
                    current = current.Next;

                if (current == null)
                    _items.AddLast(item);
                else
                    _items.AddBefore(current, item);
            }
        }

        public T Dequeue()
        {
            if (_items.Count == 0) throw new InvalidOperationException("The queue is empty!");

            var value = _items.First.Value;
            _items.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_items.Count == 0) throw new InvalidOperationException("The queue is empty!");

            return _items.First.Value;
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }

}
