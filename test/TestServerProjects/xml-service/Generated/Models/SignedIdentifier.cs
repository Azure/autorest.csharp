// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> signed identifier. </summary>
    public partial class SignedIdentifier
    {
        /// <summary> Initializes a new instance of SignedIdentifier. </summary>
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

        /// <summary> a unique id. </summary>
        public string Id { get; set; }
        /// <summary> The access policy. </summary>
        public AccessPolicy AccessPolicy { get; set; }
    }
}
