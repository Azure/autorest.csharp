// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace model_flattening.Models
{
    /// <summary> The product documentation. </summary>
    public partial class SimpleProduct : BaseProduct
    {
        /// <summary> Display name of product. </summary>
        public string? MaxProductDisplayName { get; set; }
        /// <summary> Capacity of product. For example, 4 people. </summary>
        public string Capacity { get; set; } = "Large";
        /// <summary> URL value. </summary>
        public string? OdataValue { get; set; }
    }
}
