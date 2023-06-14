// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace ServiceVersionOverride
{
    /// <summary> Client options for ServiceVersionOverrideClient. </summary>
    public partial class ServiceVersionOverrideClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2_0_0;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "1.0.1". </summary>
            V1_0_1 = 1,
            /// <summary> Service version "1.2.3". </summary>
            V1_2_3 = 2,
            /// <summary> Service version "2.0.0". </summary>
            V2_0_0 = 3,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of ServiceVersionOverrideClientOptions. </summary>
        public ServiceVersionOverrideClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1_0_1 => "1.0.1",
                ServiceVersion.V1_2_3 => "1.2.3",
                ServiceVersion.V2_0_0 => "2.0.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
