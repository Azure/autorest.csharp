// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelsTypeSpec.Models
{
    /// <summary> Unknown version of OutputBaseModelWithDiscriminator. </summary>
    internal partial class UnknownOutputBaseModelWithDiscriminator : OutputBaseModelWithDiscriminator
    {
        /// <summary> Initializes a new instance of UnknownOutputBaseModelWithDiscriminator. </summary>
        internal UnknownOutputBaseModelWithDiscriminator()
        {
        }

        /// <summary> Initializes a new instance of UnknownOutputBaseModelWithDiscriminator. </summary>
        /// <param name="kind"> Discriminator. </param>
        internal UnknownOutputBaseModelWithDiscriminator(string kind) : base(kind)
        {
        }
    }
}
