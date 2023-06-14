// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtExtensionResource
{
    /// <summary>
    /// A class representing the SubSingleton data model.
    /// SubSingleton object.
    /// </summary>
    public partial class SubSingletonData : ResourceData
    {
        /// <summary> Initializes a new instance of SubSingletonData. </summary>
        internal SubSingletonData()
        {
        }

        /// <summary> Initializes a new instance of SubSingletonData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="something"> The something. </param>
        internal SubSingletonData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string something) : base(id, name, resourceType, systemData)
        {
            Something = something;
        }

        /// <summary> The something. </summary>
        public string Something { get; }
    }
}
