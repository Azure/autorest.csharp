// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Reference to another subresource. </summary>
    public partial class SubResource
    {
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SubResource"/>. </summary>
        public SubResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SubResource"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SubResource(string id, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            _rawData = rawData;
        }

        /// <summary> Resource ID. </summary>
        public string Id { get; set; }
    }
}
