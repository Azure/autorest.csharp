// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Specs_.Azure.Core.Basic.Models
{
    /// <summary> Details about a user. </summary>
    public partial class User
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

        /// <summary> Initializes a new instance of <see cref="User"/>. </summary>
        /// <param name="name"> The user's name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public User(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Orders = new ChangeTrackingList<UserOrder>();
        }

        /// <summary> Initializes a new instance of <see cref="User"/>. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="name"> The user's name. </param>
        /// <param name="orders"> The user's order list. </param>
        /// <param name="etag"> The entity tag for this resource. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal User(int id, string name, IList<UserOrder> orders, string etag, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Name = name;
            Orders = orders;
            Etag = etag;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="User"/> for deserialization. </summary>
        internal User()
        {
        }

        /// <summary> The user's id. </summary>
        public int Id { get; }
        /// <summary> The user's name. </summary>
        public string Name { get; set; }
        /// <summary> The user's order list. </summary>
        public IList<UserOrder> Orders { get; }
        /// <summary> The entity tag for this resource. </summary>
        public string Etag { get; }
    }
}
