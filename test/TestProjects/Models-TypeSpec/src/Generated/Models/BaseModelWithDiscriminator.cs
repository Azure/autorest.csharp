// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelsTypeSpec.Models
{
    /// <summary>
    /// Base model with discriminator property.
    /// Please note <see cref="BaseModelWithDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DerivedModelWithDiscriminatorA"/> and <see cref="DerivedModelWithDiscriminatorB"/>.
    /// </summary>
    public abstract partial class BaseModelWithDiscriminator
    {
        /// <summary> Initializes a new instance of BaseModelWithDiscriminator. </summary>
        /// <param name="requiredPropertyOnBase"> Required property on base. </param>
        protected BaseModelWithDiscriminator(int requiredPropertyOnBase)
        {
            RequiredPropertyOnBase = requiredPropertyOnBase;
        }

        /// <summary> Initializes a new instance of BaseModelWithDiscriminator. </summary>
        /// <param name="discriminatorProperty"> Discriminator. </param>
        /// <param name="optionalPropertyOnBase"> Optional property on base. </param>
        /// <param name="requiredPropertyOnBase"> Required property on base. </param>
        internal BaseModelWithDiscriminator(string discriminatorProperty, string optionalPropertyOnBase, int requiredPropertyOnBase)
        {
            DiscriminatorProperty = discriminatorProperty;
            OptionalPropertyOnBase = optionalPropertyOnBase;
            RequiredPropertyOnBase = requiredPropertyOnBase;
        }

        /// <summary> Discriminator. </summary>
        internal string DiscriminatorProperty { get; set; }
        /// <summary> Optional property on base. </summary>
        public string OptionalPropertyOnBase { get; set; }
        /// <summary> Required property on base. </summary>
        public int RequiredPropertyOnBase { get; set; }
    }
}
