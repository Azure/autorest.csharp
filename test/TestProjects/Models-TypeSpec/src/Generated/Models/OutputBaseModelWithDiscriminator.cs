// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Serialization;

namespace ModelsTypeSpec.Models
{
    /// <summary>
    /// Output model with a discriminator
    /// Please note <see cref="OutputBaseModelWithDiscriminator"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="FirstDerivedOutputModel"/> and <see cref="SecondDerivedOutputModel"/>.
    /// </summary>
    [AbstractTypeDeserializer(typeof(UnknownOutputBaseModelWithDiscriminator))]
    public abstract partial class OutputBaseModelWithDiscriminator
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of OutputBaseModelWithDiscriminator. </summary>
        protected OutputBaseModelWithDiscriminator()
        {
        }

        /// <summary> Initializes a new instance of OutputBaseModelWithDiscriminator. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal OutputBaseModelWithDiscriminator(string kind, Dictionary<string, BinaryData> rawData)
        {
            Kind = kind;
            _rawData = rawData;
        }

        /// <summary> Discriminator. </summary>
        internal string Kind { get; set; }
    }
}
