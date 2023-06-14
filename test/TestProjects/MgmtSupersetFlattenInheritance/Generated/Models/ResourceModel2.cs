// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> Resource with flatten properties (contains id). Since the id comes from flattened properties, this should not be counted as a resource. </summary>
    public partial class ResourceModel2 : ResourceData
    {
        /// <summary> Initializes a new instance of ResourceModel2. </summary>
        public ResourceModel2()
        {
        }

        /// <summary> Initializes a new instance of ResourceModel2. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"></param>
        internal ResourceModel2(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string foo) : base(id, name, resourceType, systemData)
        {
            Foo = foo;
        }

        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
