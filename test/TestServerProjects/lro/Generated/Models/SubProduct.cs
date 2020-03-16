// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace lro.Models
{
    /// <summary> The SubProduct. </summary>
    public partial class SubProduct : SubResource
    {
        /// <summary> Initializes a new instance of SubProduct. </summary>
        internal SubProduct()
        {
        }

        /// <summary> Initializes a new instance of SubProduct. </summary>
        /// <param name="provisioningState"> . </param>
        /// <param name="provisioningStateValues"> . </param>
        /// <param name="id"> Sub Resource Id. </param>
        internal SubProduct(string provisioningState, SubProductPropertiesProvisioningStateValues? provisioningStateValues, string id) : base(id)
        {
            ProvisioningState = provisioningState;
            ProvisioningStateValues = provisioningStateValues;
        }

        public string ProvisioningState { get; set; }
        public SubProductPropertiesProvisioningStateValues? ProvisioningStateValues { get; internal set; }
    }
}
