// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.DocumentTranslation
{
    /// <summary> Client options for DocumentTranslationClient. </summary>
    public partial class DocumentTranslationClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_0_Preview_1;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "v1.0-preview.1". </summary>
            V1_0_Preview_1 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of DocumentTranslationClientOptions. </summary>
        public DocumentTranslationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1_0_Preview_1 => "v1.0-preview.1",
                _ => throw new NotSupportedException()
            };
        }
    }
}
