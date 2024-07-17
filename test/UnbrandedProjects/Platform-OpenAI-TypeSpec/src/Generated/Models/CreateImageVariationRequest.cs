// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

namespace OpenAI.Models
{
    /// <summary> The CreateImageVariationRequest. </summary>
    public partial class CreateImageVariationRequest
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
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        /// <summary> Initializes a new instance of <see cref="CreateImageVariationRequest"/>. </summary>
        /// <param name="image">
        /// The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB,
        /// and square.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="image"/> is null. </exception>
        public CreateImageVariationRequest(Stream image)
        {
            Argument.AssertNotNull(image, nameof(image));

            Image = image;
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="CreateImageVariationRequest"/>. </summary>
        /// <param name="image">
        /// The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB,
        /// and square.
        /// </param>
        /// <param name="n"> The number of images to generate. Must be between 1 and 10. </param>
        /// <param name="size"> The size of the generated images. Must be one of `256x256`, `512x512`, or `1024x1024`. </param>
        /// <param name="responseFormat"> The format in which the generated images are returned. Must be one of `url` or `b64_json`. </param>
        /// <param name="user"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateImageVariationRequest(Stream image, long? n, CreateImageRequestSize? size, CreateImageRequestResponseFormat? responseFormat, string user, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Image = image;
            N = n;
            Size = size;
            ResponseFormat = responseFormat;
            User = user;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateImageVariationRequest"/> for deserialization. </summary>
        internal CreateImageVariationRequest()
        {
        }

        /// <summary>
        /// The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB,
        /// and square.
        /// </summary>
        public Stream Image { get; }
        /// <summary> The number of images to generate. Must be between 1 and 10. </summary>
        public long? N { get; set; }
        /// <summary> The size of the generated images. Must be one of `256x256`, `512x512`, or `1024x1024`. </summary>
        public CreateImageRequestSize? Size { get; set; }
        /// <summary> The format in which the generated images are returned. Must be one of `url` or `b64_json`. </summary>
        public CreateImageRequestResponseFormat? ResponseFormat { get; set; }
        /// <summary> Gets or sets the user. </summary>
        public string User { get; set; }
    }
}
