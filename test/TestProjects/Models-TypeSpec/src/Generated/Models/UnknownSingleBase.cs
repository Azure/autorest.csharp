// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelsTypeSpec.Models
{
    /// <summary> Unknown version of SingleBase. </summary>
    internal partial class UnknownSingleBase : SingleBase
    {
        /// <summary> Initializes a new instance of UnknownSingleBase. </summary>
        /// <param name="size"></param>
        internal UnknownSingleBase(int size) : base(size)
        {
        }

        /// <summary> Initializes a new instance of UnknownSingleBase. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="size"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownSingleBase(string kind, int size, Dictionary<string, BinaryData> rawData) : base(kind, size, rawData)
        {
        }
    }
}
