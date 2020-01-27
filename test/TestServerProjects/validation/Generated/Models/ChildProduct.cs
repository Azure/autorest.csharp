// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace validation.Models
{
    /// <summary> The product documentation. </summary>
    public partial class ChildProduct
    {
        /// <summary> Constant string. </summary>
        public string ConstProperty { get; set; } = "constant";
        /// <summary> Count. </summary>
        public int? Count { get; set; }
    }
}
