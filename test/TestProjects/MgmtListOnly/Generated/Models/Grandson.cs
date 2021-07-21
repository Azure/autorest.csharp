// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Core;

namespace MgmtListOnly.Models
{
    /// <summary> The Grandson. </summary>
    public partial class Grandson : FakeData
    {
        /// <summary> Initializes a new instance of Grandson. </summary>
        /// <param name="location"> The location. </param>
        public Grandson(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of Grandson. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="location"> The location. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="bar"> specifies the bar. </param>
        /// <param name="foo"></param>
        internal Grandson(ResourceGroupResourceIdentifier id, string name, ResourceType type, Location location, IDictionary<string, string> tags, string bar, string foo) : base(id, name, type, location, tags, bar)
        {
            Foo = foo;
        }

        public string Foo { get; set; }
    }
}
