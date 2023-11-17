// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    /// <summary> An Access policy. </summary>
    public partial class AccessPolicy
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="AccessPolicy"/>. </summary>
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

        /// <summary> Initializes a new instance of <see cref="AccessPolicy"/>. </summary>
        /// <param name="start"> the date-time the policy is active. </param>
        /// <param name="expiry"> the date-time the policy expires. </param>
        /// <param name="permission"> the permissions for the acl policy. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AccessPolicy(DateTimeOffset start, DateTimeOffset expiry, string permission, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Start = start;
            Expiry = expiry;
            Permission = permission;
            _serializedAdditionalRawData = serializedAdditionalRawData;
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
