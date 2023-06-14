// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace security_key_LowLevel
{
    /// <summary> Client options for AutorestSecurityKeyClient. </summary>
    public partial class AutorestSecurityKeyClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_03_01_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2022-03-01-preview". </summary>
            V2022_03_01_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of AutorestSecurityKeyClientOptions. </summary>
        public AutorestSecurityKeyClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2022_03_01_Preview => "2022-03-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
