// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtParamOrdering.VirtualMachineScaleSetData
        ///
        /// </summary>
        /// <param name="location"> The location. </param>
        public VirtualMachineScaleSetData(AzureLocation location) : base(location)
        {
            Zones = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtParamOrdering.VirtualMachineScaleSetData
        ///
        /// </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="zones"> The virtual machine scale set zones. NOTE: Availability zones can only be set when you create the scale set. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, IList<string> zones, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Zones = zones;
            _rawData = rawData;
        }

        /// <summary> The virtual machine scale set zones. NOTE: Availability zones can only be set when you create the scale set. </summary>
        public IList<string> Zones { get; }
    }
}
