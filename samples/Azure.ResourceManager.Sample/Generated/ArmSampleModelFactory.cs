// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmSampleModelFactory
    {
        /// <summary> Initializes a new instance of AvailabilitySetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku">
        /// Sku of the availability set, only name is required to be set. See AvailabilitySetSkuTypes for possible set of values. Use 'Aligned' for virtual machines with managed disks and 'Classic' for virtual machines with unmanaged disks. Default value is 'Classic'.
        /// Serialized Name: AvailabilitySet.sku
        /// </param>
        /// <param name="platformUpdateDomainCount">
        /// Update Domain count.
        /// Serialized Name: AvailabilitySet.properties.platformUpdateDomainCount
        /// </param>
        /// <param name="platformFaultDomainCount">
        /// Fault Domain count.
        /// Serialized Name: AvailabilitySet.properties.platformFaultDomainCount
        /// </param>
        /// <param name="virtualMachines">
        /// A list of references to all virtual machines in the availability set.
        /// Serialized Name: AvailabilitySet.properties.virtualMachines
        /// </param>
        /// <param name="proximityPlacementGroupId">
        /// Specifies information about the proximity placement group that the availability set should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01.
        /// Serialized Name: AvailabilitySet.properties.proximityPlacementGroup
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: AvailabilitySet.properties.statuses
        /// </param>
        /// <returns> A new <see cref="Sample.AvailabilitySetData"/> instance for mocking. </returns>
        public static AvailabilitySetData AvailabilitySetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, SampleSku sku = null, int? platformUpdateDomainCount = null, int? platformFaultDomainCount = null, IEnumerable<WritableSubResource> virtualMachines = null, ResourceIdentifier proximityPlacementGroupId = null, IEnumerable<InstanceViewStatus> statuses = null)
        {
            tags ??= new Dictionary<string, string>();
            virtualMachines ??= new List<WritableSubResource>();
            statuses ??= new List<InstanceViewStatus>();

            return new AvailabilitySetData(id, name, resourceType, systemData, tags, location, sku, platformUpdateDomainCount, platformFaultDomainCount, virtualMachines?.ToList(), proximityPlacementGroupId != null ? ResourceManagerModelFactory.WritableSubResource(proximityPlacementGroupId) : null, statuses?.ToList());
        }

        /// <summary> Initializes a new instance of VirtualMachineSize. </summary>
        /// <param name="name">
        /// The name of the virtual machine size.
        /// Serialized Name: VirtualMachineSize.name
        /// </param>
        /// <param name="numberOfCores">
        /// The number of cores supported by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.numberOfCores
        /// </param>
        /// <param name="osDiskSizeInMB">
        /// The OS disk size, in MB, allowed by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.osDiskSizeInMB
        /// </param>
        /// <param name="resourceDiskSizeInMB">
        /// The resource disk size, in MB, allowed by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.resourceDiskSizeInMB
        /// </param>
        /// <param name="memoryInMB">
        /// The amount of memory, in MB, supported by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.memoryInMB
        /// </param>
        /// <param name="maxDataDiskCount">
        /// The maximum number of data disks that can be attached to the virtual machine size.
        /// Serialized Name: VirtualMachineSize.maxDataDiskCount
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineSize"/> instance for mocking. </returns>
        public static VirtualMachineSize VirtualMachineSize(string name = null, int? numberOfCores = null, int? osDiskSizeInMB = null, int? resourceDiskSizeInMB = null, int? memoryInMB = null, int? maxDataDiskCount = null)
        {
            return new VirtualMachineSize(name, numberOfCores, osDiskSizeInMB, resourceDiskSizeInMB, memoryInMB, maxDataDiskCount);
        }

        /// <summary> Initializes a new instance of ProximityPlacementGroupData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation">
        /// The extended location of the custom IP prefix.
        /// Serialized Name: ProximityPlacementGroup.extendedLocation
        /// </param>
        /// <param name="proximityPlacementGroupType">
        /// Specifies the type of the proximity placement group. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Standard** : Co-locate resources within an Azure region or Availability Zone. &lt;br&gt;&lt;br&gt; **Ultra** : For future use.
        /// Serialized Name: ProximityPlacementGroup.properties.proximityPlacementGroupType
        /// </param>
        /// <param name="virtualMachines">
        /// A list of references to all virtual machines in the proximity placement group.
        /// Serialized Name: ProximityPlacementGroup.properties.virtualMachines
        /// </param>
        /// <param name="virtualMachineScaleSets">
        /// A list of references to all virtual machine scale sets in the proximity placement group.
        /// Serialized Name: ProximityPlacementGroup.properties.virtualMachineScaleSets
        /// </param>
        /// <param name="availabilitySets">
        /// A list of references to all availability sets in the proximity placement group.
        /// Serialized Name: ProximityPlacementGroup.properties.availabilitySets
        /// </param>
        /// <param name="colocationStatus">
        /// Describes colocation status of the Proximity Placement Group.
        /// Serialized Name: ProximityPlacementGroup.properties.colocationStatus
        /// </param>
        /// <returns> A new <see cref="Sample.ProximityPlacementGroupData"/> instance for mocking. </returns>
        public static ProximityPlacementGroupData ProximityPlacementGroupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ExtendedLocation extendedLocation = null, ProximityPlacementGroupType? proximityPlacementGroupType = null, IEnumerable<SubResourceWithColocationStatus> virtualMachines = null, IEnumerable<SubResourceWithColocationStatus> virtualMachineScaleSets = null, IEnumerable<SubResourceWithColocationStatus> availabilitySets = null, InstanceViewStatus colocationStatus = null)
        {
            tags ??= new Dictionary<string, string>();
            virtualMachines ??= new List<SubResourceWithColocationStatus>();
            virtualMachineScaleSets ??= new List<SubResourceWithColocationStatus>();
            availabilitySets ??= new List<SubResourceWithColocationStatus>();

            return new ProximityPlacementGroupData(id, name, resourceType, systemData, tags, location, extendedLocation, proximityPlacementGroupType, virtualMachines?.ToList(), virtualMachineScaleSets?.ToList(), availabilitySets?.ToList(), colocationStatus);
        }

        /// <summary> Initializes a new instance of DedicatedHostGroupData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="zones">
        /// Availability Zone to use for this host group. Only single zone is supported. The zone can be assigned only during creation. If not provided, the group supports all zones in the region. If provided, enforces each host in the group to be in the same zone.
        /// Serialized Name: DedicatedHostGroup.zones
        /// </param>
        /// <param name="hostUris">
        /// Availability Zone to use for this host group. Only single zone is supported. The zone can be assigned only during creation. If not provided, the group supports all zones in the region. If provided, enforces each host in the group to be in the same zone.
        /// Serialized Name: DedicatedHostGroup.hostUris
        /// </param>
        /// <param name="tenantId">
        /// The tenant id of the dedicated host.
        /// Serialized Name: DedicatedHostGroup.tenantId
        /// </param>
        /// <param name="platformFaultDomainCount">
        /// Number of fault domains that the host group can span.
        /// Serialized Name: DedicatedHostGroup.properties.platformFaultDomainCount
        /// </param>
        /// <param name="hosts">
        /// A list of references to all dedicated hosts in the dedicated host group.
        /// Serialized Name: DedicatedHostGroup.properties.hosts
        /// </param>
        /// <param name="instanceViewHosts">
        /// The dedicated host group instance view, which has the list of instance view of the dedicated hosts under the dedicated host group.
        /// Serialized Name: DedicatedHostGroup.properties.instanceView
        /// </param>
        /// <param name="supportAutomaticPlacement">
        /// Specifies whether virtual machines or virtual machine scale sets can be placed automatically on the dedicated host group. Automatic placement means resources are allocated on dedicated hosts, that are chosen by Azure, under the dedicated host group. The value is defaulted to 'true' when not provided. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: DedicatedHostGroup.properties.supportAutomaticPlacement
        /// </param>
        /// <returns> A new <see cref="Sample.DedicatedHostGroupData"/> instance for mocking. </returns>
        public static DedicatedHostGroupData DedicatedHostGroupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, IEnumerable<string> zones = null, IEnumerable<Uri> hostUris = null, Guid? tenantId = null, int? platformFaultDomainCount = null, IEnumerable<Resources.Models.SubResource> hosts = null, IEnumerable<DedicatedHostInstanceViewWithName> instanceViewHosts = null, bool? supportAutomaticPlacement = null)
        {
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();
            hostUris ??= new List<Uri>();
            hosts ??= new List<Resources.Models.SubResource>();
            instanceViewHosts ??= new List<DedicatedHostInstanceViewWithName>();

            return new DedicatedHostGroupData(id, name, resourceType, systemData, tags, location, zones?.ToList(), hostUris?.ToList(), tenantId, platformFaultDomainCount, hosts?.ToList(), instanceViewHosts != null ? new DedicatedHostGroupInstanceView(instanceViewHosts?.ToList()) : null, supportAutomaticPlacement);
        }

        /// <summary> Initializes a new instance of SubResourceReadOnly. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResourceReadOnly.id
        /// </param>
        /// <returns> A new <see cref="Models.SubResourceReadOnly"/> instance for mocking. </returns>
        public static SubResourceReadOnly SubResourceReadOnly(string id = null)
        {
            return new SubResourceReadOnly(id);
        }

        /// <summary> Initializes a new instance of DedicatedHostInstanceViewWithName. </summary>
        /// <param name="assetId">
        /// Specifies the unique id of the dedicated physical machine on which the dedicated host resides.
        /// Serialized Name: DedicatedHostInstanceView.assetId
        /// </param>
        /// <param name="availableCapacityAllocatableVMs">
        /// Unutilized capacity of the dedicated host.
        /// Serialized Name: DedicatedHostInstanceView.availableCapacity
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: DedicatedHostInstanceView.statuses
        /// </param>
        /// <param name="name">
        /// The name of the dedicated host.
        /// Serialized Name: DedicatedHostInstanceViewWithName.name
        /// </param>
        /// <returns> A new <see cref="Models.DedicatedHostInstanceViewWithName"/> instance for mocking. </returns>
        public static DedicatedHostInstanceViewWithName DedicatedHostInstanceViewWithName(string assetId = null, IEnumerable<DedicatedHostAllocatableVM> availableCapacityAllocatableVMs = null, IEnumerable<InstanceViewStatus> statuses = null, string name = null)
        {
            availableCapacityAllocatableVMs ??= new List<DedicatedHostAllocatableVM>();
            statuses ??= new List<InstanceViewStatus>();

            return new DedicatedHostInstanceViewWithName(assetId, availableCapacityAllocatableVMs != null ? new DedicatedHostAvailableCapacity(availableCapacityAllocatableVMs?.ToList()) : null, statuses?.ToList(), name);
        }

        /// <summary> Initializes a new instance of DedicatedHostInstanceView. </summary>
        /// <param name="assetId">
        /// Specifies the unique id of the dedicated physical machine on which the dedicated host resides.
        /// Serialized Name: DedicatedHostInstanceView.assetId
        /// </param>
        /// <param name="availableCapacityAllocatableVMs">
        /// Unutilized capacity of the dedicated host.
        /// Serialized Name: DedicatedHostInstanceView.availableCapacity
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: DedicatedHostInstanceView.statuses
        /// </param>
        /// <returns> A new <see cref="Models.DedicatedHostInstanceView"/> instance for mocking. </returns>
        public static DedicatedHostInstanceView DedicatedHostInstanceView(string assetId = null, IEnumerable<DedicatedHostAllocatableVM> availableCapacityAllocatableVMs = null, IEnumerable<InstanceViewStatus> statuses = null)
        {
            availableCapacityAllocatableVMs ??= new List<DedicatedHostAllocatableVM>();
            statuses ??= new List<InstanceViewStatus>();

            return new DedicatedHostInstanceView(assetId, availableCapacityAllocatableVMs != null ? new DedicatedHostAvailableCapacity(availableCapacityAllocatableVMs?.ToList()) : null, statuses?.ToList());
        }

        /// <summary> Initializes a new instance of DedicatedHostAllocatableVM. </summary>
        /// <param name="vmSize">
        /// VM size in terms of which the unutilized capacity is represented.
        /// Serialized Name: DedicatedHostAllocatableVM.vmSize
        /// </param>
        /// <param name="count">
        /// Maximum number of VMs of size vmSize that can fit in the dedicated host's remaining capacity.
        /// Serialized Name: DedicatedHostAllocatableVM.count
        /// </param>
        /// <returns> A new <see cref="Models.DedicatedHostAllocatableVM"/> instance for mocking. </returns>
        public static DedicatedHostAllocatableVM DedicatedHostAllocatableVM(string vmSize = null, double? count = null)
        {
            return new DedicatedHostAllocatableVM(vmSize, count);
        }

        /// <summary> Initializes a new instance of DedicatedHostData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku">
        /// SKU of the dedicated host for Hardware Generation and VM family. Only name is required to be set. List Microsoft.Compute SKUs for a list of possible values.
        /// Serialized Name: DedicatedHost.sku
        /// </param>
        /// <param name="platformFaultDomain">
        /// Fault domain of the dedicated host within a dedicated host group.
        /// Serialized Name: DedicatedHost.properties.platformFaultDomain
        /// </param>
        /// <param name="autoReplaceOnFailure">
        /// Specifies whether the dedicated host should be replaced automatically in case of a failure. The value is defaulted to 'true' when not provided.
        /// Serialized Name: DedicatedHost.properties.autoReplaceOnFailure
        /// </param>
        /// <param name="hostId">
        /// A unique id generated and assigned to the dedicated host by the platform. &lt;br&gt;&lt;br&gt; Does not change throughout the lifetime of the host.
        /// Serialized Name: DedicatedHost.properties.hostId
        /// </param>
        /// <param name="virtualMachines">
        /// A list of references to all virtual machines in the Dedicated Host.
        /// Serialized Name: DedicatedHost.properties.virtualMachines
        /// </param>
        /// <param name="licenseType">
        /// Specifies the software license type that will be applied to the VMs deployed on the dedicated host. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **Windows_Server_Hybrid** &lt;br&gt;&lt;br&gt; **Windows_Server_Perpetual** &lt;br&gt;&lt;br&gt; Default: **None**
        /// Serialized Name: DedicatedHost.properties.licenseType
        /// </param>
        /// <param name="provisioningOn">
        /// The date when the host was first provisioned.
        /// Serialized Name: DedicatedHost.properties.provisioningTime
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: DedicatedHost.properties.provisioningState
        /// </param>
        /// <param name="instanceView">
        /// The dedicated host instance view.
        /// Serialized Name: DedicatedHost.properties.instanceView
        /// </param>
        /// <returns> A new <see cref="Sample.DedicatedHostData"/> instance for mocking. </returns>
        public static DedicatedHostData DedicatedHostData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, SampleSku sku = null, int? platformFaultDomain = null, bool? autoReplaceOnFailure = null, string hostId = null, IEnumerable<Resources.Models.SubResource> virtualMachines = null, DedicatedHostLicenseType? licenseType = null, DateTimeOffset? provisioningOn = null, string provisioningState = null, DedicatedHostInstanceView instanceView = null)
        {
            tags ??= new Dictionary<string, string>();
            virtualMachines ??= new List<Resources.Models.SubResource>();

            return new DedicatedHostData(id, name, resourceType, systemData, tags, location, sku, platformFaultDomain, autoReplaceOnFailure, hostId, virtualMachines?.ToList(), licenseType, provisioningOn, provisioningState, instanceView);
        }

        /// <summary> Initializes a new instance of SshPublicKeyData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="publicKey">
        /// SSH public key used to authenticate to a virtual machine through ssh. If this property is not initially provided when the resource is created, the publicKey property will be populated when generateKeyPair is called. If the public key is provided upon resource creation, the provided public key needs to be at least 2048-bit and in ssh-rsa format.
        /// Serialized Name: SshPublicKeyResource.properties.publicKey
        /// </param>
        /// <returns> A new <see cref="Sample.SshPublicKeyData"/> instance for mocking. </returns>
        public static SshPublicKeyData SshPublicKeyData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string publicKey = null)
        {
            tags ??= new Dictionary<string, string>();

            return new SshPublicKeyData(id, name, resourceType, systemData, tags, location, publicKey);
        }

        /// <summary> Initializes a new instance of SshPublicKeyGenerateKeyPairResult. </summary>
        /// <param name="privateKey">
        /// Private key portion of the key pair used to authenticate to a virtual machine through ssh. The private key is returned in RFC3447 format and should be treated as a secret.
        /// Serialized Name: SshPublicKeyGenerateKeyPairResult.privateKey
        /// </param>
        /// <param name="publicKey">
        /// Public key portion of the key pair used to authenticate to a virtual machine through ssh. The public key is in ssh-rsa format.
        /// Serialized Name: SshPublicKeyGenerateKeyPairResult.publicKey
        /// </param>
        /// <param name="id">
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{SshPublicKeyName}
        /// Serialized Name: SshPublicKeyGenerateKeyPairResult.id
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="privateKey"/>, <paramref name="publicKey"/> or <paramref name="id"/> is null. </exception>
        /// <returns> A new <see cref="Models.SshPublicKeyGenerateKeyPairResult"/> instance for mocking. </returns>
        public static SshPublicKeyGenerateKeyPairResult SshPublicKeyGenerateKeyPairResult(string privateKey = null, string publicKey = null, string id = null)
        {
            if (privateKey == null)
            {
                throw new ArgumentNullException(nameof(privateKey));
            }
            if (publicKey == null)
            {
                throw new ArgumentNullException(nameof(publicKey));
            }
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return new SshPublicKeyGenerateKeyPairResult(privateKey, publicKey, id);
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
        /// <returns> A new <see cref="Sample.VirtualMachineExtensionImageData"/> instance for mocking. </returns>
        public static VirtualMachineExtensionImageData VirtualMachineExtensionImageData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string operatingSystem = null, string computeRole = null, string handlerSchema = null, bool? vmScaleSetEnabled = null, bool? supportsMultipleExtensions = null)
        {
            tags ??= new Dictionary<string, string>();

            return new VirtualMachineExtensionImageData(id, name, resourceType, systemData, tags, location, operatingSystem, computeRole, handlerSchema, vmScaleSetEnabled, supportsMultipleExtensions);
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="forceUpdateTag">
        /// How the extension handler should be forced to update even if the extension configuration has not changed.
        /// Serialized Name: VirtualMachineExtension.properties.forceUpdateTag
        /// </param>
        /// <param name="publisher">
        /// The name of the extension handler publisher.
        /// Serialized Name: VirtualMachineExtension.properties.publisher
        /// </param>
        /// <param name="extensionType">
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtension.properties.type
        /// </param>
        /// <param name="typeHandlerVersion">
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtension.properties.typeHandlerVersion
        /// </param>
        /// <param name="autoUpgradeMinorVersion">
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// Serialized Name: VirtualMachineExtension.properties.autoUpgradeMinorVersion
        /// </param>
        /// <param name="enableAutomaticUpgrade">
        /// Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
        /// Serialized Name: VirtualMachineExtension.properties.enableAutomaticUpgrade
        /// </param>
        /// <param name="settings">
        /// Json formatted public settings for the extension.
        /// Serialized Name: VirtualMachineExtension.properties.settings
        /// </param>
        /// <param name="protectedSettings">
        /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
        /// Serialized Name: VirtualMachineExtension.properties.protectedSettings
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineExtension.properties.provisioningState
        /// </param>
        /// <param name="instanceView">
        /// The virtual machine extension instance view.
        /// Serialized Name: VirtualMachineExtension.properties.instanceView
        /// </param>
        /// <returns> A new <see cref="Sample.VirtualMachineExtensionData"/> instance for mocking. </returns>
        public static VirtualMachineExtensionData VirtualMachineExtensionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = null, bool? enableAutomaticUpgrade = null, BinaryData settings = null, BinaryData protectedSettings = null, string provisioningState = null, VirtualMachineExtensionInstanceView instanceView = null)
        {
            tags ??= new Dictionary<string, string>();

            return new VirtualMachineExtensionData(id, name, resourceType, systemData, tags, location, forceUpdateTag, publisher, extensionType, typeHandlerVersion, autoUpgradeMinorVersion, enableAutomaticUpgrade, settings, protectedSettings, provisioningState, instanceView);
        }

        /// <summary> Initializes a new instance of DataDiskImage. </summary>
        /// <param name="lun">
        /// Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
        /// Serialized Name: DataDiskImage.lun
        /// </param>
        /// <returns> A new <see cref="Models.DataDiskImage"/> instance for mocking. </returns>
        public static DataDiskImage DataDiskImage(int? lun = null)
        {
            return new DataDiskImage(lun);
        }

        /// <summary> Initializes a new instance of SampleUsage. </summary>
        /// <param name="unit">
        /// An enum describing the unit of usage measurement.
        /// Serialized Name: SampleUsage.unit
        /// </param>
        /// <param name="currentValue">
        /// The current usage of the resource.
        /// Serialized Name: SampleUsage.currentValue
        /// </param>
        /// <param name="limit">
        /// The maximum permitted usage of the resource.
        /// Serialized Name: SampleUsage.limit
        /// </param>
        /// <param name="name">
        /// The name of the type of usage.
        /// Serialized Name: SampleUsage.name
        /// </param>
        /// <returns> A new <see cref="Models.SampleUsage"/> instance for mocking. </returns>
        public static SampleUsage SampleUsage(UsageUnit unit = default, int currentValue = default, long limit = default, SampleUsageName name = null)
        {
            return new SampleUsage(unit, currentValue, limit, name);
        }

        /// <summary> Initializes a new instance of SampleUsageName. </summary>
        /// <param name="value">
        /// The name of the resource.
        /// Serialized Name: SampleUsageName.value
        /// </param>
        /// <param name="localizedValue">
        /// The localized name of the resource.
        /// Serialized Name: SampleUsageName.localizedValue
        /// </param>
        /// <returns> A new <see cref="Models.SampleUsageName"/> instance for mocking. </returns>
        public static SampleUsageName SampleUsageName(string value = null, string localizedValue = null)
        {
            return new SampleUsageName(value, localizedValue);
        }

        /// <summary> Initializes a new instance of VirtualMachineData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="plan">
        /// Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**.
        /// Serialized Name: VirtualMachine.plan
        /// </param>
        /// <param name="resources">
        /// The virtual machine child extension resources.
        /// Serialized Name: VirtualMachine.resources
        /// </param>
        /// <param name="identity">
        /// The identity of the virtual machine, if configured.
        /// Serialized Name: VirtualMachine.identity
        /// </param>
        /// <param name="zones">
        /// The virtual machine zones.
        /// Serialized Name: VirtualMachine.zones
        /// </param>
        /// <param name="hardwareVmSize">
        /// Specifies the hardware settings for the virtual machine.
        /// Serialized Name: VirtualMachine.properties.hardwareProfile
        /// </param>
        /// <param name="storageProfile">
        /// Specifies the storage settings for the virtual machine disks.
        /// Serialized Name: VirtualMachine.properties.storageProfile
        /// </param>
        /// <param name="ultraSSDEnabled">
        /// Specifies additional capabilities enabled or disabled on the virtual machine.
        /// Serialized Name: VirtualMachine.properties.additionalCapabilities
        /// </param>
        /// <param name="osProfile">
        /// Specifies the operating system settings used while creating the virtual machine. Some of the settings cannot be changed once VM is provisioned.
        /// Serialized Name: VirtualMachine.properties.osProfile
        /// </param>
        /// <param name="networkInterfaces">
        /// Specifies the network interfaces of the virtual machine.
        /// Serialized Name: VirtualMachine.properties.networkProfile
        /// </param>
        /// <param name="encryptionAtHost">
        /// Specifies the Security related profile settings for the virtual machine.
        /// Serialized Name: VirtualMachine.properties.securityProfile
        /// </param>
        /// <param name="bootDiagnostics">
        /// Specifies the boot diagnostic settings state. &lt;br&gt;&lt;br&gt;Minimum api-version: 2015-06-15.
        /// Serialized Name: VirtualMachine.properties.diagnosticsProfile
        /// </param>
        /// <param name="availabilitySetId">
        /// Specifies information about the availability set that the virtual machine should be assigned to. Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. For more information about availability sets, see [Manage the availability of virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-manage-availability?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; For more information on Azure planned maintenance, see [Planned maintenance for virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-planned-maintenance?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Currently, a VM can only be added to availability set at creation time. The availability set to which the VM is being added should be under the same resource group as the availability set resource. An existing VM cannot be added to an availability set. &lt;br&gt;&lt;br&gt;This property cannot exist along with a non-null properties.virtualMachineScaleSet reference.
        /// Serialized Name: VirtualMachine.properties.availabilitySet
        /// </param>
        /// <param name="virtualMachineScaleSetId">
        /// Specifies information about the virtual machine scale set that the virtual machine should be assigned to. Virtual machines specified in the same virtual machine scale set are allocated to different nodes to maximize availability. Currently, a VM can only be added to virtual machine scale set at creation time. An existing VM cannot be added to a virtual machine scale set. &lt;br&gt;&lt;br&gt;This property cannot exist along with a non-null properties.availabilitySet reference. &lt;br&gt;&lt;br&gt;Minimum api‐version: 2019‐03‐01
        /// Serialized Name: VirtualMachine.properties.virtualMachineScaleSet
        /// </param>
        /// <param name="proximityPlacementGroupId">
        /// Specifies information about the proximity placement group that the virtual machine should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01.
        /// Serialized Name: VirtualMachine.properties.proximityPlacementGroup
        /// </param>
        /// <param name="priority">
        /// Specifies the priority for the virtual machine. &lt;br&gt;&lt;br&gt;Minimum api-version: 2019-03-01
        /// Serialized Name: VirtualMachine.properties.priority
        /// </param>
        /// <param name="evictionPolicy">
        /// Specifies the eviction policy for the Azure Spot virtual machine and Azure Spot scale set. &lt;br&gt;&lt;br&gt;For Azure Spot virtual machines, both 'Deallocate' and 'Delete' are supported and the minimum api-version is 2019-03-01. &lt;br&gt;&lt;br&gt;For Azure Spot scale sets, both 'Deallocate' and 'Delete' are supported and the minimum api-version is 2017-10-30-preview.
        /// Serialized Name: VirtualMachine.properties.evictionPolicy
        /// </param>
        /// <param name="billingMaxPrice">
        /// Specifies the billing related details of a Azure Spot virtual machine. &lt;br&gt;&lt;br&gt;Minimum api-version: 2019-03-01.
        /// Serialized Name: VirtualMachine.properties.billingProfile
        /// </param>
        /// <param name="hostId">
        /// Specifies information about the dedicated host that the virtual machine resides in. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-10-01.
        /// Serialized Name: VirtualMachine.properties.host
        /// </param>
        /// <param name="hostGroupId">
        /// Specifies information about the dedicated host group that the virtual machine resides in. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01. &lt;br&gt;&lt;br&gt;NOTE: User cannot specify both host and hostGroup properties.
        /// Serialized Name: VirtualMachine.properties.hostGroup
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachine.properties.provisioningState
        /// </param>
        /// <param name="instanceView">
        /// The virtual machine instance view.
        /// Serialized Name: VirtualMachine.properties.instanceView
        /// </param>
        /// <param name="licenseType">
        /// Specifies that the image or disk that is being used was licensed on-premises. This element is only used for images that contain the Windows Server operating system. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; Windows_Client &lt;br&gt;&lt;br&gt; Windows_Server &lt;br&gt;&lt;br&gt; If this element is included in a request for an update, the value must match the initial value. This value cannot be updated. &lt;br&gt;&lt;br&gt; For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-hybrid-use-benefit-licensing?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15
        /// Serialized Name: VirtualMachine.properties.licenseType
        /// </param>
        /// <param name="vmId">
        /// Specifies the VM unique ID which is a 128-bits identifier that is encoded and stored in all Azure IaaS VMs SMBIOS and can be read using platform BIOS commands.
        /// Serialized Name: VirtualMachine.properties.vmId
        /// </param>
        /// <param name="extensionsTimeBudget">
        /// Specifies the time alloted for all extensions to start. The time duration should be between 15 minutes and 120 minutes (inclusive) and should be specified in ISO 8601 format. The default value is 90 minutes (PT1H30M). &lt;br&gt;&lt;br&gt; Minimum api-version: 2020-06-01
        /// Serialized Name: VirtualMachine.properties.extensionsTimeBudget
        /// </param>
        /// <returns> A new <see cref="Sample.VirtualMachineData"/> instance for mocking. </returns>
        public static VirtualMachineData VirtualMachineData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, SamplePlan plan = null, IEnumerable<VirtualMachineExtensionData> resources = null, ManagedServiceIdentity identity = null, IEnumerable<string> zones = null, VirtualMachineSizeType? hardwareVmSize = null, StorageProfile storageProfile = null, bool? ultraSSDEnabled = null, OSProfile osProfile = null, IEnumerable<NetworkInterfaceReference> networkInterfaces = null, bool? encryptionAtHost = null, BootDiagnostics bootDiagnostics = null, ResourceIdentifier availabilitySetId = null, ResourceIdentifier virtualMachineScaleSetId = null, ResourceIdentifier proximityPlacementGroupId = null, VirtualMachinePriorityType? priority = null, VirtualMachineEvictionPolicyType? evictionPolicy = null, double? billingMaxPrice = null, ResourceIdentifier hostId = null, ResourceIdentifier hostGroupId = null, string provisioningState = null, VirtualMachineInstanceView instanceView = null, string licenseType = null, string vmId = null, string extensionsTimeBudget = null)
        {
            tags ??= new Dictionary<string, string>();
            resources ??= new List<VirtualMachineExtensionData>();
            zones ??= new List<string>();
            networkInterfaces ??= new List<NetworkInterfaceReference>();

            return new VirtualMachineData(id, name, resourceType, systemData, tags, location, plan, resources?.ToList(), identity, zones?.ToList(), hardwareVmSize != null ? new HardwareProfile(hardwareVmSize) : null, storageProfile, ultraSSDEnabled != null ? new AdditionalCapabilities(ultraSSDEnabled) : null, osProfile, networkInterfaces != null ? new NetworkProfile(networkInterfaces?.ToList()) : null, encryptionAtHost != null ? new SecurityProfile(encryptionAtHost) : null, bootDiagnostics != null ? new DiagnosticsProfile(bootDiagnostics) : null, availabilitySetId != null ? ResourceManagerModelFactory.WritableSubResource(availabilitySetId) : null, virtualMachineScaleSetId != null ? ResourceManagerModelFactory.WritableSubResource(virtualMachineScaleSetId) : null, proximityPlacementGroupId != null ? ResourceManagerModelFactory.WritableSubResource(proximityPlacementGroupId) : null, priority, evictionPolicy, billingMaxPrice != null ? new BillingProfile(billingMaxPrice) : null, hostId != null ? ResourceManagerModelFactory.WritableSubResource(hostId) : null, hostGroupId != null ? ResourceManagerModelFactory.WritableSubResource(hostGroupId) : null, provisioningState, instanceView, licenseType, vmId, extensionsTimeBudget);
        }

        /// <summary> Initializes a new instance of ImageReference. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </param>
        /// <param name="publisher">
        /// The image publisher.
        /// Serialized Name: ImageReference.publisher
        /// </param>
        /// <param name="offer">
        /// Specifies the offer of the platform image or marketplace image used to create the virtual machine.
        /// Serialized Name: ImageReference.offer
        /// </param>
        /// <param name="sku">
        /// The image SKU.
        /// Serialized Name: ImageReference.sku
        /// </param>
        /// <param name="version">
        /// Specifies the version of the platform image or marketplace image used to create the virtual machine. The allowed formats are Major.Minor.Build or 'latest'. Major, Minor, and Build are decimal numbers. Specify 'latest' to use the latest version of an image available at deploy time. Even if you use 'latest', the VM image will not automatically update after deploy time even if a new version becomes available.
        /// Serialized Name: ImageReference.version
        /// </param>
        /// <param name="exactVersion">
        /// Specifies in decimal numbers, the version of platform image or marketplace image used to create the virtual machine. This readonly field differs from 'version', only if the value specified in 'version' field is 'latest'.
        /// Serialized Name: ImageReference.exactVersion
        /// </param>
        /// <returns> A new <see cref="Models.ImageReference"/> instance for mocking. </returns>
        public static ImageReference ImageReference(string id = null, string publisher = null, string offer = null, string sku = null, string version = null, string exactVersion = null)
        {
            return new ImageReference(id, publisher, offer, sku, version, exactVersion);
        }

        /// <summary> Initializes a new instance of DataDisk. </summary>
        /// <param name="lun">
        /// Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
        /// Serialized Name: DataDisk.lun
        /// </param>
        /// <param name="name">
        /// The disk name.
        /// Serialized Name: DataDisk.name
        /// </param>
        /// <param name="vhdUri">
        /// The virtual hard disk.
        /// Serialized Name: DataDisk.vhd
        /// </param>
        /// <param name="imageUri">
        /// The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist.
        /// Serialized Name: DataDisk.image
        /// </param>
        /// <param name="caching">
        /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
        /// Serialized Name: DataDisk.caching
        /// </param>
        /// <param name="writeAcceleratorEnabled">
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// Serialized Name: DataDisk.writeAcceleratorEnabled
        /// </param>
        /// <param name="createOption">
        /// Specifies how the virtual machine should be created.&lt;br&gt;&lt;br&gt; Possible values are:&lt;br&gt;&lt;br&gt; **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.&lt;br&gt;&lt;br&gt; **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// Serialized Name: DataDisk.createOption
        /// </param>
        /// <param name="diskSizeGB">
        /// Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. &lt;br&gt;&lt;br&gt; This value cannot be larger than 1023 GB
        /// Serialized Name: DataDisk.diskSizeGB
        /// </param>
        /// <param name="managedDisk">
        /// The managed disk parameters.
        /// Serialized Name: DataDisk.managedDisk
        /// </param>
        /// <param name="toBeDetached">
        /// Specifies whether the data disk is in process of detachment from the VirtualMachine/VirtualMachineScaleset
        /// Serialized Name: DataDisk.toBeDetached
        /// </param>
        /// <param name="diskIopsReadWrite">
        /// Specifies the Read-Write IOPS for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set.
        /// Serialized Name: DataDisk.diskIOPSReadWrite
        /// </param>
        /// <param name="diskMBpsReadWrite">
        /// Specifies the bandwidth in MB per second for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set.
        /// Serialized Name: DataDisk.diskMBpsReadWrite
        /// </param>
        /// <returns> A new <see cref="Models.DataDisk"/> instance for mocking. </returns>
        public static DataDisk DataDisk(int lun = default, string name = null, Uri vhdUri = null, Uri imageUri = null, CachingType? caching = null, bool? writeAcceleratorEnabled = null, DiskCreateOptionType createOption = default, int? diskSizeGB = null, ManagedDiskParameters managedDisk = null, bool? toBeDetached = null, long? diskIopsReadWrite = null, long? diskMBpsReadWrite = null)
        {
            return new DataDisk(lun, name, vhdUri != null ? new VirtualHardDisk(vhdUri) : null, imageUri != null ? new VirtualHardDisk(imageUri) : null, caching, writeAcceleratorEnabled, createOption, diskSizeGB, managedDisk, toBeDetached, diskIopsReadWrite, diskMBpsReadWrite);
        }

        /// <summary> Initializes a new instance of VirtualMachineInstanceView. </summary>
        /// <param name="platformUpdateDomain">
        /// Specifies the update domain of the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.platformUpdateDomain
        /// </param>
        /// <param name="platformFaultDomain">
        /// Specifies the fault domain of the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.platformFaultDomain
        /// </param>
        /// <param name="computerName">
        /// The computer name assigned to the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.computerName
        /// </param>
        /// <param name="osName">
        /// The Operating System running on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.osName
        /// </param>
        /// <param name="osVersion">
        /// The version of Operating System running on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.osVersion
        /// </param>
        /// <param name="hyperVGeneration">
        /// Specifies the HyperVGeneration Type associated with a resource
        /// Serialized Name: VirtualMachineInstanceView.hyperVGeneration
        /// </param>
        /// <param name="rdpThumbPrint">
        /// The Remote desktop certificate thumbprint.
        /// Serialized Name: VirtualMachineInstanceView.rdpThumbPrint
        /// </param>
        /// <param name="vmAgent">
        /// The VM Agent running on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.vmAgent
        /// </param>
        /// <param name="maintenanceRedeployStatus">
        /// The Maintenance Operation status on the virtual machine.
        /// Serialized Name: VirtualMachineInstanceView.maintenanceRedeployStatus
        /// </param>
        /// <param name="disks">
        /// The virtual machine disk information.
        /// Serialized Name: VirtualMachineInstanceView.disks
        /// </param>
        /// <param name="extensions">
        /// The extensions information.
        /// Serialized Name: VirtualMachineInstanceView.extensions
        /// </param>
        /// <param name="vmHealthStatus">
        /// The health status for the VM.
        /// Serialized Name: VirtualMachineInstanceView.vmHealth
        /// </param>
        /// <param name="bootDiagnostics">
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// Serialized Name: VirtualMachineInstanceView.bootDiagnostics
        /// </param>
        /// <param name="assignedHost">
        /// Resource id of the dedicated host, on which the virtual machine is allocated through automatic placement, when the virtual machine is associated with a dedicated host group that has automatic placement enabled. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: VirtualMachineInstanceView.assignedHost
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineInstanceView.statuses
        /// </param>
        /// <param name="patchStatus">
        /// The status of virtual machine patch operations.
        /// Serialized Name: VirtualMachineInstanceView.patchStatus
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineInstanceView"/> instance for mocking. </returns>
        public static VirtualMachineInstanceView VirtualMachineInstanceView(int? platformUpdateDomain = null, int? platformFaultDomain = null, string computerName = null, string osName = null, string osVersion = null, HyperVGeneration? hyperVGeneration = null, string rdpThumbPrint = null, VirtualMachineAgentInstanceView vmAgent = null, MaintenanceRedeployStatus maintenanceRedeployStatus = null, IEnumerable<DiskInstanceView> disks = null, IEnumerable<VirtualMachineExtensionInstanceView> extensions = null, InstanceViewStatus vmHealthStatus = null, BootDiagnosticsInstanceView bootDiagnostics = null, string assignedHost = null, IEnumerable<InstanceViewStatus> statuses = null, VirtualMachinePatchStatus patchStatus = null)
        {
            disks ??= new List<DiskInstanceView>();
            extensions ??= new List<VirtualMachineExtensionInstanceView>();
            statuses ??= new List<InstanceViewStatus>();

            return new VirtualMachineInstanceView(platformUpdateDomain, platformFaultDomain, computerName, osName, osVersion, hyperVGeneration, rdpThumbPrint, vmAgent, maintenanceRedeployStatus, disks?.ToList(), extensions?.ToList(), vmHealthStatus != null ? new VirtualMachineHealthStatus(vmHealthStatus) : null, bootDiagnostics, assignedHost, statuses?.ToList(), patchStatus);
        }

        /// <summary> Initializes a new instance of VirtualMachineAgentInstanceView. </summary>
        /// <param name="vmAgentVersion">
        /// The VM Agent full version.
        /// Serialized Name: VirtualMachineAgentInstanceView.vmAgentVersion
        /// </param>
        /// <param name="extensionHandlers">
        /// The virtual machine extension handler instance view.
        /// Serialized Name: VirtualMachineAgentInstanceView.extensionHandlers
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineAgentInstanceView.statuses
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineAgentInstanceView"/> instance for mocking. </returns>
        public static VirtualMachineAgentInstanceView VirtualMachineAgentInstanceView(string vmAgentVersion = null, IEnumerable<VirtualMachineExtensionHandlerInstanceView> extensionHandlers = null, IEnumerable<InstanceViewStatus> statuses = null)
        {
            extensionHandlers ??= new List<VirtualMachineExtensionHandlerInstanceView>();
            statuses ??= new List<InstanceViewStatus>();

            return new VirtualMachineAgentInstanceView(vmAgentVersion, extensionHandlers?.ToList(), statuses?.ToList());
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionHandlerInstanceView. </summary>
        /// <param name="virtualMachineExtensionHandlerInstanceViewType">
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtensionHandlerInstanceView.type
        /// </param>
        /// <param name="typeHandlerVersion">
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtensionHandlerInstanceView.typeHandlerVersion
        /// </param>
        /// <param name="status">
        /// The extension handler status.
        /// Serialized Name: VirtualMachineExtensionHandlerInstanceView.status
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineExtensionHandlerInstanceView"/> instance for mocking. </returns>
        public static VirtualMachineExtensionHandlerInstanceView VirtualMachineExtensionHandlerInstanceView(string virtualMachineExtensionHandlerInstanceViewType = null, string typeHandlerVersion = null, InstanceViewStatus status = null)
        {
            return new VirtualMachineExtensionHandlerInstanceView(virtualMachineExtensionHandlerInstanceViewType, typeHandlerVersion, status);
        }

        /// <summary> Initializes a new instance of MaintenanceRedeployStatus. </summary>
        /// <param name="isCustomerInitiatedMaintenanceAllowed">
        /// True, if customer is allowed to perform Maintenance.
        /// Serialized Name: MaintenanceRedeployStatus.isCustomerInitiatedMaintenanceAllowed
        /// </param>
        /// <param name="preMaintenanceWindowStartOn">
        /// Start Time for the Pre Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.preMaintenanceWindowStartTime
        /// </param>
        /// <param name="preMaintenanceWindowEndOn">
        /// End Time for the Pre Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.preMaintenanceWindowEndTime
        /// </param>
        /// <param name="maintenanceWindowStartOn">
        /// Start Time for the Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.maintenanceWindowStartTime
        /// </param>
        /// <param name="maintenanceWindowEndOn">
        /// End Time for the Maintenance Window.
        /// Serialized Name: MaintenanceRedeployStatus.maintenanceWindowEndTime
        /// </param>
        /// <param name="lastOperationResultCode">
        /// The Last Maintenance Operation Result Code.
        /// Serialized Name: MaintenanceRedeployStatus.lastOperationResultCode
        /// </param>
        /// <param name="lastOperationMessage">
        /// Message returned for the last Maintenance Operation.
        /// Serialized Name: MaintenanceRedeployStatus.lastOperationMessage
        /// </param>
        /// <returns> A new <see cref="Models.MaintenanceRedeployStatus"/> instance for mocking. </returns>
        public static MaintenanceRedeployStatus MaintenanceRedeployStatus(bool? isCustomerInitiatedMaintenanceAllowed = null, DateTimeOffset? preMaintenanceWindowStartOn = null, DateTimeOffset? preMaintenanceWindowEndOn = null, DateTimeOffset? maintenanceWindowStartOn = null, DateTimeOffset? maintenanceWindowEndOn = null, MaintenanceOperationResultCodeType? lastOperationResultCode = null, string lastOperationMessage = null)
        {
            return new MaintenanceRedeployStatus(isCustomerInitiatedMaintenanceAllowed, preMaintenanceWindowStartOn, preMaintenanceWindowEndOn, maintenanceWindowStartOn, maintenanceWindowEndOn, lastOperationResultCode, lastOperationMessage);
        }

        /// <summary> Initializes a new instance of DiskInstanceView. </summary>
        /// <param name="name">
        /// The disk name.
        /// Serialized Name: DiskInstanceView.name
        /// </param>
        /// <param name="encryptionSettings">
        /// Specifies the encryption settings for the OS Disk. &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15
        /// Serialized Name: DiskInstanceView.encryptionSettings
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: DiskInstanceView.statuses
        /// </param>
        /// <returns> A new <see cref="Models.DiskInstanceView"/> instance for mocking. </returns>
        public static DiskInstanceView DiskInstanceView(string name = null, IEnumerable<DiskEncryptionSettings> encryptionSettings = null, IEnumerable<InstanceViewStatus> statuses = null)
        {
            encryptionSettings ??= new List<DiskEncryptionSettings>();
            statuses ??= new List<InstanceViewStatus>();

            return new DiskInstanceView(name, encryptionSettings?.ToList(), statuses?.ToList());
        }

        /// <summary> Initializes a new instance of BootDiagnosticsInstanceView. </summary>
        /// <param name="consoleScreenshotBlobUri">
        /// The console screenshot blob URI. &lt;br&gt;&lt;br&gt;NOTE: This will **not** be set if boot diagnostics is currently enabled with managed storage.
        /// Serialized Name: BootDiagnosticsInstanceView.consoleScreenshotBlobUri
        /// </param>
        /// <param name="serialConsoleLogBlobUri">
        /// The serial console log blob Uri. &lt;br&gt;&lt;br&gt;NOTE: This will **not** be set if boot diagnostics is currently enabled with managed storage.
        /// Serialized Name: BootDiagnosticsInstanceView.serialConsoleLogBlobUri
        /// </param>
        /// <param name="status">
        /// The boot diagnostics status information for the VM. &lt;br&gt;&lt;br&gt; NOTE: It will be set only if there are errors encountered in enabling boot diagnostics.
        /// Serialized Name: BootDiagnosticsInstanceView.status
        /// </param>
        /// <returns> A new <see cref="Models.BootDiagnosticsInstanceView"/> instance for mocking. </returns>
        public static BootDiagnosticsInstanceView BootDiagnosticsInstanceView(Uri consoleScreenshotBlobUri = null, Uri serialConsoleLogBlobUri = null, InstanceViewStatus status = null)
        {
            return new BootDiagnosticsInstanceView(consoleScreenshotBlobUri, serialConsoleLogBlobUri, status);
        }

        /// <summary> Initializes a new instance of VirtualMachinePatchStatus. </summary>
        /// <param name="availablePatchSummary">
        /// The available patch summary of the latest assessment operation for the virtual machine.
        /// Serialized Name: VirtualMachinePatchStatus.availablePatchSummary
        /// </param>
        /// <param name="lastPatchInstallationSummary">
        /// The installation summary of the latest installation operation for the virtual machine.
        /// Serialized Name: VirtualMachinePatchStatus.lastPatchInstallationSummary
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachinePatchStatus"/> instance for mocking. </returns>
        public static VirtualMachinePatchStatus VirtualMachinePatchStatus(AvailablePatchSummary availablePatchSummary = null, LastPatchInstallationSummary lastPatchInstallationSummary = null)
        {
            return new VirtualMachinePatchStatus(availablePatchSummary, lastPatchInstallationSummary);
        }

        /// <summary> Initializes a new instance of AvailablePatchSummary. </summary>
        /// <param name="status">
        /// The overall success or failure status of the operation. It remains "InProgress" until the operation completes. At that point it will become "Failed", "Succeeded", or "CompletedWithWarnings."
        /// Serialized Name: AvailablePatchSummary.status
        /// </param>
        /// <param name="assessmentActivityId">
        /// The activity ID of the operation that produced this result. It is used to correlate across CRP and extension logs.
        /// Serialized Name: AvailablePatchSummary.assessmentActivityId
        /// </param>
        /// <param name="rebootPending">
        /// The overall reboot status of the VM. It will be true when partially installed patches require a reboot to complete installation but the reboot has not yet occurred.
        /// Serialized Name: AvailablePatchSummary.rebootPending
        /// </param>
        /// <param name="criticalAndSecurityPatchCount">
        /// The number of critical or security patches that have been detected as available and not yet installed.
        /// Serialized Name: AvailablePatchSummary.criticalAndSecurityPatchCount
        /// </param>
        /// <param name="otherPatchCount">
        /// The number of all available patches excluding critical and security.
        /// Serialized Name: AvailablePatchSummary.otherPatchCount
        /// </param>
        /// <param name="startOn">
        /// The UTC timestamp when the operation began.
        /// Serialized Name: AvailablePatchSummary.startTime
        /// </param>
        /// <param name="lastModifiedOn">
        /// The UTC timestamp when the operation began.
        /// Serialized Name: AvailablePatchSummary.lastModifiedTime
        /// </param>
        /// <param name="error">
        /// The errors that were encountered during execution of the operation. The details array contains the list of them.
        /// Serialized Name: AvailablePatchSummary.error
        /// </param>
        /// <returns> A new <see cref="Models.AvailablePatchSummary"/> instance for mocking. </returns>
        public static AvailablePatchSummary AvailablePatchSummary(PatchOperationStatus? status = null, string assessmentActivityId = null, bool? rebootPending = null, int? criticalAndSecurityPatchCount = null, int? otherPatchCount = null, DateTimeOffset? startOn = null, DateTimeOffset? lastModifiedOn = null, ApiError error = null)
        {
            return new AvailablePatchSummary(status, assessmentActivityId, rebootPending, criticalAndSecurityPatchCount, otherPatchCount, startOn, lastModifiedOn, error);
        }

        /// <summary> Initializes a new instance of ApiError. </summary>
        /// <param name="details">
        /// The Api error details
        /// Serialized Name: ApiError.details
        /// </param>
        /// <param name="innererror">
        /// The Api inner error
        /// Serialized Name: ApiError.innererror
        /// </param>
        /// <param name="code">
        /// The error code.
        /// Serialized Name: ApiError.code
        /// </param>
        /// <param name="target">
        /// The target of the particular error.
        /// Serialized Name: ApiError.target
        /// </param>
        /// <param name="message">
        /// The error message.
        /// Serialized Name: ApiError.message
        /// </param>
        /// <returns> A new <see cref="Models.ApiError"/> instance for mocking. </returns>
        public static ApiError ApiError(IEnumerable<ApiErrorBase> details = null, InnerError innererror = null, string code = null, string target = null, string message = null)
        {
            details ??= new List<ApiErrorBase>();

            return new ApiError(details?.ToList(), innererror, code, target, message);
        }

        /// <summary> Initializes a new instance of ApiErrorBase. </summary>
        /// <param name="code">
        /// The error code.
        /// Serialized Name: ApiErrorBase.code
        /// </param>
        /// <param name="target">
        /// The target of the particular error.
        /// Serialized Name: ApiErrorBase.target
        /// </param>
        /// <param name="message">
        /// The error message.
        /// Serialized Name: ApiErrorBase.message
        /// </param>
        /// <returns> A new <see cref="Models.ApiErrorBase"/> instance for mocking. </returns>
        public static ApiErrorBase ApiErrorBase(string code = null, string target = null, string message = null)
        {
            return new ApiErrorBase(code, target, message);
        }

        /// <summary> Initializes a new instance of InnerError. </summary>
        /// <param name="exceptiontype">
        /// The exception type.
        /// Serialized Name: InnerError.exceptiontype
        /// </param>
        /// <param name="errordetail">
        /// The internal error message or exception dump.
        /// Serialized Name: InnerError.errordetail
        /// </param>
        /// <returns> A new <see cref="Models.InnerError"/> instance for mocking. </returns>
        public static InnerError InnerError(string exceptiontype = null, string errordetail = null)
        {
            return new InnerError(exceptiontype, errordetail);
        }

        /// <summary> Initializes a new instance of LastPatchInstallationSummary. </summary>
        /// <param name="status">
        /// The overall success or failure status of the operation. It remains "InProgress" until the operation completes. At that point it will become "Failed", "Succeeded", or "CompletedWithWarnings."
        /// Serialized Name: LastPatchInstallationSummary.status
        /// </param>
        /// <param name="installationActivityId">
        /// The activity ID of the operation that produced this result. It is used to correlate across CRP and extension logs.
        /// Serialized Name: LastPatchInstallationSummary.installationActivityId
        /// </param>
        /// <param name="maintenanceWindowExceeded">
        /// Describes whether the operation ran out of time before it completed all its intended actions
        /// Serialized Name: LastPatchInstallationSummary.maintenanceWindowExceeded
        /// </param>
        /// <param name="rebootStatus">
        /// The reboot status of the machine after the patch operation. It will be in "NotNeeded" status if reboot is not needed after the patch operation. "Required" will be the status once the patch is applied and machine is required to reboot. "Started" will be the reboot status when the machine has started to reboot. "Failed" will be the status if the machine is failed to reboot. "Completed" will be the status once the machine is rebooted successfully
        /// Serialized Name: LastPatchInstallationSummary.rebootStatus
        /// </param>
        /// <param name="notSelectedPatchCount">
        /// The number of all available patches but not going to be installed because it didn't match a classification or inclusion list entry.
        /// Serialized Name: LastPatchInstallationSummary.notSelectedPatchCount
        /// </param>
        /// <param name="excludedPatchCount">
        /// The number of all available patches but excluded explicitly by a customer-specified exclusion list match.
        /// Serialized Name: LastPatchInstallationSummary.excludedPatchCount
        /// </param>
        /// <param name="pendingPatchCount">
        /// The number of all available patches expected to be installed over the course of the patch installation operation.
        /// Serialized Name: LastPatchInstallationSummary.pendingPatchCount
        /// </param>
        /// <param name="installedPatchCount">
        /// The count of patches that successfully installed.
        /// Serialized Name: LastPatchInstallationSummary.installedPatchCount
        /// </param>
        /// <param name="failedPatchCount">
        /// The count of patches that failed installation.
        /// Serialized Name: LastPatchInstallationSummary.failedPatchCount
        /// </param>
        /// <param name="startOn">
        /// The UTC timestamp when the operation began.
        /// Serialized Name: LastPatchInstallationSummary.startTime
        /// </param>
        /// <param name="lastModifiedOn">
        /// The UTC timestamp when the operation began.
        /// Serialized Name: LastPatchInstallationSummary.lastModifiedTime
        /// </param>
        /// <param name="startedBy">
        /// The person or system account that started the operation
        /// Serialized Name: LastPatchInstallationSummary.startedBy
        /// </param>
        /// <param name="error">
        /// The errors that were encountered during execution of the operation. The details array contains the list of them.
        /// Serialized Name: LastPatchInstallationSummary.error
        /// </param>
        /// <returns> A new <see cref="Models.LastPatchInstallationSummary"/> instance for mocking. </returns>
        public static LastPatchInstallationSummary LastPatchInstallationSummary(PatchOperationStatus? status = null, string installationActivityId = null, bool? maintenanceWindowExceeded = null, RebootStatus? rebootStatus = null, int? notSelectedPatchCount = null, int? excludedPatchCount = null, int? pendingPatchCount = null, int? installedPatchCount = null, int? failedPatchCount = null, DateTimeOffset? startOn = null, DateTimeOffset? lastModifiedOn = null, string startedBy = null, ApiError error = null)
        {
            return new LastPatchInstallationSummary(status, installationActivityId, maintenanceWindowExceeded, rebootStatus, notSelectedPatchCount, excludedPatchCount, pendingPatchCount, installedPatchCount, failedPatchCount, startOn, lastModifiedOn, startedBy, error);
        }

        /// <summary> Initializes a new instance of ImageData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sourceVirtualMachineId">
        /// The source virtual machine from which Image is created.
        /// Serialized Name: Image.properties.sourceVirtualMachine
        /// </param>
        /// <param name="storageProfile">
        /// Specifies the storage settings for the virtual machine disks.
        /// Serialized Name: Image.properties.storageProfile
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state.
        /// Serialized Name: Image.properties.provisioningState
        /// </param>
        /// <param name="hyperVGeneration">
        /// Gets the HyperVGenerationType of the VirtualMachine created from the image
        /// Serialized Name: Image.properties.hyperVGeneration
        /// </param>
        /// <returns> A new <see cref="Sample.ImageData"/> instance for mocking. </returns>
        public static ImageData ImageData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ResourceIdentifier sourceVirtualMachineId = null, ImageStorageProfile storageProfile = null, string provisioningState = null, HyperVGeneration? hyperVGeneration = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ImageData(id, name, resourceType, systemData, tags, location, sourceVirtualMachineId != null ? ResourceManagerModelFactory.WritableSubResource(sourceVirtualMachineId) : null, storageProfile, provisioningState, hyperVGeneration);
        }

        /// <summary> Initializes a new instance of VirtualMachineCaptureResult. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </param>
        /// <param name="schema">
        /// the schema of the captured virtual machine
        /// Serialized Name: VirtualMachineCaptureResult.$schema
        /// </param>
        /// <param name="contentVersion">
        /// the version of the content
        /// Serialized Name: VirtualMachineCaptureResult.contentVersion
        /// </param>
        /// <param name="parameters">
        /// parameters of the captured virtual machine
        /// Serialized Name: VirtualMachineCaptureResult.parameters
        /// </param>
        /// <param name="resources">
        /// a list of resource items of the captured virtual machine
        /// Serialized Name: VirtualMachineCaptureResult.resources
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineCaptureResult"/> instance for mocking. </returns>
        public static VirtualMachineCaptureResult VirtualMachineCaptureResult(string id = null, string schema = null, string contentVersion = null, BinaryData parameters = null, IEnumerable<BinaryData> resources = null)
        {
            resources ??= new List<BinaryData>();

            return new VirtualMachineCaptureResult(id, schema, contentVersion, parameters, resources?.ToList());
        }

        /// <summary> Initializes a new instance of RetrieveBootDiagnosticsDataResult. </summary>
        /// <param name="consoleScreenshotBlobUri">
        /// The console screenshot blob URI
        /// Serialized Name: RetrieveBootDiagnosticsDataResult.consoleScreenshotBlobUri
        /// </param>
        /// <param name="serialConsoleLogBlobUri">
        /// The serial console log blob URI.
        /// Serialized Name: RetrieveBootDiagnosticsDataResult.serialConsoleLogBlobUri
        /// </param>
        /// <returns> A new <see cref="Models.RetrieveBootDiagnosticsDataResult"/> instance for mocking. </returns>
        public static RetrieveBootDiagnosticsDataResult RetrieveBootDiagnosticsDataResult(Uri consoleScreenshotBlobUri = null, Uri serialConsoleLogBlobUri = null)
        {
            return new RetrieveBootDiagnosticsDataResult(consoleScreenshotBlobUri, serialConsoleLogBlobUri);
        }

        /// <summary> Initializes a new instance of VirtualMachineAssessPatchesResult. </summary>
        /// <param name="status">
        /// The overall success or failure status of the operation. It remains "InProgress" until the operation completes. At that point it will become "Failed", "Succeeded", or "CompletedWithWarnings."
        /// Serialized Name: VirtualMachineAssessPatchesResult.status
        /// </param>
        /// <param name="assessmentActivityId">
        /// The activity ID of the operation that produced this result. It is used to correlate across CRP and extension logs.
        /// Serialized Name: VirtualMachineAssessPatchesResult.assessmentActivityId
        /// </param>
        /// <param name="rebootPending">
        /// The overall reboot status of the VM. It will be true when partially installed patches require a reboot to complete installation but the reboot has not yet occurred.
        /// Serialized Name: VirtualMachineAssessPatchesResult.rebootPending
        /// </param>
        /// <param name="criticalAndSecurityPatchCount">
        /// The number of critical or security patches that have been detected as available and not yet installed.
        /// Serialized Name: VirtualMachineAssessPatchesResult.criticalAndSecurityPatchCount
        /// </param>
        /// <param name="otherPatchCount">
        /// The number of all available patches excluding critical and security.
        /// Serialized Name: VirtualMachineAssessPatchesResult.otherPatchCount
        /// </param>
        /// <param name="startOn">
        /// The UTC timestamp when the operation began.
        /// Serialized Name: VirtualMachineAssessPatchesResult.startDateTime
        /// </param>
        /// <param name="patches">
        /// The list of patches that have been detected as available for installation.
        /// Serialized Name: VirtualMachineAssessPatchesResult.patches
        /// </param>
        /// <param name="error">
        /// The errors that were encountered during execution of the operation. The details array contains the list of them.
        /// Serialized Name: VirtualMachineAssessPatchesResult.error
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineAssessPatchesResult"/> instance for mocking. </returns>
        public static VirtualMachineAssessPatchesResult VirtualMachineAssessPatchesResult(PatchOperationStatus? status = null, string assessmentActivityId = null, bool? rebootPending = null, int? criticalAndSecurityPatchCount = null, int? otherPatchCount = null, DateTimeOffset? startOn = null, IEnumerable<VirtualMachineSoftwarePatchProperties> patches = null, ApiError error = null)
        {
            patches ??= new List<VirtualMachineSoftwarePatchProperties>();

            return new VirtualMachineAssessPatchesResult(status, assessmentActivityId, rebootPending, criticalAndSecurityPatchCount, otherPatchCount, startOn, patches?.ToList(), error);
        }

        /// <summary> Initializes a new instance of VirtualMachineSoftwarePatchProperties. </summary>
        /// <param name="patchId">
        /// A unique identifier for the patch.
        /// Serialized Name: VirtualMachineSoftwarePatchProperties.patchId
        /// </param>
        /// <param name="name">
        /// The friendly name of the patch.
        /// Serialized Name: VirtualMachineSoftwarePatchProperties.name
        /// </param>
        /// <param name="version">
        /// The version number of the patch. This property applies only to Linux patches.
        /// Serialized Name: VirtualMachineSoftwarePatchProperties.version
        /// </param>
        /// <param name="kbid">
        /// The KBID of the patch. Only applies to Windows patches.
        /// Serialized Name: VirtualMachineSoftwarePatchProperties.kbid
        /// </param>
        /// <param name="classifications">
        /// The classification(s) of the patch as provided by the patch publisher.
        /// Serialized Name: VirtualMachineSoftwarePatchProperties.classifications
        /// </param>
        /// <param name="rebootBehavior">
        /// Describes the reboot requirements of the patch.
        /// Serialized Name: VirtualMachineSoftwarePatchProperties.rebootBehavior
        /// </param>
        /// <param name="activityId">
        /// The activity ID of the operation that produced this result. It is used to correlate across CRP and extension logs.
        /// Serialized Name: VirtualMachineSoftwarePatchProperties.activityId
        /// </param>
        /// <param name="publishedOn">
        /// The UTC timestamp when the repository published this patch.
        /// Serialized Name: VirtualMachineSoftwarePatchProperties.publishedDate
        /// </param>
        /// <param name="lastModifiedOn">
        /// The UTC timestamp of the last update to this patch record.
        /// Serialized Name: VirtualMachineSoftwarePatchProperties.lastModifiedDateTime
        /// </param>
        /// <param name="assessmentState">
        /// Describes the outcome of an install operation for a given patch.
        /// Serialized Name: VirtualMachineSoftwarePatchProperties.assessmentState
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineSoftwarePatchProperties"/> instance for mocking. </returns>
        public static VirtualMachineSoftwarePatchProperties VirtualMachineSoftwarePatchProperties(string patchId = null, string name = null, string version = null, string kbid = null, IEnumerable<string> classifications = null, SoftwareUpdateRebootBehavior? rebootBehavior = null, string activityId = null, DateTimeOffset? publishedOn = null, DateTimeOffset? lastModifiedOn = null, PatchAssessmentState? assessmentState = null)
        {
            classifications ??= new List<string>();

            return new VirtualMachineSoftwarePatchProperties(patchId, name, version, kbid, classifications?.ToList(), rebootBehavior, activityId, publishedOn, lastModifiedOn, assessmentState);
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku">
        /// The virtual machine scale set sku.
        /// Serialized Name: VirtualMachineScaleSet.sku
        /// </param>
        /// <param name="plan">
        /// Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**.
        /// Serialized Name: VirtualMachineScaleSet.plan
        /// </param>
        /// <param name="identity">
        /// The identity of the virtual machine scale set, if configured.
        /// Serialized Name: VirtualMachineScaleSet.identity
        /// </param>
        /// <param name="zones">
        /// The virtual machine scale set zones. NOTE: Availability zones can only be set when you create the scale set
        /// Serialized Name: VirtualMachineScaleSet.zones
        /// </param>
        /// <param name="upgradePolicy">
        /// The upgrade policy.
        /// Serialized Name: VirtualMachineScaleSet.properties.upgradePolicy
        /// </param>
        /// <param name="automaticRepairsPolicy">
        /// Policy for automatic repairs.
        /// Serialized Name: VirtualMachineScaleSet.properties.automaticRepairsPolicy
        /// </param>
        /// <param name="virtualMachineProfile">
        /// The virtual machine profile.
        /// Serialized Name: VirtualMachineScaleSet.properties.virtualMachineProfile
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineScaleSet.properties.provisioningState
        /// </param>
        /// <param name="overprovision">
        /// Specifies whether the Virtual Machine Scale Set should be overprovisioned.
        /// Serialized Name: VirtualMachineScaleSet.properties.overprovision
        /// </param>
        /// <param name="doNotRunExtensionsOnOverprovisionedVMs">
        /// When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept. This property will hence ensure that the extensions do not run on the extra overprovisioned VMs.
        /// Serialized Name: VirtualMachineScaleSet.properties.doNotRunExtensionsOnOverprovisionedVMs
        /// </param>
        /// <param name="uniqueId">
        /// Specifies the ID which uniquely identifies a Virtual Machine Scale Set.
        /// Serialized Name: VirtualMachineScaleSet.properties.uniqueId
        /// </param>
        /// <param name="singlePlacementGroup">
        /// When true this limits the scale set to a single placement group, of max size 100 virtual machines. NOTE: If singlePlacementGroup is true, it may be modified to false. However, if singlePlacementGroup is false, it may not be modified to true.
        /// Serialized Name: VirtualMachineScaleSet.properties.singlePlacementGroup
        /// </param>
        /// <param name="zoneBalance">
        /// Whether to force strictly even Virtual Machine distribution cross x-zones in case there is zone outage.
        /// Serialized Name: VirtualMachineScaleSet.properties.zoneBalance
        /// </param>
        /// <param name="platformFaultDomainCount">
        /// Fault Domain count for each placement group.
        /// Serialized Name: VirtualMachineScaleSet.properties.platformFaultDomainCount
        /// </param>
        /// <param name="proximityPlacementGroupId">
        /// Specifies information about the proximity placement group that the virtual machine scale set should be assigned to. &lt;br&gt;&lt;br&gt;Minimum api-version: 2018-04-01.
        /// Serialized Name: VirtualMachineScaleSet.properties.proximityPlacementGroup
        /// </param>
        /// <param name="hostGroupId">
        /// Specifies information about the dedicated host group that the virtual machine scale set resides in. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: VirtualMachineScaleSet.properties.hostGroup
        /// </param>
        /// <param name="ultraSSDEnabled">
        /// Specifies additional capabilities enabled or disabled on the Virtual Machines in the Virtual Machine Scale Set. For instance: whether the Virtual Machines have the capability to support attaching managed data disks with UltraSSD_LRS storage account type.
        /// Serialized Name: VirtualMachineScaleSet.properties.additionalCapabilities
        /// </param>
        /// <param name="scaleInRules">
        /// Specifies the scale-in policy that decides which virtual machines are chosen for removal when a Virtual Machine Scale Set is scaled-in.
        /// Serialized Name: VirtualMachineScaleSet.properties.scaleInPolicy
        /// </param>
        /// <returns> A new <see cref="Sample.VirtualMachineScaleSetData"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetData VirtualMachineScaleSetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, SampleSku sku = null, SamplePlan plan = null, ManagedServiceIdentity identity = null, IEnumerable<string> zones = null, UpgradePolicy upgradePolicy = null, AutomaticRepairsPolicy automaticRepairsPolicy = null, VirtualMachineScaleSetVMProfile virtualMachineProfile = null, string provisioningState = null, bool? overprovision = null, bool? doNotRunExtensionsOnOverprovisionedVMs = null, string uniqueId = null, bool? singlePlacementGroup = null, bool? zoneBalance = null, int? platformFaultDomainCount = null, ResourceIdentifier proximityPlacementGroupId = null, ResourceIdentifier hostGroupId = null, bool? ultraSSDEnabled = null, IEnumerable<VirtualMachineScaleSetScaleInRule> scaleInRules = null)
        {
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();
            scaleInRules ??= new List<VirtualMachineScaleSetScaleInRule>();

            return new VirtualMachineScaleSetData(id, name, resourceType, systemData, tags, location, sku, plan, identity, zones?.ToList(), upgradePolicy, automaticRepairsPolicy, virtualMachineProfile, provisioningState, overprovision, doNotRunExtensionsOnOverprovisionedVMs, uniqueId, singlePlacementGroup, zoneBalance, platformFaultDomainCount, proximityPlacementGroupId != null ? ResourceManagerModelFactory.WritableSubResource(proximityPlacementGroupId) : null, hostGroupId != null ? ResourceManagerModelFactory.WritableSubResource(hostGroupId) : null, ultraSSDEnabled != null ? new AdditionalCapabilities(ultraSSDEnabled) : null, scaleInRules != null ? new ScaleInPolicy(scaleInRules?.ToList()) : null);
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionData. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResourceReadOnly.id
        /// </param>
        /// <param name="name">
        /// The name of the extension.
        /// Serialized Name: VirtualMachineScaleSetExtension.name
        /// </param>
        /// <param name="resourceType">
        /// Resource type
        /// Serialized Name: VirtualMachineScaleSetExtension.type
        /// </param>
        /// <param name="forceUpdateTag">
        /// If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed.
        /// Serialized Name: VirtualMachineScaleSetExtension.properties.forceUpdateTag
        /// </param>
        /// <param name="publisher">
        /// The name of the extension handler publisher.
        /// Serialized Name: VirtualMachineScaleSetExtension.properties.publisher
        /// </param>
        /// <param name="extensionType">
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineScaleSetExtension.properties.type
        /// </param>
        /// <param name="typeHandlerVersion">
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineScaleSetExtension.properties.typeHandlerVersion
        /// </param>
        /// <param name="autoUpgradeMinorVersion">
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// Serialized Name: VirtualMachineScaleSetExtension.properties.autoUpgradeMinorVersion
        /// </param>
        /// <param name="enableAutomaticUpgrade">
        /// Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
        /// Serialized Name: VirtualMachineScaleSetExtension.properties.enableAutomaticUpgrade
        /// </param>
        /// <param name="settings">
        /// Json formatted public settings for the extension.
        /// Serialized Name: VirtualMachineScaleSetExtension.properties.settings
        /// </param>
        /// <param name="protectedSettings">
        /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
        /// Serialized Name: VirtualMachineScaleSetExtension.properties.protectedSettings
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineScaleSetExtension.properties.provisioningState
        /// </param>
        /// <param name="provisionAfterExtensions">
        /// Collection of extension names after which this extension needs to be provisioned.
        /// Serialized Name: VirtualMachineScaleSetExtension.properties.provisionAfterExtensions
        /// </param>
        /// <returns> A new <see cref="Sample.VirtualMachineScaleSetExtensionData"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetExtensionData VirtualMachineScaleSetExtensionData(string id = null, string name = null, ResourceType? resourceType = null, string forceUpdateTag = null, string publisher = null, string extensionType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = null, bool? enableAutomaticUpgrade = null, BinaryData settings = null, BinaryData protectedSettings = null, string provisioningState = null, IEnumerable<string> provisionAfterExtensions = null)
        {
            provisionAfterExtensions ??= new List<string>();

            return new VirtualMachineScaleSetExtensionData(id, name, resourceType, forceUpdateTag, publisher, extensionType, typeHandlerVersion, autoUpgradeMinorVersion, enableAutomaticUpgrade, settings, protectedSettings, provisioningState, provisionAfterExtensions?.ToList());
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetInstanceView. </summary>
        /// <param name="virtualMachineStatusesSummary">
        /// The instance view status summary for the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.virtualMachine
        /// </param>
        /// <param name="extensions">
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.extensions
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.statuses
        /// </param>
        /// <param name="orchestrationServices">
        /// The orchestration services information.
        /// Serialized Name: VirtualMachineScaleSetInstanceView.orchestrationServices
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineScaleSetInstanceView"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetInstanceView VirtualMachineScaleSetInstanceView(IEnumerable<VirtualMachineStatusCodeCount> virtualMachineStatusesSummary = null, IEnumerable<VirtualMachineScaleSetVMExtensionsSummary> extensions = null, IEnumerable<InstanceViewStatus> statuses = null, IEnumerable<OrchestrationServiceSummary> orchestrationServices = null)
        {
            virtualMachineStatusesSummary ??= new List<VirtualMachineStatusCodeCount>();
            extensions ??= new List<VirtualMachineScaleSetVMExtensionsSummary>();
            statuses ??= new List<InstanceViewStatus>();
            orchestrationServices ??= new List<OrchestrationServiceSummary>();

            return new VirtualMachineScaleSetInstanceView(virtualMachineStatusesSummary != null ? new VirtualMachineScaleSetInstanceViewStatusesSummary(virtualMachineStatusesSummary?.ToList()) : null, extensions?.ToList(), statuses?.ToList(), orchestrationServices?.ToList());
        }

        /// <summary> Initializes a new instance of VirtualMachineStatusCodeCount. </summary>
        /// <param name="code">
        /// The instance view status code.
        /// Serialized Name: VirtualMachineStatusCodeCount.code
        /// </param>
        /// <param name="count">
        /// The number of instances having a particular status code.
        /// Serialized Name: VirtualMachineStatusCodeCount.count
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineStatusCodeCount"/> instance for mocking. </returns>
        public static VirtualMachineStatusCodeCount VirtualMachineStatusCodeCount(string code = null, int? count = null)
        {
            return new VirtualMachineStatusCodeCount(code, count);
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMExtensionsSummary. </summary>
        /// <param name="name">
        /// The extension name.
        /// Serialized Name: VirtualMachineScaleSetVMExtensionsSummary.name
        /// </param>
        /// <param name="statusesSummary">
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetVMExtensionsSummary.statusesSummary
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineScaleSetVMExtensionsSummary"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetVMExtensionsSummary VirtualMachineScaleSetVMExtensionsSummary(string name = null, IEnumerable<VirtualMachineStatusCodeCount> statusesSummary = null)
        {
            statusesSummary ??= new List<VirtualMachineStatusCodeCount>();

            return new VirtualMachineScaleSetVMExtensionsSummary(name, statusesSummary?.ToList());
        }

        /// <summary> Initializes a new instance of OrchestrationServiceSummary. </summary>
        /// <param name="serviceName">
        /// The name of the service.
        /// Serialized Name: OrchestrationServiceSummary.serviceName
        /// </param>
        /// <param name="serviceState">
        /// The current state of the service.
        /// Serialized Name: OrchestrationServiceSummary.serviceState
        /// </param>
        /// <returns> A new <see cref="Models.OrchestrationServiceSummary"/> instance for mocking. </returns>
        public static OrchestrationServiceSummary OrchestrationServiceSummary(OrchestrationServiceName? serviceName = null, OrchestrationServiceState? serviceState = null)
        {
            return new OrchestrationServiceSummary(serviceName, serviceState);
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetExtensionPatch. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="forceUpdateTag">
        /// If a value is provided and is different from the previous value, the extension handler will be forced to update even if the extension configuration has not changed.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.forceUpdateTag
        /// </param>
        /// <param name="publisher">
        /// The name of the extension handler publisher.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.publisher
        /// </param>
        /// <param name="typePropertiesType">
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.type
        /// </param>
        /// <param name="typeHandlerVersion">
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.typeHandlerVersion
        /// </param>
        /// <param name="autoUpgradeMinorVersion">
        /// Indicates whether the extension should use a newer minor version if one is available at deployment time. Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.autoUpgradeMinorVersion
        /// </param>
        /// <param name="enableAutomaticUpgrade">
        /// Indicates whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.enableAutomaticUpgrade
        /// </param>
        /// <param name="settings">
        /// Json formatted public settings for the extension.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.settings
        /// </param>
        /// <param name="protectedSettings">
        /// The extension can contain either protectedSettings or protectedSettingsFromKeyVault or no protected settings at all.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.protectedSettings
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.provisioningState
        /// </param>
        /// <param name="provisionAfterExtensions">
        /// Collection of extension names after which this extension needs to be provisioned.
        /// Serialized Name: VirtualMachineScaleSetExtensionUpdate.properties.provisionAfterExtensions
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineScaleSetExtensionPatch"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetExtensionPatch VirtualMachineScaleSetExtensionPatch(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string forceUpdateTag = null, string publisher = null, string typePropertiesType = null, string typeHandlerVersion = null, bool? autoUpgradeMinorVersion = null, bool? enableAutomaticUpgrade = null, BinaryData settings = null, BinaryData protectedSettings = null, string provisioningState = null, IEnumerable<string> provisionAfterExtensions = null)
        {
            provisionAfterExtensions ??= new List<string>();

            return new VirtualMachineScaleSetExtensionPatch(id, name, resourceType, systemData, forceUpdateTag, publisher, typePropertiesType, typeHandlerVersion, autoUpgradeMinorVersion, enableAutomaticUpgrade, settings, protectedSettings, provisioningState, provisionAfterExtensions?.ToList());
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetSku. </summary>
        /// <param name="resourceType">
        /// The type of resource the sku applies to.
        /// Serialized Name: VirtualMachineScaleSetSku.resourceType
        /// </param>
        /// <param name="sku">
        /// The Sku.
        /// Serialized Name: VirtualMachineScaleSetSku.sku
        /// </param>
        /// <param name="capacity">
        /// Specifies the number of virtual machines in the scale set.
        /// Serialized Name: VirtualMachineScaleSetSku.capacity
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineScaleSetSku"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetSku VirtualMachineScaleSetSku(ResourceType? resourceType = null, SampleSku sku = null, VirtualMachineScaleSetSkuCapacity capacity = null)
        {
            return new VirtualMachineScaleSetSku(resourceType, sku, capacity);
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetSkuCapacity. </summary>
        /// <param name="minimum">
        /// The minimum capacity.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.minimum
        /// </param>
        /// <param name="maximum">
        /// The maximum capacity that can be set.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.maximum
        /// </param>
        /// <param name="defaultCapacity">
        /// The default capacity.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.defaultCapacity
        /// </param>
        /// <param name="scaleType">
        /// The scale type applicable to the sku.
        /// Serialized Name: VirtualMachineScaleSetSkuCapacity.scaleType
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineScaleSetSkuCapacity"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetSkuCapacity VirtualMachineScaleSetSkuCapacity(long? minimum = null, long? maximum = null, long? defaultCapacity = null, VirtualMachineScaleSetSkuScaleType? scaleType = null)
        {
            return new VirtualMachineScaleSetSkuCapacity(minimum, maximum, defaultCapacity, scaleType);
        }

        /// <summary> Initializes a new instance of UpgradeOperationHistoricalStatusInfo. </summary>
        /// <param name="properties">
        /// Information about the properties of the upgrade operation.
        /// Serialized Name: UpgradeOperationHistoricalStatusInfo.properties
        /// </param>
        /// <param name="upgradeOperationHistoricalStatusInfoType">
        /// Resource type
        /// Serialized Name: UpgradeOperationHistoricalStatusInfo.type
        /// </param>
        /// <param name="location">
        /// Resource location
        /// Serialized Name: UpgradeOperationHistoricalStatusInfo.location
        /// </param>
        /// <returns> A new <see cref="Models.UpgradeOperationHistoricalStatusInfo"/> instance for mocking. </returns>
        public static UpgradeOperationHistoricalStatusInfo UpgradeOperationHistoricalStatusInfo(UpgradeOperationHistoricalStatusInfoProperties properties = null, string upgradeOperationHistoricalStatusInfoType = null, AzureLocation? location = null)
        {
            return new UpgradeOperationHistoricalStatusInfo(properties, upgradeOperationHistoricalStatusInfoType, location);
        }

        /// <summary> Initializes a new instance of UpgradeOperationHistoricalStatusInfoProperties. </summary>
        /// <param name="runningStatus">
        /// Information about the overall status of the upgrade operation.
        /// Serialized Name: UpgradeOperationHistoricalStatusInfoProperties.runningStatus
        /// </param>
        /// <param name="progress">
        /// Counts of the VMs in each state.
        /// Serialized Name: UpgradeOperationHistoricalStatusInfoProperties.progress
        /// </param>
        /// <param name="error">
        /// Error Details for this upgrade if there are any.
        /// Serialized Name: UpgradeOperationHistoricalStatusInfoProperties.error
        /// </param>
        /// <param name="startedBy">
        /// Invoker of the Upgrade Operation
        /// Serialized Name: UpgradeOperationHistoricalStatusInfoProperties.startedBy
        /// </param>
        /// <param name="targetImageReference">
        /// Image Reference details
        /// Serialized Name: UpgradeOperationHistoricalStatusInfoProperties.targetImageReference
        /// </param>
        /// <param name="rollbackInfo">
        /// Information about OS rollback if performed
        /// Serialized Name: UpgradeOperationHistoricalStatusInfoProperties.rollbackInfo
        /// </param>
        /// <returns> A new <see cref="Models.UpgradeOperationHistoricalStatusInfoProperties"/> instance for mocking. </returns>
        public static UpgradeOperationHistoricalStatusInfoProperties UpgradeOperationHistoricalStatusInfoProperties(UpgradeOperationHistoryStatus runningStatus = null, RollingUpgradeProgressInfo progress = null, ApiError error = null, UpgradeOperationInvoker? startedBy = null, ImageReference targetImageReference = null, RollbackStatusInfo rollbackInfo = null)
        {
            return new UpgradeOperationHistoricalStatusInfoProperties(runningStatus, progress, error, startedBy, targetImageReference, rollbackInfo);
        }

        /// <summary> Initializes a new instance of UpgradeOperationHistoryStatus. </summary>
        /// <param name="code">
        /// Code indicating the current status of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.code
        /// </param>
        /// <param name="startOn">
        /// Start time of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.startTime
        /// </param>
        /// <param name="endOn">
        /// End time of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.endTime
        /// </param>
        /// <returns> A new <see cref="Models.UpgradeOperationHistoryStatus"/> instance for mocking. </returns>
        public static UpgradeOperationHistoryStatus UpgradeOperationHistoryStatus(UpgradeState? code = null, DateTimeOffset? startOn = null, DateTimeOffset? endOn = null)
        {
            return new UpgradeOperationHistoryStatus(code, startOn, endOn);
        }

        /// <summary> Initializes a new instance of RollingUpgradeProgressInfo. </summary>
        /// <param name="successfulInstanceCount">
        /// The number of instances that have been successfully upgraded.
        /// Serialized Name: RollingUpgradeProgressInfo.successfulInstanceCount
        /// </param>
        /// <param name="failedInstanceCount">
        /// The number of instances that have failed to be upgraded successfully.
        /// Serialized Name: RollingUpgradeProgressInfo.failedInstanceCount
        /// </param>
        /// <param name="inProgressInstanceCount">
        /// The number of instances that are currently being upgraded.
        /// Serialized Name: RollingUpgradeProgressInfo.inProgressInstanceCount
        /// </param>
        /// <param name="pendingInstanceCount">
        /// The number of instances that have not yet begun to be upgraded.
        /// Serialized Name: RollingUpgradeProgressInfo.pendingInstanceCount
        /// </param>
        /// <returns> A new <see cref="Models.RollingUpgradeProgressInfo"/> instance for mocking. </returns>
        public static RollingUpgradeProgressInfo RollingUpgradeProgressInfo(int? successfulInstanceCount = null, int? failedInstanceCount = null, int? inProgressInstanceCount = null, int? pendingInstanceCount = null)
        {
            return new RollingUpgradeProgressInfo(successfulInstanceCount, failedInstanceCount, inProgressInstanceCount, pendingInstanceCount);
        }

        /// <summary> Initializes a new instance of RollbackStatusInfo. </summary>
        /// <param name="successfullyRolledbackInstanceCount">
        /// The number of instances which have been successfully rolled back.
        /// Serialized Name: RollbackStatusInfo.successfullyRolledbackInstanceCount
        /// </param>
        /// <param name="failedRolledbackInstanceCount">
        /// The number of instances which failed to rollback.
        /// Serialized Name: RollbackStatusInfo.failedRolledbackInstanceCount
        /// </param>
        /// <param name="rollbackError">
        /// Error details if OS rollback failed.
        /// Serialized Name: RollbackStatusInfo.rollbackError
        /// </param>
        /// <returns> A new <see cref="Models.RollbackStatusInfo"/> instance for mocking. </returns>
        public static RollbackStatusInfo RollbackStatusInfo(int? successfullyRolledbackInstanceCount = null, int? failedRolledbackInstanceCount = null, ApiError rollbackError = null)
        {
            return new RollbackStatusInfo(successfullyRolledbackInstanceCount, failedRolledbackInstanceCount, rollbackError);
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetRollingUpgradeData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="policy">
        /// The rolling upgrade policies applied for this upgrade.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.policy
        /// </param>
        /// <param name="runningStatus">
        /// Information about the current running state of the overall upgrade.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.runningStatus
        /// </param>
        /// <param name="progress">
        /// Information about the number of virtual machine instances in each upgrade state.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.progress
        /// </param>
        /// <param name="error">
        /// Error details for this upgrade, if there are any.
        /// Serialized Name: RollingUpgradeStatusInfo.properties.error
        /// </param>
        /// <returns> A new <see cref="Sample.VirtualMachineScaleSetRollingUpgradeData"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetRollingUpgradeData VirtualMachineScaleSetRollingUpgradeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, RollingUpgradePolicy policy = null, RollingUpgradeRunningStatus runningStatus = null, RollingUpgradeProgressInfo progress = null, ApiError error = null)
        {
            tags ??= new Dictionary<string, string>();

            return new VirtualMachineScaleSetRollingUpgradeData(id, name, resourceType, systemData, tags, location, policy, runningStatus, progress, error);
        }

        /// <summary> Initializes a new instance of RollingUpgradeRunningStatus. </summary>
        /// <param name="code">
        /// Code indicating the current status of the upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.code
        /// </param>
        /// <param name="startOn">
        /// Start time of the upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.startTime
        /// </param>
        /// <param name="lastAction">
        /// The last action performed on the rolling upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.lastAction
        /// </param>
        /// <param name="lastActionOn">
        /// Last action time of the upgrade.
        /// Serialized Name: RollingUpgradeRunningStatus.lastActionTime
        /// </param>
        /// <returns> A new <see cref="Models.RollingUpgradeRunningStatus"/> instance for mocking. </returns>
        public static RollingUpgradeRunningStatus RollingUpgradeRunningStatus(RollingUpgradeStatusCode? code = null, DateTimeOffset? startOn = null, RollingUpgradeActionType? lastAction = null, DateTimeOffset? lastActionOn = null)
        {
            return new RollingUpgradeRunningStatus(code, startOn, lastAction, lastActionOn);
        }

        /// <summary> Initializes a new instance of RecoveryWalkResponse. </summary>
        /// <param name="walkPerformed">
        /// Whether the recovery walk was performed
        /// Serialized Name: RecoveryWalkResponse.walkPerformed
        /// </param>
        /// <param name="nextPlatformUpdateDomain">
        /// The next update domain that needs to be walked. Null means walk spanning all update domains has been completed
        /// Serialized Name: RecoveryWalkResponse.nextPlatformUpdateDomain
        /// </param>
        /// <returns> A new <see cref="Models.RecoveryWalkResponse"/> instance for mocking. </returns>
        public static RecoveryWalkResponse RecoveryWalkResponse(bool? walkPerformed = null, int? nextPlatformUpdateDomain = null)
        {
            return new RecoveryWalkResponse(walkPerformed, nextPlatformUpdateDomain);
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="instanceId">
        /// The virtual machine instance ID.
        /// Serialized Name: VirtualMachineScaleSetVM.instanceId
        /// </param>
        /// <param name="sku">
        /// The virtual machine SKU.
        /// Serialized Name: VirtualMachineScaleSetVM.sku
        /// </param>
        /// <param name="plan">
        /// Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**.
        /// Serialized Name: VirtualMachineScaleSetVM.plan
        /// </param>
        /// <param name="resources">
        /// The virtual machine child extension resources.
        /// Serialized Name: VirtualMachineScaleSetVM.resources
        /// </param>
        /// <param name="zones">
        /// The virtual machine zones.
        /// Serialized Name: VirtualMachineScaleSetVM.zones
        /// </param>
        /// <param name="latestModelApplied">
        /// Specifies whether the latest model has been applied to the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.latestModelApplied
        /// </param>
        /// <param name="vmId">
        /// Azure VM unique ID.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.vmId
        /// </param>
        /// <param name="instanceView">
        /// The virtual machine instance view.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.instanceView
        /// </param>
        /// <param name="hardwareVmSize">
        /// Specifies the hardware settings for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.hardwareProfile
        /// </param>
        /// <param name="storageProfile">
        /// Specifies the storage settings for the virtual machine disks.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.storageProfile
        /// </param>
        /// <param name="ultraSSDEnabled">
        /// Specifies additional capabilities enabled or disabled on the virtual machine in the scale set. For instance: whether the virtual machine has the capability to support attaching managed data disks with UltraSSD_LRS storage account type.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.additionalCapabilities
        /// </param>
        /// <param name="osProfile">
        /// Specifies the operating system settings for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.osProfile
        /// </param>
        /// <param name="encryptionAtHost">
        /// Specifies the Security related profile settings for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.securityProfile
        /// </param>
        /// <param name="networkInterfaces">
        /// Specifies the network interfaces of the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.networkProfile
        /// </param>
        /// <param name="networkInterfaceConfigurations">
        /// Specifies the network profile configuration of the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.networkProfileConfiguration
        /// </param>
        /// <param name="bootDiagnostics">
        /// Specifies the boot diagnostic settings state. &lt;br&gt;&lt;br&gt;Minimum api-version: 2015-06-15.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.diagnosticsProfile
        /// </param>
        /// <param name="availabilitySetId">
        /// Specifies information about the availability set that the virtual machine should be assigned to. Virtual machines specified in the same availability set are allocated to different nodes to maximize availability. For more information about availability sets, see [Manage the availability of virtual machines](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-manage-availability?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json). &lt;br&gt;&lt;br&gt; For more information on Azure planned maintenance, see [Planned maintenance for virtual machines in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-planned-maintenance?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Currently, a VM can only be added to availability set at creation time. An existing VM cannot be added to an availability set.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.availabilitySet
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state, which only appears in the response.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.provisioningState
        /// </param>
        /// <param name="licenseType">
        /// Specifies that the image or disk that is being used was licensed on-premises. This element is only used for images that contain the Windows Server operating system. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; Windows_Client &lt;br&gt;&lt;br&gt; Windows_Server &lt;br&gt;&lt;br&gt; If this element is included in a request for an update, the value must match the initial value. This value cannot be updated. &lt;br&gt;&lt;br&gt; For more information, see [Azure Hybrid Use Benefit for Windows Server](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-windows-hybrid-use-benefit-licensing?toc=%2fazure%2fvirtual-machines%2fwindows%2ftoc.json) &lt;br&gt;&lt;br&gt; Minimum api-version: 2015-06-15
        /// Serialized Name: VirtualMachineScaleSetVM.properties.licenseType
        /// </param>
        /// <param name="modelDefinitionApplied">
        /// Specifies whether the model applied to the virtual machine is the model of the virtual machine scale set or the customized model for the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.modelDefinitionApplied
        /// </param>
        /// <param name="protectionPolicy">
        /// Specifies the protection policy of the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVM.properties.protectionPolicy
        /// </param>
        /// <returns> A new <see cref="Sample.VirtualMachineScaleSetVMData"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetVMData VirtualMachineScaleSetVMData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string instanceId = null, SampleSku sku = null, SamplePlan plan = null, IEnumerable<VirtualMachineExtensionData> resources = null, IEnumerable<string> zones = null, bool? latestModelApplied = null, string vmId = null, VirtualMachineScaleSetVMInstanceView instanceView = null, VirtualMachineSizeType? hardwareVmSize = null, StorageProfile storageProfile = null, bool? ultraSSDEnabled = null, OSProfile osProfile = null, bool? encryptionAtHost = null, IEnumerable<NetworkInterfaceReference> networkInterfaces = null, IEnumerable<VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations = null, BootDiagnostics bootDiagnostics = null, ResourceIdentifier availabilitySetId = null, string provisioningState = null, string licenseType = null, string modelDefinitionApplied = null, VirtualMachineScaleSetVMProtectionPolicy protectionPolicy = null)
        {
            tags ??= new Dictionary<string, string>();
            resources ??= new List<VirtualMachineExtensionData>();
            zones ??= new List<string>();
            networkInterfaces ??= new List<NetworkInterfaceReference>();
            networkInterfaceConfigurations ??= new List<VirtualMachineScaleSetNetworkConfiguration>();

            return new VirtualMachineScaleSetVMData(id, name, resourceType, systemData, tags, location, instanceId, sku, plan, resources?.ToList(), zones?.ToList(), latestModelApplied, vmId, instanceView, hardwareVmSize != null ? new HardwareProfile(hardwareVmSize) : null, storageProfile, ultraSSDEnabled != null ? new AdditionalCapabilities(ultraSSDEnabled) : null, osProfile, encryptionAtHost != null ? new SecurityProfile(encryptionAtHost) : null, networkInterfaces != null ? new NetworkProfile(networkInterfaces?.ToList()) : null, networkInterfaceConfigurations != null ? new VirtualMachineScaleSetVMNetworkProfileConfiguration(networkInterfaceConfigurations?.ToList()) : null, bootDiagnostics != null ? new DiagnosticsProfile(bootDiagnostics) : null, availabilitySetId != null ? ResourceManagerModelFactory.WritableSubResource(availabilitySetId) : null, provisioningState, licenseType, modelDefinitionApplied, protectionPolicy);
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMInstanceView. </summary>
        /// <param name="platformUpdateDomain">
        /// The Update Domain count.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.platformUpdateDomain
        /// </param>
        /// <param name="platformFaultDomain">
        /// The Fault Domain count.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.platformFaultDomain
        /// </param>
        /// <param name="rdpThumbPrint">
        /// The Remote desktop certificate thumbprint.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.rdpThumbPrint
        /// </param>
        /// <param name="vmAgent">
        /// The VM Agent running on the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.vmAgent
        /// </param>
        /// <param name="maintenanceRedeployStatus">
        /// The Maintenance Operation status on the virtual machine.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.maintenanceRedeployStatus
        /// </param>
        /// <param name="disks">
        /// The disks information.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.disks
        /// </param>
        /// <param name="extensions">
        /// The extensions information.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.extensions
        /// </param>
        /// <param name="vmHealthStatus">
        /// The health status for the VM.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.vmHealth
        /// </param>
        /// <param name="bootDiagnostics">
        /// Boot Diagnostics is a debugging feature which allows you to view Console Output and Screenshot to diagnose VM status. &lt;br&gt;&lt;br&gt; You can easily view the output of your console log. &lt;br&gt;&lt;br&gt; Azure also enables you to see a screenshot of the VM from the hypervisor.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.bootDiagnostics
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.statuses
        /// </param>
        /// <param name="assignedHost">
        /// Resource id of the dedicated host, on which the virtual machine is allocated through automatic placement, when the virtual machine is associated with a dedicated host group that has automatic placement enabled. &lt;br&gt;&lt;br&gt;Minimum api-version: 2020-06-01.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.assignedHost
        /// </param>
        /// <param name="placementGroupId">
        /// The placement group in which the VM is running. If the VM is deallocated it will not have a placementGroupId.
        /// Serialized Name: VirtualMachineScaleSetVMInstanceView.placementGroupId
        /// </param>
        /// <returns> A new <see cref="Models.VirtualMachineScaleSetVMInstanceView"/> instance for mocking. </returns>
        public static VirtualMachineScaleSetVMInstanceView VirtualMachineScaleSetVMInstanceView(int? platformUpdateDomain = null, int? platformFaultDomain = null, string rdpThumbPrint = null, VirtualMachineAgentInstanceView vmAgent = null, MaintenanceRedeployStatus maintenanceRedeployStatus = null, IEnumerable<DiskInstanceView> disks = null, IEnumerable<VirtualMachineExtensionInstanceView> extensions = null, InstanceViewStatus vmHealthStatus = null, BootDiagnosticsInstanceView bootDiagnostics = null, IEnumerable<InstanceViewStatus> statuses = null, string assignedHost = null, string placementGroupId = null)
        {
            disks ??= new List<DiskInstanceView>();
            extensions ??= new List<VirtualMachineExtensionInstanceView>();
            statuses ??= new List<InstanceViewStatus>();

            return new VirtualMachineScaleSetVMInstanceView(platformUpdateDomain, platformFaultDomain, rdpThumbPrint, vmAgent, maintenanceRedeployStatus, disks?.ToList(), extensions?.ToList(), vmHealthStatus != null ? new VirtualMachineHealthStatus(vmHealthStatus) : null, bootDiagnostics, statuses?.ToList(), assignedHost, placementGroupId);
        }

        /// <summary> Initializes a new instance of LogAnalytics. </summary>
        /// <param name="logAnalyticsOutput">
        /// LogAnalyticsOutput
        /// Serialized Name: LogAnalyticsOperationResult.properties
        /// </param>
        /// <returns> A new <see cref="Models.LogAnalytics"/> instance for mocking. </returns>
        public static LogAnalytics LogAnalytics(string logAnalyticsOutput = null)
        {
            return new LogAnalytics(logAnalyticsOutput != null ? new LogAnalyticsOutput(logAnalyticsOutput) : null);
        }
    }
}
