// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The Basic. </summary>
    public partial class Basic
    {
        /// <summary> Initializes a new instance of Basic. </summary>
        public Basic()
        {
        }

        /// <summary> Initializes a new instance of Basic. </summary>
        /// <param name="id"> Basic Id. </param>
        /// <param name="name"> Name property with a very long description that does not fit on a single line and a line break. </param>
        /// <param name="color"></param>
        internal Basic(int? id, string name, CMYKColors? color)
        {
            Id = id;
            Name = name;
            Color = color;
        }

        /// <summary> Basic Id. </summary>
        public int? Id { get; set; }
        /// <summary> Name property with a very long description that does not fit on a single line and a line break. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the color. </summary>
        public CMYKColors? Color { get; set; }
    }
}
