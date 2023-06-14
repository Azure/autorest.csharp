// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    /// <summary> The resource link properties. </summary>
    public partial class ResourceLinkProperties
    {
        /// <summary> Initializes a new instance of ResourceLinkProperties. </summary>
        /// <param name="targetId"> The fully qualified ID of the target resource in the link. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetId"/> is null. </exception>
        public ResourceLinkProperties(string targetId)
        {
            Argument.AssertNotNull(targetId, nameof(targetId));

            TargetId = targetId;
        }

        /// <summary> Initializes a new instance of ResourceLinkProperties. </summary>
        /// <param name="sourceId"> The fully qualified ID of the source resource in the link. </param>
        /// <param name="targetId"> The fully qualified ID of the target resource in the link. </param>
        /// <param name="notes"> Notes about the resource link. </param>
        internal ResourceLinkProperties(string sourceId, string targetId, string notes)
        {
            SourceId = sourceId;
            TargetId = targetId;
            Notes = notes;
        }

        /// <summary> The fully qualified ID of the source resource in the link. </summary>
        public string SourceId { get; }
        /// <summary> The fully qualified ID of the target resource in the link. </summary>
        public string TargetId { get; set; }
        /// <summary> Notes about the resource link. </summary>
        public string Notes { get; set; }
    }
}
