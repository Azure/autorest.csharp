// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The UnknownBaseClassWithExtensibleEnumDiscriminator. </summary>
    internal partial class UnknownBaseClassWithExtensibleEnumDiscriminator : BaseClassWithExtensibleEnumDiscriminator
    {
        /// <summary> Initializes a new instance of UnknownBaseClassWithExtensibleEnumDiscriminator. </summary>
        /// <param name="discriminatorProperty"></param>
        internal UnknownBaseClassWithExtensibleEnumDiscriminator(BaseClassWithEntensibleEnumDiscriminatorEnum discriminatorProperty) : base(discriminatorProperty)
        {
            DiscriminatorProperty = discriminatorProperty;
        }
    }
}
