// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CustomNamespace
{
    /// <summary> Client options for SchemaMappingClient. </summary>
    internal partial class MainClientOptions : ClientOptions
    {

        internal string Version { get; }

        /// <summary> Initializes new instance of MainClientOptions. </summary>
        public MainClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V1_0_0 => "1.0.0",
                _ => throw new NotSupportedException()
            };
        }
    }
}
