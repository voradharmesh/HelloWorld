//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Linq;
//using System.Security.Permissions;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataStructures.CSharp
//{
//    public class HashTableNodePair<TKey, TValue>
//    {
//        public HashTableNodePair(TKey key, TValue value)
//        {
//            Key = key;
//            Value = value;
//        }

//        public TKey Key { get; private set; }
//        public TValue Value { get; set; }
//    }

//    public class HashTableArrayNode<TKey, TValue>
//    {
//        private LinkedList<HashTableNodePair<TKey, TValue>> _items;

//        public void Add(TKey key, TValue value)
//        {
//            if (_items == null)
//                _items = new LinkedList<HashTableNodePair<TKey, TValue>>();
//            else
//            {
//                foreach (var pair in _items)
//                {
//                    if (pair.Key.Equals(key))
//                    {
//                        throw new ArgumentException("The collection already contains the key");
//                    }
//                }
//            }
//            _items.AddFirst(new HashTableNodePair<TKey, TValue>(key, value));
//        }

//        public void Update(TKey key, TValue value)
//        {
//            var update = false;
//            if (_items != null)
//            {
//                foreach (var pair in _items)
//                {
//                    if (pair.Key.Equals(key))
//                    {
//                        pair.Value = value;
//                        update = true;
//                        break;
//                    }
//                }
//            }
//            if (!update)
//                throw new ArgumentException("The collection does not contain the key");
//        }

//        public bool TryGetValue(TKey key, out TValue value)
//        {
//            value = default(TValue);
//            var found = false;
//            if (_items == null) return false;
//            foreach (var pair in _items)
//            {
//                if (pair.Key.Equals(key))
//                {
//                    value = pair.Value;
//                    found = true;
//                    break;
//                }
//            }
//            return found;
//        }

//        public bool Remove(TKey key)
//        {
//            var removed = false;
//            if (_items != null)
//            {
//                var current = _items.First;
//                while (current != null)
//                {
//                    if (current.Value.Key.Equals(key))
//                    {
//                        _items.Remove(current);
//                        removed = true;
//                        break;
//                    }
//                    current = current.Next;
//                }
//            }
//            return removed;
//        }

//        public void Clear()
//        {
//            if (_items != null)
//            {
//                _items.Clear();
//            }
//        }

//        public IEnumerable<TValue> Values
//        {
//            get
//            {
//                if (_items != null)
//                {
//                    foreach (var node in _items)
//                    {
//                        yield return node.Value;
//                    }
//                }
//            }
//        }

//        public IEnumerable<TKey> Keys
//        {
//            get
//            {
//                if (_items != null)
//                {
//                    foreach (var node in _items)
//                    {
//                        yield return node.Key;
//                    }
//                }
//            }
//        }

//        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
//        {
//            get
//            {
//                if (_items != null)
//                {
//                    foreach (var node in Items)
//                    {
//                        yield return node;
//                    }
//                }
//            }
//        }
//    }

//    public class HashTableArray<TKey, TValue>
//    {
//        private readonly HashTableArrayNode<TKey, TValue>[] _array;

//        public HashTableArray(int capacity)
//        {
//            _array = new HashTableArrayNode<TKey,TValue>[capacity];
//            for (var i = 0; i < capacity; i++)
//                _array[i] = new HashTableArrayNode<TKey, TValue>();
//        }

//        public void Add(TKey key, TValue value)
//        {
//            _array[GetIndex(key)].Add(key, value);
//        }

//        public void Update(TKey key, TValue value)
//        {
//            _array[GetIndex(key)].Update(key, value);
//        }

//        public bool Remove(TKey key)
//        {
//            return _array[GetIndex(key)].Remove[key];
//        }




//        public bool TryGetValue(TKey key, out TValue value )
//        {
//            return _array[GetIndex(key)].TryGetValue(key, out value);
//        }

//        public int Capacity
//        {
//            get { return _array.Length; }
//        }

//        public void Clear()
//        {
//            foreach (HashTableArrayNode<TKey, TValue> node in _array)
//            {
//                node.Clear();
//            }
//        }

//        public IEnumerable<TValue> Values
//        {
//            get
//            {
//                foreach (var node in _array)
//                {
//                    foreach (TValue value in node.Values)
//                    {
//                        yield return value;
//                    }
//                }
//            }
//        }

//        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
//        {
//            get
//            {
//                foreach (var node in _array)
//                {
//                    foreach (var pair in node.Items)
//                        yield return pair;
//                }
//            }
//        }
//    }

//    public class DRVHashTable<TKey, TValue>
//    {
//        private const double _fillFactor = 0.75;
//        private int _maxItemsAtCurrentSize;
//        private int _count;
//        private HashTableArray<TKey, TValue> _array;

//        public DRVHashTable() : this(1000)
//        {
//        }

//        public DRVHashTable(int initialCapacity)
//        {
//            if (initialCapacity < 1 )
//                throw new ArgumentOutOfRangeException("initialCapacity");

//            _array = new HashTableArray<TKey, TValue>(initialCapacity);
//            _maxItemsAtCurrentSize = (int) (initialCapacity*_fillFactor) + 1;
//        }

//        public void Add(TKey key, TValue value)
//        {
//            if (_count >= _maxItemsAtCurrentSize)
//            {
//                var largerArray = new HashTableArray<TKey, TValue>(_array.Capacity * 2);
//                foreach (HashTableNodePair<TKey, TValue> node in _array.Items)
//                {
//                    largerArray.Add(node.Key, node.Value);
//                }
//                _array = largerArray;
//                _maxItemsAtCurrentSize = (int) (_array.Capacity*_fillFactor) + 1;
//            }
//            _array.Add(key, value);
//            _count ++;
//        }

//        public bool Remove(TKey key)
//        {
//            bool removed = _array.Remove(key);
//            if (removed)
//                _count--;
//            return removed;
//        }

//        public TValue this[TKey key]
//        {
//            get
//            {
//                TValue value;
//                if (!_array.TryGetValue(key, out value))
//                {
//                    throw new ArgumentException("key");
//                }
//                return value;
//            }
//        }
//    }
//}
