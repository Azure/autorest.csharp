// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing the ResGrpParent data model.
    /// Specifies information.
    /// </summary>
    public partial class ResGrpParentData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of ResGrpParentData. </summary>
        /// <param name="location"> The location. </param>
        public ResGrpParentData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of ResGrpParentData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="bar"> specifies the bar. </param>
        internal ResGrpParentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string bar) : base(id, name, resourceType, systemData, tags, location)
        {
            Bar = bar;
        }

        /// <summary> specifies the bar. </summary>
        public string Bar { get; set; }
    }
}
