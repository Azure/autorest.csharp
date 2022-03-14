// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    /// <summary> The LegalHold property of a blob container. </summary>
    public partial class LegalHoldProperties
    {
        /// <summary> Initializes a new instance of LegalHoldProperties. </summary>
        internal LegalHoldProperties()
        {
            Tags = new ChangeTrackingList<TagProperty>();
        }

        /// <summary> Initializes a new instance of LegalHoldProperties. </summary>
        /// <param name="hasLegalHold"> The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account. </param>
        /// <param name="tags"> The list of LegalHold tags of a blob container. </param>
        /// <param name="protectedAppendWritesHistory"> Protected append blob writes history. </param>
        internal LegalHoldProperties(bool? hasLegalHold, IReadOnlyList<TagProperty> tags, ProtectedAppendWritesHistory protectedAppendWritesHistory)
        {
            HasLegalHold = hasLegalHold;
            Tags = tags;
            ProtectedAppendWritesHistory = protectedAppendWritesHistory;
        }

        /// <summary> The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account. </summary>
        public bool? HasLegalHold { get; }
        /// <summary> The list of LegalHold tags of a blob container. </summary>
        public IReadOnlyList<TagProperty> Tags { get; }
        /// <summary> Protected append blob writes history. </summary>
        public ProtectedAppendWritesHistory ProtectedAppendWritesHistory { get; }
    }
}
