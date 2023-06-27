// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace required_optional.Models
{
    /// <summary> The ArrayOptionalWrapper. </summary>
    public partial class ArrayOptionalWrapper
    {
        /// <summary> Initializes a new instance of ArrayOptionalWrapper. </summary>
        public ArrayOptionalWrapper()
        {
            Value = new ChangeTrackingList<string>();
        }

        /// <summary> Gets the value. </summary>
        public IList<string> Value { get; }
    }
}
