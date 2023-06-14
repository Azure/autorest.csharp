// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtExactMatchInheritance
{
    /// <summary> A class representing the ExactMatchModel5 data model. </summary>
    public partial class ExactMatchModel5Data : TrackedResourceData
    {
        /// <summary> Initializes a new instance of ExactMatchModel5Data. </summary>
        /// <param name="location"> The location. </param>
        public ExactMatchModel5Data(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel5Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="new"></param>
        internal ExactMatchModel5Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string @new) : base(id, name, resourceType, systemData, tags, location)
        {
            New = @new;
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
