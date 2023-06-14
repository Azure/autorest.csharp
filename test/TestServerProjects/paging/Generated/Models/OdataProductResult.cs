// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace paging.Models
{
    /// <summary> The OdataProductResult. </summary>
    internal partial class OdataProductResult
    {
        /// <summary> Initializes a new instance of OdataProductResult. </summary>
        internal OdataProductResult()
        {
            Values = new ChangeTrackingList<Product>();
        }

        /// <summary> Initializes a new instance of OdataProductResult. </summary>
        /// <param name="values"></param>
        /// <param name="odataNextLink"></param>
        internal OdataProductResult(IReadOnlyList<Product> values, string odataNextLink)
        {
            Values = values;
            OdataNextLink = odataNextLink;
        }

        /// <summary> Gets the values. </summary>
        public IReadOnlyList<Product> Values { get; }
        /// <summary> Gets the odata next link. </summary>
        public string OdataNextLink { get; }
    }
}
