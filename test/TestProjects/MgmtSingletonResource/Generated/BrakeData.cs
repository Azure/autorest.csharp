// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtSingletonResource
{
    /// <summary> A class representing the Brake data model. </summary>
    public partial class BrakeData : ResourceData
    {
        /// <summary> Initializes a new instance of BrakeData. </summary>
        internal BrakeData()
        {
        }

        /// <summary> Initializes a new instance of BrakeData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="hitBrake"></param>
        internal BrakeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, bool? hitBrake) : base(id, name, resourceType, systemData)
        {
            HitBrake = hitBrake;
        }

        /// <summary> Gets the hit brake. </summary>
        public bool? HitBrake { get; }
    }
}
