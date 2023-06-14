// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Specs_.Azure.Core.Traits
{
    /// <summary> Client options for TraitsClient. </summary>
    public partial class TraitsClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_12_01_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2022-12-01-preview". </summary>
            V2022_12_01_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of TraitsClientOptions. </summary>
        public TraitsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2022_12_01_Preview => "2022-12-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
