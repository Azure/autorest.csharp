// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsAzureCompositeModelClient.Models
{
    using Fixtures.Azure;
    using Fixtures.Azure.AcceptanceTestsAzureCompositeModelClient;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class CatalogArray
    {
        /// <summary>
        /// Initializes a new instance of the CatalogArray class.
        /// </summary>
        public CatalogArray()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CatalogArray class.
        /// </summary>
        /// <param name="productArray">Array of products</param>
        public CatalogArray(IList<Product> productArray = default(IList<Product>))
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
        public IList<Product> ProductArray { get; set; }

    }
}
