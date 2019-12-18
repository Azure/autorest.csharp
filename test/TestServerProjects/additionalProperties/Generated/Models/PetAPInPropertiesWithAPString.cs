// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace additionalProperties.Models.V100
{
    public partial class PetAPInPropertiesWithAPString : IDictionary<string, string>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; internal set; }
        public string OdataLocation { get; set; }
        public IDictionary<string, float>? AdditionalProperties { get; set; }
        private readonly IDictionary<string, string> _additionalProperties = new Dictionary<string, string>();
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _additionalProperties.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _additionalProperties.GetEnumerator();
        public ICollection<string> Keys => _additionalProperties.Keys;
        public ICollection<string> Values => _additionalProperties.Values;
        public bool TryGetValue(string key, out string value) => _additionalProperties.TryGetValue(key, out value);
        public void Add(string key, string value) => _additionalProperties.Add(key, value);
        public bool ContainsKey(string key) => _additionalProperties.ContainsKey(key);
        public bool Remove(string key) => _additionalProperties.Remove(key);
        public int Count => _additionalProperties.Count;
        bool ICollection<KeyValuePair<string, string>>.IsReadOnly => _additionalProperties.IsReadOnly;
        void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> value) => _additionalProperties.Add(value);
        bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> value) => _additionalProperties.Remove(value);
        bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> value) => _additionalProperties.Contains(value);
        void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] destination, int offset) => _additionalProperties.CopyTo(destination, offset);
        void ICollection<KeyValuePair<string, string>>.Clear() => _additionalProperties.Clear();
        public string this[string key]
        {
            get => _additionalProperties[key];
            set => _additionalProperties[key] = value;
        }
    }
}
