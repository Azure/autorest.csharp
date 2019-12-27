// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models.V100
{
    public partial class Slide
    {
        public string? Type { get; set; }
        public string? Title { get; set; }
        public ICollection<string>? Items { get; set; }
    }
}
