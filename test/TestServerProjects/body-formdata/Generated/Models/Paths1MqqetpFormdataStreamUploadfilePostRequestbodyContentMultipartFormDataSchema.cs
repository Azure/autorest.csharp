// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using body_formdata;

namespace body_formdata.Models
{
    /// <summary> The Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema. </summary>
    internal partial class Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema
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

        /// <summary> Initializes a new instance of <see cref="Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema"/>. </summary>
        /// <param name="fileContent"> File to upload. </param>
        /// <param name="fileName"> File name to upload. Name has to be spelled exactly as written here. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileContent"/> or <paramref name="fileName"/> is null. </exception>
        internal Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema(Stream fileContent, string fileName)
        {
            Argument.AssertNotNull(fileContent, nameof(fileContent));
            Argument.AssertNotNull(fileName, nameof(fileName));

            FileContent = fileContent;
            FileName = fileName;
        }

        /// <summary> Initializes a new instance of <see cref="Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema"/>. </summary>
        /// <param name="fileContent"> File to upload. </param>
        /// <param name="fileName"> File name to upload. Name has to be spelled exactly as written here. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema(Stream fileContent, string fileName, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            FileContent = fileContent;
            FileName = fileName;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema"/> for deserialization. </summary>
        internal Paths1MqqetpFormdataStreamUploadfilePostRequestbodyContentMultipartFormDataSchema()
        {
        }

        /// <summary> File to upload. </summary>
        public Stream FileContent { get; }
        /// <summary> File name to upload. Name has to be spelled exactly as written here. </summary>
        public string FileName { get; }
    }
}
