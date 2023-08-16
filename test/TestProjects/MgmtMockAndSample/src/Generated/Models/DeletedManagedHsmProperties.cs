// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Properties of the deleted managed HSM. </summary>
    public partial class DeletedManagedHsmProperties
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.Models.DeletedManagedHsmProperties
        ///
        /// </summary>
        internal DeletedManagedHsmProperties()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.Models.DeletedManagedHsmProperties
        ///
        /// </summary>
        /// <param name="mhsmId"> The resource id of the original managed HSM. </param>
        /// <param name="location"> The location of the original managed HSM. </param>
        /// <param name="deletedOn"> The deleted date. </param>
        /// <param name="scheduledPurgeOn"> The scheduled purged date. </param>
        /// <param name="purgeProtectionEnabled"> Purge protection status of the original managed HSM. </param>
        /// <param name="tags"> Tags of the original managed HSM. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DeletedManagedHsmProperties(string mhsmId, AzureLocation? location, DateTimeOffset? deletedOn, DateTimeOffset? scheduledPurgeOn, bool? purgeProtectionEnabled, IReadOnlyDictionary<string, string> tags, Dictionary<string, BinaryData> rawData)
        {
            MhsmId = mhsmId;
            Location = location;
            DeletedOn = deletedOn;
            ScheduledPurgeOn = scheduledPurgeOn;
            PurgeProtectionEnabled = purgeProtectionEnabled;
            Tags = tags;
            _rawData = rawData;
        }

        /// <summary> The resource id of the original managed HSM. </summary>
        public string MhsmId { get; }
        /// <summary> The location of the original managed HSM. </summary>
        public AzureLocation? Location { get; }
        /// <summary> The deleted date. </summary>
        public DateTimeOffset? DeletedOn { get; }
        /// <summary> The scheduled purged date. </summary>
        public DateTimeOffset? ScheduledPurgeOn { get; }
        /// <summary> Purge protection status of the original managed HSM. </summary>
        public bool? PurgeProtectionEnabled { get; }
        /// <summary> Tags of the original managed HSM. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
