// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The AnotherDerivedClassWithExtensibleEnumDiscriminator. </summary>
    public partial class AnotherDerivedClassWithExtensibleEnumDiscriminator : BaseClassWithExtensibleEnumDiscriminator
    {
        /// <summary> Initializes a new instance of AnotherDerivedClassWithExtensibleEnumDiscriminator. </summary>
        public AnotherDerivedClassWithExtensibleEnumDiscriminator()
        {
            DiscriminatorProperty = new BaseClassWithEntensibleEnumDiscriminatorEnum("random value");
        }

        /// <summary> Initializes a new instance of AnotherDerivedClassWithExtensibleEnumDiscriminator. </summary>
        /// <param name="discriminatorProperty"></param>
        internal AnotherDerivedClassWithExtensibleEnumDiscriminator(BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty) : base(discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty;
        }
    }
}
