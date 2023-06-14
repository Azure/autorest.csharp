// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Model.Usage.Models
{
    /// <summary> Record used both as operation parameter and return type. </summary>
    public partial class InputOutputRecord
    {
        /// <summary> Initializes a new instance of InputOutputRecord. </summary>
        /// <param name="requiredProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProp"/> is null. </exception>
        public InputOutputRecord(string requiredProp)
        {
            Argument.AssertNotNull(requiredProp, nameof(requiredProp));

            RequiredProp = requiredProp;
        }

        /// <summary> Gets or sets the required prop. </summary>
        public string RequiredProp { get; set; }
    }
}
