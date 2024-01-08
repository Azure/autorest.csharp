// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace _Type.Union.Models
{
    /// <summary> The GetResponse7. </summary>
    public partial class GetResponse7
    {
        /// <summary> Initializes a new instance of <see cref="GetResponse7"/>. </summary>
        /// <param name="prop"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="prop"/> is null. </exception>
        internal GetResponse7(StringAndArrayCases prop)
        {
            Argument.AssertNotNull(prop, nameof(prop));

            Prop = prop;
        }

        /// <summary> Gets the prop. </summary>
        public StringAndArrayCases Prop { get; }
    }
}
