// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace body_complex.Models
{
    /// <summary> The ArrayWrapper. </summary>
    public partial class ArrayWrapper
    {
        /// <summary> Initializes a new instance of ArrayWrapper. </summary>
        public ArrayWrapper()
        {
            Array = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of ArrayWrapper. </summary>
        /// <param name="array"></param>
        internal ArrayWrapper(IList<string> array)
        {
            Array = array;
        }

        /// <summary> Gets the array. </summary>
        public IList<string> Array { get; }
    }
}
