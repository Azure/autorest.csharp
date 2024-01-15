// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Payload.MultiPart.Models
{
    /// <summary> The ComplexPartsRequest. </summary>
    public partial class ComplexPartsRequest
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

        /// <summary> Initializes a new instance of <see cref="ComplexPartsRequest"/>. </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <param name="profileImage"></param>
        /// <param name="previousAddresses"></param>
        /// <param name="pictures"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="address"/>, <paramref name="profileImage"/>, <paramref name="previousAddresses"/> or <paramref name="pictures"/> is null. </exception>
        public ComplexPartsRequest(string id, Address address, BinaryData profileImage, IEnumerable<Address> previousAddresses, IEnumerable<BinaryData> pictures)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(address, nameof(address));
            Argument.AssertNotNull(profileImage, nameof(profileImage));
            Argument.AssertNotNull(previousAddresses, nameof(previousAddresses));
            Argument.AssertNotNull(pictures, nameof(pictures));

            Id = id;
            Address = address;
            ProfileImage = profileImage;
            PreviousAddresses = previousAddresses.ToList();
            Pictures = pictures.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ComplexPartsRequest"/>. </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <param name="profileImage"></param>
        /// <param name="previousAddresses"></param>
        /// <param name="pictures"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ComplexPartsRequest(string id, Address address, BinaryData profileImage, IList<Address> previousAddresses, IList<BinaryData> pictures, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Address = address;
            ProfileImage = profileImage;
            PreviousAddresses = previousAddresses;
            Pictures = pictures;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ComplexPartsRequest"/> for deserialization. </summary>
        internal ComplexPartsRequest()
        {
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
        /// <summary> Gets the address. </summary>
        public Address Address { get; }
        /// <summary>
        /// Gets the profile image
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData ProfileImage { get; }
        /// <summary> Gets the previous addresses. </summary>
        public IList<Address> PreviousAddresses { get; }
        /// <summary>
        /// Gets the pictures
        /// <para>
        /// To assign a byte[] to the element of this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public IList<BinaryData> Pictures { get; }
    }
}
