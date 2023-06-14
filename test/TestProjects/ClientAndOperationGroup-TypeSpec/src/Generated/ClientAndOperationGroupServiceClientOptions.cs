// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ClientAndOperationGroupService
{
    /// <summary> Client options for ClientAndOperationGroupServiceClient. </summary>
    public partial class ClientAndOperationGroupServiceClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2015_06_18;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2015-06-18". </summary>
            V2015_06_18 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of ClientAndOperationGroupServiceClientOptions. </summary>
        public ClientAndOperationGroupServiceClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2015_06_18 => "2015-06-18",
                _ => throw new NotSupportedException()
            };
        }
    }
}
