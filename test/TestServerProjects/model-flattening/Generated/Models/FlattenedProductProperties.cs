// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace model_flattening.Models
{
    /// <summary> The FlattenedProduct-properties. </summary>
    public partial class FlattenedProductProperties
    {
        public string PName { get; set; }
        public string Type { get; set; }
        public FlattenedProductPropertiesProvisioningStateValues? ProvisioningStateValues { get; internal set; }
        public string ProvisioningState { get; set; }
    }
}
