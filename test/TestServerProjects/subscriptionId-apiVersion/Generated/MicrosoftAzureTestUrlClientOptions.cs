// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace subscriptionId_apiVersion
{
    /// <summary> Client options for MicrosoftAzureTestUrlClient. </summary>
    public partial class MicrosoftAzureTestUrlClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2014_04_01_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2014-04-01-preview". </summary>
            V2014_04_01_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of MicrosoftAzureTestUrlClientOptions. </summary>
        public MicrosoftAzureTestUrlClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2014_04_01_Preview => "2014-04-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
