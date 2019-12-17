// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace additionalProperties.Models.V100
{
    public partial class PetAPInProperties
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; internal set; }
        public IDictionary<string, float>? AdditionalProperties { get; set; }
    }
}
