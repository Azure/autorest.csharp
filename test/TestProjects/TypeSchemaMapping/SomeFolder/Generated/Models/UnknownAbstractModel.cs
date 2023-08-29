// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace TypeSchemaMapping.Models
{
    /// <summary> The UnknownAbstractModel. </summary>
    internal partial class UnknownAbstractModel : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of global::TypeSchemaMapping.Models.UnknownAbstractModel
        ///
        /// </summary>
        /// <param name="discriminatorProperty"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownAbstractModel(string discriminatorProperty, Dictionary<string, BinaryData> rawData) : base(discriminatorProperty, rawData)
        {
            DiscriminatorProperty = discriminatorProperty ?? "Unknown";
        }

        /// <summary> Initializes a new instance of <see cref="UnknownAbstractModel"/> for deserialization. </summary>
        internal UnknownAbstractModel()
        {
        }
    }
}
