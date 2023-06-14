// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtPropertyChooser.Models
{
    /// <summary> The Resource model definition. </summary>
    public partial class MgmtPropertyChooserResourceData : ResourceData
    {
        /// <summary> Initializes a new instance of MgmtPropertyChooserResourceData. </summary>
        /// <param name="location"> Resource location. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        public MgmtPropertyChooserResourceData(string location)
        {
            Argument.AssertNotNull(location, nameof(location));

            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of MgmtPropertyChooserResourceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        internal MgmtPropertyChooserResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string location, IDictionary<string, string> tags) : base(id, name, resourceType, systemData)
        {
            Location = location;
            Tags = tags;
        }

        /// <summary> Resource location. </summary>
        public string Location { get; set; }
        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
