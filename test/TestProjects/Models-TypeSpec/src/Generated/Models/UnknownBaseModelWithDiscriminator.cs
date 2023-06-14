// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelsTypeSpec.Models
{
    /// <summary> Unknown version of BaseModelWithDiscriminator. </summary>
    internal partial class UnknownBaseModelWithDiscriminator : BaseModelWithDiscriminator
    {
        /// <summary> Initializes a new instance of UnknownBaseModelWithDiscriminator. </summary>
        /// <param name="requiredPropertyOnBase"> Required property on base. </param>
        internal UnknownBaseModelWithDiscriminator(int requiredPropertyOnBase) : base(requiredPropertyOnBase)
        {
        }

        /// <summary> Initializes a new instance of UnknownBaseModelWithDiscriminator. </summary>
        /// <param name="discriminatorProperty"> Discriminator. </param>
        /// <param name="optionalPropertyOnBase"> Optional property on base. </param>
        /// <param name="requiredPropertyOnBase"> Required property on base. </param>
        internal UnknownBaseModelWithDiscriminator(string discriminatorProperty, string optionalPropertyOnBase, int requiredPropertyOnBase) : base(discriminatorProperty, optionalPropertyOnBase, requiredPropertyOnBase)
        {
        }
    }
}
