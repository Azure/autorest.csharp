// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The DerivedClassWithEnumDiscriminator. </summary>
    internal partial class DerivedClassWithEnumDiscriminator : BaseClassWithEnumDiscriminator
    {
        /// <summary> Initializes a new instance of DerivedClassWithEnumDiscriminator. </summary>
        internal DerivedClassWithEnumDiscriminator()
        {
            DiscriminatorProperty = BaseClassWithEnumDiscriminatorEnum.Derived;
        }
    }
}
