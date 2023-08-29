// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtParamOrdering.Models;

namespace MgmtParamOrdering
{
    /// <summary>
    /// A class representing the EnvironmentContainerResource data model.
    /// Azure Resource Manager resource envelope.
    /// </summary>
    public partial class EnvironmentContainerResourceData : TrackedResourceData
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtParamOrdering.EnvironmentContainerResourceData
        ///
        /// </summary>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Additional attributes of the entity. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public EnvironmentContainerResourceData(AzureLocation location, EnvironmentContainer properties) : base(location)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtParamOrdering.EnvironmentContainerResourceData
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Additional attributes of the entity. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal EnvironmentContainerResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, EnvironmentContainer properties, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Properties = properties;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="EnvironmentContainerResourceData"/> for deserialization. </summary>
        internal EnvironmentContainerResourceData()
        {
        }

        /// <summary> Additional attributes of the entity. </summary>
        public EnvironmentContainer Properties { get; set; }
    }
}
