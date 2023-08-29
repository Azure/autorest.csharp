// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> An Access policy. </summary>
    public partial class AccessPolicy
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::xml_service.Models.AccessPolicy
        ///
        /// </summary>
        /// <param name="start"> the date-time the policy is active. </param>
        /// <param name="expiry"> the date-time the policy expires. </param>
        /// <param name="permission"> the permissions for the acl policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="permission"/> is null. </exception>
        public AccessPolicy(DateTimeOffset start, DateTimeOffset expiry, string permission)
        {
            Argument.AssertNotNull(permission, nameof(permission));

            Start = start;
            Expiry = expiry;
            Permission = permission;
        }

        /// <summary>
        /// Initializes a new instance of global::xml_service.Models.AccessPolicy
        ///
        /// </summary>
        /// <param name="start"> the date-time the policy is active. </param>
        /// <param name="expiry"> the date-time the policy expires. </param>
        /// <param name="permission"> the permissions for the acl policy. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal AccessPolicy(DateTimeOffset start, DateTimeOffset expiry, string permission, Dictionary<string, BinaryData> rawData)
        {
            Start = start;
            Expiry = expiry;
            Permission = permission;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="AccessPolicy"/> for deserialization. </summary>
        internal AccessPolicy()
        {
        }

        /// <summary> the date-time the policy is active. </summary>
        public DateTimeOffset Start { get; set; }
        /// <summary> the date-time the policy expires. </summary>
        public DateTimeOffset Expiry { get; set; }
        /// <summary> the permissions for the acl policy. </summary>
        public string Permission { get; set; }
    }
}
