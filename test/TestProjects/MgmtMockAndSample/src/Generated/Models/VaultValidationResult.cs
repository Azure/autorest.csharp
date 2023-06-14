// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> List of keys. </summary>
    public partial class VaultValidationResult
    {
        /// <summary> Initializes a new instance of VaultValidationResult. </summary>
        internal VaultValidationResult()
        {
            Issues = new ChangeTrackingList<VaultIssue>();
        }

        /// <summary> Initializes a new instance of VaultValidationResult. </summary>
        /// <param name="issues"> The list of vaults. </param>
        /// <param name="result"> The result of the validation. </param>
        internal VaultValidationResult(IReadOnlyList<VaultIssue> issues, string result)
        {
            Issues = issues;
            Result = result;
        }

        /// <summary> The list of vaults. </summary>
        public IReadOnlyList<VaultIssue> Issues { get; }
        /// <summary> The result of the validation. </summary>
        public string Result { get; }
    }
}
