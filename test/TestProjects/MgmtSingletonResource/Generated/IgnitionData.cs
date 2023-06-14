// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSingletonResource
{
    /// <summary> A class representing the Ignition data model. </summary>
    public partial class IgnitionData : ResourceData
    {
        /// <summary> Initializes a new instance of IgnitionData. </summary>
        internal IgnitionData()
        {
        }

        /// <summary> Initializes a new instance of IgnitionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="pushButton"></param>
        internal IgnitionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, bool? pushButton) : base(id, name, resourceType, systemData)
        {
            PushButton = pushButton;
        }

        /// <summary> Gets the push button. </summary>
        public bool? PushButton { get; }
    }
}
