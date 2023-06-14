// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Inheritance.Models
{
    /// <summary>
    /// The BaseClassWithExtensibleEnumDiscriminator.
    /// Please note <see cref="BaseClassWithExtensibleEnumDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DerivedClassWithExtensibleEnumDiscriminator"/> and <see cref="AnotherDerivedClassWithExtensibleEnumDiscriminator"/>.
    /// </summary>
    public abstract partial class BaseClassWithExtensibleEnumDiscriminator
    {
        /// <summary> Initializes a new instance of BaseClassWithExtensibleEnumDiscriminator. </summary>
        protected BaseClassWithExtensibleEnumDiscriminator()
        {
        }

        /// <summary> Initializes a new instance of BaseClassWithExtensibleEnumDiscriminator. </summary>
        /// <param name="discriminatorProperty"></param>
        internal BaseClassWithExtensibleEnumDiscriminator(BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty;
        }

        /// <summary> Gets or sets the discriminator property. </summary>
        internal BaseClassWithEntensibleEnumDiscriminatorEnum DiscriminatorProperty { get; set; }
    }
}
