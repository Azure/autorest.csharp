// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

#nullable enable

namespace Azure.Core
{
    internal enum ChangeType
    {
        Add,
        Change,
        Remove
    }

    internal class ChangeTrackingDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue> where TKey: notnull
    {
        private IDictionary<TKey, TValue>? _innerDictionary;
        private IDictionary<TKey, ChangeType>? _changeDictionary;

        public ChangeTrackingDictionary()
        {
        }

        public ChangeTrackingDictionary(Optional<IReadOnlyDictionary<TKey, TValue>> optionalDictionary) : this(optionalDictionary.Value)
        {
        }

        public ChangeTrackingDictionary(Optional<IDictionary<TKey, TValue>> optionalDictionary) : this(optionalDictionary.Value)
        {
        }

        private ChangeTrackingDictionary(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null) return;

            _innerDictionary = new Dictionary<TKey, TValue>(dictionary);
        }

        private ChangeTrackingDictionary(IReadOnlyDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null) return;

            _innerDictionary = new Dictionary<TKey, TValue>();
            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                _innerDictionary.Add(pair);
            }
        }

        public bool IsUndefined => _innerDictionary == null;
        public bool IsChanged => _changeDictionary != null && _changeDictionary.Count > 0;
        public IDictionary<TKey, ChangeType>? ChangeDictionary => _changeDictionary;

        public bool ShouldSetNull(TKey key)
        {
            return _changeDictionary != null && _changeDictionary.ContainsKey(key) && _changeDictionary[key] == ChangeType.Remove;
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
            SetChangeType(item.Key, ChangeType.Add);
        }

        public void Clear()
        {
            foreach (KeyValuePair<TKey, TValue> pair in EnsureDictionary())
            {
                SetChangeType(pair.Key, ChangeType.Remove);
            }
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
                SetChangeType(item.Key, ChangeType.Remove);
                return true;
            }
            else
            {
                return false;
            }
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
            SetChangeType(key, ChangeType.Add);
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
                SetChangeType(key, ChangeType.Remove);
                return true;
            }
            else
            {
                return false;
            }
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
                SetChangeType(key, ChangeType.Change);
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

        private IDictionary<TKey, ChangeType> EnsureChangeDictionary()
        {
            return _changeDictionary ??= new Dictionary<TKey, ChangeType>();
        }

        private void SetChangeType(TKey key, ChangeType changeType)
        {
            var changeDictionary = EnsureChangeDictionary();
            if (changeDictionary.TryGetValue(key, out var lastChange))
            {
                if ((lastChange == ChangeType.Change && changeType == ChangeType.Change) || (lastChange == ChangeType.Remove && changeType == ChangeType.Add))
                {
                    changeDictionary[key] = ChangeType.Change;
                }
                else if (lastChange == ChangeType.Add && changeType == ChangeType.Change)
                {
                    changeDictionary[key] = ChangeType.Add;
                }
                else if (lastChange == ChangeType.Change && changeType == ChangeType.Remove)
                {
                    changeDictionary[key] = ChangeType.Remove;
                }
                else if (lastChange == ChangeType.Add && changeType == ChangeType.Remove)
                {
                    changeDictionary.Remove(key);
                }
            }
            else
            {
                changeDictionary[key] = changeType;
            }
        }
    }
}
