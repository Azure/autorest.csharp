// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Inheritance.Models
{
    /// <summary>
    /// The BaseClassWithEnumDiscriminator.
    /// Please note <see cref="BaseClassWithEnumDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DerivedClassWithEnumDiscriminator"/>.
    /// </summary>
    internal abstract partial class BaseClassWithEnumDiscriminator
    {
        /// <summary> Initializes a new instance of BaseClassWithEnumDiscriminator. </summary>
        protected BaseClassWithEnumDiscriminator()
        {
        }

        /// <summary> Gets or sets the discriminator property. </summary>
        internal BaseClassWithEnumDiscriminatorEnum DiscriminatorProperty { get; set; }
    }
}
