// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The ArrayWrapper. </summary>
    public partial class ArrayWrapper
    {
<<<<<<< HEAD
        /// <summary> Initializes a new instance of ArrayWrapper. </summary>
        public ArrayWrapper()
        {
        }
        /// <summary> Initializes a new instance of ArrayWrapper. </summary>
        internal ArrayWrapper(ICollection<string> array)
        {
            Array = array;
        }
        public ICollection<string> Array { get; set; }
=======
        public IList<string> Array { get; set; }
>>>>>>> feature/v3
    }
}
