// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Model.Usage.Models
{
    /// <summary> Record used in operation parameters. </summary>
    public partial class InputRecord
    {
        /// <summary> Initializes a new instance of InputRecord. </summary>
        /// <param name="requiredProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProp"/> is null. </exception>
        public InputRecord(string requiredProp)
        {
            Argument.AssertNotNull(requiredProp, nameof(requiredProp));

            RequiredProp = requiredProp;
        }

        /// <summary> Gets the required prop. </summary>
        public string RequiredProp { get; }
    }
}
