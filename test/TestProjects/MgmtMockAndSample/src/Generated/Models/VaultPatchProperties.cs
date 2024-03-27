// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> Properties of the vault. </summary>
    public partial class VaultPatchProperties
    {
        /// <summary> Initializes a new instance of <see cref="VaultPatchProperties"/>. </summary>
        public VaultPatchProperties()
        {
            AccessPolicies = new ChangeTrackingList<AccessPolicyEntry>();
        }

        /// <summary> Initializes a new instance of <see cref="VaultPatchProperties"/>. </summary>
        /// <param name="tenantId"> The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault. </param>
        /// <param name="sku"> SKU details. </param>
        /// <param name="accessPolicies"> An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID. </param>
        /// <param name="enabledForDeployment"> Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key vault. </param>
        /// <param name="enabledForDiskEncryption"> Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys. </param>
        /// <param name="enabledForTemplateDeployment"> Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault. </param>
        /// <param name="enableSoftDelete"> Property to specify whether the 'soft delete' functionality is enabled for this key vault. Once set to true, it cannot be reverted to false. </param>
        /// <param name="enableRbacAuthorization"> Property that controls how data actions are authorized. When true, the key vault will use Role Based Access Control (RBAC) for authorization of data actions, and the access policies specified in vault properties will be  ignored. When false, the key vault will use the access policies specified in vault properties, and any policy stored on Azure Resource Manager will be ignored. If null or not specified, the value of this property will not change. </param>
        /// <param name="softDeleteRetentionInDays"> softDelete data retention days. It accepts &gt;=7 and &lt;=90. </param>
        /// <param name="createMode"> The vault's create mode to indicate whether the vault need to be recovered or not. </param>
        /// <param name="enablePurgeProtection"> Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible - that is, the property does not accept false as its value. </param>
        /// <param name="networkAcls"> A collection of rules governing the accessibility of the vault from specific network locations. </param>
        /// <param name="publicNetworkAccess"> Property to specify whether the vault will accept traffic from public internet. If set to 'disabled' all traffic except private endpoint traffic and that that originates from trusted services will be blocked. This will override the set firewall rules, meaning that even if the firewall rules are present we will not honor the rules. </param>
        internal VaultPatchProperties(Guid? tenantId, MgmtMockAndSampleSku sku, IList<AccessPolicyEntry> accessPolicies, bool? enabledForDeployment, bool? enabledForDiskEncryption, bool? enabledForTemplateDeployment, bool? enableSoftDelete, bool? enableRbacAuthorization, int? softDeleteRetentionInDays, CreateMode? createMode, bool? enablePurgeProtection, NetworkRuleSet networkAcls, string publicNetworkAccess)
        {
            TenantId = tenantId;
            Sku = sku;
            AccessPolicies = accessPolicies;
            EnabledForDeployment = enabledForDeployment;
            EnabledForDiskEncryption = enabledForDiskEncryption;
            EnabledForTemplateDeployment = enabledForTemplateDeployment;
            EnableSoftDelete = enableSoftDelete;
            EnableRbacAuthorization = enableRbacAuthorization;
            SoftDeleteRetentionInDays = softDeleteRetentionInDays;
            CreateMode = createMode;
            EnablePurgeProtection = enablePurgeProtection;
            NetworkAcls = networkAcls;
            PublicNetworkAccess = publicNetworkAccess;
        }

        /// <summary> The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault. </summary>
        public Guid? TenantId { get; set; }
        /// <summary> SKU details. </summary>
        public MgmtMockAndSampleSku Sku { get; set; }
        /// <summary> An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID. </summary>
        public IList<AccessPolicyEntry> AccessPolicies { get; }
        /// <summary> Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key vault. </summary>
        public bool? EnabledForDeployment { get; set; }
        /// <summary> Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys. </summary>
        public bool? EnabledForDiskEncryption { get; set; }
        /// <summary> Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault. </summary>
        public bool? EnabledForTemplateDeployment { get; set; }
        /// <summary> Property to specify whether the 'soft delete' functionality is enabled for this key vault. Once set to true, it cannot be reverted to false. </summary>
        public bool? EnableSoftDelete { get; set; }
        /// <summary> Property that controls how data actions are authorized. When true, the key vault will use Role Based Access Control (RBAC) for authorization of data actions, and the access policies specified in vault properties will be  ignored. When false, the key vault will use the access policies specified in vault properties, and any policy stored on Azure Resource Manager will be ignored. If null or not specified, the value of this property will not change. </summary>
        public bool? EnableRbacAuthorization { get; set; }
        /// <summary> softDelete data retention days. It accepts &gt;=7 and &lt;=90. </summary>
        public int? SoftDeleteRetentionInDays { get; set; }
        /// <summary> The vault's create mode to indicate whether the vault need to be recovered or not. </summary>
        public CreateMode? CreateMode { get; set; }
        /// <summary> Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible - that is, the property does not accept false as its value. </summary>
        public bool? EnablePurgeProtection { get; set; }
        /// <summary> A collection of rules governing the accessibility of the vault from specific network locations. </summary>
        public NetworkRuleSet NetworkAcls { get; set; }
        /// <summary> Property to specify whether the vault will accept traffic from public internet. If set to 'disabled' all traffic except private endpoint traffic and that that originates from trusted services will be blocked. This will override the set firewall rules, meaning that even if the firewall rules are present we will not honor the rules. </summary>
        public string PublicNetworkAccess { get; set; }
    }
}
