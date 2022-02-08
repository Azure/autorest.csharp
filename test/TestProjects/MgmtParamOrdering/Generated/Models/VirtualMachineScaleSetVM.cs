// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtParamOrdering.Models
{
    /// <summary> Describes a virtual machine scale set virtual machine. </summary>
    public partial class VirtualMachineScaleSetVM : TrackedResourceData
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVM. </summary>
        /// <param name="location"> The location. </param>
        public VirtualMachineScaleSetVM(AzureLocation location) : base(location)
        {
            Zones = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVM. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="instanceId"> remove some properties to simplify; The virtual machine instance ID. </param>
        /// <param name="zones"> The virtual machine zones. </param>
        internal VirtualMachineScaleSetVM(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string instanceId, IReadOnlyList<string> zones) : base(id, name, type, systemData, tags, location)
        {
            InstanceId = instanceId;
            Zones = zones;
        }

        /// <summary> remove some properties to simplify; The virtual machine instance ID. </summary>
        public string InstanceId { get; }
        /// <summary> The virtual machine zones. </summary>
        public IReadOnlyList<string> Zones { get; }
    }
}
