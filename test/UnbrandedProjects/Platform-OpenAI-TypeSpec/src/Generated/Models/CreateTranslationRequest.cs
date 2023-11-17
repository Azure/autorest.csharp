// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net.ClientModel.Internal;

namespace OpenAI.Models
{
    /// <summary> The CreateTranslationRequest. </summary>
    public partial class CreateTranslationRequest
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

        /// <summary> Initializes a new instance of <see cref="CreateTranslationRequest"/>. </summary>
        /// <param name="file">
        /// The audio file object (not file name) to translate, in one of these formats: flac, mp3, mp4,
        /// mpeg, mpga, m4a, ogg, wav, or webm.
        /// </param>
        /// <param name="model"> ID of the model to use. Only `whisper-1` is currently available. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
        public CreateTranslationRequest(BinaryData file, CreateTranslationRequestModel model)
        {
            ClientUtilities.AssertNotNull(file, nameof(file));

            File = file;
            Model = model;
            _serializedAdditionalRawData = new OptionalDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="CreateTranslationRequest"/>. </summary>
        /// <param name="file">
        /// The audio file object (not file name) to translate, in one of these formats: flac, mp3, mp4,
        /// mpeg, mpga, m4a, ogg, wav, or webm.
        /// </param>
        /// <param name="model"> ID of the model to use. Only `whisper-1` is currently available. </param>
        /// <param name="prompt">
        /// An optional text to guide the model's style or continue a previous audio segment. The
        /// [prompt](/docs/guides/speech-to-text/prompting) should match the audio language.
        /// </param>
        /// <param name="responseFormat">
        /// The format of the transcript output, in one of these options: json, text, srt, verbose_json, or
        /// vtt.
        /// </param>
        /// <param name="temperature">
        /// The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more
        /// random, while lower values like 0.2 will make it more focused and deterministic. If set to 0,
        /// the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to
        /// automatically increase the temperature until certain thresholds are hit.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateTranslationRequest(BinaryData file, CreateTranslationRequestModel model, string prompt, CreateTranslationRequestResponseFormat? responseFormat, double? temperature, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            File = file;
            Model = model;
            Prompt = prompt;
            ResponseFormat = responseFormat;
            Temperature = temperature;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateTranslationRequest"/> for deserialization. </summary>
        internal CreateTranslationRequest()
        {
        }

        /// <summary>
        /// The audio file object (not file name) to translate, in one of these formats: flac, mp3, mp4,
        /// mpeg, mpga, m4a, ogg, wav, or webm.
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
        public BinaryData File { get; }
        /// <summary> ID of the model to use. Only `whisper-1` is currently available. </summary>
        public CreateTranslationRequestModel Model { get; }
        /// <summary>
        /// An optional text to guide the model's style or continue a previous audio segment. The
        /// [prompt](/docs/guides/speech-to-text/prompting) should match the audio language.
        /// </summary>
        public string Prompt { get; set; }
        /// <summary>
        /// The format of the transcript output, in one of these options: json, text, srt, verbose_json, or
        /// vtt.
        /// </summary>
        public CreateTranslationRequestResponseFormat? ResponseFormat { get; set; }
        /// <summary>
        /// The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more
        /// random, while lower values like 0.2 will make it more focused and deterministic. If set to 0,
        /// the model will use [log probability](https://en.wikipedia.org/wiki/Log_probability) to
        /// automatically increase the temperature until certain thresholds are hit.
        /// </summary>
        public double? Temperature { get; set; }
    }
}
