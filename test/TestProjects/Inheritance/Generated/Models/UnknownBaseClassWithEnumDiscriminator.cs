// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The UnknownBaseClassWithEnumDiscriminator. </summary>
    internal partial class UnknownBaseClassWithEnumDiscriminator : BaseClassWithEnumDiscriminator
    {
        /// <summary> Initializes a new instance of UnknownBaseClassWithEnumDiscriminator. </summary>
        /// <param name="discriminatorProperty"></param>
        internal UnknownBaseClassWithEnumDiscriminator(BaseClassWithEnumDiscriminatorEnum discriminatorProperty) : base(discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty;
        }
    }
}
