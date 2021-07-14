// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Core;

namespace SupersetInheritance
{
    /// <summary> A class representing the SupersetModel4 data model. </summary>
    public partial class SupersetModel4Data : TrackedResource<ResourceGroupResourceIdentifier>
    {
        /// <summary> Initializes a new instance of SupersetModel4Data. </summary>
        /// <param name="location"> The location. </param>
        public SupersetModel4Data(LocationData location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of SupersetModel4Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="location"> The location. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="new"> . </param>
        internal SupersetModel4Data(ResourceGroupResourceIdentifier id, string name, ResourceType type, LocationData location, IDictionary<string, string> tags, string @new) : base(id, name, type, location, tags)
        {
            New = @new;
        }

        public string New { get; set; }
    }
}
