// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSupersetFlattenInheritance
{
    /// <summary>
    /// A class representing the ResourceModel1 data model.
    /// Resource WITHOUT flatten properties.
    /// </summary>
    public partial class ResourceModel1Data : ResourceData
    {
        /// <summary> Initializes a new instance of ResourceModel1Data. </summary>
        public ResourceModel1Data()
        {
        }

        /// <summary> Initializes a new instance of ResourceModel1Data. </summary>
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
