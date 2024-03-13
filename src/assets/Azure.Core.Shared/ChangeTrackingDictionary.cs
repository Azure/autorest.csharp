// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

#nullable enable

namespace Azure.Core
{
    internal class ChangeTrackingDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue> where TKey : notnull
    {
        private IDictionary<TKey, TValue>? _innerDictionary;
        private List<TKey>? _changedKeys;
        private bool _isRemoved = false;

        public ChangeTrackingDictionary()
        {
        }

        public ChangeTrackingDictionary(Optional<IReadOnlyDictionary<TKey, TValue>> optionalDictionary) : this(optionalDictionary.Value)
        {
        }

        public ChangeTrackingDictionary(Optional<IDictionary<TKey, TValue>> optionalDictionary) : this(optionalDictionary.Value)
        {
        }

        internal ChangeTrackingDictionary(IDictionary<TKey, TValue> dictionary, bool asChanged = false)
        {
            if (dictionary == null)
                return;

            _innerDictionary = new Dictionary<TKey, TValue>(dictionary);

            if (asChanged)
            {
                foreach (TKey key in dictionary.Keys)
                {
                    AddChangedKey(key);
                }
            }
        }

        private ChangeTrackingDictionary(IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
                return;

            _innerDictionary = new Dictionary<TKey, TValue>();
            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                _innerDictionary.Add(pair);
            }
        }

        public bool IsUndefined => _innerDictionary == null;
        public IReadOnlyList<TKey>? ChangedKeys => _changedKeys;

        // These two methods are consistent with `IsChanged(TKey key = null)`
        public bool IsChanged(TKey key)
        {
            return EnsureChangedKeys().Contains(key);
        }
        public bool IsChanged()
        {
            return _changedKeys?.Count > 0;
        }

        public bool IsRemoved(TKey key)
        {
            return !ContainsKey(key) && IsChanged(key);
        }
        public bool IsRemoved()
        {
            return _isRemoved && !IsChanged(); // Consider this case: call `Clear()` first and then call `Add()`
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            if (IsUndefined)
            {
                IEnumerator<KeyValuePair<TKey, TValue>> GetEmptyEnumerator()
                {
                    yield break;
                }
                return GetEmptyEnumerator();
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
            AddChangedKey(item.Key);
        }

        public void Clear()
        {
            EnsureDictionary().Clear();
            _isRemoved = true;
            _changedKeys = null;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (IsUndefined)
            {
                return false;
            }

            return EnsureDictionary().Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (IsUndefined)
            {
                return;
            }

            EnsureDictionary().CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (IsUndefined)
            {
                return false;
            }

            if (EnsureDictionary().Remove(item))
            {
                AddChangedKey(item.Key);
                return true;
            }
            return false;
        }

        public int Count
        {
            get
            {
                if (IsUndefined)
                {
                    return 0;
                }

                return EnsureDictionary().Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                if (IsUndefined)
                {
                    return false;
                }
                return EnsureDictionary().IsReadOnly;
            }
        }

        public void Add(TKey key, TValue value)
        {
            EnsureDictionary().Add(key, value);
            AddChangedKey(key);
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

            if (EnsureDictionary().Remove(key))
            {
                AddChangedKey(key);
                return true;
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (IsUndefined)
            {
                value = default!;
                return false;
            }
            return EnsureDictionary().TryGetValue(key, out value!);
        }

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
                AddChangedKey(key);
            }
        }

        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

        public ICollection<TKey> Keys
        {
            get
            {
                if (IsUndefined)
                {
                    return Array.Empty<TKey>();
                }

                return EnsureDictionary().Keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                if (IsUndefined)
                {
                    return Array.Empty<TValue>();
                }

                return EnsureDictionary().Values;
            }
        }

        private IDictionary<TKey, TValue> EnsureDictionary()
        {
            return _innerDictionary ??= new Dictionary<TKey, TValue>();
        }

        private IList<TKey> EnsureChangedKeys()
        {
            return _changedKeys ??= new List<TKey>();
        }

        private void AddChangedKey(TKey key)
        {
            if (!EnsureChangedKeys().Contains(key))
            {
                EnsureChangedKeys().Add(key);
            }
        }
    }
}
