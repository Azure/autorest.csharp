// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.Storage.Management
{
    /// <summary> Client options for Storage. </summary>
    public class StorageManagementClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2019_06_01;
        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2019-06-01". </summary>
            V2019_06_01 = 1,
        }
        internal string Version { get; }
        /// <summary> Initializes new instance of StorageManagementClientOptions. </summary>
        public StorageManagementClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2019_06_01 => "2019-06-01",
                _ => throw new NotSupportedException()
            };
        }
    }
}
