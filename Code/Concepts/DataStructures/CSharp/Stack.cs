using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.CSharp
{
    //PROS:No hard size (depth) limit, Easy to implement:No bounds checking, empty list = empty stack
    //CON: can be performance issue, per node memory overhead, Memory allocation on push
    public class DRVStackByLinkList<T> : IEnumerable<T>
    {
        readonly DRVDoubleLinkedlist<T>  _list = new DRVDoubleLinkedlist<T>();

        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        public T Pop()
        {
            if (_list.Count == 0) throw new InvalidOperationException("The Stack is empty!");

            var value = _list.Head.Data;
            _list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_list.Count == 0) throw new InvalidOperationException("The Stack is empty!");

            return _list.Head.Data;
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public void Clear()
        {
            _list.Clear();
        }

        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        #endregion IEnumerable

    }

    public class DRVStackByArray<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];
        private int _size;

        public void Push(T item)
        {
            if (_size == _items.Length) // 0 or array size.
            {
                var newLength = _size == 0 ? 4 : _size*2;
                var newArray = new T[newLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }
            _items[_size] = item;
            _size++;
        }

        public T Pop()
        {
            if (_size == 0)
                   throw new InvalidOperationException("The stack is empty!");

            _size--;
            return _items[_size];
        }

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("The stack is empty!");
            
            return _items[_size - 1];
        }

        public int Count
        {
            get { return _size; }
        }

        public void Clear()
        {
            for (var i = 0; i < _size; i++)
            {
                var disposable = _items[i] as IDisposable;
                if (disposable != null)
                    using (disposable) { }

                _items[i] = default(T);
            }
            
            _size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = _size-1; i >= 0; i--)
                yield return _items[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public class PostfixCalculator
    {

    }
}
