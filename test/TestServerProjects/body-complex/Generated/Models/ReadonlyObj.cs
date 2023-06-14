// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The ReadonlyObj. </summary>
    public partial class ReadonlyObj
    {
        /// <summary> Initializes a new instance of ReadonlyObj. </summary>
        public ReadonlyObj()
        {
        }

        /// <summary> Initializes a new instance of ReadonlyObj. </summary>
        /// <param name="id"></param>
        /// <param name="size"></param>
        internal ReadonlyObj(string id, int? size)
        {
            Id = id;
            Size = size;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
        /// <summary> Gets or sets the size. </summary>
        public int? Size { get; set; }
    }
}
