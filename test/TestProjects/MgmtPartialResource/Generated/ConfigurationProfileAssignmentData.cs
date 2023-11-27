// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtPartialResource.Models;

namespace MgmtPartialResource
{
    /// <summary>
    /// A class representing the ConfigurationProfileAssignment data model.
    /// Configuration profile assignment is an association between a VM and automanage profile configuration.
    /// </summary>
    public partial class ConfigurationProfileAssignmentData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="ConfigurationProfileAssignmentData"/>. </summary>
        /// <param name="location"> The location. </param>
        public ConfigurationProfileAssignmentData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of <see cref="ConfigurationProfileAssignmentData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Properties of the configuration profile assignment. </param>
        internal ConfigurationProfileAssignmentData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ConfigurationProfileAssignmentProperties properties) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
        }

        /// <summary> Properties of the configuration profile assignment. </summary>
        public ConfigurationProfileAssignmentProperties Properties { get; set; }
    }
}
