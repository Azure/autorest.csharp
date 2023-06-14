// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
        internal SecondDerivedOutputModel(string kind, bool second) : base(kind)
        {
            Second = second;
        }

        /// <summary> Gets the second. </summary>
        public bool Second { get; }
    }
}
