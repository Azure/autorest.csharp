// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;

namespace body_date
{
    internal class ChangeTrackingDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue> where TKey : notnull
    {
        private IDictionary<TKey, TValue> _innerDictionary;

        public ChangeTrackingDictionary()
        {
        }

        public ChangeTrackingDictionary(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                return;
            }
            _innerDictionary = new Dictionary<TKey, TValue>(dictionary);
        }

        public ChangeTrackingDictionary(IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                return;
            }
            _innerDictionary = new Dictionary<TKey, TValue>();
            foreach (var pair in dictionary)
            {
                _innerDictionary.Add(pair);
            }
        }

        public bool IsUndefined => _innerDictionary == null;

        public int Count => IsUndefined ? 0 : EnsureDictionary().Count;

        public bool IsReadOnly => IsUndefined ? false : EnsureDictionary().IsReadOnly;

        public ICollection<TKey> Keys => IsUndefined ? Array.Empty<TKey>() : EnsureDictionary().Keys;

        public ICollection<TValue> Values => IsUndefined ? Array.Empty<TValue>() : EnsureDictionary().Values;

        public TValue this[TKey key]
        {
            get
            {
                if (IsUndefined)
                {
                    throw new KeyNotFoundException(nameof(key));
                }
                return EnsureDictionary()[key];
            }
            set
            {
                EnsureDictionary()[key] = value;
            }
        }

        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            if (IsUndefined)
            {
                IEnumerator<KeyValuePair<TKey, TValue>> enumerateEmpty()
                {
                    yield break;
                }
                return enumerateEmpty();
            }
            return EnsureDictionary().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            EnsureDictionary().Add(item);
        }

        public void Clear()
        {
            EnsureDictionary().Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (IsUndefined)
            {
                return false;
            }
            return EnsureDictionary().Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            if (IsUndefined)
            {
                return;
            }
            EnsureDictionary().CopyTo(array, index);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (IsUndefined)
            {
                return false;
            }
            return EnsureDictionary().Remove(item);
        }

        public void Add(TKey key, TValue value)
        {
            EnsureDictionary().Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            if (IsUndefined)
            {
                return false;
            }
            return EnsureDictionary().ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            if (IsUndefined)
            {
                return false;
            }
            return EnsureDictionary().Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (IsUndefined)
            {
                value = default;
                return false;
            }
            return EnsureDictionary().TryGetValue(key, out value);
        }

        public IDictionary<TKey, TValue> EnsureDictionary()
        {
            return _innerDictionary ??= new Dictionary<TKey, TValue>();
        }
    }
}
