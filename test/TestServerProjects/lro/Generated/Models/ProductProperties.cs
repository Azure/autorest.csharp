// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace lro.Models
{
    /// <summary> The ProductProperties. </summary>
    public partial class ProductProperties
    {
        public string ProvisioningState { get; set; }
        public ProductPropertiesProvisioningStateValues? ProvisioningStateValues { get; internal set; }
    }
}
