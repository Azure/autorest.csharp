// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelsTypeSpec.Models
{
    /// <summary> First derived model as an output. </summary>
    public partial class FirstDerivedOutputModel : OutputBaseModelWithDiscriminator
    {
        /// <summary> Initializes a new instance of FirstDerivedOutputModel. </summary>
        /// <param name="first"></param>
        internal FirstDerivedOutputModel(bool first)
        {
            Kind = "first";
            First = first;
        }

        /// <summary> Initializes a new instance of FirstDerivedOutputModel. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="first"></param>
        internal FirstDerivedOutputModel(string kind, bool first) : base(kind)
        {
            First = first;
        }

        /// <summary> Gets the first. </summary>
        public bool First { get; }
    }
}
