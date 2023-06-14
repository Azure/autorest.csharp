// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace ApiVersionInCadl
{
    /// <summary> Client options for ApiVersionInCadlClient. </summary>
    public partial class ApiVersionInCadlClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_2;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "v1.1". </summary>
            V1_1 = 1,
            /// <summary> Service version "v1.2". </summary>
            V1_2 = 2,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of ApiVersionInCadlClientOptions. </summary>
        public ApiVersionInCadlClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1_1 => "v1.1",
                ServiceVersion.V1_2 => "v1.2",
                _ => throw new NotSupportedException()
            };
        }
    }
}
