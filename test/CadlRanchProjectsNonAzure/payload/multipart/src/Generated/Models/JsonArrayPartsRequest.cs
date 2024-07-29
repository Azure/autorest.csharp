// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

namespace Payload.MultiPart.Models
{
    /// <summary> The JsonArrayPartsRequest. </summary>
    public partial class JsonArrayPartsRequest
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

        /// <summary> Initializes a new instance of <see cref="JsonArrayPartsRequest"/>. </summary>
        /// <param name="profileImage"></param>
        /// <param name="previousAddresses"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="profileImage"/> or <paramref name="previousAddresses"/> is null. </exception>
        public JsonArrayPartsRequest(Stream profileImage, Address previousAddresses)
        {
            Argument.AssertNotNull(profileImage, nameof(profileImage));
            Argument.AssertNotNull(previousAddresses, nameof(previousAddresses));

            ProfileImage = profileImage;
            PreviousAddresses = previousAddresses;
        }

        /// <summary> Initializes a new instance of <see cref="JsonArrayPartsRequest"/>. </summary>
        /// <param name="profileImage"></param>
        /// <param name="previousAddresses"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal JsonArrayPartsRequest(Stream profileImage, Address previousAddresses, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ProfileImage = profileImage;
            PreviousAddresses = previousAddresses;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="JsonArrayPartsRequest"/> for deserialization. </summary>
        internal JsonArrayPartsRequest()
        {
        }

        /// <summary> Gets the profile image. </summary>
        public Stream ProfileImage { get; }
        /// <summary> Gets the previous addresses. </summary>
        public Address PreviousAddresses { get; }
    }
}
