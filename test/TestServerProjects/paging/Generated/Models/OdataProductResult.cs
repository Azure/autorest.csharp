// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace paging.Models
{
    /// <summary> The OdataProductResult. </summary>
    internal partial class OdataProductResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::paging.Models.OdataProductResult
        ///
        /// </summary>
        internal OdataProductResult()
        {
            Values = new ChangeTrackingList<Product>();
        }

        /// <summary>
        /// Initializes a new instance of global::paging.Models.OdataProductResult
        ///
        /// </summary>
        /// <param name="values"></param>
        /// <param name="odataNextLink"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal OdataProductResult(IReadOnlyList<Product> values, string odataNextLink, Dictionary<string, BinaryData> rawData)
        {
            Values = values;
            OdataNextLink = odataNextLink;
            _rawData = rawData;
        }

        /// <summary> Gets the values. </summary>
        public IReadOnlyList<Product> Values { get; }
        /// <summary> Gets the odata next link. </summary>
        public string OdataNextLink { get; }
    }
}
