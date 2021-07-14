// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Core;

namespace ExactMatchFlattenInheritance
{
    /// <summary> A class representing the AzureResourceFlattenModel3 data model. </summary>
    public partial class AzureResourceFlattenModel3Data : TrackedResource<ResourceGroupResourceIdentifier>
    {
        /// <summary> Initializes a new instance of AzureResourceFlattenModel3Data. </summary>
        /// <param name="location"> The location. </param>
        public AzureResourceFlattenModel3Data(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of AzureResourceFlattenModel3Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="location"> The location. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="foo"> New property. </param>
        internal AzureResourceFlattenModel3Data(ResourceGroupResourceIdentifier id, string name, ResourceType type, Location location, IDictionary<string, string> tags, int? foo) : base(id, name, type, location, tags)
        {
            Foo = foo;
        }

        /// <summary> New property. </summary>
        public int? Foo { get; set; }
    }
}
