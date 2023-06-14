// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Network.Management.Interface
{
    /// <summary> Client options for AzureNetworkManagementInterfaceClient. </summary>
    public partial class AzureNetworkManagementInterfaceClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2019_11_01;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2019-11-01". </summary>
            V2019_11_01 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of AzureNetworkManagementInterfaceClientOptions. </summary>
        public AzureNetworkManagementInterfaceClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2019_11_01 => "2019-11-01",
                _ => throw new NotSupportedException()
            };
        }
    }
}
