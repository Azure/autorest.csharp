// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace model_flattening.Models
{
    /// <summary> The product URL. </summary>
    public partial class ProductUrl : GenericUrl
    {
        /// <summary> URL value. </summary>
        public string? OdataValue { get; set; }
    }
}
