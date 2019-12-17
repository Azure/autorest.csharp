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
        public ChildProduct Child { get; set; }
        public ConstantProduct ConstChild { get; set; }
        public float ConstInt { get; set; }
        public string ConstString { get; set; }
        public string ConstStringAsEnum { get; set; }
    }
}
