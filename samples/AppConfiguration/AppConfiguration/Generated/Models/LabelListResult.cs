// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AppConfiguration.Models.V10
{
    public partial class LabelListResult
    {
        public ICollection<Label>? Items { get; set; }
        public string? NextLink { get; set; }
    }
}
