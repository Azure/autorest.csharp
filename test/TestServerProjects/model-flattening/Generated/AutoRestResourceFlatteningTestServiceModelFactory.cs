// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace model_flattening.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class AutoRestResourceFlatteningTestServiceModelFactory
    {
        /// <summary> Initializes a new instance of Resource. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="type"> Resource Type. </param>
        /// <param name="tags"> Dictionary of &lt;string&gt;. </param>
        /// <param name="location"> Resource Location. </param>
        /// <param name="name"> Resource Name. </param>
        /// <returns> A new <see cref="Models.Resource"/> instance for mocking. </returns>
        public static Resource Resource(string id = null, string type = null, IDictionary<string, string> tags = null, string location = null, string name = null)
        {
            tags ??= new Dictionary<string, string>();

            return new Resource(id, type, tags, location, name);
        }

        /// <summary> Initializes a new instance of FlattenedProduct. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="type"> Resource Type. </param>
        /// <param name="tags"> Dictionary of &lt;string&gt;. </param>
        /// <param name="location"> Resource Location. </param>
        /// <param name="name"> Resource Name. </param>
        /// <param name="pName"></param>
        /// <param name="typePropertiesType"></param>
        /// <param name="provisioningStateValues"></param>
        /// <param name="provisioningState"></param>
        /// <returns> A new <see cref="Models.FlattenedProduct"/> instance for mocking. </returns>
        public static FlattenedProduct FlattenedProduct(string id = null, string type = null, IDictionary<string, string> tags = null, string location = null, string name = null, string pName = null, string typePropertiesType = null, FlattenedProductPropertiesProvisioningStateValues? provisioningStateValues = null, string provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();

            return new FlattenedProduct(id, type, tags, location, name, pName, typePropertiesType, provisioningStateValues, provisioningState);
        }

        /// <summary> Initializes a new instance of ProductWrapper. </summary>
        /// <param name="value"> the product value. </param>
        /// <returns> A new <see cref="Models.ProductWrapper"/> instance for mocking. </returns>
        public static ProductWrapper ProductWrapper(string value = null)
        {
            return new ProductWrapper(value);
        }
    }
}
