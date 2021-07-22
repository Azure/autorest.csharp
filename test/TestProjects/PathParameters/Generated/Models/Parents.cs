// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace PathParameters.Models
{
    /// <summary> The Parents. </summary>
    public partial class Parents
    {
        /// <summary> Initializes a new instance of Parents. </summary>
        internal Parents()
        {
            Value = new ChangeTrackingList<ParentData>();
        }

        /// <summary> Initializes a new instance of Parents. </summary>
        /// <param name="value"></param>
        internal Parents(IReadOnlyList<ParentData> value)
        {
            Value = value;
        }

        public IReadOnlyList<ParentData> Value { get; }
    }
}
