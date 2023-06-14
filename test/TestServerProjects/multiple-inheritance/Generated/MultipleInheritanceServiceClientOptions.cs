// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace multiple_inheritance
{
    /// <summary> Client options for MultipleInheritanceServiceClient. </summary>
    public partial class MultipleInheritanceServiceClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V3_0_0;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "3.0.0". </summary>
            V3_0_0 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of MultipleInheritanceServiceClientOptions. </summary>
        public MultipleInheritanceServiceClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V3_0_0 => "3.0.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
