// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtSafeFlatten.Models
{
    /// <summary> The LayerOneFooType. </summary>
    public partial class LayerOneFooType : LayerOneBaseType
    {
        /// <summary> Initializes a new instance of LayerOneFooType. </summary>
        /// <param name="parameters"> Defines the parameters for the type. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public LayerOneFooType(string parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Parameters = parameters;
            Name = LayerOneTypeName.LayerOneFoo;
        }

        /// <summary> Initializes a new instance of LayerOneFooType. </summary>
        /// <param name="name"></param>
        /// <param name="parameters"> Defines the parameters for the type. </param>
        internal LayerOneFooType(LayerOneTypeName name, string parameters) : base(name)
        {
            Parameters = parameters;
            Name = name;
        }

        /// <summary> Defines the parameters for the type. </summary>
        public string Parameters { get; set; }
    }
}
