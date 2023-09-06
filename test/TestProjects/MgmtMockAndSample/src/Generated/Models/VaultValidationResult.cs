// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> List of keys. </summary>
    public partial class VaultValidationResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="VaultValidationResult"/>. </summary>
        internal VaultValidationResult()
        {
            Issues = new ChangeTrackingList<VaultIssue>();
        }

        /// <summary> Initializes a new instance of <see cref="VaultValidationResult"/>. </summary>
        /// <param name="issues"> The list of vaults. </param>
        /// <param name="result"> The result of the validation. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VaultValidationResult(IReadOnlyList<VaultIssue> issues, string result, Dictionary<string, BinaryData> rawData)
        {
            Issues = issues;
            Result = result;
            _rawData = rawData;
        }

        /// <summary> The list of vaults. </summary>
        public IReadOnlyList<VaultIssue> Issues { get; }
        /// <summary> The result of the validation. </summary>
        public string Result { get; }
    }
}
