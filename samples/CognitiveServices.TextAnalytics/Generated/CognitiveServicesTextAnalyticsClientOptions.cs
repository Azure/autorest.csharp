// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveServices.TextAnalytics
{
    /// <summary> Client options for CognitiveServicesTextAnalyticsClient. </summary>
    public partial class CognitiveServicesTextAnalyticsClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V3_0;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "v3.0". </summary>
            V3_0 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of CognitiveServicesTextAnalyticsClientOptions. </summary>
        public CognitiveServicesTextAnalyticsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V3_0 => "v3.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
