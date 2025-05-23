// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Scm.Payload.Multipart.Models
{
    /// <summary> The FileWithHttpPartOptionalContentTypeRequest. </summary>
    public partial class FileWithHttpPartOptionalContentTypeRequest
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

        /// <summary> Initializes a new instance of <see cref="FileWithHttpPartOptionalContentTypeRequest"/>. </summary>
        /// <param name="profileImage"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="profileImage"/> is null. </exception>
        public FileWithHttpPartOptionalContentTypeRequest(FileOptionalContentType profileImage)
        {
            Argument.AssertNotNull(profileImage, nameof(profileImage));

            ProfileImage = profileImage;
        }

        /// <summary> Initializes a new instance of <see cref="FileWithHttpPartOptionalContentTypeRequest"/>. </summary>
        /// <param name="profileImage"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FileWithHttpPartOptionalContentTypeRequest(FileOptionalContentType profileImage, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ProfileImage = profileImage;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="FileWithHttpPartOptionalContentTypeRequest"/> for deserialization. </summary>
        internal FileWithHttpPartOptionalContentTypeRequest()
        {
        }

        /// <summary> Gets the profile image. </summary>
        public FileOptionalContentType ProfileImage { get; }
    }
}
