// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace additionalProperties.Models.V100
{
    public partial class PetAPTrue : IDictionary<string, object>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; internal set; }
        private readonly IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _additionalProperties.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _additionalProperties.GetEnumerator();
        public ICollection<string> Keys => _additionalProperties.Keys;
        public ICollection<object> Values => _additionalProperties.Values;
        public bool TryGetValue(string key, out object value) => _additionalProperties.TryGetValue(key, out value);
        public void Add(string key, object value) => _additionalProperties.Add(key, value);
        public bool ContainsKey(string key) => _additionalProperties.ContainsKey(key);
        public bool Remove(string key) => _additionalProperties.Remove(key);
        public int Count => _additionalProperties.Count;
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly => _additionalProperties.IsReadOnly;
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> value) => _additionalProperties.Add(value);
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> value) => _additionalProperties.Remove(value);
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> value) => _additionalProperties.Contains(value);
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] destination, int offset) => _additionalProperties.CopyTo(destination, offset);
        void ICollection<KeyValuePair<string, object>>.Clear() => _additionalProperties.Clear();
        public object this[string key]
        {
            get => _additionalProperties[key];
            set => _additionalProperties[key] = value;
        }
    }
}
