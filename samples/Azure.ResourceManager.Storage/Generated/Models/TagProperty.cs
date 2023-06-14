// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> A tag of the LegalHold of a blob container. </summary>
    public partial class TagProperty
    {
        /// <summary> Initializes a new instance of TagProperty. </summary>
        internal TagProperty()
        {
        }

        /// <summary> Initializes a new instance of TagProperty. </summary>
        /// <param name="tag"> The tag value. </param>
        /// <param name="timestamp"> Returns the date and time the tag was added. </param>
        /// <param name="objectIdentifier"> Returns the Object ID of the user who added the tag. </param>
        /// <param name="tenantId"> Returns the Tenant ID that issued the token for the user who added the tag. </param>
        /// <param name="upn"> Returns the User Principal Name of the user who added the tag. </param>
        internal TagProperty(string tag, DateTimeOffset? timestamp, string objectIdentifier, Guid? tenantId, string upn)
        {
            Tag = tag;
            Timestamp = timestamp;
            ObjectIdentifier = objectIdentifier;
            TenantId = tenantId;
            Upn = upn;
        }

        /// <summary> The tag value. </summary>
        public string Tag { get; }
        /// <summary> Returns the date and time the tag was added. </summary>
        public DateTimeOffset? Timestamp { get; }
        /// <summary> Returns the Object ID of the user who added the tag. </summary>
        public string ObjectIdentifier { get; }
        /// <summary> Returns the Tenant ID that issued the token for the user who added the tag. </summary>
        public Guid? TenantId { get; }
        /// <summary> Returns the User Principal Name of the user who added the tag. </summary>
        public string Upn { get; }
    }
}
