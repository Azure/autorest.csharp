// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelsTypeSpec.Models
{
    /// <summary> Deriver model with discriminator property. </summary>
    public partial class DerivedModelWithDiscriminatorB : BaseModelWithDiscriminator
    {
        /// <summary> Initializes a new instance of DerivedModelWithDiscriminatorB. </summary>
        /// <param name="requiredPropertyOnBase"> Required property on base. </param>
        /// <param name="requiredInt"> Required int. </param>
        public DerivedModelWithDiscriminatorB(int requiredPropertyOnBase, int requiredInt) : base(requiredPropertyOnBase)
        {
            DiscriminatorProperty = "B";
            RequiredInt = requiredInt;
        }

        /// <summary> Initializes a new instance of DerivedModelWithDiscriminatorB. </summary>
        /// <param name="discriminatorProperty"> Discriminator. </param>
        /// <param name="optionalPropertyOnBase"> Optional property on base. </param>
        /// <param name="requiredPropertyOnBase"> Required property on base. </param>
        /// <param name="requiredInt"> Required int. </param>
        internal DerivedModelWithDiscriminatorB(string discriminatorProperty, string optionalPropertyOnBase, int requiredPropertyOnBase, int requiredInt) : base(discriminatorProperty, optionalPropertyOnBase, requiredPropertyOnBase)
        {
            RequiredInt = requiredInt;
        }

        /// <summary> Required int. </summary>
        public int RequiredInt { get; set; }
    }
}
