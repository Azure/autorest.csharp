// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace ModelsTypeSpec.Models
{
    /// <summary> Unknown version of DerivedWithDiscriminatorDefinedOnBase. </summary>
    internal partial class UnknownDerivedWithDiscriminatorDefinedOnBase : DerivedWithDiscriminatorDefinedOnBase
    {
        /// <summary> Initializes a new instance of <see cref="UnknownDerivedWithDiscriminatorDefinedOnBase"/>. </summary>
        /// <param name="kind"> Required kind. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="optionalString"> Optional string. </param>
        /// <param name="requiredString"> Required string. </param>
        /// <param name="optionalInt"> Optional int. </param>
        internal UnknownDerivedWithDiscriminatorDefinedOnBase(string kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string optionalString, string requiredString, int? optionalInt) : base(kind, serializedAdditionalRawData, optionalString, requiredString, optionalInt)
        {
        }

        /// <summary> Initializes a new instance of <see cref="UnknownDerivedWithDiscriminatorDefinedOnBase"/> for deserialization. </summary>
        internal UnknownDerivedWithDiscriminatorDefinedOnBase()
        {
        }
    }
}
