// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> Properties of the vault. </summary>
    public partial class VaultProperties
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="VaultProperties"/>. </summary>
        /// <param name="tenantId"> The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault. </param>
        /// <param name="sku"> SKU details. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sku"/> is null. </exception>
        public VaultProperties(Guid tenantId, MgmtMockAndSampleSku sku)
        {
            Argument.AssertNotNull(sku, nameof(sku));

            TenantId = tenantId;
            Sku = sku;
            AccessPolicies = new ChangeTrackingList<AccessPolicyEntry>();
            Deployments = new ChangeTrackingList<string>();
            PrivateEndpointConnections = new ChangeTrackingList<PrivateEndpointConnectionItem>();
        }

        /// <summary> Initializes a new instance of <see cref="VaultProperties"/>. </summary>
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
        /// <param name="readWriteSingleStringProperty"> This is a single property of string. </param>
        /// <param name="readOnlySingleStringProperty"> This is a single property of read-only string. </param>
        /// <param name="extremelyDeepStringProperty"> This is a single property of string. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VaultProperties(TimeSpan? duration, DateTimeOffset? createOn, Guid tenantId, MgmtMockAndSampleSku sku, IList<AccessPolicyEntry> accessPolicies, Uri vaultUri, string hsmPoolResourceId, IList<string> deployments, bool? enabledForDiskEncryption, bool? enabledForTemplateDeployment, bool? enableSoftDelete, int? softDeleteRetentionInDays, bool? enableRbacAuthorization, CreateMode? createMode, bool? enablePurgeProtection, NetworkRuleSet networkAcls, VaultProvisioningState? provisioningState, IReadOnlyList<PrivateEndpointConnectionItem> privateEndpointConnections, string publicNetworkAccess, SinglePropertyModel readWriteSingleStringProperty, ReadOnlySinglePropertyModel readOnlySingleStringProperty, ExtremelyDeepSinglePropertyModel extremelyDeepStringProperty, Dictionary<string, BinaryData> rawData)
        {
            Duration = duration;
            CreateOn = createOn;
            TenantId = tenantId;
            Sku = sku;
            AccessPolicies = accessPolicies;
            VaultUri = vaultUri;
            HsmPoolResourceId = hsmPoolResourceId;
            Deployments = deployments;
            EnabledForDiskEncryption = enabledForDiskEncryption;
            EnabledForTemplateDeployment = enabledForTemplateDeployment;
            EnableSoftDelete = enableSoftDelete;
            SoftDeleteRetentionInDays = softDeleteRetentionInDays;
            EnableRbacAuthorization = enableRbacAuthorization;
            CreateMode = createMode;
            EnablePurgeProtection = enablePurgeProtection;
            NetworkAcls = networkAcls;
            ProvisioningState = provisioningState;
            PrivateEndpointConnections = privateEndpointConnections;
            PublicNetworkAccess = publicNetworkAccess;
            ReadWriteSingleStringProperty = readWriteSingleStringProperty;
            ReadOnlySingleStringProperty = readOnlySingleStringProperty;
            ExtremelyDeepStringProperty = extremelyDeepStringProperty;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="VaultProperties"/> for deserialization. </summary>
        internal VaultProperties()
        {
        }

        /// <summary> Time elapsed for task. </summary>
        public TimeSpan? Duration { get; set; }
        /// <summary> The date and time when the cluster creating. </summary>
        public DateTimeOffset? CreateOn { get; set; }
        /// <summary> The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault. </summary>
        public Guid TenantId { get; set; }
        /// <summary> SKU details. </summary>
        public MgmtMockAndSampleSku Sku { get; set; }
        /// <summary> An array of 0 to 1024 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID. When `createMode` is set to `recover`, access policies are not required. Otherwise, access policies are required. </summary>
        public IList<AccessPolicyEntry> AccessPolicies { get; }
        /// <summary> The URI of the vault for performing operations on keys and secrets. </summary>
        public Uri VaultUri { get; set; }
        /// <summary> The resource id of HSM Pool. </summary>
        public string HsmPoolResourceId { get; }
        /// <summary> Specify a list of resource identifiers of deployment. </summary>
        public IList<string> Deployments { get; }
        /// <summary> Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys. </summary>
        public bool? EnabledForDiskEncryption { get; set; }
        /// <summary> Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault. </summary>
        public bool? EnabledForTemplateDeployment { get; set; }
        /// <summary> Property to specify whether the 'soft delete' functionality is enabled for this key vault. If it's not set to any value(true or false) when creating new key vault, it will be set to true by default. Once set to true, it cannot be reverted to false. </summary>
        public bool? EnableSoftDelete { get; set; }
        /// <summary> softDelete data retention days. It accepts &gt;=7 and &lt;=90. </summary>
        public int? SoftDeleteRetentionInDays { get; set; }
        /// <summary> Property that controls how data actions are authorized. When true, the key vault will use Role Based Access Control (RBAC) for authorization of data actions, and the access policies specified in vault properties will be  ignored. When false, the key vault will use the access policies specified in vault properties, and any policy stored on Azure Resource Manager will be ignored. If null or not specified, the vault is created with the default value of false. Note that management actions are always authorized with RBAC. </summary>
        public bool? EnableRbacAuthorization { get; set; }
        /// <summary> The vault's create mode to indicate whether the vault need to be recovered or not. </summary>
        public CreateMode? CreateMode { get; set; }
        /// <summary> Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible - that is, the property does not accept false as its value. </summary>
        public bool? EnablePurgeProtection { get; set; }
        /// <summary> Rules governing the accessibility of the key vault from specific network locations. </summary>
        public NetworkRuleSet NetworkAcls { get; set; }
        /// <summary> Provisioning state of the vault. </summary>
        public VaultProvisioningState? ProvisioningState { get; set; }
        /// <summary> List of private endpoint connections associated with the key vault. </summary>
        public IReadOnlyList<PrivateEndpointConnectionItem> PrivateEndpointConnections { get; }
        /// <summary> Property to specify whether the vault will accept traffic from public internet. If set to 'disabled' all traffic except private endpoint traffic and that that originates from trusted services will be blocked. This will override the set firewall rules, meaning that even if the firewall rules are present we will not honor the rules. </summary>
        public string PublicNetworkAccess { get; set; }
        /// <summary> This is a single property of string. </summary>
        internal SinglePropertyModel ReadWriteSingleStringProperty { get; set; }
        /// <summary> This is a string property. </summary>
        public string ReadWriteSingleStringPropertySomething
        {
            get => ReadWriteSingleStringProperty is null ? default : ReadWriteSingleStringProperty.Something;
            set
            {
                if (ReadWriteSingleStringProperty is null)
                    ReadWriteSingleStringProperty = new SinglePropertyModel();
                ReadWriteSingleStringProperty.Something = value;
            }
        }

        /// <summary> This is a single property of read-only string. </summary>
        internal ReadOnlySinglePropertyModel ReadOnlySingleStringProperty { get; set; }
        /// <summary> This is a read only string property. </summary>
        public string ReadOnlySomething
        {
            get => ReadOnlySingleStringProperty is null ? default : ReadOnlySingleStringProperty.ReadOnlySomething;
        }

        /// <summary> This is a single property of string. </summary>
        internal ExtremelyDeepSinglePropertyModel ExtremelyDeepStringProperty { get; set; }
        /// <summary> This is a string property. </summary>
        public string DeepSomething
        {
            get => ExtremelyDeepStringProperty is null ? default : ExtremelyDeepStringProperty.DeepSomething;
            set
            {
                if (ExtremelyDeepStringProperty is null)
                    ExtremelyDeepStringProperty = new ExtremelyDeepSinglePropertyModel();
                ExtremelyDeepStringProperty.DeepSomething = value;
            }
        }
    }
}
