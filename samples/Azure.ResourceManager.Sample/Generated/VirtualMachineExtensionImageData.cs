// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary>
    /// A class representing the VirtualMachineExtensionImage data model.
    /// Describes a Virtual Machine Extension Image.
    /// Serialized Name: VirtualMachineExtensionImage
    /// </summary>
    public partial class VirtualMachineExtensionImageData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of VirtualMachineExtensionImageData. </summary>
        /// <param name="location"> The location. </param>
        public VirtualMachineExtensionImageData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionImageData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="operatingSystem">
        /// The operating system this extension supports.
        /// Serialized Name: VirtualMachineExtensionImage.properties.operatingSystem
        /// </param>
        /// <param name="computeRole">
        /// The type of role (IaaS or PaaS) this extension supports.
        /// Serialized Name: VirtualMachineExtensionImage.properties.computeRole
        /// </param>
        /// <param name="handlerSchema">
        /// The schema defined by publisher, where extension consumers should provide settings in a matching schema.
        /// Serialized Name: VirtualMachineExtensionImage.properties.handlerSchema
        /// </param>
        /// <param name="vmScaleSetEnabled">
        /// Whether the extension can be used on xRP VMScaleSets. By default existing extensions are usable on scalesets, but there might be cases where a publisher wants to explicitly indicate the extension is only enabled for CRP VMs but not VMSS.
        /// Serialized Name: VirtualMachineExtensionImage.properties.vmScaleSetEnabled
        /// </param>
        /// <param name="supportsMultipleExtensions">
        /// Whether the handler can support multiple extensions.
        /// Serialized Name: VirtualMachineExtensionImage.properties.supportsMultipleExtensions
        /// </param>
        internal VirtualMachineExtensionImageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string operatingSystem, string computeRole, string handlerSchema, bool? vmScaleSetEnabled, bool? supportsMultipleExtensions) : base(id, name, resourceType, systemData, tags, location)
        {
            OperatingSystem = operatingSystem;
            ComputeRole = computeRole;
            HandlerSchema = handlerSchema;
            VmScaleSetEnabled = vmScaleSetEnabled;
            SupportsMultipleExtensions = supportsMultipleExtensions;
        }

        /// <summary>
        /// The operating system this extension supports.
        /// Serialized Name: VirtualMachineExtensionImage.properties.operatingSystem
        /// </summary>
        public string OperatingSystem { get; set; }
        /// <summary>
        /// The type of role (IaaS or PaaS) this extension supports.
        /// Serialized Name: VirtualMachineExtensionImage.properties.computeRole
        /// </summary>
        public string ComputeRole { get; set; }
        /// <summary>
        /// The schema defined by publisher, where extension consumers should provide settings in a matching schema.
        /// Serialized Name: VirtualMachineExtensionImage.properties.handlerSchema
        /// </summary>
        public string HandlerSchema { get; set; }
        /// <summary>
        /// Whether the extension can be used on xRP VMScaleSets. By default existing extensions are usable on scalesets, but there might be cases where a publisher wants to explicitly indicate the extension is only enabled for CRP VMs but not VMSS.
        /// Serialized Name: VirtualMachineExtensionImage.properties.vmScaleSetEnabled
        /// </summary>
        public bool? VmScaleSetEnabled { get; set; }
        /// <summary>
        /// Whether the handler can support multiple extensions.
        /// Serialized Name: VirtualMachineExtensionImage.properties.supportsMultipleExtensions
        /// </summary>
        public bool? SupportsMultipleExtensions { get; set; }
    }
}
