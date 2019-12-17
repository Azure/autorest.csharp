// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace validation.Models.V100
{
    public partial class Error
    {
        public int? Code { get; set; }
        public string? Message { get; set; }
        public string? Fields { get; set; }
    }
}
