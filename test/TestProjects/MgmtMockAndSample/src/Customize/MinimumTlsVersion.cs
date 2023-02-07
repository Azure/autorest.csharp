// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    // customize the enum entries to keep the underscore
    public readonly partial struct MinimumTlsVersion
    {
        /// <summary> TLS1_0. </summary>
        [CodeGenMember("TLS10")]
        public static MinimumTlsVersion Tls1_0 { get; } = new MinimumTlsVersion(Tls1_0Value);
        /// <summary> TLS1_1. </summary>
        [CodeGenMember("TLS11")]
        public static MinimumTlsVersion Tls1_1 { get; } = new MinimumTlsVersion(Tls1_1Value);
        /// <summary> TLS1_2. </summary>
        [CodeGenMember("TLS12")]
        public static MinimumTlsVersion Tls1_2 { get; } = new MinimumTlsVersion(Tls1_2Value);
    }
}
