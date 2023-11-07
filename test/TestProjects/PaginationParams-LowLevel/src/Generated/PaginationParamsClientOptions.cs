// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace PaginationParams_LowLevel
{
    /// <summary> Client options for PaginationParamsClient. </summary>
    public partial class PaginationParamsClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2020_06_01;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2020-06-01". </summary>
            V2020_06_01 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of PaginationParamsClientOptions. </summary>
        public PaginationParamsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2020_06_01 => "2020-06-01",
                _ => throw new NotSupportedException()
            };
        }

        /// <summary> server parameter. </summary>
        public Uri Endpoint { get; set; }
    }
}
