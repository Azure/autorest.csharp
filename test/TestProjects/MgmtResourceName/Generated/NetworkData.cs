// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtResourceName
{
    /// <summary> A class representing the Network data model. </summary>
    public partial class NetworkData : ResourceData
    {
        /// <summary> Initializes a new instance of NetworkData. </summary>
        public NetworkData()
        {
        }

        /// <summary> Initializes a new instance of NetworkData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="new"></param>
        internal NetworkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string @new) : base(id, name, resourceType, systemData)
        {
            New = @new;
        }

        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
