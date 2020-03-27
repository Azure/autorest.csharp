// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Storage.Management.Models
{
    /// <summary> The LegalHold property of a blob container. </summary>
    public partial class LegalHoldProperties
    {
        /// <summary> Initializes a new instance of LegalHoldProperties. </summary>
        public LegalHoldProperties()
        {
        }

        /// <summary> Initializes a new instance of LegalHoldProperties. </summary>
        /// <param name="hasLegalHold"> The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account. </param>
        /// <param name="tags"> The list of LegalHold tags of a blob container. </param>
        internal LegalHoldProperties(bool? hasLegalHold, IList<TagProperty> tags)
        {
            HasLegalHold = hasLegalHold;
            Tags = tags;
        }

        /// <summary> The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account. </summary>
        public bool? HasLegalHold { get; }
        /// <summary> The list of LegalHold tags of a blob container. </summary>
        public IList<TagProperty> Tags { get; set; }
    }
}
