// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch
{
    /// <summary> Client options for CognitiveServicesClient. </summary>
    public partial class CognitiveServicesClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2019_05_06_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2019-05-06-Preview". </summary>
            V2019_05_06_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of CognitiveServicesClientOptions. </summary>
        public CognitiveServicesClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2019_05_06_Preview => "2019-05-06-Preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
