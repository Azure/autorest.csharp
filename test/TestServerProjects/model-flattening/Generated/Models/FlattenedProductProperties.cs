// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace model_flattening.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class FlattenedProductProperties
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? PName { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Type { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-CHOICE. </summary>
        public FlattenedProductPropertiesProvisioningStateValues? ProvisioningStateValues { get; internal set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? ProvisioningState { get; set; }
    }
}
