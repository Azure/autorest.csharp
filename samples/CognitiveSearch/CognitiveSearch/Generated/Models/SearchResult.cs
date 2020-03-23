// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Contains a document found by a search query, plus associated metadata. </summary>
    public partial class SearchResult : IDictionary<string, object>
    {
        /// <summary> Initializes a new instance of SearchResult. </summary>
        internal SearchResult()
        {
        }

        /// <summary> Initializes a new instance of SearchResult. </summary>
        /// <param name="score"> The relevance score of the document compared to other documents returned by the query. </param>
        /// <param name="highlights"> Text fragments from the document that indicate the matching search terms, organized by each applicable field; null if hit highlighting was not enabled for the query. </param>
        /// <param name="additionalProperties"> . </param>
        internal SearchResult(double? score, IDictionary<string, IList<string>> highlights, IDictionary<string, object> additionalProperties)
        {
            Score = score;
            Highlights = highlights;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> The relevance score of the document compared to other documents returned by the query. </summary>
        public double? Score { get; }
        /// <summary> Text fragments from the document that indicate the matching search terms, organized by each applicable field; null if hit highlighting was not enabled for the query. </summary>
        public IDictionary<string, IList<string>> Highlights { get; }
        internal IDictionary<string, object> AdditionalProperties { get; } = new Dictionary<string, object>();
        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => AdditionalProperties.GetEnumerator();
        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => AdditionalProperties.GetEnumerator();
        /// <inheritdoc />
        public ICollection<string> Keys => AdditionalProperties.Keys;
        /// <inheritdoc />
        public ICollection<object> Values => AdditionalProperties.Values;
        /// <inheritdoc />
        public bool TryGetValue(string key, out object value) => AdditionalProperties.TryGetValue(key, out value);
        /// <inheritdoc />
        public void Add(string key, object value) => AdditionalProperties.Add(key, value);
        /// <inheritdoc />
        public bool ContainsKey(string key) => AdditionalProperties.ContainsKey(key);
        /// <inheritdoc />
        public bool Remove(string key) => AdditionalProperties.Remove(key);
        /// <inheritdoc />
        int ICollection<KeyValuePair<string, object>>.Count => AdditionalProperties.Count;
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
