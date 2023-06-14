// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtExactMatchInheritance.Models
{
    /// <summary> The ExactMatchModel10. </summary>
    public partial class ExactMatchModel10 : ResourceData
    {
        /// <summary> Initializes a new instance of ExactMatchModel10. </summary>
        public ExactMatchModel10()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of ExactMatchModel10. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"></param>
        /// <param name="tags"> Dictionary of &lt;string&gt;. </param>
        internal ExactMatchModel10(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation? location, IDictionary<string, string> tags) : base(id, name, resourceType, systemData)
        {
            Location = location;
            Tags = tags;
        }

        /// <summary> Gets or sets the location. </summary>
        public AzureLocation? Location { get; set; }
        /// <summary> Dictionary of &lt;string&gt;. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
