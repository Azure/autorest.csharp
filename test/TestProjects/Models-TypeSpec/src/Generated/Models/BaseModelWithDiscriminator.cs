// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary>
    /// Base model with discriminator property.
    /// Please note <see cref="BaseModelWithDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DerivedModelWithDiscriminatorA"/> and <see cref="DerivedModelWithDiscriminatorB"/>.
    /// </summary>
    public abstract partial class BaseModelWithDiscriminator
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="BaseModelWithDiscriminator"/>. </summary>
        /// <param name="requiredPropertyOnBase"> Required property on base. </param>
        protected BaseModelWithDiscriminator(int requiredPropertyOnBase)
        {
            RequiredPropertyOnBase = requiredPropertyOnBase;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="BaseModelWithDiscriminator"/>. </summary>
        /// <param name="discriminatorProperty"> Discriminator. </param>
        /// <param name="optionalPropertyOnBase"> Optional property on base. </param>
        /// <param name="requiredPropertyOnBase"> Required property on base. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal BaseModelWithDiscriminator(string discriminatorProperty, string optionalPropertyOnBase, int requiredPropertyOnBase, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            DiscriminatorProperty = discriminatorProperty;
            OptionalPropertyOnBase = optionalPropertyOnBase;
            RequiredPropertyOnBase = requiredPropertyOnBase;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="BaseModelWithDiscriminator"/> for deserialization. </summary>
        internal BaseModelWithDiscriminator()
        {
        }

        /// <summary> Discriminator. </summary>
        internal string DiscriminatorProperty { get; set; }
        /// <summary> Optional property on base. </summary>
        public string OptionalPropertyOnBase { get; set; }
        /// <summary> Required property on base. </summary>
        public int RequiredPropertyOnBase { get; set; }
    }
}
