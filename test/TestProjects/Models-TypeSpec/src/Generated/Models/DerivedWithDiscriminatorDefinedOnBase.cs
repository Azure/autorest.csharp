// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> A derived class in the discriminated set inheriting from a base with the predefined discriminator property. </summary>
    public partial class DerivedWithDiscriminatorDefinedOnBase : BaseModelWithDiscriminatorDefinedOnBase
    {
        /// <summary> Initializes a new instance of <see cref="DerivedWithDiscriminatorDefinedOnBase"/>. </summary>
        /// <param name="kind"> Required kind. </param>
        /// <param name="requiredString"> Required string. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> or <paramref name="requiredString"/> is null. </exception>
        public DerivedWithDiscriminatorDefinedOnBase(string kind, string requiredString) : base(kind)
        {
            Argument.AssertNotNull(kind, nameof(kind));
            Argument.AssertNotNull(requiredString, nameof(requiredString));

            Kind = "A";
            RequiredString = requiredString;
        }

        /// <summary> Initializes a new instance of <see cref="DerivedWithDiscriminatorDefinedOnBase"/>. </summary>
        /// <param name="kind"> Required kind. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="optionalString"> Optional string. </param>
        /// <param name="requiredString"> Required string. </param>
        /// <param name="optionalInt"> Optional int. </param>
        internal DerivedWithDiscriminatorDefinedOnBase(string kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string optionalString, string requiredString, int? optionalInt) : base(kind, serializedAdditionalRawData, optionalString)
        {
            RequiredString = requiredString;
            OptionalInt = optionalInt;
        }

        /// <summary> Initializes a new instance of <see cref="DerivedWithDiscriminatorDefinedOnBase"/> for deserialization. </summary>
        internal DerivedWithDiscriminatorDefinedOnBase()
        {
        }

        /// <summary> Required string. </summary>
        public string RequiredString { get; set; }
        /// <summary> Optional int. </summary>
        public int? OptionalInt { get; set; }
    }
}
