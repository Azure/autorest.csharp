// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Actions are applied to the filtered blobs when the execution condition is met. </summary>
    public partial class ManagementPolicyAction
    {
        /// <summary> Initializes a new instance of ManagementPolicyAction. </summary>
        public ManagementPolicyAction()
        {
        }

        /// <summary> Initializes a new instance of ManagementPolicyAction. </summary>
        /// <param name="baseBlob"> The management policy action for base blob. </param>
        /// <param name="snapshot"> The management policy action for snapshot. </param>
        /// <param name="version"> The management policy action for version. </param>
        internal ManagementPolicyAction(ManagementPolicyBaseBlob baseBlob, ManagementPolicySnapShot snapshot, ManagementPolicyVersion version)
        {
            BaseBlob = baseBlob;
            Snapshot = snapshot;
            Version = version;
        }

        /// <summary> The management policy action for base blob. </summary>
        public ManagementPolicyBaseBlob BaseBlob { get; set; }
        /// <summary> The management policy action for snapshot. </summary>
        public ManagementPolicySnapShot Snapshot { get; set; }
        /// <summary> The management policy action for version. </summary>
        public ManagementPolicyVersion Version { get; set; }
    }
}
