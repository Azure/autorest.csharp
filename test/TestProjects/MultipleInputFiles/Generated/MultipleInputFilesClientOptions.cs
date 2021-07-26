// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace MultipleInputFiles
{
    /// <summary> Client options for MultipleInputFilesClient. </summary>
    public partial class MultipleInputFilesClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V1_0;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "1.0". </summary>
            V1_0 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of MultipleInputFilesClientOptions. </summary>
        public MultipleInputFilesClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1_0 => "1.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
