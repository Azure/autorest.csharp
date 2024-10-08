// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace TypeSpec.Versioning.Specific
{
    /// <summary> Client options for SpecificClient. </summary>
    public partial class SpecificClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_09_01;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2022-09-01". </summary>
            V2022_09_01 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of SpecificClientOptions. </summary>
        public SpecificClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2022_09_01 => "2022-09-01",
                _ => throw new NotSupportedException()
            };
        }
    }
}
