// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace httpInfrastructure.quirks.Models
{
    /// <summary> The Error. </summary>
    public partial class Error
    {
        public int? Status { get; set; }
        public string Message { get; set; }
    }
}
