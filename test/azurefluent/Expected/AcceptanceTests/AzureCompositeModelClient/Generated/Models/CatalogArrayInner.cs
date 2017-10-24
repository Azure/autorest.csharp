// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.Fluent.AcceptanceTestsAzureCompositeModelClient.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class CatalogArrayInner
    {
        /// <summary>
        /// Initializes a new instance of the CatalogArrayInner class.
        /// </summary>
        public CatalogArrayInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CatalogArrayInner class.
        /// </summary>
        /// <param name="productArray">Array of products</param>
        public CatalogArrayInner(IList<ProductInner> productArray = default(IList<ProductInner>))
        {
            ProductArray = productArray;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets array of products
        /// </summary>
        [JsonProperty(PropertyName = "productArray")]
        public IList<ProductInner> ProductArray { get; set; }

    }
}
