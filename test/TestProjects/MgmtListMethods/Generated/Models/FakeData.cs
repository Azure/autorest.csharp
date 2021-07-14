// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Core;

namespace MgmtListMethods.Models
{
    /// <summary> A class representing the Fake data model. </summary>
    public partial class FakeData : TrackedResource<ResourceGroupResourceIdentifier>
    {
        /// <summary> Initializes a new instance of FakeData. </summary>
        /// <param name="location"> The location. </param>
        public FakeData(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of FakeData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="location"> The location. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="properties"> The instance view of a resource. </param>
        internal FakeData(ResourceGroupResourceIdentifier id, string name, ResourceType type, Location location, IDictionary<string, string> tags, FakeProperties properties) : base(id, name, type, location, tags)
        {
            Properties = properties;
        }

        /// <summary> The instance view of a resource. </summary>
        public FakeProperties Properties { get; set; }
    }
}
