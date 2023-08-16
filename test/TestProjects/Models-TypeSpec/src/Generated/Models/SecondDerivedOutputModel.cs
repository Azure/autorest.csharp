// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelsTypeSpec.Models
{
    /// <summary> Second derived model as an output. </summary>
    public partial class SecondDerivedOutputModel : OutputBaseModelWithDiscriminator
    {
        /// <summary> Initializes a new instance of SecondDerivedOutputModel. </summary>
        /// <param name="second"></param>
        internal SecondDerivedOutputModel(bool second)
        {
            Kind = "second";
            Second = second;
        }

        /// <summary> Initializes a new instance of SecondDerivedOutputModel. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="second"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SecondDerivedOutputModel(string kind, bool second, Dictionary<string, BinaryData> rawData) : base(kind, rawData)
        {
            Second = second;
        }

        /// <summary> Gets the second. </summary>
        public bool Second { get; }
    }
}
