// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Server.Path.Multiple
{
    /// <summary> Client options for MultipleClient. </summary>
    public partial class MultipleClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_0;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "v1.0". </summary>
            V1_0 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of MultipleClientOptions. </summary>
        public MultipleClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1_0 => "v1.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
