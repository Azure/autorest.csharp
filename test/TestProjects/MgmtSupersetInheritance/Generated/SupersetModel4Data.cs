// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSupersetInheritance
{
    /// <summary>
    /// A class representing the SupersetModel4 data model.
    /// This model does not have systemData, but should inherit from TrackedResource.
    /// </summary>
    public partial class SupersetModel4Data : TrackedResourceData
    {
        /// <summary> Initializes a new instance of SupersetModel4Data. </summary>
        /// <param name="location"> The location. </param>
        public SupersetModel4Data(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of SupersetModel4Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="new"></param>
        internal SupersetModel4Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string @new) : base(id, name, resourceType, systemData, tags, location)
        {
            New = @new;
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
