// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace AppConfiguration.Models
{
    /// <summary> The result of a list request. </summary>
    internal partial class LabelListResult
    {
        /// <summary> Initializes a new instance of LabelListResult. </summary>
        internal LabelListResult()
        {
            Items = new ChangeTrackingList<Label>();
        }

        /// <summary> Initializes a new instance of LabelListResult. </summary>
        /// <param name="items"> The collection value. </param>
        /// <param name="nextLink"> The URI that can be used to request the next set of paged results. </param>
        internal LabelListResult(IReadOnlyList<Label> items, string nextLink)
        {
            Items = items;
            NextLink = nextLink;
        }

        /// <summary> The collection value. </summary>
        public IReadOnlyList<Label> Items { get; }
        /// <summary> The URI that can be used to request the next set of paged results. </summary>
        public string NextLink { get; }
    }
}
