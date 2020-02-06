// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The ReadonlyObj. </summary>
    public partial class ReadonlyObj
    {
        public string Id { get; internal set; }
        public int? Size { get; set; }
    }
}
