// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtMockAndSample.Models
{
    /// <summary> The VaultIssue. </summary>
    public partial class VaultIssue
    {
        /// <summary> Initializes a new instance of VaultIssue. </summary>
        internal VaultIssue()
        {
        }

        /// <summary> Initializes a new instance of VaultIssue. </summary>
        /// <param name="vaultIssueType"> The type of the issue. </param>
        /// <param name="description"> The description of the issue. </param>
        /// <param name="sev"> The severity of the issue. </param>
        internal VaultIssue(string vaultIssueType, string description, int? sev)
        {
            VaultIssueType = vaultIssueType;
            Description = description;
            Sev = sev;
        }

        /// <summary> The type of the issue. </summary>
        public string VaultIssueType { get; }
        /// <summary> The description of the issue. </summary>
        public string Description { get; }
        /// <summary> The severity of the issue. </summary>
        public int? Sev { get; }
    }
}
