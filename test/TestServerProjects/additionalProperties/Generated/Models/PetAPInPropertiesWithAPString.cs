// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace additionalProperties.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class PetAPInPropertiesWithAPString : IDictionary<string, string>
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-INTEGER. </summary>
        public int Id { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Name { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? Status { get; internal set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string OdataLocation { get; set; }
        /// <summary> Dictionary of &lt;components·schemas·petapinproperties·properties·additionalproperties·additionalproperties&gt;. </summary>
        public IDictionary<string, float>? AdditionalProperties { get; set; }
        private readonly IDictionary<string, string> _additionalProperties = new Dictionary<string, string>();
        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _additionalProperties.GetEnumerator();
        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => _additionalProperties.GetEnumerator();
        /// <inheritdoc />
        public ICollection<string> Keys => _additionalProperties.Keys;
        /// <inheritdoc />
        public ICollection<string> Values => _additionalProperties.Values;
        /// <inheritdoc />
        public bool TryGetValue(string key, out string value) => _additionalProperties.TryGetValue(key, out value);
        /// <inheritdoc />
        public void Add(string key, string value) => _additionalProperties.Add(key, value);
        /// <inheritdoc />
        public bool ContainsKey(string key) => _additionalProperties.ContainsKey(key);
        /// <inheritdoc />
        public bool Remove(string key) => _additionalProperties.Remove(key);
        /// <inheritdoc />
        int ICollection<KeyValuePair<string, string>>.Count => _additionalProperties.Count;
        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, string>>.IsReadOnly => _additionalProperties.IsReadOnly;
        /// <inheritdoc />
        void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> value) => _additionalProperties.Add(value);
        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> value) => _additionalProperties.Remove(value);
        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> value) => _additionalProperties.Contains(value);
        /// <inheritdoc />
        void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] destination, int offset) => _additionalProperties.CopyTo(destination, offset);
        /// <inheritdoc />
        void ICollection<KeyValuePair<string, string>>.Clear() => _additionalProperties.Clear();
        /// <inheritdoc />
        public string this[string key]
        {
            get => _additionalProperties[key];
            set => _additionalProperties[key] = value;
        }
    }
}
