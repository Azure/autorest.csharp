// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace ParameterSequence_LowLevel
{
    /// <summary> Client options for ParameterSequenceClient. </summary>
    public partial class ParameterSequenceClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2014_04_01_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2014-04-01-preview". </summary>
            V2014_04_01_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of ParameterSequenceClientOptions. </summary>
        public ParameterSequenceClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2014_04_01_Preview => "2014-04-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
