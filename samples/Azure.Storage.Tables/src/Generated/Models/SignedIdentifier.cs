// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    /// <summary> signed identifier. </summary>
    public partial class SignedIdentifier
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SignedIdentifier"/>. </summary>
        /// <param name="id"> a unique id. </param>
        /// <param name="accessPolicy"> The access policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="accessPolicy"/> is null. </exception>
        public SignedIdentifier(string id, AccessPolicy accessPolicy)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(accessPolicy, nameof(accessPolicy));

            Id = id;
            AccessPolicy = accessPolicy;
        }

        /// <summary> Initializes a new instance of <see cref="SignedIdentifier"/>. </summary>
        /// <param name="id"> a unique id. </param>
        /// <param name="accessPolicy"> The access policy. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SignedIdentifier(string id, AccessPolicy accessPolicy, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            AccessPolicy = accessPolicy;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="SignedIdentifier"/> for deserialization. </summary>
        internal SignedIdentifier()
        {
        }

        /// <summary> a unique id. </summary>
        public string Id { get; set; }
        /// <summary> The access policy. </summary>
        public AccessPolicy AccessPolicy { get; set; }
    }
}
