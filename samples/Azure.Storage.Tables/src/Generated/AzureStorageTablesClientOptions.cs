// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Storage.Tables
{
    /// <summary> Client options for AzureStorageTablesClient. </summary>
    public partial class AzureStorageTablesClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2018_10_10;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2018-10-10". </summary>
            V2018_10_10 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of AzureStorageTablesClientOptions. </summary>
        public AzureStorageTablesClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2018_10_10 => "2018-10-10",
                _ => throw new NotSupportedException()
            };
        }
    }
}
