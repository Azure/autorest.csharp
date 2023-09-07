// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSupersetFlattenInheritance
{
    /// <summary>
    /// A class representing the TrackedResourceModel1 data model.
    /// TrackedResource WITHOUT flatten properties
    /// </summary>
    public partial class TrackedResourceModel1Data : TrackedResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="TrackedResourceModel1Data"/>. </summary>
        /// <param name="location"> The location. </param>
        public TrackedResourceModel1Data(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="TrackedResourceModel1Data"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="foo"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TrackedResourceModel1Data(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string foo, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Foo = foo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="TrackedResourceModel1Data"/> for deserialization. </summary>
        internal TrackedResourceModel1Data()
        {
        }

        /// <summary> Gets or sets the foo. </summary>
        public string Foo { get; set; }
    }
}
