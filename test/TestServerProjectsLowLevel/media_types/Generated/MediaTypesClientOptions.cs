// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace media_types_LowLevel
{
    /// <summary> Client options for MediaTypesClient. </summary>
    public partial class MediaTypesClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2_0_preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2.0-preview". </summary>
            V2_0_preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of MediaTypesClientOptions. </summary>
        public MediaTypesClientOptions(ServiceVersion version = LatestVersion)
        {
            Diagnostics.SuppressNestedClientSpans = true;
            Version = version switch
            {
                ServiceVersion.V2_0_preview => "2.0-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
