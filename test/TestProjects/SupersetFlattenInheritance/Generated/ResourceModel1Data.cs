// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace SupersetFlattenInheritance
{
    /// <summary> A class representing the ResourceModel1 data model. </summary>
    public partial class ResourceModel1Data : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ResourceModel1Data"/>. </summary>
        public ResourceModel1Data()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ResourceModel1Data"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"></param>
        internal ResourceModel1Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string foo) : base(id, name, resourceType, systemData)
        {
            Foo = foo;
        }

        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
