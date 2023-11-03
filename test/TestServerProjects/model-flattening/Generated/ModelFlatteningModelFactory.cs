// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace model_flattening.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ModelFlatteningModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.Resource"/>. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="type"> Resource Type. </param>
        /// <param name="tags"> Dictionary of &lt;string&gt;. </param>
        /// <param name="location"> Resource Location. </param>
        /// <param name="name"> Resource Name. </param>
        /// <returns> A new <see cref="Models.Resource"/> instance for mocking. </returns>
        public static Resource Resource(string id = null, string type = null, IDictionary<string, string> tags = null, string location = null, string name = null)
        {
            tags ??= new Dictionary<string, string>();

            return new Resource(id, type, tags, location, name, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.FlattenedProduct"/>. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="type"> Resource Type. </param>
        /// <param name="tags"> Dictionary of &lt;string&gt;. </param>
        /// <param name="location"> Resource Location. </param>
        /// <param name="name"> Resource Name. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="pName"></param>
        /// <param name="typePropertiesType"></param>
        /// <param name="provisioningStateValues"></param>
        /// <param name="provisioningState"></param>
        /// <returns> A new <see cref="Models.FlattenedProduct"/> instance for mocking. </returns>
        public static FlattenedProduct FlattenedProduct(string id = null, string type = null, IDictionary<string, string> tags = null, string location = null, string name = null, IDictionary<string, BinaryData> serializedAdditionalRawData = null, string pName = null, string typePropertiesType = null, FlattenedProductPropertiesProvisioningStateValues? provisioningStateValues = null, string provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();
            serializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

            return new FlattenedProduct(id, type, tags, location, name, serializedAdditionalRawData, pName, typePropertiesType, provisioningStateValues, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ProductWrapper"/>. </summary>
        /// <param name="value"> the product value. </param>
        /// <returns> A new <see cref="Models.ProductWrapper"/> instance for mocking. </returns>
        public static ProductWrapper ProductWrapper(string value = null)
        {
            return new ProductWrapper(value, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.FlattenParameterGroup"/>. </summary>
        /// <param name="name"> Product name with value 'groupproduct'. </param>
        /// <param name="simpleBodyProduct"> Simple body product to put. </param>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        /// <param name="description"> Description of product. </param>
        /// <param name="maxProductDisplayName"> Display name of product. </param>
        /// <param name="capacity"> Capacity of product. For example, 4 people. </param>
        /// <param name="genericValue"> Generic URL value. </param>
        /// <param name="odataValue"> URL value. </param>
        /// <returns> A new <see cref="Models.FlattenParameterGroup"/> instance for mocking. </returns>
        public static FlattenParameterGroup FlattenParameterGroup(string name = null, SimpleProduct simpleBodyProduct = null, string productId = null, string description = null, string maxProductDisplayName = null, SimpleProductPropertiesMaxProductCapacity? capacity = null, string genericValue = null, string odataValue = null)
        {
            return new FlattenParameterGroup(name, simpleBodyProduct, productId, description, maxProductDisplayName, capacity, genericValue, odataValue, new Dictionary<string, BinaryData>());
        }
    }
}
