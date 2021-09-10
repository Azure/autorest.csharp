// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;
using Azure.ResourceManager.Models;

namespace SupersetFlattenInheritance
{
    /// <summary> A class representing the ResourceModel1 data model. </summary>
    public partial class ResourceModel1Data : Resource
    {
        /// <summary> Initializes a new instance of ResourceModel1Data. </summary>
        public ResourceModel1Data()
        {
        }

        /// <summary> Initializes a new instance of ResourceModel1Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="foo"> The Foo. </param>
        internal ResourceModel1Data(ResourceIdentifier id, string name, ResourceType type, string foo) : base(id, name, type)
        {
            Foo = foo;
        }

        /// <summary> The Foo. </summary>
        public string Foo { get; set; }
    }
}
