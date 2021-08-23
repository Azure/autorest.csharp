// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace MgmtContextualPath.Models
{
    /// <summary> Specifies information. </summary>
    public partial class ResGrpParentWithNonResCh : TrackedResource
    {
        /// <summary> Initializes a new instance of ResGrpParentWithNonResCh. </summary>
        /// <param name="location"> The location. </param>
        public ResGrpParentWithNonResCh(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of ResGrpParentWithNonResCh. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="location"> The location. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="bar"> specifies the bar. </param>
        internal ResGrpParentWithNonResCh(ResourceIdentifier id, string name, ResourceType type, Location location, IDictionary<string, string> tags, string bar) : base(id, name, type, location, tags)
        {
            Bar = bar;
        }

        /// <summary> specifies the bar. </summary>
        public string Bar { get; set; }
    }
}
