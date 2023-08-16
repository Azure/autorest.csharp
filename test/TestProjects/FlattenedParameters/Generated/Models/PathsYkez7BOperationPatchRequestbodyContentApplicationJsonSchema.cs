// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace FlattenedParameters.Models
{
    /// <summary> The PathsYkez7BOperationPatchRequestbodyContentApplicationJsonSchema. </summary>
    internal partial class PathsYkez7BOperationPatchRequestbodyContentApplicationJsonSchema
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::FlattenedParameters.Models.PathsYkez7BOperationPatchRequestbodyContentApplicationJsonSchema
        ///
        /// </summary>
        public PathsYkez7BOperationPatchRequestbodyContentApplicationJsonSchema()
        {
            Items = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// Initializes a new instance of global::FlattenedParameters.Models.PathsYkez7BOperationPatchRequestbodyContentApplicationJsonSchema
        ///
        /// </summary>
        /// <param name="items"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PathsYkez7BOperationPatchRequestbodyContentApplicationJsonSchema(IList<string> items, Dictionary<string, BinaryData> rawData)
        {
            Items = items;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the items. </summary>
        public IList<string> Items { get; set; }
    }
}
