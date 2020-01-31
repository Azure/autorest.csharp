// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace model_flattening.Models
{
    /// <summary> Flattened product. </summary>
    public partial class FlattenedProduct : Resource
    {
        public string PName { get; set; }
        public string TypePropertiesType { get; set; }
        public FlattenedProductPropertiesProvisioningStateValues? ProvisioningStateValues { get; internal set; }
        public string ProvisioningState { get; set; }
    }
}
