// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> A single bucket of a facet query result. Reports the number of documents with a field value falling within a particular range or having a particular value or interval. </summary>
    public partial class FacetResult
    {
        /// <summary> Initializes a new instance of FacetResult. </summary>
        internal FacetResult()
        {
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary> Initializes a new instance of FacetResult. </summary>
        /// <param name="count"> The approximate count of documents falling within the bucket described by this facet. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal FacetResult(long? count, IReadOnlyDictionary<string, object> additionalProperties)
        {
            Count = count;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> The approximate count of documents falling within the bucket described by this facet. </summary>
        public long? Count { get; }
        /// <summary> Additional Properties. </summary>
        public IReadOnlyDictionary<string, object> AdditionalProperties { get; }
    }
}
