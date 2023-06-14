// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace xms_error_responses
{
    /// <summary> Client options for XMSErrorResponseExtensionsClient. </summary>
    public partial class XMSErrorResponseExtensionsClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V0_0_0;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "0.0.0". </summary>
            V0_0_0 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of XMSErrorResponseExtensionsClientOptions. </summary>
        public XMSErrorResponseExtensionsClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V0_0_0 => "0.0.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
