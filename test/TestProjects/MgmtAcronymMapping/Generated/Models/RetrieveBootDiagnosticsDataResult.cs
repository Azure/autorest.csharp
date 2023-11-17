// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// The SAS URIs of the console screenshot and serial log blobs.
    /// Serialized Name: RetrieveBootDiagnosticsDataResult
    /// </summary>
    public partial class RetrieveBootDiagnosticsDataResult
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

        /// <summary> Initializes a new instance of <see cref="RetrieveBootDiagnosticsDataResult"/>. </summary>
        internal RetrieveBootDiagnosticsDataResult()
        {
        }

        /// <summary> Initializes a new instance of <see cref="RetrieveBootDiagnosticsDataResult"/>. </summary>
        /// <param name="consoleScreenshotBlobUri">
        /// The console screenshot blob URI
        /// Serialized Name: RetrieveBootDiagnosticsDataResult.consoleScreenshotBlobUri
        /// </param>
        /// <param name="serialConsoleLogBlobUri">
        /// The serial console log blob URI.
        /// Serialized Name: RetrieveBootDiagnosticsDataResult.serialConsoleLogBlobUri
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal RetrieveBootDiagnosticsDataResult(Uri consoleScreenshotBlobUri, Uri serialConsoleLogBlobUri, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ConsoleScreenshotBlobUri = consoleScreenshotBlobUri;
            SerialConsoleLogBlobUri = serialConsoleLogBlobUri;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The console screenshot blob URI
        /// Serialized Name: RetrieveBootDiagnosticsDataResult.consoleScreenshotBlobUri
        /// </summary>
        public Uri ConsoleScreenshotBlobUri { get; }
        /// <summary>
        /// The serial console log blob URI.
        /// Serialized Name: RetrieveBootDiagnosticsDataResult.serialConsoleLogBlobUri
        /// </summary>
        public Uri SerialConsoleLogBlobUri { get; }
    }
}
