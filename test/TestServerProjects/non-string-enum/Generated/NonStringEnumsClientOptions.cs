// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace non_string_enum
{
    /// <summary> Client options for NonStringEnumsClient. </summary>
    public partial class NonStringEnumsClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2_0_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2.0-preview". </summary>
            V2_0_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of NonStringEnumsClientOptions. </summary>
        public NonStringEnumsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2_0_Preview => "2.0-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
