// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace lro.Models
{
    /// <summary> The SubProductProperties. </summary>
    public partial class SubProductProperties
    {
        public string ProvisioningState { get; set; }
        public SubProductPropertiesProvisioningStateValues? ProvisioningStateValues { get; internal set; }
    }
}
