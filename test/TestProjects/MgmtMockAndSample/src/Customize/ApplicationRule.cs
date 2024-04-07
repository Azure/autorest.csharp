// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Models
{
    [CodeGenSerialization(nameof(NewIntSerializeProperty), "newIntSerializeProperty")]
    [CodeGenSerialization(nameof(NewGeneratedTypeSerializeProperty), "newGeneratedTypeSerializeProperty")]
    public partial class ApplicationRule : FirewallPolicyRule
    {
        /// <summary>
        /// add int? serialize property to ApplicationRule.
        /// </summary>
        public int? NewIntSerializeProperty { get; set; }
        /// <summary>
        /// add generated type serialize property to ApplicationRule.
        /// </summary>
        public VaultKey NewGeneratedTypeSerializeProperty { get; set; }
    }
}
