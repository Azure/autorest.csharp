// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MixApiVersion
{
    /// <summary> Client options for MixApiVersionClient. </summary>
    public partial class MixApiVersionClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_11_30_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2022-11-30-preview". </summary>
            V2022_11_30_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of MixApiVersionClientOptions. </summary>
        public MixApiVersionClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2022_11_30_Preview => "2022-11-30-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
