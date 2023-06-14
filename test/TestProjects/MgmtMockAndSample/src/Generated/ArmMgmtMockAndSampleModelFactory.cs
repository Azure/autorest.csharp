// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtMockAndSampleModelFactory
    {
        /// <summary> Initializes a new instance of VaultProperties. </summary>
        /// <param name="duration"> Time elapsed for task. </param>
        /// <param name="createOn"> The date and time when the cluster creating. </param>
        /// <param name="tenantId"> The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault. </param>
        /// <param name="sku"> SKU details. </param>
        /// <param name="accessPolicies"> An array of 0 to 1024 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID. When `createMode` is set to `recover`, access policies are not required. Otherwise, access policies are required. </param>
        /// <param name="vaultUri"> The URI of the vault for performing operations on keys and secrets. </param>
        /// <param name="hsmPoolResourceId"> The resource id of HSM Pool. </param>
        /// <param name="deployments"> Specify a list of resource identifiers of deployment. </param>
        /// <param name="enabledForDiskEncryption"> Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys. </param>
        /// <param name="enabledForTemplateDeployment"> Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault. </param>
        /// <param name="enableSoftDelete"> Property to specify whether the 'soft delete' functionality is enabled for this key vault. If it's not set to any value(true or false) when creating new key vault, it will be set to true by default. Once set to true, it cannot be reverted to false. </param>
        /// <param name="softDeleteRetentionInDays"> softDelete data retention days. It accepts &gt;=7 and &lt;=90. </param>
        /// <param name="enableRbacAuthorization"> Property that controls how data actions are authorized. When true, the key vault will use Role Based Access Control (RBAC) for authorization of data actions, and the access policies specified in vault properties will be  ignored. When false, the key vault will use the access policies specified in vault properties, and any policy stored on Azure Resource Manager will be ignored. If null or not specified, the vault is created with the default value of false. Note that management actions are always authorized with RBAC. </param>
        /// <param name="createMode"> The vault's create mode to indicate whether the vault need to be recovered or not. </param>
        /// <param name="enablePurgeProtection"> Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible - that is, the property does not accept false as its value. </param>
        /// <param name="networkAcls"> Rules governing the accessibility of the key vault from specific network locations. </param>
        /// <param name="provisioningState"> Provisioning state of the vault. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connections associated with the key vault. </param>
        /// <param name="publicNetworkAccess"> Property to specify whether the vault will accept traffic from public internet. If set to 'disabled' all traffic except private endpoint traffic and that that originates from trusted services will be blocked. This will override the set firewall rules, meaning that even if the firewall rules are present we will not honor the rules. </param>
        /// <param name="readWriteSingleStringPropertySomething"> This is a single property of string. </param>
        /// <param name="readOnlySomething"> This is a single property of read-only string. </param>
        /// <param name="deepSomething"> This is a single property of string. </param>
        /// <returns> A new <see cref="Models.VaultProperties"/> instance for mocking. </returns>
        public static VaultProperties VaultProperties(TimeSpan? duration = null, DateTimeOffset? createOn = null, Guid tenantId = default, MgmtMockAndSampleSku sku = null, IEnumerable<AccessPolicyEntry> accessPolicies = null, Uri vaultUri = null, string hsmPoolResourceId = null, IEnumerable<string> deployments = null, bool? enabledForDiskEncryption = null, bool? enabledForTemplateDeployment = null, bool? enableSoftDelete = null, int? softDeleteRetentionInDays = null, bool? enableRbacAuthorization = null, CreateMode? createMode = null, bool? enablePurgeProtection = null, NetworkRuleSet networkAcls = null, VaultProvisioningState? provisioningState = null, IEnumerable<PrivateEndpointConnectionItem> privateEndpointConnections = null, string publicNetworkAccess = null, string readWriteSingleStringPropertySomething = null, string readOnlySomething = null, string deepSomething = null)
        {
            accessPolicies ??= new List<AccessPolicyEntry>();
            deployments ??= new List<string>();
            privateEndpointConnections ??= new List<PrivateEndpointConnectionItem>();

            return new VaultProperties(duration, createOn, tenantId, sku, accessPolicies?.ToList(), vaultUri, hsmPoolResourceId, deployments?.ToList(), enabledForDiskEncryption, enabledForTemplateDeployment, enableSoftDelete, softDeleteRetentionInDays, enableRbacAuthorization, createMode, enablePurgeProtection, networkAcls, provisioningState, privateEndpointConnections?.ToList(), publicNetworkAccess, readWriteSingleStringPropertySomething != null ? new SinglePropertyModel(readWriteSingleStringPropertySomething) : null, readOnlySomething != null ? new ReadOnlySinglePropertyModel(readOnlySomething) : null, deepSomething != null ? new ExtremelyDeepSinglePropertyModel(new SuperDeepSinglePropertyModel(new VeryDeepSinglePropertyModel(new DeepSinglePropertyModel(new SinglePropertyModel(deepSomething))))) : null);
        }

        /// <summary> Initializes a new instance of PrivateEndpointConnectionItem. </summary>
        /// <param name="id"> Id of private endpoint connection. </param>
        /// <param name="etag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpointId"> Properties of the private endpoint object. </param>
        /// <param name="connectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        /// <returns> A new <see cref="Models.PrivateEndpointConnectionItem"/> instance for mocking. </returns>
        public static PrivateEndpointConnectionItem PrivateEndpointConnectionItem(string id = null, string etag = null, ResourceIdentifier privateEndpointId = null, MgmtMockAndSamplePrivateLinkServiceConnectionState connectionState = null, MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? provisioningState = null)
        {
            return new PrivateEndpointConnectionItem(id, etag, privateEndpointId != null ? ResourceManagerModelFactory.SubResource(privateEndpointId) : null, connectionState, provisioningState);
        }

        /// <summary> Initializes a new instance of VaultData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        /// <param name="properties"> Properties of the vault. </param>
        /// <param name="identity"> Identity of the vault. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.VaultData"/> instance for mocking. </returns>
        public static VaultData VaultData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, AzureLocation? location = null, IReadOnlyDictionary<string, string> tags = null, VaultProperties properties = null, ManagedServiceIdentity identity = null)
        {
            tags ??= new Dictionary<string, string>();

            return new VaultData(id, name, resourceType, systemData, location, tags, properties, identity);
        }

        /// <summary> Initializes a new instance of VaultKey. </summary>
        /// <param name="key"> name of the key. </param>
        /// <param name="content"> content of the key. </param>
        /// <returns> A new <see cref="Models.VaultKey"/> instance for mocking. </returns>
        public static VaultKey VaultKey(string key = null, string content = null)
        {
            return new VaultKey(key, content);
        }

        /// <summary> Initializes a new instance of VaultValidationResult. </summary>
        /// <param name="issues"> The list of vaults. </param>
        /// <param name="result"> The result of the validation. </param>
        /// <returns> A new <see cref="Models.VaultValidationResult"/> instance for mocking. </returns>
        public static VaultValidationResult VaultValidationResult(IEnumerable<VaultIssue> issues = null, string result = null)
        {
            issues ??= new List<VaultIssue>();

            return new VaultValidationResult(issues?.ToList(), result);
        }

        /// <summary> Initializes a new instance of VaultIssue. </summary>
        /// <param name="vaultIssueType"> The type of the issue. </param>
        /// <param name="description"> The description of the issue. </param>
        /// <param name="sev"> The severity of the issue. </param>
        /// <returns> A new <see cref="Models.VaultIssue"/> instance for mocking. </returns>
        public static VaultIssue VaultIssue(string vaultIssueType = null, string description = null, int? sev = null)
        {
            return new VaultIssue(vaultIssueType, description, sev);
        }

        /// <summary> Initializes a new instance of VaultAccessPolicyParameters. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The resource type of the access policy. </param>
        /// <param name="accessPolicies"> Properties of the access policy. </param>
        /// <returns> A new <see cref="Models.VaultAccessPolicyParameters"/> instance for mocking. </returns>
        public static VaultAccessPolicyParameters VaultAccessPolicyParameters(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, AzureLocation? location = null, IEnumerable<AccessPolicyEntry> accessPolicies = null)
        {
            accessPolicies ??= new List<AccessPolicyEntry>();

            return new VaultAccessPolicyParameters(id, name, resourceType, systemData, location, accessPolicies != null ? new VaultAccessPolicyProperties(accessPolicies?.ToList()) : null);
        }

        /// <summary> Initializes a new instance of DeletedVaultData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> Properties of the vault. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.DeletedVaultData"/> instance for mocking. </returns>
        public static DeletedVaultData DeletedVaultData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, DeletedVaultProperties properties = null)
        {
            return new DeletedVaultData(id, name, resourceType, systemData, properties);
        }

        /// <summary> Initializes a new instance of DeletedVaultProperties. </summary>
        /// <param name="vaultId"> The resource id of the original vault. </param>
        /// <param name="location"> The location of the original vault. </param>
        /// <param name="deletedOn"> The deleted date. </param>
        /// <param name="scheduledPurgeOn"> The scheduled purged date. </param>
        /// <param name="tags"> Tags of the original vault. </param>
        /// <param name="purgeProtectionEnabled"> Purge protection status of the original vault. </param>
        /// <returns> A new <see cref="Models.DeletedVaultProperties"/> instance for mocking. </returns>
        public static DeletedVaultProperties DeletedVaultProperties(string vaultId = null, AzureLocation? location = null, DateTimeOffset? deletedOn = null, DateTimeOffset? scheduledPurgeOn = null, IReadOnlyDictionary<string, string> tags = null, bool? purgeProtectionEnabled = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DeletedVaultProperties(vaultId, location, deletedOn, scheduledPurgeOn, tags, purgeProtectionEnabled);
        }

        /// <summary> Initializes a new instance of CheckNameAvailabilityResult. </summary>
        /// <param name="nameAvailable"> A boolean value that indicates whether the name is available for you to use. If true, the name is available. If false, the name has already been taken or is invalid and cannot be used. </param>
        /// <param name="reason"> The reason that a vault name could not be used. The Reason element is only returned if NameAvailable is false. </param>
        /// <param name="message"> An error message explaining the Reason value in more detail. </param>
        /// <returns> A new <see cref="Models.CheckNameAvailabilityResult"/> instance for mocking. </returns>
        public static CheckNameAvailabilityResult CheckNameAvailabilityResult(bool? nameAvailable = null, Reason? reason = null, string message = null)
        {
            return new CheckNameAvailabilityResult(nameAvailable, reason, message);
        }

        /// <summary> Initializes a new instance of MgmtMockAndSamplePrivateEndpointConnectionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpointId"> Properties of the private endpoint object. </param>
        /// <param name="connectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.MgmtMockAndSamplePrivateEndpointConnectionData"/> instance for mocking. </returns>
        public static MgmtMockAndSamplePrivateEndpointConnectionData MgmtMockAndSamplePrivateEndpointConnectionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string etag = null, ResourceIdentifier privateEndpointId = null, MgmtMockAndSamplePrivateLinkServiceConnectionState connectionState = null, MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? provisioningState = null, AzureLocation? location = null, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new MgmtMockAndSamplePrivateEndpointConnectionData(id, name, resourceType, systemData, etag, privateEndpointId != null ? ResourceManagerModelFactory.SubResource(privateEndpointId) : null, connectionState, provisioningState, location, tags);
        }

        /// <summary> Initializes a new instance of MgmtMockAndSamplePrivateLinkResource. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="groupId"> Group identifier of private link resource. </param>
        /// <param name="requiredMembers"> Required member names of private link resource. </param>
        /// <param name="requiredZoneNames"> Required DNS zone names of the the private link resource. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        /// <returns> A new <see cref="Models.MgmtMockAndSamplePrivateLinkResource"/> instance for mocking. </returns>
        public static MgmtMockAndSamplePrivateLinkResource MgmtMockAndSamplePrivateLinkResource(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string groupId = null, IEnumerable<string> requiredMembers = null, IEnumerable<string> requiredZoneNames = null, AzureLocation? location = null, IReadOnlyDictionary<string, string> tags = null)
        {
            requiredMembers ??= new List<string>();
            requiredZoneNames ??= new List<string>();
            tags ??= new Dictionary<string, string>();

            return new MgmtMockAndSamplePrivateLinkResource(id, name, resourceType, systemData, groupId, requiredMembers?.ToList(), requiredZoneNames?.ToList(), location, tags);
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionImageData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="operatingSystem"> The operating system this extension supports. </param>
        /// <param name="computeRole"> The type of role (IaaS or PaaS) this extension supports. </param>
        /// <param name="handlerSchema"> The schema defined by publisher, where extension consumers should provide settings in a matching schema. </param>
        /// <param name="vmScaleSetEnabled"> Whether the extension can be used on xRP VMScaleSets. By default existing extensions are usable on scalesets, but there might be cases where a publisher wants to explicitly indicate the extension is only enabled for CRP VMs but not VMSS. </param>
        /// <param name="supportsMultipleExtensions"> Whether the handler can support multiple extensions. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.VirtualMachineExtensionImageData"/> instance for mocking. </returns>
        public static VirtualMachineExtensionImageData VirtualMachineExtensionImageData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string operatingSystem = null, string computeRole = null, string handlerSchema = null, bool? vmScaleSetEnabled = null, bool? supportsMultipleExtensions = null, AzureLocation? location = null, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new VirtualMachineExtensionImageData(id, name, resourceType, systemData, operatingSystem, computeRole, handlerSchema, vmScaleSetEnabled, supportsMultipleExtensions, location, tags);
        }

        /// <summary> Initializes a new instance of DiskEncryptionSetData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identity"> Identity for the virtual machine. </param>
        /// <param name="encryptionType"> The type of key used to encrypt the data of the disk. </param>
        /// <param name="activeKey"> The key vault key which is currently used by this disk encryption set. </param>
        /// <param name="previousKeys"> A readonly collection of key vault keys previously used by this disk encryption set while a key rotation is in progress. It will be empty if there is no ongoing key rotation. </param>
        /// <param name="provisioningState"> The disk encryption set provisioning state. </param>
        /// <param name="rotationToLatestKeyVersionEnabled"> Set this flag to true to enable auto-updating of this disk encryption set to the latest key version. </param>
        /// <param name="lastKeyRotationTimestamp"> The time when the active key of this disk encryption set was updated. </param>
        /// <param name="federatedClientId"> Multi-tenant application client id to access key vault in a different tenant. Setting the value to 'None' will clear the property. </param>
        /// <param name="minimumTlsVersion"> The minimum tls version. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.DiskEncryptionSetData"/> instance for mocking. </returns>
        public static DiskEncryptionSetData DiskEncryptionSetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ManagedServiceIdentity identity = null, DiskEncryptionSetType? encryptionType = null, KeyForDiskEncryptionSet activeKey = null, IEnumerable<KeyForDiskEncryptionSet> previousKeys = null, string provisioningState = null, bool? rotationToLatestKeyVersionEnabled = null, DateTimeOffset? lastKeyRotationTimestamp = null, string federatedClientId = null, MinimumTlsVersion? minimumTlsVersion = null, AzureLocation? location = null, IReadOnlyDictionary<string, string> tags = null)
        {
            previousKeys ??= new List<KeyForDiskEncryptionSet>();
            tags ??= new Dictionary<string, string>();

            return new DiskEncryptionSetData(id, name, resourceType, systemData, identity, encryptionType, activeKey, previousKeys?.ToList(), provisioningState, rotationToLatestKeyVersionEnabled, lastKeyRotationTimestamp, federatedClientId, minimumTlsVersion, location, tags);
        }

        /// <summary> Initializes a new instance of ManagedHsmData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Properties of the managed HSM. </param>
        /// <param name="sku"> SKU details. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.ManagedHsmData"/> instance for mocking. </returns>
        public static ManagedHsmData ManagedHsmData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ManagedHsmProperties properties = null, ManagedHsmSku sku = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ManagedHsmData(id, name, resourceType, systemData, tags, location, properties, sku);
        }

        /// <summary> Initializes a new instance of ManagedHsmProperties. </summary>
        /// <param name="settings"> The settings that should be applied to this ManagedHsm. This should be a JSON string or JSON object. </param>
        /// <param name="protectedSettings"> The protected settings that should be applied to this ManagedHsm. This should be a JSON string or JSON object. </param>
        /// <param name="rawMessage"> The raw message content. </param>
        /// <param name="tenantId"> The Azure Active Directory tenant ID that should be used for authenticating requests to the managed HSM pool. </param>
        /// <param name="initialAdminObjectIds"> Array of initial administrators object ids for this managed hsm pool. </param>
        /// <param name="hsmUri"> The URI of the managed hsm pool for performing operations on keys. </param>
        /// <param name="enableSoftDelete"> Property to specify whether the 'soft delete' functionality is enabled for this managed HSM pool. If it's not set to any value(true or false) when creating new managed HSM pool, it will be set to true by default. Once set to true, it cannot be reverted to false. </param>
        /// <param name="softDeleteRetentionInDays"> softDelete data retention days. It accepts &gt;=7 and &lt;=90. </param>
        /// <param name="enablePurgeProtection"> Property specifying whether protection against purge is enabled for this managed HSM pool. Setting this property to true activates protection against purge for this managed HSM pool and its content - only the Managed HSM service may initiate a hard, irrecoverable deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible. </param>
        /// <param name="createMode"> The create mode to indicate whether the resource is being created or is being recovered from a deleted resource. </param>
        /// <param name="statusMessage"> Resource Status Message. </param>
        /// <param name="provisioningState"> Provisioning state. </param>
        /// <param name="networkAcls"> Rules governing the accessibility of the key vault from specific network locations. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connections associated with the managed hsm pool. </param>
        /// <param name="publicNetworkAccess"> Control permission for data plane traffic coming from public networks while private endpoint is enabled. </param>
        /// <param name="scheduledPurgeOn"> The scheduled purge date in UTC. </param>
        /// <returns> A new <see cref="Models.ManagedHsmProperties"/> instance for mocking. </returns>
        public static ManagedHsmProperties ManagedHsmProperties(BinaryData settings = null, BinaryData protectedSettings = null, byte[] rawMessage = null, Guid? tenantId = null, IEnumerable<string> initialAdminObjectIds = null, Uri hsmUri = null, bool? enableSoftDelete = null, int? softDeleteRetentionInDays = null, bool? enablePurgeProtection = null, CreateMode? createMode = null, string statusMessage = null, ProvisioningState? provisioningState = null, MhsmNetworkRuleSet networkAcls = null, IEnumerable<MhsmPrivateEndpointConnectionItem> privateEndpointConnections = null, PublicNetworkAccess? publicNetworkAccess = null, DateTimeOffset? scheduledPurgeOn = null)
        {
            initialAdminObjectIds ??= new List<string>();
            privateEndpointConnections ??= new List<MhsmPrivateEndpointConnectionItem>();

            return new ManagedHsmProperties(settings, protectedSettings, rawMessage, tenantId, initialAdminObjectIds?.ToList(), hsmUri, enableSoftDelete, softDeleteRetentionInDays, enablePurgeProtection, createMode, statusMessage, provisioningState, networkAcls, privateEndpointConnections?.ToList(), publicNetworkAccess, scheduledPurgeOn);
        }

        /// <summary> Initializes a new instance of MhsmPrivateEndpointConnectionItem. </summary>
        /// <param name="privateEndpointId"> Properties of the private endpoint object. </param>
        /// <param name="privateLinkServiceConnectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        /// <returns> A new <see cref="Models.MhsmPrivateEndpointConnectionItem"/> instance for mocking. </returns>
        public static MhsmPrivateEndpointConnectionItem MhsmPrivateEndpointConnectionItem(ResourceIdentifier privateEndpointId = null, MhsmPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? provisioningState = null)
        {
            return new MhsmPrivateEndpointConnectionItem(privateEndpointId != null ? ResourceManagerModelFactory.SubResource(privateEndpointId) : null, privateLinkServiceConnectionState, provisioningState);
        }

        /// <summary> Initializes a new instance of MhsmPrivateEndpointConnectionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpointId"> Properties of the private endpoint object. </param>
        /// <param name="privateLinkServiceConnectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        /// <param name="sku"> SKU details. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.MhsmPrivateEndpointConnectionData"/> instance for mocking. </returns>
        public static MhsmPrivateEndpointConnectionData MhsmPrivateEndpointConnectionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string etag = null, ResourceIdentifier privateEndpointId = null, MhsmPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, MgmtMockAndSamplePrivateEndpointConnectionProvisioningState? provisioningState = null, ManagedHsmSku sku = null)
        {
            tags ??= new Dictionary<string, string>();

            return new MhsmPrivateEndpointConnectionData(id, name, resourceType, systemData, tags, location, etag, privateEndpointId != null ? ResourceManagerModelFactory.SubResource(privateEndpointId) : null, privateLinkServiceConnectionState, provisioningState, sku);
        }

        /// <summary> Initializes a new instance of DeletedManagedHsmData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="properties"> Properties of the deleted managed HSM. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.DeletedManagedHsmData"/> instance for mocking. </returns>
        public static DeletedManagedHsmData DeletedManagedHsmData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, DeletedManagedHsmProperties properties = null)
        {
            return new DeletedManagedHsmData(id, name, resourceType, systemData, properties);
        }

        /// <summary> Initializes a new instance of DeletedManagedHsmProperties. </summary>
        /// <param name="mhsmId"> The resource id of the original managed HSM. </param>
        /// <param name="location"> The location of the original managed HSM. </param>
        /// <param name="deletedOn"> The deleted date. </param>
        /// <param name="scheduledPurgeOn"> The scheduled purged date. </param>
        /// <param name="purgeProtectionEnabled"> Purge protection status of the original managed HSM. </param>
        /// <param name="tags"> Tags of the original managed HSM. </param>
        /// <returns> A new <see cref="Models.DeletedManagedHsmProperties"/> instance for mocking. </returns>
        public static DeletedManagedHsmProperties DeletedManagedHsmProperties(string mhsmId = null, AzureLocation? location = null, DateTimeOffset? deletedOn = null, DateTimeOffset? scheduledPurgeOn = null, bool? purgeProtectionEnabled = null, IReadOnlyDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new DeletedManagedHsmProperties(mhsmId, location, deletedOn, scheduledPurgeOn, purgeProtectionEnabled, tags);
        }

        /// <summary> Initializes a new instance of MhsmPrivateLinkResource. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="groupId"> Group identifier of private link resource. </param>
        /// <param name="requiredMembers"> Required member names of private link resource. </param>
        /// <param name="requiredZoneNames"> Required DNS zone names of the the private link resource. </param>
        /// <param name="sku"> SKU details. </param>
        /// <returns> A new <see cref="Models.MhsmPrivateLinkResource"/> instance for mocking. </returns>
        public static MhsmPrivateLinkResource MhsmPrivateLinkResource(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string groupId = null, IEnumerable<string> requiredMembers = null, IEnumerable<string> requiredZoneNames = null, ManagedHsmSku sku = null)
        {
            tags ??= new Dictionary<string, string>();
            requiredMembers ??= new List<string>();
            requiredZoneNames ??= new List<string>();

            return new MhsmPrivateLinkResource(id, name, resourceType, systemData, tags, location, groupId, requiredMembers?.ToList(), requiredZoneNames?.ToList(), sku);
        }

        /// <summary> Initializes a new instance of FirewallPolicyData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="identity"> The identity of the firewall policy. </param>
        /// <param name="startupProbe"> StartupProbe indicates that the App Instance has successfully initialized. If specified, no other probes are executed until this completes successfully. If this probe fails, the Pod will be restarted, just as if the livenessProbe failed. This can be used to provide different probe parameters at the beginning of a App Instance's lifecycle, when it might take a long time to load data or warm a cache, than during steady-state operation. This cannot be updated. More info: https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle#container-probes. </param>
        /// <param name="readinessProbe"> Periodic probe of App Instance service readiness. App Instance will be removed from service endpoints if the probe fails. More info: https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle#container-probes. </param>
        /// <param name="desiredStatusCode"> The desired status code. </param>
        /// <param name="ruleCollectionGroups"> List of references to FirewallPolicyRuleCollectionGroups. </param>
        /// <param name="provisioningState"> The provisioning state of the firewall policy resource. </param>
        /// <param name="basePolicyId"> The parent firewall policy from which rules are inherited. </param>
        /// <param name="firewalls"> List of references to Azure Firewalls that this Firewall Policy is associated with. </param>
        /// <param name="childPolicies"> List of references to Child Firewall Policies. </param>
        /// <param name="threatIntelWhitelist"> ThreatIntel Whitelist for Firewall Policy. </param>
        /// <param name="insights"> Insights on Firewall Policy. </param>
        /// <param name="snatPrivateRanges"> The private IP addresses/IP ranges to which traffic will not be SNAT. </param>
        /// <param name="dnsSettings"> DNS Proxy Settings definition. </param>
        /// <param name="intrusionDetection"> The configuration for Intrusion detection. </param>
        /// <param name="transportSecurityCertificateAuthority"> TLS Configuration definition. </param>
        /// <param name="skuTier"> The Firewall Policy SKU. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.FirewallPolicyData"/> instance for mocking. </returns>
        public static FirewallPolicyData FirewallPolicyData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, string etag = null, ManagedServiceIdentity identity = null, Probe startupProbe = null, Probe readinessProbe = null, DesiredStatusCode? desiredStatusCode = null, IEnumerable<WritableSubResource> ruleCollectionGroups = null, ProvisioningState? provisioningState = null, ResourceIdentifier basePolicyId = null, IEnumerable<WritableSubResource> firewalls = null, IEnumerable<WritableSubResource> childPolicies = null, FirewallPolicyThreatIntelWhitelist threatIntelWhitelist = null, FirewallPolicyInsights insights = null, IEnumerable<string> snatPrivateRanges = null, DnsSettings dnsSettings = null, FirewallPolicyIntrusionDetection intrusionDetection = null, FirewallPolicyCertificateAuthority transportSecurityCertificateAuthority = null, FirewallPolicySkuTier? skuTier = null)
        {
            tags ??= new Dictionary<string, string>();
            ruleCollectionGroups ??= new List<WritableSubResource>();
            firewalls ??= new List<WritableSubResource>();
            childPolicies ??= new List<WritableSubResource>();
            snatPrivateRanges ??= new List<string>();

            return new FirewallPolicyData(id, name, resourceType, systemData, tags, location, etag, identity, startupProbe, readinessProbe, desiredStatusCode, ruleCollectionGroups?.ToList(), provisioningState, basePolicyId != null ? ResourceManagerModelFactory.WritableSubResource(basePolicyId) : null, firewalls?.ToList(), childPolicies?.ToList(), threatIntelWhitelist, insights, snatPrivateRanges != null ? new FirewallPolicySnat(snatPrivateRanges?.ToList()) : null, dnsSettings, intrusionDetection, transportSecurityCertificateAuthority != null ? new FirewallPolicyTransportSecurity(transportSecurityCertificateAuthority) : null, skuTier != null ? new FirewallPolicySku(skuTier) : null);
        }

        /// <summary> Initializes a new instance of FirewallPolicyRuleCollectionGroupData. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="resourceType"> Rule Group type. </param>
        /// <param name="priority"> Priority of the Firewall Policy Rule Collection Group resource. </param>
        /// <param name="ruleCollections">
        /// Group of Firewall Policy rule collections.
        /// Please note <see cref="FirewallPolicyRuleCollection"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="FirewallPolicyFilterRuleCollection"/> and <see cref="FirewallPolicyNatRuleCollection"/>.
        /// </param>
        /// <param name="provisioningState"> The provisioning state of the firewall policy rule collection group resource. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.FirewallPolicyRuleCollectionGroupData"/> instance for mocking. </returns>
        public static FirewallPolicyRuleCollectionGroupData FirewallPolicyRuleCollectionGroupData(string id = null, string name = null, string etag = null, ResourceType? resourceType = null, int? priority = null, IEnumerable<FirewallPolicyRuleCollection> ruleCollections = null, ProvisioningState? provisioningState = null)
        {
            ruleCollections ??= new List<FirewallPolicyRuleCollection>();

            return new FirewallPolicyRuleCollectionGroupData(id, name, etag, resourceType, priority, ruleCollections?.ToList(), provisioningState);
        }

        /// <summary> Initializes a new instance of RoleAssignmentData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="scope"> The role assignment scope. </param>
        /// <param name="roleDefinitionId"> The role definition ID. </param>
        /// <param name="principalId"> The principal ID. </param>
        /// <param name="canDelegate"> The Delegation flag for the role assignment. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.RoleAssignmentData"/> instance for mocking. </returns>
        public static RoleAssignmentData RoleAssignmentData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string scope = null, string roleDefinitionId = null, string principalId = null, bool? canDelegate = null)
        {
            return new RoleAssignmentData(id, name, resourceType, systemData, scope, roleDefinitionId, principalId, canDelegate);
        }

        /// <summary> Initializes a new instance of EventData. </summary>
        /// <param name="authorization"> The sender authorization information. </param>
        /// <param name="tenantId"> the Azure tenant Id. </param>
        /// <returns> A new <see cref="Models.EventData"/> instance for mocking. </returns>
        public static EventData EventData(SenderAuthorization authorization = null, Guid? tenantId = null)
        {
            return new EventData(authorization, tenantId);
        }

        /// <summary> Initializes a new instance of SenderAuthorization. </summary>
        /// <param name="action"> the permissible actions. For instance: microsoft.support/supporttickets/write. </param>
        /// <param name="role"> the role of the user. For instance: Subscription Admin. </param>
        /// <param name="scope"> the scope. </param>
        /// <returns> A new <see cref="Models.SenderAuthorization"/> instance for mocking. </returns>
        public static SenderAuthorization SenderAuthorization(string action = null, string role = null, string scope = null)
        {
            return new SenderAuthorization(action, role, scope);
        }

        /// <summary> Initializes a new instance of TemplateHashResult. </summary>
        /// <param name="minifiedTemplate"> The minified template string. </param>
        /// <param name="templateHash"> The template hash. </param>
        /// <returns> A new <see cref="Models.TemplateHashResult"/> instance for mocking. </returns>
        public static TemplateHashResult TemplateHashResult(string minifiedTemplate = null, string templateHash = null)
        {
            return new TemplateHashResult(minifiedTemplate, templateHash);
        }

        /// <summary> Initializes a new instance of GuestConfigurationAssignmentData. </summary>
        /// <param name="id"> ARM resource id of the guest configuration assignment. </param>
        /// <param name="name"> Name of the guest configuration assignment. </param>
        /// <param name="location"> Region where the VM is located. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="properties"> Properties of the Guest configuration assignment. </param>
        /// <returns> A new <see cref="MgmtMockAndSample.GuestConfigurationAssignmentData"/> instance for mocking. </returns>
        public static GuestConfigurationAssignmentData GuestConfigurationAssignmentData(string id = null, string name = null, AzureLocation? location = null, ResourceType? resourceType = null, GuestConfigurationAssignmentProperties properties = null)
        {
            return new GuestConfigurationAssignmentData(id, name, location, resourceType, properties);
        }

        /// <summary> Initializes a new instance of GuestConfigurationAssignmentProperties. </summary>
        /// <param name="targetResourceId"> VM resource Id. </param>
        /// <param name="complianceStatus"> A value indicating compliance status of the machine for the assigned guest configuration. </param>
        /// <param name="lastComplianceStatusChecked"> Date and time when last compliance status was checked. </param>
        /// <param name="latestReportId"> Id of the latest report for the guest configuration assignment. </param>
        /// <param name="parameterHash"> parameter hash for the guest configuration assignment. </param>
        /// <param name="context"> The source which initiated the guest configuration assignment. Ex: Azure Policy. </param>
        /// <param name="assignmentHash"> Combined hash of the configuration package and parameters. </param>
        /// <param name="provisioningState"> The provisioning state, which only appears in the response. </param>
        /// <param name="resourceType"> Type of the resource - VMSS / VM. </param>
        /// <returns> A new <see cref="Models.GuestConfigurationAssignmentProperties"/> instance for mocking. </returns>
        public static GuestConfigurationAssignmentProperties GuestConfigurationAssignmentProperties(string targetResourceId = null, ComplianceStatus? complianceStatus = null, DateTimeOffset? lastComplianceStatusChecked = null, string latestReportId = null, string parameterHash = null, string context = null, string assignmentHash = null, ProvisioningState? provisioningState = null, ResourceType? resourceType = null)
        {
            return new GuestConfigurationAssignmentProperties(targetResourceId, complianceStatus, lastComplianceStatusChecked, latestReportId, parameterHash, context, assignmentHash, provisioningState, resourceType);
        }

        /// <summary> Initializes a new instance of GuestConfigurationBaseResource. </summary>
        /// <param name="id"> ARM resource id of the guest configuration assignment. </param>
        /// <param name="name"> Name of the guest configuration assignment. </param>
        /// <param name="location"> Region where the VM is located. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <returns> A new <see cref="Models.GuestConfigurationBaseResource"/> instance for mocking. </returns>
        public static GuestConfigurationBaseResource GuestConfigurationBaseResource(string id = null, string name = null, AzureLocation? location = null, ResourceType? resourceType = null)
        {
            return new GuestConfigurationBaseResource(id, name, location, resourceType);
        }
    }
}
