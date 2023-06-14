// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The SAS URIs of the console screenshot and serial log blobs.
    /// Serialized Name: RetrieveBootDiagnosticsDataResult
    /// </summary>
    public partial class RetrieveBootDiagnosticsDataResult
    {
        /// <summary> Initializes a new instance of RetrieveBootDiagnosticsDataResult. </summary>
        internal RetrieveBootDiagnosticsDataResult()
        {
        }

        /// <summary> Initializes a new instance of RetrieveBootDiagnosticsDataResult. </summary>
        /// <param name="consoleScreenshotBlobUri">
        /// The console screenshot blob URI
        /// Serialized Name: RetrieveBootDiagnosticsDataResult.consoleScreenshotBlobUri
        /// </param>
        /// <param name="serialConsoleLogBlobUri">
        /// The serial console log blob URI.
        /// Serialized Name: RetrieveBootDiagnosticsDataResult.serialConsoleLogBlobUri
        /// </param>
        internal RetrieveBootDiagnosticsDataResult(Uri consoleScreenshotBlobUri, Uri serialConsoleLogBlobUri)
        {
            ConsoleScreenshotBlobUri = consoleScreenshotBlobUri;
            SerialConsoleLogBlobUri = serialConsoleLogBlobUri;
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
