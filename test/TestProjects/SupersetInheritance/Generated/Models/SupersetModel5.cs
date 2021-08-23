// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;
using SupersetInheritance;

namespace SupersetInheritance.Models
{
    /// <summary> The SupersetModel5. </summary>
    public partial class SupersetModel5 : SupersetModel4Data
    {
        /// <summary> Initializes a new instance of SupersetModel5. </summary>
        /// <param name="location"> The location. </param>
        public SupersetModel5(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of SupersetModel5. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="new"></param>
        /// <param name="foo"></param>
        internal SupersetModel5(ResourceIdentifier id, string name, ResourceType type, IDictionary<string, string> tags, Location location, string @new, string foo) : base(id, name, type, tags, location, @new)
        {
            Foo = foo;
        }

        public string Foo { get; set; }
    }
}
