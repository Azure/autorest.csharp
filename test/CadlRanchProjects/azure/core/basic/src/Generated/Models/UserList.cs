// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace _Specs_.Azure.Core.Basic.Models
{
    /// <summary> The UserList. </summary>
    public partial class UserList
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

        /// <summary> Initializes a new instance of <see cref="UserList"/>. </summary>
        /// <param name="users"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="users"/> is null. </exception>
        internal UserList(IEnumerable<User> users)
        {
            Argument.AssertNotNull(users, nameof(users));

            Users = users.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="UserList"/>. </summary>
        /// <param name="users"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UserList(IReadOnlyList<User> users, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Users = users;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="UserList"/> for deserialization. </summary>
        internal UserList()
        {
        }

        /// <summary> Gets the users. </summary>
        public IReadOnlyList<User> Users { get; }
    }
}
