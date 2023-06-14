// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace extensible_enums_swagger
{
    /// <summary> Client options for PetStoreIncClient. </summary>
    public partial class PetStoreIncClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2016_07_07;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2016-07-07". </summary>
            V2016_07_07 = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of PetStoreIncClientOptions. </summary>
        public PetStoreIncClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2016_07_07 => "2016-07-07",
                _ => throw new NotSupportedException()
            };
        }
    }
}
