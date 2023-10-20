// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSupersetFlattenInheritance.Models
{
    /// <summary> Resource with flatten properties (contains id). Since the id comes from flattened properties, this should not be counted as a resource. </summary>
    public partial class ResourceModel2 : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ResourceModel2"/>. </summary>
        public ResourceModel2()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ResourceModel2"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="foo"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ResourceModel2(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string foo, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Foo = foo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
