// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace lro.Models
{
    /// <summary> The SubProduct. </summary>
    public partial class SubProduct : SubResource
    {
        /// <summary>
        /// Initializes a new instance of global::lro.Models.SubProduct
        ///
        /// </summary>
        public SubProduct()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::lro.Models.SubProduct
        ///
        /// </summary>
        /// <param name="id"> Sub Resource Id. </param>
        /// <param name="provisioningState"></param>
        /// <param name="provisioningStateValues"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SubProduct(string id, string provisioningState, SubProductPropertiesProvisioningStateValues? provisioningStateValues, Dictionary<string, BinaryData> rawData) : base(id, rawData)
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
