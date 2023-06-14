// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace lro.Models
{
    /// <summary> The SubProduct. </summary>
    public partial class SubProduct : SubResource
    {
        /// <summary> Initializes a new instance of SubProduct. </summary>
        public SubProduct()
        {
        }

        /// <summary> Initializes a new instance of SubProduct. </summary>
        /// <param name="id"> Sub Resource Id. </param>
        /// <param name="provisioningState"></param>
        /// <param name="provisioningStateValues"></param>
        internal SubProduct(string id, string provisioningState, SubProductPropertiesProvisioningStateValues? provisioningStateValues) : base(id)
        {
            ProvisioningState = provisioningState;
            ProvisioningStateValues = provisioningStateValues;
        }

        /// <summary> Gets or sets the provisioning state. </summary>
        public string ProvisioningState { get; set; }
        /// <summary> Gets the provisioning state values. </summary>
        public SubProductPropertiesProvisioningStateValues? ProvisioningStateValues { get; }
    }
}
