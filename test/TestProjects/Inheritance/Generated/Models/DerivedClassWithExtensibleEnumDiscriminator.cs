// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The DerivedClassWithExtensibleEnumDiscriminator. </summary>
    public partial class DerivedClassWithExtensibleEnumDiscriminator : BaseClassWithExtensibleEnumDiscriminator
    {
        /// <summary> Initializes a new instance of DerivedClassWithExtensibleEnumDiscriminator. </summary>
        public DerivedClassWithExtensibleEnumDiscriminator()
        {
            DiscriminatorProperty = BaseClassWithEntensibleEnumDiscriminatorEnum.Derived;
        }

        /// <summary> Initializes a new instance of DerivedClassWithExtensibleEnumDiscriminator. </summary>
        /// <param name="discriminatorProperty"></param>
        internal DerivedClassWithExtensibleEnumDiscriminator(BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty) : base(discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty;
        }
    }
}
