// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The SmartSalmon. </summary>
    public partial class SmartSalmon : Salmon, IDictionary<string, object>
    {
        /// <summary> Initializes a new instance of SmartSalmon. </summary>
        /// <param name="length"> . </param>
        public SmartSalmon(float length) : base(length)
        {
            Fishtype = "smart_salmon";
            AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary> Initializes a new instance of SmartSalmon. </summary>
        /// <param name="collegeDegree"> . </param>
        /// <param name="additionalProperties"> . </param>
        /// <param name="location"> . </param>
        /// <param name="iswild"> . </param>
        /// <param name="fishtype"> . </param>
        /// <param name="species"> . </param>
        /// <param name="length"> . </param>
        /// <param name="siblings"> . </param>
        internal SmartSalmon(string collegeDegree, IDictionary<string, object> additionalProperties, string location, bool? iswild, string fishtype, string species, float length, IList<Fish> siblings) : base(location, iswild, fishtype, species, length, siblings)
        {
            CollegeDegree = collegeDegree;
            AdditionalProperties = additionalProperties;
            Fishtype = fishtype ?? "smart_salmon";
        }

        public string CollegeDegree { get; set; }
        internal IDictionary<string, object> AdditionalProperties { get; }
        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => AdditionalProperties.GetEnumerator();
        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => AdditionalProperties.GetEnumerator();
        /// <inheritdoc />
        public bool TryGetValue(string key, out object value) => AdditionalProperties.TryGetValue(key, out value);
        /// <inheritdoc />
        public bool ContainsKey(string key) => AdditionalProperties.ContainsKey(key);
        /// <inheritdoc />
        public ICollection<string> Keys => AdditionalProperties.Keys;
        /// <inheritdoc />
        public ICollection<object> Values => AdditionalProperties.Values;
        /// <inheritdoc />
        int ICollection<KeyValuePair<string, object>>.Count => AdditionalProperties.Count;
        /// <inheritdoc />
        public void Add(string key, object value) => AdditionalProperties.Add(key, value);
        /// <inheritdoc />
        public bool Remove(string key) => AdditionalProperties.Remove(key);
        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly => AdditionalProperties.IsReadOnly;
        /// <inheritdoc />
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> value) => AdditionalProperties.Add(value);
        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> value) => AdditionalProperties.Remove(value);
        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> value) => AdditionalProperties.Contains(value);
        /// <inheritdoc />
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] destination, int offset) => AdditionalProperties.CopyTo(destination, offset);
        /// <inheritdoc />
        void ICollection<KeyValuePair<string, object>>.Clear() => AdditionalProperties.Clear();
        /// <inheritdoc />
        public object this[string key]
        {
            get => AdditionalProperties[key];
            set => AdditionalProperties[key] = value;
        }
    }
}
