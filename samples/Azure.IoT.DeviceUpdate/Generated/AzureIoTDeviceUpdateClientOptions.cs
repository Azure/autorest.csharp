// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.IoT.DeviceUpdate
{
    /// <summary> Client options for AzureIoTDeviceUpdate library clients. </summary>
    public partial class AzureIoTDeviceUpdateClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2021_06_01_preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2021-06-01-preview". </summary>
            V2021_06_01_preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of AzureIoTDeviceUpdateClientOptions. </summary>
        public AzureIoTDeviceUpdateClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2021_06_01_preview => "2021-06-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
