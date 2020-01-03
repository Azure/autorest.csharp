// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models.V100
{
    public partial class AppleBarrel
    {
        public ICollection<string>? GoodApples { get; set; }
        public ICollection<string>? BadApples { get; set; }
    }
}
