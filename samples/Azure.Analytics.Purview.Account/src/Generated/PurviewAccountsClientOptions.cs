// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Analytics.Purview.Account
{
    /// <summary> Client options for PurviewAccountsClient. </summary>
    public partial class PurviewAccountsClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2019_11_01_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2019-11-01-preview". </summary>
            V2019_11_01_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of PurviewAccountsClientOptions. </summary>
        public PurviewAccountsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2019_11_01_Preview => "2019-11-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
