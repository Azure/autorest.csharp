// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Authentication.ApiKey
{
    /// <summary> Client options for ApiKeyClient. </summary>
    public partial class ApiKeyClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_0_0;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "1.0.0". </summary>
            V1_0_0 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of ApiKeyClientOptions. </summary>
        public ApiKeyClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1_0_0 => "1.0.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
