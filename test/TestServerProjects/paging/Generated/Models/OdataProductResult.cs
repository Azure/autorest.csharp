// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace paging.Models
{
    /// <summary> The OdataProductResult. </summary>
    public partial class OdataProductResult
    {
        /// <summary> Initializes a new instance of OdataProductResult. </summary>
        internal OdataProductResult()
        {
        }
        /// <summary> Initializes a new instance of OdataProductResult. </summary>
        /// <param name="values"> . </param>
        /// <param name="odataNextLink"> . </param>
        internal OdataProductResult(IList<Product> values, string odataNextLink)
        {
            Values = values;
            OdataNextLink = odataNextLink;
        }
        public IList<Product> Values { get; set; }
        public string OdataNextLink { get; set; }
    }
}
