// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> Represents the properties of the Dns Resource Reference Request. </summary>
    public partial class DnsResourceReferenceContent
    {
        /// <summary> Initializes a new instance of DnsResourceReferenceContent. </summary>
        public DnsResourceReferenceContent()
        {
            TargetResources = new ChangeTrackingList<WritableSubResource>();
        }

        /// <summary> A list of references to azure resources for which referencing dns records need to be queried. </summary>
        public IList<WritableSubResource> TargetResources { get; }
    }
}
