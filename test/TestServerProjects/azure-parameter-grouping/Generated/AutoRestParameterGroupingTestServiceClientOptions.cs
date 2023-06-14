// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace azure_parameter_grouping
{
    /// <summary> Client options for AutoRestParameterGroupingTestServiceClient. </summary>
    public partial class AutoRestParameterGroupingTestServiceClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_0_0;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "1.0.0". </summary>
            V1_0_0 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of AutoRestParameterGroupingTestServiceClientOptions. </summary>
        public AutoRestParameterGroupingTestServiceClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1_0_0 => "1.0.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
