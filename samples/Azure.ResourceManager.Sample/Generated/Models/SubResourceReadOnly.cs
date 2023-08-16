// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The SubResourceReadOnly.
    /// Serialized Name: SubResourceReadOnly
    /// </summary>
    public partial class SubResourceReadOnly
    {
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.SubResourceReadOnly
        ///
        /// </summary>
        public SubResourceReadOnly()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.SubResourceReadOnly
        ///
        /// </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResourceReadOnly.id
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SubResourceReadOnly(string id, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            _rawData = rawData;
        }

        /// <summary>
        /// Resource Id
        /// Serialized Name: SubResourceReadOnly.id
        /// </summary>
        public string Id { get; }
    }
}
