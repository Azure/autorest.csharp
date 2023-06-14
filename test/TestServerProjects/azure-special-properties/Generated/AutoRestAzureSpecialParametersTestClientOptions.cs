// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace azure_special_properties
{
    /// <summary> Client options for AutoRestAzureSpecialParametersTestClient. </summary>
    public partial class AutoRestAzureSpecialParametersTestClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2015_07_01_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2015-07-01-preview". </summary>
            V2015_07_01_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of AutoRestAzureSpecialParametersTestClientOptions. </summary>
        public AutoRestAzureSpecialParametersTestClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2015_07_01_Preview => "2015-07-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
