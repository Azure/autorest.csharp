// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace custom_baseUrl_paging.Models
{
    /// <summary> The Product. </summary>
    public partial class Product
    {
        /// <summary> Initializes a new instance of Product. </summary>
        internal Product()
        {
        }

        /// <summary> Initializes a new instance of Product. </summary>
        /// <param name="properties"></param>
        internal Product(ProductProperties properties)
        {
            Properties = properties;
        }

        /// <summary> Gets the properties. </summary>
        public ProductProperties Properties { get; }
    }
}
