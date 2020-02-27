// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace lro.Models
{
    /// <summary> The SubProduct. </summary>
    public partial class SubProduct : SubResource
    {
        public string ProvisioningState { get; set; }
        public SubProductPropertiesProvisioningStateValues? ProvisioningStateValues { get; internal set; }
    }
}
