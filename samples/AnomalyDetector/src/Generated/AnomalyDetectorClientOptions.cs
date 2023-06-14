// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace AnomalyDetector
{
    /// <summary> Client options for AnomalyDetectorClient. </summary>
    public partial class AnomalyDetectorClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_1;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "v1.1". </summary>
            V1_1 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of AnomalyDetectorClientOptions. </summary>
        public AnomalyDetectorClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1_1 => "v1.1",
                _ => throw new NotSupportedException()
            };
        }
    }
}
