// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Model.Usage.Models
{
    /// <summary> Record used in operation return type. </summary>
    public partial class OutputRecord
    {
        /// <summary> Initializes a new instance of OutputRecord. </summary>
        /// <param name="requiredProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProp"/> is null. </exception>
        internal OutputRecord(string requiredProp)
        {
            Argument.AssertNotNull(requiredProp, nameof(requiredProp));

            RequiredProp = requiredProp;
        }

        /// <summary> Gets the required prop. </summary>
        public string RequiredProp { get; }
    }
}
