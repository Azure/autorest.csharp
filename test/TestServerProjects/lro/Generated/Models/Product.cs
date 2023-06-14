// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace lro.Models
{
    /// <summary> The Product. </summary>
    public partial class Product : Resource
    {
        /// <summary> Initializes a new instance of Product. </summary>
        public Product()
        {
        }

        /// <summary> Initializes a new instance of Product. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="type"> Resource Type. </param>
        /// <param name="tags"> Dictionary of &lt;string&gt;. </param>
        /// <param name="location"> Resource Location. </param>
        /// <param name="name"> Resource Name. </param>
        /// <param name="provisioningState"></param>
        /// <param name="provisioningStateValues"></param>
        internal Product(string id, string type, IDictionary<string, string> tags, string location, string name, string provisioningState, ProductPropertiesProvisioningStateValues? provisioningStateValues) : base(id, type, tags, location, name)
        {
            ProvisioningState = provisioningState;
            ProvisioningStateValues = provisioningStateValues;
        }

        /// <summary> Gets or sets the provisioning state. </summary>
        public string ProvisioningState { get; set; }
        /// <summary> Gets the provisioning state values. </summary>
        public ProductPropertiesProvisioningStateValues? ProvisioningStateValues { get; }
    }
}
