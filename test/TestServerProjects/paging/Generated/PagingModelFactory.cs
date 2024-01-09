// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace paging.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class PagingModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.Product"/>. </summary>
        /// <param name="properties"></param>
        /// <returns> A new <see cref="Models.Product"/> instance for mocking. </returns>
        public static Product Product(ProductProperties properties = null)
        {
            return new Product(properties, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ProductProperties"/>. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns> A new <see cref="Models.ProductProperties"/> instance for mocking. </returns>
        public static ProductProperties ProductProperties(int? id = null, string name = null)
        {
            return new ProductProperties(id, name, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.PagingGetMultiplePagesWithOffsetOptions"/>. </summary>
        /// <param name="maxresults"> Sets the maximum number of items to return in the response. </param>
        /// <param name="offset"> Offset of return value. </param>
        /// <param name="timeout"> Sets the maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. </param>
        /// <returns> A new <see cref="Models.PagingGetMultiplePagesWithOffsetOptions"/> instance for mocking. </returns>
        public static PagingGetMultiplePagesWithOffsetOptions PagingGetMultiplePagesWithOffsetOptions(int? maxresults = null, int offset = default, int? timeout = null)
        {
            return new PagingGetMultiplePagesWithOffsetOptions(maxresults, offset, timeout, serializedAdditionalRawData: null);
        }
    }
}
