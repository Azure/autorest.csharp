// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Spread
{
    /// <summary> Client options for SpreadClient. </summary>
    public partial class SpreadClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_01_01_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2022-01-01-preview". </summary>
            V2022_01_01_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of SpreadClientOptions. </summary>
        public SpreadClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2022_01_01_Preview => "2022-01-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
