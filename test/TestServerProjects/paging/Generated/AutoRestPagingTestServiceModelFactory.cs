// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace paging.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class AutoRestPagingTestServiceModelFactory
    {
        /// <summary> Initializes a new instance of Product. </summary>
        /// <param name="properties"></param>
        /// <returns> A new <see cref="Models.Product"/> instance for mocking. </returns>
        public static Product Product(ProductProperties properties = null)
        {
            return new Product(properties);
        }

        /// <summary> Initializes a new instance of ProductProperties. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns> A new <see cref="Models.ProductProperties"/> instance for mocking. </returns>
        public static ProductProperties ProductProperties(int? id = null, string name = null)
        {
            return new ProductProperties(id, name);
        }
    }
}
