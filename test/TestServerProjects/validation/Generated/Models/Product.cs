// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace validation.Models.V100
{
    public partial class Product
    {
        public ICollection<string>? DisplayNames { get; set; }
        public int? Capacity { get; set; }
        public string? Image { get; set; }
        public ChildProduct Child { get; set; } = new ChildProduct();
        public ConstantProduct ConstChild { get; set; } = new ConstantProduct();
        public float ConstInt { get; set; } = 0F;
        public string ConstString { get; set; } = "constant";
        public string ConstStringAsEnum { get; set; } = "constant_string_as_enum";
    }
}
