// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing the FakeConfiguration data model.
    /// Describes the properties of a Fake Configuration.
    /// </summary>
    public partial class FakeConfigurationData : TrackedResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="FakeConfigurationData"/>. </summary>
        /// <param name="location"> The location. </param>
        public FakeConfigurationData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="FakeConfigurationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="configValue"> Value of the configuration. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FakeConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string configValue, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData, tags, location)
        {
            ConfigValue = configValue;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="FakeConfigurationData"/> for deserialization. </summary>
        internal FakeConfigurationData()
        {
        }

        /// <summary> Value of the configuration. </summary>
        public string ConfigValue { get; set; }
    }
}
