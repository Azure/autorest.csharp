// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Inheritance.Models
{
    /// <summary> The DerivedClassWithEnumDiscriminator. </summary>
    internal partial class DerivedClassWithEnumDiscriminator : BaseClassWithEnumDiscriminator
    {
        /// <summary> Initializes a new instance of <see cref="DerivedClassWithEnumDiscriminator"/>. </summary>
        internal DerivedClassWithEnumDiscriminator()
        {
            DiscriminatorProperty = BaseClassWithEnumDiscriminatorEnum.Derived;
        }

        /// <summary> Initializes a new instance of <see cref="DerivedClassWithEnumDiscriminator"/>. </summary>
        /// <param name="discriminatorProperty"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DerivedClassWithEnumDiscriminator(BaseClassWithEnumDiscriminatorEnum discriminatorProperty, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(discriminatorProperty, serializedAdditionalRawData)
        {
            DiscriminatorProperty = discriminatorProperty;
        }
    }
}
