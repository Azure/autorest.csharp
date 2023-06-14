// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a Virtual Machine Image.
    /// Serialized Name: VirtualMachineImage
    /// </summary>
    public partial class VirtualMachineImage : VirtualMachineImageResource
    {
        /// <summary> Initializes a new instance of VirtualMachineImage. </summary>
        /// <param name="name">
        /// The name of the resource.
        /// Serialized Name: VirtualMachineImageResource.name
        /// </param>
        /// <param name="location">
        /// The supported Azure location of the resource.
        /// Serialized Name: VirtualMachineImageResource.location
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public VirtualMachineImage(string name, AzureLocation location) : base(name, location)
        {
            Argument.AssertNotNull(name, nameof(name));

            DataDiskImages = new ChangeTrackingList<DataDiskImage>();
        }

        /// <summary> Initializes a new instance of VirtualMachineImage. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </param>
        /// <param name="name">
        /// The name of the resource.
        /// Serialized Name: VirtualMachineImageResource.name
        /// </param>
        /// <param name="location">
        /// The supported Azure location of the resource.
        /// Serialized Name: VirtualMachineImageResource.location
        /// </param>
        /// <param name="tags">
        /// Specifies the tags that are assigned to the virtual machine. For more information about using tags, see [Using tags to organize your Azure resources](https://docs.microsoft.com/azure/azure-resource-manager/resource-group-using-tags.md).
        /// Serialized Name: VirtualMachineImageResource.tags
        /// </param>
        /// <param name="plan">
        /// Used for establishing the purchase context of any 3rd Party artifact through MarketPlace.
        /// Serialized Name: VirtualMachineImage.properties.plan
        /// </param>
        /// <param name="osDiskImage">
        /// Contains the os disk image information.
        /// Serialized Name: VirtualMachineImage.properties.osDiskImage
        /// </param>
        /// <param name="dataDiskImages"> Serialized Name: VirtualMachineImage.properties.dataDiskImages. </param>
        /// <param name="automaticOSUpgradeProperties">
        /// Describes automatic OS upgrade properties on the image.
        /// Serialized Name: VirtualMachineImage.properties.automaticOSUpgradeProperties
        /// </param>
        /// <param name="hyperVGeneration">
        /// Specifies the HyperVGeneration Type
        /// Serialized Name: VirtualMachineImage.properties.hyperVGeneration
        /// </param>
        /// <param name="disallowed">
        /// Specifies disallowed configuration for the VirtualMachine created from the image
        /// Serialized Name: VirtualMachineImage.properties.disallowed
        /// </param>
        internal VirtualMachineImage(string id, string name, AzureLocation location, IDictionary<string, string> tags, PurchasePlan plan, OSDiskImage osDiskImage, IList<DataDiskImage> dataDiskImages, AutomaticOSUpgradeProperties automaticOSUpgradeProperties, HyperVGeneration? hyperVGeneration, DisallowedConfiguration disallowed) : base(id, name, location, tags)
        {
            Plan = plan;
            OsDiskImage = osDiskImage;
            DataDiskImages = dataDiskImages;
            AutomaticOSUpgradeProperties = automaticOSUpgradeProperties;
            HyperVGeneration = hyperVGeneration;
            Disallowed = disallowed;
        }

        /// <summary>
        /// Used for establishing the purchase context of any 3rd Party artifact through MarketPlace.
        /// Serialized Name: VirtualMachineImage.properties.plan
        /// </summary>
        public PurchasePlan Plan { get; set; }
        /// <summary>
        /// Contains the os disk image information.
        /// Serialized Name: VirtualMachineImage.properties.osDiskImage
        /// </summary>
        internal OSDiskImage OsDiskImage { get; set; }
        /// <summary>
        /// The operating system of the osDiskImage.
        /// Serialized Name: OSDiskImage.operatingSystem
        /// </summary>
        public OperatingSystemType? OsDiskImageOperatingSystem
        {
            get => OsDiskImage is null ? default(OperatingSystemType?) : OsDiskImage.OperatingSystem;
            set
            {
                OsDiskImage = value.HasValue ? new OSDiskImage(value.Value) : null;
            }
        }

        /// <summary> Serialized Name: VirtualMachineImage.properties.dataDiskImages. </summary>
        public IList<DataDiskImage> DataDiskImages { get; }
        /// <summary>
        /// Describes automatic OS upgrade properties on the image.
        /// Serialized Name: VirtualMachineImage.properties.automaticOSUpgradeProperties
        /// </summary>
        internal AutomaticOSUpgradeProperties AutomaticOSUpgradeProperties { get; set; }
        /// <summary>
        /// Specifies whether automatic OS upgrade is supported on the image.
        /// Serialized Name: AutomaticOSUpgradeProperties.automaticOSUpgradeSupported
        /// </summary>
        public bool? AutomaticOSUpgradeSupported
        {
            get => AutomaticOSUpgradeProperties is null ? default(bool?) : AutomaticOSUpgradeProperties.AutomaticOSUpgradeSupported;
            set
            {
                AutomaticOSUpgradeProperties = value.HasValue ? new AutomaticOSUpgradeProperties(value.Value) : null;
            }
        }

        /// <summary>
        /// Specifies the HyperVGeneration Type
        /// Serialized Name: VirtualMachineImage.properties.hyperVGeneration
        /// </summary>
        public HyperVGeneration? HyperVGeneration { get; set; }
        /// <summary>
        /// Specifies disallowed configuration for the VirtualMachine created from the image
        /// Serialized Name: VirtualMachineImage.properties.disallowed
        /// </summary>
        internal DisallowedConfiguration Disallowed { get; set; }
        /// <summary>
        /// VM disk types which are disallowed.
        /// Serialized Name: DisallowedConfiguration.vmDiskType
        /// </summary>
        public VmDiskType? DisallowedVmDiskType
        {
            get => Disallowed is null ? default : Disallowed.VmDiskType;
            set
            {
                if (Disallowed is null)
                    Disallowed = new DisallowedConfiguration();
                Disallowed.VmDiskType = value;
            }
        }
    }
}
