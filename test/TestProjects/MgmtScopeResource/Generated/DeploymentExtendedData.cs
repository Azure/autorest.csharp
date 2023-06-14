// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary>
    /// A class representing the DeploymentExtended data model.
    /// Deployment information.
    /// </summary>
    public partial class DeploymentExtendedData : ResourceData
    {
        /// <summary> Initializes a new instance of DeploymentExtendedData. </summary>
        internal DeploymentExtendedData()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of DeploymentExtendedData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> the location of the deployment. </param>
        /// <param name="properties"> Deployment properties. </param>
        /// <param name="tags"> Deployment tags. </param>
        internal DeploymentExtendedData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string location, DeploymentPropertiesExtended properties, IReadOnlyDictionary<string, string> tags) : base(id, name, resourceType, systemData)
        {
            Location = location;
            Properties = properties;
            Tags = tags;
        }

        /// <summary> the location of the deployment. </summary>
        public string Location { get; }
        /// <summary> Deployment properties. </summary>
        public DeploymentPropertiesExtended Properties { get; }
        /// <summary> Deployment tags. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
