// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtSafeFlatten.Models
{
    /// <summary> The LayerOneFooType. </summary>
    public partial class LayerOneFooType : LayerOneBaseType
    {
        /// <summary>
        /// Initializes a new instance of global::MgmtSafeFlatten.Models.LayerOneFooType
        ///
        /// </summary>
        /// <param name="parameters"> Defines the parameters for the type. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public LayerOneFooType(string parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = LayerOneTypeName.LayerOneFoo;
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtSafeFlatten.Models.LayerOneFooType
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"> Defines the parameters for the type. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal LayerOneFooType(LayerOneTypeName name, string parameters, Dictionary<string, BinaryData> rawData) : base(name, rawData)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="LayerOneFooType"/> for deserialization. </summary>
        internal LayerOneFooType()
        {
        }

        /// <summary> Defines the parameters for the type. </summary>
        public string Parameters { get; set; }
    }
}
