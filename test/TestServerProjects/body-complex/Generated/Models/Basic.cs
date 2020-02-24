// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The Basic. </summary>
    public partial class Basic
    {
        /// <summary> Basic Id. </summary>
        public int? Id { get; set; }
        /// <summary> Name property with a very long description that does not fit on a single line and a line break. </summary>
        public string Name { get; set; }
        public CMYKColors? Color { get; set; }
    }
}
