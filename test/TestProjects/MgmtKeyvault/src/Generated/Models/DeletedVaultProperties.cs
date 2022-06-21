// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtKeyvault.Models
{
    /// <summary> Properties of the deleted vault. </summary>
    public partial class DeletedVaultProperties
    {
        /// <summary> Initializes a new instance of DeletedVaultProperties. </summary>
        internal DeletedVaultProperties()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of DeletedVaultProperties. </summary>
        /// <param name="vaultId"> The resource id of the original vault. </param>
        /// <param name="location"> The location of the original vault. </param>
        /// <param name="deletionOn"> The deleted date. </param>
        /// <param name="scheduledPurgeOn"> The scheduled purged date. </param>
        /// <param name="tags"> Tags of the original vault. </param>
        /// <param name="purgeProtectionEnabled"> Purge protection status of the original vault. </param>
        internal DeletedVaultProperties(string vaultId, AzureLocation? location, DateTimeOffset? deletionOn, DateTimeOffset? scheduledPurgeOn, IReadOnlyDictionary<string, string> tags, bool? purgeProtectionEnabled)
        {
            VaultId = vaultId;
            Location = location;
            DeletionOn = deletionOn;
            ScheduledPurgeOn = scheduledPurgeOn;
            Tags = tags;
            PurgeProtectionEnabled = purgeProtectionEnabled;
        }

        /// <summary> The resource id of the original vault. </summary>
        public string VaultId { get; }
        /// <summary> The location of the original vault. </summary>
        public AzureLocation? Location { get; }
        /// <summary> The deleted date. </summary>
        public DateTimeOffset? DeletionOn { get; }
        /// <summary> The scheduled purged date. </summary>
        public DateTimeOffset? ScheduledPurgeOn { get; }
        /// <summary> Tags of the original vault. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
        /// <summary> Purge protection status of the original vault. </summary>
        public bool? PurgeProtectionEnabled { get; }
    }
}
