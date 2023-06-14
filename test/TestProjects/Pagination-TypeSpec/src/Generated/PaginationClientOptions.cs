// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Pagination
{
    /// <summary> Client options for PaginationClient. </summary>
    public partial class PaginationClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_05_13;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2022-05-13". </summary>
            V2022_05_13 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of PaginationClientOptions. </summary>
        public PaginationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2022_05_13 => "2022-05-13",
                _ => throw new NotSupportedException()
            };
        }
    }
}
