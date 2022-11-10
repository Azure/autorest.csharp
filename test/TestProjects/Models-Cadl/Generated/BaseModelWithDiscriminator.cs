// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace ModelsInCadl
{
    /// <summary>
    /// Base model with discriminator property.
    /// Please note <see cref="BaseModelWithDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DerivedModelWithDiscriminatorA"/> and <see cref="DerivedModelWithDiscriminatorB"/>.
    /// </summary>
    public abstract partial class BaseModelWithDiscriminator
    {
        /// <summary> Initializes a new instance of BaseModelWithDiscriminator. </summary>
        /// <param name="discriminatorProperty"> Discriminator. </param>
        protected BaseModelWithDiscriminator(string discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty;
        }

        /// <summary> Discriminator. </summary>
        public string DiscriminatorProperty { get; }
    }
}
