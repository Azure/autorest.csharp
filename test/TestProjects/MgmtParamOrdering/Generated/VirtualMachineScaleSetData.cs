// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtParamOrdering
{
    /// <summary>
    /// A class representing the VirtualMachineScaleSet data model.
    /// Describes a Virtual Machine Scale Set.
    /// </summary>
    public partial class VirtualMachineScaleSetData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetData. </summary>
        /// <param name="location"> The location. </param>
        public VirtualMachineScaleSetData(AzureLocation location) : base(location)
        {
            Zones = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="zones"> The virtual machine scale set zones. NOTE: Availability zones can only be set when you create the scale set. </param>
        internal VirtualMachineScaleSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IList<string> zones) : base(id, name, resourceType, systemData, tags, location)
        {
            Zones = zones;
        }

        /// <summary> The virtual machine scale set zones. NOTE: Availability zones can only be set when you create the scale set. </summary>
        public IList<string> Zones { get; }
    }
}
