// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace body_complex_LowLevel
{
    /// <summary> Client options for AutoRestComplexTestService library clients. </summary>
    public partial class AutoRestComplexTestServiceClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2016_02_29;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2016-02-29". </summary>
            V2016_02_29 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of AutoRestComplexTestServiceClientOptions. </summary>
        public AutoRestComplexTestServiceClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2016_02_29 => "2016-02-29",
                _ => throw new NotSupportedException()
            };
        }
    }
}
