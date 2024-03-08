// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using _Specs_.Azure.ClientGenerator.Core.Access;

namespace _Specs_.Azure.ClientGenerator.Core.Access.Models
{
    /// <summary> Used in internal operations, should be generated but not exported. </summary>
    internal partial class RealModel : AbstractModel
    {
        /// <summary> Initializes a new instance of <see cref="RealModel"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal RealModel(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Kind = "real";
        }

        /// <summary> Initializes a new instance of <see cref="RealModel"/>. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="name"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RealModel(string kind, string name, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(kind, name, serializedAdditionalRawData)
        {
        }

        /// <summary> Initializes a new instance of <see cref="RealModel"/> for deserialization. </summary>
        internal RealModel()
        {
        }
    }
}
