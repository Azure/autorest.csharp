// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace BodyAndPath_LowLevel
{
    /// <summary> Client options for BodyAndPathClient. </summary>
    public partial class BodyAndPathClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2014_04_01_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2014-04-01-preview". </summary>
            V2014_04_01_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of BodyAndPathClientOptions. </summary>
        public BodyAndPathClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2014_04_01_Preview => "2014-04-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
