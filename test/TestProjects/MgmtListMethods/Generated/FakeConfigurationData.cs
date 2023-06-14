// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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
        /// <summary> Initializes a new instance of FakeConfigurationData. </summary>
        /// <param name="location"> The location. </param>
        public FakeConfigurationData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of FakeConfigurationData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="configValue"> Value of the configuration. </param>
        internal FakeConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string configValue) : base(id, name, resourceType, systemData, tags, location)
        {
            ConfigValue = configValue;
        }

        /// <summary> Value of the configuration. </summary>
        public string ConfigValue { get; set; }
    }
}
