// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace SingleTopLevelClientWithOperations_LowLevel
{
    /// <summary> Client options for TopLevelClientWithOperationClient. </summary>
    public partial class TopLevelClientWithOperationClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2021_10_19;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2021-10-19". </summary>
            V2021_10_19 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of TopLevelClientWithOperationClientOptions. </summary>
        public TopLevelClientWithOperationClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2021_10_19 => "2021-10-19",
                _ => throw new NotSupportedException()
            };
        }
    }
}
