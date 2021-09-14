// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace ExactMatchInheritance
{
    /// <summary> A class representing the ExactMatchModel5 data model. </summary>
    public partial class ExactMatchModel5Data : TrackedResource
    {
        /// <summary> Initializes a new instance of ExactMatchModel5Data. </summary>
        /// <param name="location"> The location. </param>
        public ExactMatchModel5Data(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel5Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="new"></param>
        internal ExactMatchModel5Data(ResourceIdentifier id, string name, ResourceType type, IDictionary<string, string> tags, Location location, string @new) : base(id, name, type, tags, location)
        {
            New = @new;
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
