// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace model_flattening.Models
{
    /// <summary> Flattened product. </summary>
    public partial class FlattenedProduct : Resource
    {
        /// <summary> Initializes a new instance of FlattenedProduct. </summary>
        public FlattenedProduct()
        {
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
        internal FlattenedProduct(string id, string type, IDictionary<string, string> tags, string location, string name, string pName, string typePropertiesType, FlattenedProductPropertiesProvisioningStateValues? provisioningStateValues, string provisioningState) : base(id, type, tags, location, name)
        {
            PName = pName;
            TypePropertiesType = typePropertiesType;
            ProvisioningStateValues = provisioningStateValues;
            ProvisioningState = provisioningState;
        }

        /// <summary> Gets or sets the pname. </summary>
        public string PName { get; set; }
        /// <summary> Gets or sets the typepropertiestype. </summary>
        public string TypePropertiesType { get; set; }
        /// <summary> Gets the provisioningstatevalues. </summary>
        public FlattenedProductPropertiesProvisioningStateValues? ProvisioningStateValues { get; }
        /// <summary> Gets or sets the provisioningstate. </summary>
        public string ProvisioningState { get; set; }
    }
}
