// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Internal;
using System.Collections.Generic;
using System.Linq;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The List Image operation response.
    /// Serialized Name: ImageListResult
    /// </summary>
    internal partial class ImageListResult
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

        /// <summary> Initializes a new instance of <see cref="ImageListResult"/>. </summary>
        /// <param name="images">
        /// The list of Images.
        /// Serialized Name: ImageListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="images"/> is null. </exception>
        internal ImageListResult(IEnumerable<ImageData> images)
        {
            ClientUtilities.AssertNotNull(images, nameof(images));

            Images = images.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ImageListResult"/>. </summary>
        /// <param name="images">
        /// The list of Images.
        /// Serialized Name: ImageListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of Images. Call ListNext() with this to fetch the next page of Images.
        /// Serialized Name: ImageListResult.nextLink
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ImageListResult(IReadOnlyList<ImageData> images, string nextLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Images = images;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ImageListResult"/> for deserialization. </summary>
        internal ImageListResult()
        {
        }

        /// <summary>
        /// The list of Images.
        /// Serialized Name: ImageListResult.value
        /// </summary>
        public IReadOnlyList<ImageData> Images { get; }
        /// <summary>
        /// The uri to fetch the next page of Images. Call ListNext() with this to fetch the next page of Images.
        /// Serialized Name: ImageListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
