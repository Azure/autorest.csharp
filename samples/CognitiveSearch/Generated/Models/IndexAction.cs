// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Represents an index action that operates on a document. </summary>
    public partial class IndexAction
    {
        /// <summary> Initializes a new instance of IndexAction. </summary>
        public IndexAction()
        {
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary> The operation to perform on a document in an indexing batch. </summary>
        public IndexActionType? ActionType { get; set; }
        /// <summary> Additional Properties. </summary>
        public IDictionary<string, object> AdditionalProperties { get; }
    }
}
