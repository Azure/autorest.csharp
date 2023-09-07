// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtExactMatchFlattenInheritance.Models
{
    /// <summary> This model is x-ms-azure-resource, has flatten properties, and all reference type properties are in flatten properties. </summary>
    public partial class AzureResourceFlattenModel3 : TrackedResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="AzureResourceFlattenModel3"/>. </summary>
        /// <param name="location"> The location. </param>
        public AzureResourceFlattenModel3(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="AzureResourceFlattenModel3"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="foo"> New property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AzureResourceFlattenModel3(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, int? foo, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Foo = foo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="AzureResourceFlattenModel3"/> for deserialization. </summary>
        internal AzureResourceFlattenModel3()
        {
        }

        /// <summary> New property. </summary>
        public int? Foo { get; set; }
    }
}
