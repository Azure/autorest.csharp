// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmStorageModelFactory
    {
        /// <summary> Initializes a new instance of BlobServiceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="sku"> Sku name and tier. </param>
        /// <param name="corsRulesValue"> Specifies CORS rules for the Blob service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the Blob service. </param>
        /// <param name="defaultServiceVersion"> DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version is not specified. Possible values include version 2008-10-27 and all more recent versions. </param>
        /// <param name="deleteRetentionPolicy"> The blob service properties for blob soft delete. </param>
        /// <param name="isVersioningEnabled"> Versioning is enabled if set to true. </param>
        /// <param name="automaticSnapshotPolicyEnabled"> Deprecated in favor of isVersioningEnabled property. </param>
        /// <param name="changeFeed"> The blob service properties for change feed events. </param>
        /// <param name="restorePolicy"> The blob service properties for blob restore policy. </param>
        /// <param name="containerDeleteRetentionPolicy"> The blob service properties for container soft delete. </param>
        /// <param name="lastAccessTimeTrackingPolicy"> The blob service property to configure last access time based tracking policy. </param>
        /// <returns> A new <see cref="Storage.BlobServiceData"/> instance for mocking. </returns>
        public static BlobServiceData BlobServiceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, StorageSku sku = null, IEnumerable<CorsRule> corsRulesValue = null, string defaultServiceVersion = null, DeleteRetentionPolicy deleteRetentionPolicy = null, bool? isVersioningEnabled = null, bool? automaticSnapshotPolicyEnabled = null, ChangeFeed changeFeed = null, RestorePolicyProperties restorePolicy = null, DeleteRetentionPolicy containerDeleteRetentionPolicy = null, LastAccessTimeTrackingPolicy lastAccessTimeTrackingPolicy = null)
        {
            corsRulesValue ??= new List<CorsRule>();

            return new BlobServiceData(id, name, resourceType, systemData, sku, corsRulesValue != null ? new CorsRules(corsRulesValue?.ToList()) : null, defaultServiceVersion, deleteRetentionPolicy, isVersioningEnabled, automaticSnapshotPolicyEnabled, changeFeed, restorePolicy, containerDeleteRetentionPolicy, lastAccessTimeTrackingPolicy);
        }

        /// <summary> Initializes a new instance of RestorePolicyProperties. </summary>
        /// <param name="enabled"> Blob restore is enabled if set to true. </param>
        /// <param name="days"> how long this blob can be restored. It should be great than zero and less than DeleteRetentionPolicy.days. </param>
        /// <param name="lastEnabledOn"> Deprecated in favor of minRestoreTime property. </param>
        /// <param name="minRestoreOn"> Returns the minimum date and time that the restore can be started. </param>
        /// <returns> A new <see cref="Models.RestorePolicyProperties"/> instance for mocking. </returns>
        public static RestorePolicyProperties RestorePolicyProperties(bool enabled = default, int? days = null, DateTimeOffset? lastEnabledOn = null, DateTimeOffset? minRestoreOn = null)
        {
            return new RestorePolicyProperties(enabled, days, lastEnabledOn, minRestoreOn);
        }

        /// <summary> Initializes a new instance of StorageSku. </summary>
        /// <param name="name"> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </param>
        /// <param name="tier"> The SKU tier. This is based on the SKU name. </param>
        /// <returns> A new <see cref="Models.StorageSku"/> instance for mocking. </returns>
        public static StorageSku StorageSku(StorageSkuName name = default, StorageSkuTier? tier = null)
        {
            return new StorageSku(name, tier);
        }

        /// <summary> Initializes a new instance of BlobContainerData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="version"> The version of the deleted blob container. </param>
        /// <param name="deleted"> Indicates whether the blob container was deleted. </param>
        /// <param name="deletedOn"> Blob container deletion time. </param>
        /// <param name="remainingRetentionDays"> Remaining retention days for soft deleted blob container. </param>
        /// <param name="defaultEncryptionScope"> Default the container to use specified encryption scope for all writes. </param>
        /// <param name="denyEncryptionScopeOverride"> Block override of encryption scope from the container default. </param>
        /// <param name="publicAccess"> Specifies whether data in the container may be accessed publicly and the level of access. </param>
        /// <param name="lastModifiedOn"> Returns the date and time the container was last modified. </param>
        /// <param name="leaseStatus"> The lease status of the container. </param>
        /// <param name="leaseState"> Lease state of the container. </param>
        /// <param name="leaseDuration"> Specifies whether the lease on a container is of infinite or fixed duration, only when the container is leased. </param>
        /// <param name="metadata"> A name-value pair to associate with the container as metadata. </param>
        /// <param name="immutabilityPolicy"> The ImmutabilityPolicy property of the container. </param>
        /// <param name="legalHold"> The LegalHold property of the container. </param>
        /// <param name="hasLegalHold"> The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account. </param>
        /// <param name="hasImmutabilityPolicy"> The hasImmutabilityPolicy public property is set to true by SRP if ImmutabilityPolicy has been created for this container. The hasImmutabilityPolicy public property is set to false by SRP if ImmutabilityPolicy has not been created for this container. </param>
        /// <param name="immutableStorageWithVersioning"> The object level immutability property of the container. The property is immutable and can only be set to true at the container creation time. Existing containers must undergo a migration process. </param>
        /// <param name="enableNfsV3RootSquash"> Enable NFSv3 root squash on blob container. </param>
        /// <param name="enableNfsV3AllSquash"> Enable NFSv3 all squash on blob container. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <returns> A new <see cref="Storage.BlobContainerData"/> instance for mocking. </returns>
        public static BlobContainerData BlobContainerData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string version = null, bool? deleted = null, DateTimeOffset? deletedOn = null, int? remainingRetentionDays = null, string defaultEncryptionScope = null, bool? denyEncryptionScopeOverride = null, PublicAccess? publicAccess = null, DateTimeOffset? lastModifiedOn = null, LeaseStatus? leaseStatus = null, LeaseState? leaseState = null, LeaseDuration? leaseDuration = null, IDictionary<string, string> metadata = null, ImmutabilityPolicyProperties immutabilityPolicy = null, LegalHoldProperties legalHold = null, bool? hasLegalHold = null, bool? hasImmutabilityPolicy = null, ImmutableStorageWithVersioning immutableStorageWithVersioning = null, bool? enableNfsV3RootSquash = null, bool? enableNfsV3AllSquash = null, ETag? etag = null)
        {
            metadata ??= new Dictionary<string, string>();

            return new BlobContainerData(id, name, resourceType, systemData, version, deleted, deletedOn, remainingRetentionDays, defaultEncryptionScope, denyEncryptionScopeOverride, publicAccess, lastModifiedOn, leaseStatus, leaseState, leaseDuration, metadata, immutabilityPolicy, legalHold, hasLegalHold, hasImmutabilityPolicy, immutableStorageWithVersioning, enableNfsV3RootSquash, enableNfsV3AllSquash, etag);
        }

        /// <summary> Initializes a new instance of ImmutabilityPolicyProperties. </summary>
        /// <param name="etag"> ImmutabilityPolicy Etag. </param>
        /// <param name="updateHistory"> The ImmutabilityPolicy update history of the blob container. </param>
        /// <param name="immutabilityPeriodSinceCreationInDays"> The immutability period for the blobs in the container since the policy creation, in days. </param>
        /// <param name="state"> The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked. </param>
        /// <param name="allowProtectedAppendWrites"> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. </param>
        /// <param name="allowProtectedAppendWritesAll"> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. The 'allowProtectedAppendWrites' and 'allowProtectedAppendWritesAll' properties are mutually exclusive. </param>
        /// <returns> A new <see cref="Models.ImmutabilityPolicyProperties"/> instance for mocking. </returns>
        public static ImmutabilityPolicyProperties ImmutabilityPolicyProperties(ETag? etag = null, IEnumerable<UpdateHistoryProperty> updateHistory = null, int? immutabilityPeriodSinceCreationInDays = null, ImmutabilityPolicyState? state = null, bool? allowProtectedAppendWrites = null, bool? allowProtectedAppendWritesAll = null)
        {
            updateHistory ??= new List<UpdateHistoryProperty>();

            return new ImmutabilityPolicyProperties(etag, updateHistory?.ToList(), immutabilityPeriodSinceCreationInDays, state, allowProtectedAppendWrites, allowProtectedAppendWritesAll);
        }

        /// <summary> Initializes a new instance of UpdateHistoryProperty. </summary>
        /// <param name="update"> The ImmutabilityPolicy update type of a blob container, possible values include: put, lock and extend. </param>
        /// <param name="immutabilityPeriodSinceCreationInDays"> The immutability period for the blobs in the container since the policy creation, in days. </param>
        /// <param name="timestamp"> Returns the date and time the ImmutabilityPolicy was updated. </param>
        /// <param name="objectIdentifier"> Returns the Object ID of the user who updated the ImmutabilityPolicy. </param>
        /// <param name="tenantId"> Returns the Tenant ID that issued the token for the user who updated the ImmutabilityPolicy. </param>
        /// <param name="upn"> Returns the User Principal Name of the user who updated the ImmutabilityPolicy. </param>
        /// <param name="allowProtectedAppendWrites"> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. </param>
        /// <param name="allowProtectedAppendWritesAll"> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. The 'allowProtectedAppendWrites' and 'allowProtectedAppendWritesAll' properties are mutually exclusive. </param>
        /// <returns> A new <see cref="Models.UpdateHistoryProperty"/> instance for mocking. </returns>
        public static UpdateHistoryProperty UpdateHistoryProperty(ImmutabilityPolicyUpdateType? update = null, int? immutabilityPeriodSinceCreationInDays = null, DateTimeOffset? timestamp = null, string objectIdentifier = null, Guid? tenantId = null, string upn = null, bool? allowProtectedAppendWrites = null, bool? allowProtectedAppendWritesAll = null)
        {
            return new UpdateHistoryProperty(update, immutabilityPeriodSinceCreationInDays, timestamp, objectIdentifier, tenantId, upn, allowProtectedAppendWrites, allowProtectedAppendWritesAll);
        }

        /// <summary> Initializes a new instance of LegalHoldProperties. </summary>
        /// <param name="hasLegalHold"> The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account. </param>
        /// <param name="tags"> The list of LegalHold tags of a blob container. </param>
        /// <param name="protectedAppendWritesHistory"> Protected append blob writes history. </param>
        /// <returns> A new <see cref="Models.LegalHoldProperties"/> instance for mocking. </returns>
        public static LegalHoldProperties LegalHoldProperties(bool? hasLegalHold = null, IEnumerable<TagProperty> tags = null, ProtectedAppendWritesHistory protectedAppendWritesHistory = null)
        {
            tags ??= new List<TagProperty>();

            return new LegalHoldProperties(hasLegalHold, tags?.ToList(), protectedAppendWritesHistory);
        }

        /// <summary> Initializes a new instance of TagProperty. </summary>
        /// <param name="tag"> The tag value. </param>
        /// <param name="timestamp"> Returns the date and time the tag was added. </param>
        /// <param name="objectIdentifier"> Returns the Object ID of the user who added the tag. </param>
        /// <param name="tenantId"> Returns the Tenant ID that issued the token for the user who added the tag. </param>
        /// <param name="upn"> Returns the User Principal Name of the user who added the tag. </param>
        /// <returns> A new <see cref="Models.TagProperty"/> instance for mocking. </returns>
        public static TagProperty TagProperty(string tag = null, DateTimeOffset? timestamp = null, string objectIdentifier = null, Guid? tenantId = null, string upn = null)
        {
            return new TagProperty(tag, timestamp, objectIdentifier, tenantId, upn);
        }

        /// <summary> Initializes a new instance of ProtectedAppendWritesHistory. </summary>
        /// <param name="allowProtectedAppendWritesAll"> When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining legal hold protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. </param>
        /// <param name="timestamp"> Returns the date and time the tag was added. </param>
        /// <returns> A new <see cref="Models.ProtectedAppendWritesHistory"/> instance for mocking. </returns>
        public static ProtectedAppendWritesHistory ProtectedAppendWritesHistory(bool? allowProtectedAppendWritesAll = null, DateTimeOffset? timestamp = null)
        {
            return new ProtectedAppendWritesHistory(allowProtectedAppendWritesAll, timestamp);
        }

        /// <summary> Initializes a new instance of ImmutableStorageWithVersioning. </summary>
        /// <param name="enabled"> This is an immutable property, when set to true it enables object level immutability at the container level. </param>
        /// <param name="timeStamp"> Returns the date and time the object level immutability was enabled. </param>
        /// <param name="migrationState"> This property denotes the container level immutability to object level immutability migration state. </param>
        /// <returns> A new <see cref="Models.ImmutableStorageWithVersioning"/> instance for mocking. </returns>
        public static ImmutableStorageWithVersioning ImmutableStorageWithVersioning(bool? enabled = null, DateTimeOffset? timeStamp = null, MigrationState? migrationState = null)
        {
            return new ImmutableStorageWithVersioning(enabled, timeStamp, migrationState);
        }

        /// <summary> Initializes a new instance of LegalHold. </summary>
        /// <param name="hasLegalHold"> The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account. </param>
        /// <param name="tags"> Each tag should be 3 to 23 alphanumeric characters and is normalized to lower case at SRP. </param>
        /// <param name="allowProtectedAppendWritesAll"> When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining legal hold protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. </param>
        /// <returns> A new <see cref="Models.LegalHold"/> instance for mocking. </returns>
        public static LegalHold LegalHold(bool? hasLegalHold = null, IEnumerable<string> tags = null, bool? allowProtectedAppendWritesAll = null)
        {
            tags ??= new List<string>();

            return new LegalHold(hasLegalHold, tags?.ToList(), allowProtectedAppendWritesAll);
        }

        /// <summary> Initializes a new instance of ImmutabilityPolicyData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="immutabilityPeriodSinceCreationInDays"> The immutability period for the blobs in the container since the policy creation, in days. </param>
        /// <param name="state"> The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked. </param>
        /// <param name="allowProtectedAppendWrites"> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. </param>
        /// <param name="allowProtectedAppendWritesAll"> This property can only be changed for unlocked time-based retention policies. When enabled, new blocks can be written to both 'Append and Bock Blobs' while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted. This property cannot be changed with ExtendImmutabilityPolicy API. The 'allowProtectedAppendWrites' and 'allowProtectedAppendWritesAll' properties are mutually exclusive. </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <returns> A new <see cref="Storage.ImmutabilityPolicyData"/> instance for mocking. </returns>
        public static ImmutabilityPolicyData ImmutabilityPolicyData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, int? immutabilityPeriodSinceCreationInDays = null, ImmutabilityPolicyState? state = null, bool? allowProtectedAppendWrites = null, bool? allowProtectedAppendWritesAll = null, ETag? etag = null)
        {
            return new ImmutabilityPolicyData(id, name, resourceType, systemData, immutabilityPeriodSinceCreationInDays, state, allowProtectedAppendWrites, allowProtectedAppendWritesAll, etag);
        }

        /// <summary> Initializes a new instance of LeaseContainerResponse. </summary>
        /// <param name="leaseId"> Returned unique lease ID that must be included with any request to delete the container, or to renew, change, or release the lease. </param>
        /// <param name="leaseTimeSeconds"> Approximate time remaining in the lease period, in seconds. </param>
        /// <returns> A new <see cref="Models.LeaseContainerResponse"/> instance for mocking. </returns>
        public static LeaseContainerResponse LeaseContainerResponse(string leaseId = null, string leaseTimeSeconds = null)
        {
            return new LeaseContainerResponse(leaseId, leaseTimeSeconds);
        }

        /// <summary> Initializes a new instance of FileServiceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="sku"> Sku name and tier. </param>
        /// <param name="corsRulesValue"> Specifies CORS rules for the File service. You can include up to five CorsRule elements in the request. If no CorsRule elements are included in the request body, all CORS rules will be deleted, and CORS will be disabled for the File service. </param>
        /// <param name="shareDeleteRetentionPolicy"> The file service properties for share soft delete. </param>
        /// <param name="protocolSmb"> Protocol settings for file service. </param>
        /// <returns> A new <see cref="Storage.FileServiceData"/> instance for mocking. </returns>
        public static FileServiceData FileServiceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, StorageSku sku = null, IEnumerable<CorsRule> corsRulesValue = null, DeleteRetentionPolicy shareDeleteRetentionPolicy = null, SmbSetting protocolSmb = null)
        {
            corsRulesValue ??= new List<CorsRule>();

            return new FileServiceData(id, name, resourceType, systemData, sku, corsRulesValue != null ? new CorsRules(corsRulesValue?.ToList()) : null, shareDeleteRetentionPolicy, protocolSmb != null ? new ProtocolSettings(protocolSmb) : null);
        }

        /// <summary> Initializes a new instance of FileShareData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="lastModifiedOn"> Returns the date and time the share was last modified. </param>
        /// <param name="metadata"> A name-value pair to associate with the share as metadata. </param>
        /// <param name="shareQuota"> The maximum size of the share, in gigabytes. Must be greater than 0, and less than or equal to 5TB (5120). For Large File Shares, the maximum size is 102400. </param>
        /// <param name="enabledProtocols"> The authentication protocol that is used for the file share. Can only be specified when creating a share. </param>
        /// <param name="rootSquash"> The property is for NFS share only. The default is NoRootSquash. </param>
        /// <param name="version"> The version of the share. </param>
        /// <param name="deleted"> Indicates whether the share was deleted. </param>
        /// <param name="deletedOn"> The deleted time if the share was deleted. </param>
        /// <param name="remainingRetentionDays"> Remaining retention days for share that was soft deleted. </param>
        /// <param name="accessTier"> Access tier for specific share. GpV2 account can choose between TransactionOptimized (default), Hot, and Cool. FileStorage account can choose Premium. </param>
        /// <param name="accessTierChangeOn"> Indicates the last modification time for share access tier. </param>
        /// <param name="accessTierStatus"> Indicates if there is a pending transition for access tier. </param>
        /// <param name="shareUsageBytes"> The approximate size of the data stored on the share. Note that this value may not include all recently created or recently resized files. </param>
        /// <param name="leaseStatus"> The lease status of the share. </param>
        /// <param name="leaseState"> Lease state of the share. </param>
        /// <param name="leaseDuration"> Specifies whether the lease on a share is of infinite or fixed duration, only when the share is leased. </param>
        /// <param name="signedIdentifiers"> List of stored access policies specified on the share. </param>
        /// <param name="snapshotOn"> Creation time of share snapshot returned in the response of list shares with expand param "snapshots". </param>
        /// <param name="etag"> Resource Etag. </param>
        /// <returns> A new <see cref="Storage.FileShareData"/> instance for mocking. </returns>
        public static FileShareData FileShareData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, DateTimeOffset? lastModifiedOn = null, IDictionary<string, string> metadata = null, int? shareQuota = null, EnabledProtocol? enabledProtocols = null, RootSquashType? rootSquash = null, string version = null, bool? deleted = null, DateTimeOffset? deletedOn = null, int? remainingRetentionDays = null, ShareAccessTier? accessTier = null, DateTimeOffset? accessTierChangeOn = null, string accessTierStatus = null, long? shareUsageBytes = null, LeaseStatus? leaseStatus = null, LeaseState? leaseState = null, LeaseDuration? leaseDuration = null, IEnumerable<SignedIdentifier> signedIdentifiers = null, DateTimeOffset? snapshotOn = null, ETag? etag = null)
        {
            metadata ??= new Dictionary<string, string>();
            signedIdentifiers ??= new List<SignedIdentifier>();

            return new FileShareData(id, name, resourceType, systemData, lastModifiedOn, metadata, shareQuota, enabledProtocols, rootSquash, version, deleted, deletedOn, remainingRetentionDays, accessTier, accessTierChangeOn, accessTierStatus, shareUsageBytes, leaseStatus, leaseState, leaseDuration, signedIdentifiers?.ToList(), snapshotOn, etag);
        }

        /// <summary> Initializes a new instance of LeaseShareResponse. </summary>
        /// <param name="leaseId"> Returned unique lease ID that must be included with any request to delete the share, or to renew, change, or release the lease. </param>
        /// <param name="leaseTimeSeconds"> Approximate time remaining in the lease period, in seconds. </param>
        /// <returns> A new <see cref="Models.LeaseShareResponse"/> instance for mocking. </returns>
        public static LeaseShareResponse LeaseShareResponse(string leaseId = null, string leaseTimeSeconds = null)
        {
            return new LeaseShareResponse(leaseId, leaseTimeSeconds);
        }

        /// <summary> Initializes a new instance of StorageSkuInformation. </summary>
        /// <param name="name"> The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType. </param>
        /// <param name="tier"> The SKU tier. This is based on the SKU name. </param>
        /// <param name="resourceType"> The type of the resource, usually it is 'storageAccounts'. </param>
        /// <param name="kind"> Indicates the type of storage account. </param>
        /// <param name="locations"> The set of locations that the SKU is available. This will be supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). </param>
        /// <param name="capabilities"> The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </param>
        /// <param name="restrictions"> The restrictions because of which SKU cannot be used. This is empty if there are no restrictions. </param>
        /// <returns> A new <see cref="Models.StorageSkuInformation"/> instance for mocking. </returns>
        public static StorageSkuInformation StorageSkuInformation(StorageSkuName name = default, StorageSkuTier? tier = null, ResourceType? resourceType = null, StorageKind? kind = null, IEnumerable<string> locations = null, IEnumerable<SKUCapability> capabilities = null, IEnumerable<Restriction> restrictions = null)
        {
            locations ??= new List<string>();
            capabilities ??= new List<SKUCapability>();
            restrictions ??= new List<Restriction>();

            return new StorageSkuInformation(name, tier, resourceType, kind, locations?.ToList(), capabilities?.ToList(), restrictions?.ToList());
        }

        /// <summary> Initializes a new instance of SKUCapability. </summary>
        /// <param name="name"> The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc. </param>
        /// <param name="value"> A string value to indicate states of given capability. Possibly 'true' or 'false'. </param>
        /// <returns> A new <see cref="Models.SKUCapability"/> instance for mocking. </returns>
        public static SKUCapability SKUCapability(string name = null, string value = null)
        {
            return new SKUCapability(name, value);
        }

        /// <summary> Initializes a new instance of Restriction. </summary>
        /// <param name="restrictionType"> The type of restrictions. As of now only possible value for this is location. </param>
        /// <param name="values"> The value of restrictions. If the restriction type is set to location. This would be different locations where the SKU is restricted. </param>
        /// <param name="reasonCode"> The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription" is related to capacity at DC. </param>
        /// <returns> A new <see cref="Models.Restriction"/> instance for mocking. </returns>
        public static Restriction Restriction(string restrictionType = null, IEnumerable<string> values = null, ReasonCode? reasonCode = null)
        {
            values ??= new List<string>();

            return new Restriction(restrictionType, values?.ToList(), reasonCode);
        }

        /// <summary> Initializes a new instance of CheckNameAvailabilityResult. </summary>
        /// <param name="nameAvailable"> Gets a boolean value that indicates whether the name is available for you to use. If true, the name is available. If false, the name has already been taken or is invalid and cannot be used. </param>
        /// <param name="reason"> Gets the reason that a storage account name could not be used. The Reason element is only returned if NameAvailable is false. </param>
        /// <param name="message"> Gets an error message explaining the Reason value in more detail. </param>
        /// <returns> A new <see cref="Models.CheckNameAvailabilityResult"/> instance for mocking. </returns>
        public static CheckNameAvailabilityResult CheckNameAvailabilityResult(bool? nameAvailable = null, Reason? reason = null, string message = null)
        {
            return new CheckNameAvailabilityResult(nameAvailable, reason, message);
        }

        /// <summary> Initializes a new instance of EncryptionService. </summary>
        /// <param name="enabled"> A boolean indicating whether or not the service encrypts the data as it is stored. </param>
        /// <param name="lastEnabledOn"> Gets a rough estimate of the date/time when the encryption was last enabled by the user. Only returned when encryption is enabled. There might be some unencrypted blobs which were written after this time, as it is just a rough estimate. </param>
        /// <param name="keyType"> Encryption key type to be used for the encryption service. 'Account' key type implies that an account-scoped encryption key will be used. 'Service' key type implies that a default service key is used. </param>
        /// <returns> A new <see cref="Models.EncryptionService"/> instance for mocking. </returns>
        public static EncryptionService EncryptionService(bool? enabled = null, DateTimeOffset? lastEnabledOn = null, KeyType? keyType = null)
        {
            return new EncryptionService(enabled, lastEnabledOn, keyType);
        }

        /// <summary> Initializes a new instance of KeyVaultProperties. </summary>
        /// <param name="keyName"> The name of KeyVault key. </param>
        /// <param name="keyVersion"> The version of KeyVault key. </param>
        /// <param name="keyVaultUri"> The Uri of KeyVault. </param>
        /// <param name="currentVersionedKeyIdentifier"> The object identifier of the current versioned Key Vault Key in use. </param>
        /// <param name="lastKeyRotationTimestamp"> Timestamp of last rotation of the Key Vault Key. </param>
        /// <returns> A new <see cref="Models.KeyVaultProperties"/> instance for mocking. </returns>
        public static KeyVaultProperties KeyVaultProperties(string keyName = null, string keyVersion = null, Uri keyVaultUri = null, string currentVersionedKeyIdentifier = null, DateTimeOffset? lastKeyRotationTimestamp = null)
        {
            return new KeyVaultProperties(keyName, keyVersion, keyVaultUri, currentVersionedKeyIdentifier, lastKeyRotationTimestamp);
        }

        /// <summary> Initializes a new instance of StorageAccountData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> Gets the SKU. </param>
        /// <param name="kind"> Gets the Kind. </param>
        /// <param name="identity"> The identity of the resource. </param>
        /// <param name="extendedLocation"> The extendedLocation of the resource. </param>
        /// <param name="provisioningState"> Gets the status of the storage account at the time the operation was called. </param>
        /// <param name="primaryEndpoints"> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object. Note that Standard_ZRS and Premium_LRS accounts only return the blob endpoint. </param>
        /// <param name="primaryLocation"> Gets the location of the primary data center for the storage account. </param>
        /// <param name="statusOfPrimary"> Gets the status indicating whether the primary location of the storage account is available or unavailable. </param>
        /// <param name="lastGeoFailoverOn"> Gets the timestamp of the most recent instance of a failover to the secondary location. Only the most recent timestamp is retained. This element is not returned if there has never been a failover instance. Only available if the accountType is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="secondaryLocation"> Gets the location of the geo-replicated secondary for the storage account. Only available if the accountType is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="statusOfSecondary"> Gets the status indicating whether the secondary location of the storage account is available or unavailable. Only available if the SKU name is Standard_GRS or Standard_RAGRS. </param>
        /// <param name="createdOn"> Gets the creation date and time of the storage account in UTC. </param>
        /// <param name="customDomain"> Gets the custom domain the user assigned to this storage account. </param>
        /// <param name="sasPolicy"> SasPolicy assigned to the storage account. </param>
        /// <param name="keyExpirationPeriodInDays"> KeyPolicy assigned to the storage account. </param>
        /// <param name="keyCreationTime"> Storage account keys creation time. </param>
        /// <param name="secondaryEndpoints"> Gets the URLs that are used to perform a retrieval of a public blob, queue, or table object from the secondary location of the storage account. Only available if the SKU name is Standard_RAGRS. </param>
        /// <param name="encryption"> Gets the encryption settings on the account. If unspecified, the account is unencrypted. </param>
        /// <param name="accessTier"> Required for storage accounts where kind = BlobStorage. The access tier used for billing. </param>
        /// <param name="azureFilesIdentityBasedAuthentication"> Provides the identity based authentication settings for Azure Files. </param>
        /// <param name="enableHttpsTrafficOnly"> Allows https traffic only to storage service if sets to true. </param>
        /// <param name="networkRuleSet"> Network rule set. </param>
        /// <param name="isHnsEnabled"> Account HierarchicalNamespace enabled if sets to true. </param>
        /// <param name="geoReplicationStats"> Geo Replication Stats. </param>
        /// <param name="failoverInProgress"> If the failover is in progress, the value will be true, otherwise, it will be null. </param>
        /// <param name="largeFileSharesState"> Allow large file shares if sets to Enabled. It cannot be disabled once it is enabled. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connection associated with the specified storage account. </param>
        /// <param name="routingPreference"> Maintains information about the network routing choice opted by the user for data transfer. </param>
        /// <param name="blobRestoreStatus"> Blob restore status. </param>
        /// <param name="allowBlobPublicAccess"> Allow or disallow public access to all blobs or containers in the storage account. The default interpretation is true for this property. </param>
        /// <param name="minimumTlsVersion"> Set the minimum TLS version to be permitted on requests to storage. The default interpretation is TLS 1.0 for this property. </param>
        /// <param name="allowSharedKeyAccess"> Indicates whether the storage account permits requests to be authorized with the account access key via Shared Key. If false, then all requests, including shared access signatures, must be authorized with Azure Active Directory (Azure AD). The default value is null, which is equivalent to true. </param>
        /// <param name="enableNfsV3"> NFS 3.0 protocol support enabled if set to true. </param>
        /// <param name="allowCrossTenantReplication"> Allow or disallow cross AAD tenant object replication. The default interpretation is true for this property. </param>
        /// <param name="defaultToOAuthAuthentication"> A boolean flag which indicates whether the default authentication is OAuth or not. The default interpretation is false for this property. </param>
        /// <param name="publicNetworkAccess"> Allow or disallow public network access to Storage Account. Value is optional but if passed in, must be 'Enabled' or 'Disabled'. </param>
        /// <param name="immutableStorageWithVersioning"> The property is immutable and can only be set to true at the account creation time. When set to true, it enables object level immutability for all the containers in the account by default. </param>
        /// <returns> A new <see cref="Storage.StorageAccountData"/> instance for mocking. </returns>
        public static StorageAccountData StorageAccountData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, StorageSku sku = null, StorageKind? kind = null, ManagedServiceIdentity identity = null, ExtendedLocation extendedLocation = null, ProvisioningState? provisioningState = null, Endpoints primaryEndpoints = null, string primaryLocation = null, AccountStatus? statusOfPrimary = null, DateTimeOffset? lastGeoFailoverOn = null, string secondaryLocation = null, AccountStatus? statusOfSecondary = null, DateTimeOffset? createdOn = null, CustomDomain customDomain = null, SasPolicy sasPolicy = null, int? keyExpirationPeriodInDays = null, KeyCreationTime keyCreationTime = null, Endpoints secondaryEndpoints = null, Encryption encryption = null, AccessTier? accessTier = null, AzureFilesIdentityBasedAuthentication azureFilesIdentityBasedAuthentication = null, bool? enableHttpsTrafficOnly = null, NetworkRuleSet networkRuleSet = null, bool? isHnsEnabled = null, GeoReplicationStats geoReplicationStats = null, bool? failoverInProgress = null, LargeFileSharesState? largeFileSharesState = null, IEnumerable<StoragePrivateEndpointConnectionData> privateEndpointConnections = null, RoutingPreference routingPreference = null, BlobRestoreStatus blobRestoreStatus = null, bool? allowBlobPublicAccess = null, MinimumTlsVersion? minimumTlsVersion = null, bool? allowSharedKeyAccess = null, bool? enableNfsV3 = null, bool? allowCrossTenantReplication = null, bool? defaultToOAuthAuthentication = null, PublicNetworkAccess? publicNetworkAccess = null, ImmutableStorageAccount immutableStorageWithVersioning = null)
        {
            tags ??= new Dictionary<string, string>();
            privateEndpointConnections ??= new List<StoragePrivateEndpointConnectionData>();

            return new StorageAccountData(id, name, resourceType, systemData, tags, location, sku, kind, identity, extendedLocation, provisioningState, primaryEndpoints, primaryLocation, statusOfPrimary, lastGeoFailoverOn, secondaryLocation, statusOfSecondary, createdOn, customDomain, sasPolicy, keyExpirationPeriodInDays.HasValue ? new KeyPolicy(keyExpirationPeriodInDays.Value) : null, keyCreationTime, secondaryEndpoints, encryption, accessTier, azureFilesIdentityBasedAuthentication, enableHttpsTrafficOnly, networkRuleSet, isHnsEnabled, geoReplicationStats, failoverInProgress, largeFileSharesState, privateEndpointConnections?.ToList(), routingPreference, blobRestoreStatus, allowBlobPublicAccess, minimumTlsVersion, allowSharedKeyAccess, enableNfsV3, allowCrossTenantReplication, defaultToOAuthAuthentication, publicNetworkAccess, immutableStorageWithVersioning);
        }

        /// <summary> Initializes a new instance of Endpoints. </summary>
        /// <param name="blob"> Gets the blob endpoint. </param>
        /// <param name="queue"> Gets the queue endpoint. </param>
        /// <param name="table"> Gets the table endpoint. </param>
        /// <param name="file"> Gets the file endpoint. </param>
        /// <param name="web"> Gets the web endpoint. </param>
        /// <param name="dfs"> Gets the dfs endpoint. </param>
        /// <param name="microsoftEndpoints"> Gets the microsoft routing storage endpoints. </param>
        /// <param name="internetEndpoints"> Gets the internet routing storage endpoints. </param>
        /// <returns> A new <see cref="Models.Endpoints"/> instance for mocking. </returns>
        public static Endpoints Endpoints(string blob = null, string queue = null, string table = null, string file = null, string web = null, string dfs = null, StorageAccountMicrosoftEndpoints microsoftEndpoints = null, StorageAccountInternetEndpoints internetEndpoints = null)
        {
            return new Endpoints(blob, queue, table, file, web, dfs, microsoftEndpoints, internetEndpoints);
        }

        /// <summary> Initializes a new instance of StorageAccountMicrosoftEndpoints. </summary>
        /// <param name="blob"> Gets the blob endpoint. </param>
        /// <param name="queue"> Gets the queue endpoint. </param>
        /// <param name="table"> Gets the table endpoint. </param>
        /// <param name="file"> Gets the file endpoint. </param>
        /// <param name="web"> Gets the web endpoint. </param>
        /// <param name="dfs"> Gets the dfs endpoint. </param>
        /// <returns> A new <see cref="Models.StorageAccountMicrosoftEndpoints"/> instance for mocking. </returns>
        public static StorageAccountMicrosoftEndpoints StorageAccountMicrosoftEndpoints(string blob = null, string queue = null, string table = null, string file = null, string web = null, string dfs = null)
        {
            return new StorageAccountMicrosoftEndpoints(blob, queue, table, file, web, dfs);
        }

        /// <summary> Initializes a new instance of StorageAccountInternetEndpoints. </summary>
        /// <param name="blob"> Gets the blob endpoint. </param>
        /// <param name="file"> Gets the file endpoint. </param>
        /// <param name="web"> Gets the web endpoint. </param>
        /// <param name="dfs"> Gets the dfs endpoint. </param>
        /// <returns> A new <see cref="Models.StorageAccountInternetEndpoints"/> instance for mocking. </returns>
        public static StorageAccountInternetEndpoints StorageAccountInternetEndpoints(string blob = null, string file = null, string web = null, string dfs = null)
        {
            return new StorageAccountInternetEndpoints(blob, file, web, dfs);
        }

        /// <summary> Initializes a new instance of KeyCreationTime. </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <returns> A new <see cref="Models.KeyCreationTime"/> instance for mocking. </returns>
        public static KeyCreationTime KeyCreationTime(DateTimeOffset? key1 = null, DateTimeOffset? key2 = null)
        {
            return new KeyCreationTime(key1, key2);
        }

        /// <summary> Initializes a new instance of GeoReplicationStats. </summary>
        /// <param name="status"> The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location is temporarily unavailable. </param>
        /// <param name="lastSyncOn"> All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime is not available, this can happen if secondary is offline or we are in bootstrap. </param>
        /// <param name="canFailover"> A boolean flag which indicates whether or not account failover is supported for the account. </param>
        /// <returns> A new <see cref="Models.GeoReplicationStats"/> instance for mocking. </returns>
        public static GeoReplicationStats GeoReplicationStats(GeoReplicationStatus? status = null, DateTimeOffset? lastSyncOn = null, bool? canFailover = null)
        {
            return new GeoReplicationStats(status, lastSyncOn, canFailover);
        }

        /// <summary> Initializes a new instance of StoragePrivateEndpointConnectionData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="privateEndpointId"> The resource of private end point. </param>
        /// <param name="connectionState"> A collection of information about the state of the connection between service consumer and provider. </param>
        /// <param name="provisioningState"> The provisioning state of the private endpoint connection resource. </param>
        /// <returns> A new <see cref="Storage.StoragePrivateEndpointConnectionData"/> instance for mocking. </returns>
        public static StoragePrivateEndpointConnectionData StoragePrivateEndpointConnectionData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ResourceIdentifier privateEndpointId = null, StoragePrivateLinkServiceConnectionState connectionState = null, StoragePrivateEndpointConnectionProvisioningState? provisioningState = null)
        {
            return new StoragePrivateEndpointConnectionData(id, name, resourceType, systemData, privateEndpointId != null ? ResourceManagerModelFactory.SubResource(privateEndpointId) : null, connectionState, provisioningState);
        }

        /// <summary> Initializes a new instance of BlobRestoreStatus. </summary>
        /// <param name="status"> The status of blob restore progress. Possible values are: - InProgress: Indicates that blob restore is ongoing. - Complete: Indicates that blob restore has been completed successfully. - Failed: Indicates that blob restore is failed. </param>
        /// <param name="failureReason"> Failure reason when blob restore is failed. </param>
        /// <param name="restoreId"> Id for tracking blob restore request. </param>
        /// <param name="parameters"> Blob restore request parameters. </param>
        /// <returns> A new <see cref="Models.BlobRestoreStatus"/> instance for mocking. </returns>
        public static BlobRestoreStatus BlobRestoreStatus(BlobRestoreProgressStatus? status = null, string failureReason = null, string restoreId = null, BlobRestoreContent parameters = null)
        {
            return new BlobRestoreStatus(status, failureReason, restoreId, parameters);
        }

        /// <summary> Initializes a new instance of DeletedAccountData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="storageAccountResourceId"> Full resource id of the original storage account. </param>
        /// <param name="location"> Location of the deleted account. </param>
        /// <param name="restoreReference"> Can be used to attempt recovering this deleted account via PutStorageAccount API. </param>
        /// <param name="creationTime"> Creation time of the deleted account. </param>
        /// <param name="deletionTime"> Deletion time of the deleted account. </param>
        /// <returns> A new <see cref="Storage.DeletedAccountData"/> instance for mocking. </returns>
        public static DeletedAccountData DeletedAccountData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string storageAccountResourceId = null, AzureLocation? location = null, string restoreReference = null, string creationTime = null, string deletionTime = null)
        {
            return new DeletedAccountData(id, name, resourceType, systemData, storageAccountResourceId, location, restoreReference, creationTime, deletionTime);
        }

        /// <summary> Initializes a new instance of StorageAccountListKeysResult. </summary>
        /// <param name="keys"> Gets the list of storage account keys and their properties for the specified storage account. </param>
        /// <returns> A new <see cref="Models.StorageAccountListKeysResult"/> instance for mocking. </returns>
        public static StorageAccountListKeysResult StorageAccountListKeysResult(IEnumerable<StorageAccountKey> keys = null)
        {
            keys ??= new List<StorageAccountKey>();

            return new StorageAccountListKeysResult(keys?.ToList());
        }

        /// <summary> Initializes a new instance of StorageAccountKey. </summary>
        /// <param name="keyName"> Name of the key. </param>
        /// <param name="value"> Base 64-encoded value of the key. </param>
        /// <param name="permissions"> Permissions for the key -- read-only or full permissions. </param>
        /// <param name="createdOn"> Creation time of the key, in round trip date format. </param>
        /// <returns> A new <see cref="Models.StorageAccountKey"/> instance for mocking. </returns>
        public static StorageAccountKey StorageAccountKey(string keyName = null, string value = null, KeyPermission? permissions = null, DateTimeOffset? createdOn = null)
        {
            return new StorageAccountKey(keyName, value, permissions, createdOn);
        }

        /// <summary> Initializes a new instance of StorageUsage. </summary>
        /// <param name="unit"> Gets the unit of measurement. </param>
        /// <param name="currentValue"> Gets the current count of the allocated resources in the subscription. </param>
        /// <param name="limit"> Gets the maximum count of the resources that can be allocated in the subscription. </param>
        /// <param name="name"> Gets the name of the type of usage. </param>
        /// <returns> A new <see cref="Models.StorageUsage"/> instance for mocking. </returns>
        public static StorageUsage StorageUsage(UsageUnit? unit = null, int? currentValue = null, int? limit = null, UsageName name = null)
        {
            return new StorageUsage(unit, currentValue, limit, name);
        }

        /// <summary> Initializes a new instance of UsageName. </summary>
        /// <param name="value"> Gets a string describing the resource name. </param>
        /// <param name="localizedValue"> Gets a localized string describing the resource name. </param>
        /// <returns> A new <see cref="Models.UsageName"/> instance for mocking. </returns>
        public static UsageName UsageName(string value = null, string localizedValue = null)
        {
            return new UsageName(value, localizedValue);
        }

        /// <summary> Initializes a new instance of ListAccountSasResponse. </summary>
        /// <param name="accountSasToken"> List SAS credentials of storage account. </param>
        /// <returns> A new <see cref="Models.ListAccountSasResponse"/> instance for mocking. </returns>
        public static ListAccountSasResponse ListAccountSasResponse(string accountSasToken = null)
        {
            return new ListAccountSasResponse(accountSasToken);
        }

        /// <summary> Initializes a new instance of ListServiceSasResponse. </summary>
        /// <param name="serviceSasToken"> List service SAS credentials of specific resource. </param>
        /// <returns> A new <see cref="Models.ListServiceSasResponse"/> instance for mocking. </returns>
        public static ListServiceSasResponse ListServiceSasResponse(string serviceSasToken = null)
        {
            return new ListServiceSasResponse(serviceSasToken);
        }

        /// <summary> Initializes a new instance of ManagementPolicyData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="lastModifiedOn"> Returns the date and time the ManagementPolicies was last modified. </param>
        /// <param name="rules"> The Storage Account ManagementPolicy, in JSON format. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts. </param>
        /// <returns> A new <see cref="Storage.ManagementPolicyData"/> instance for mocking. </returns>
        public static ManagementPolicyData ManagementPolicyData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, DateTimeOffset? lastModifiedOn = null, IEnumerable<ManagementPolicyRule> rules = null)
        {
            rules ??= new List<ManagementPolicyRule>();

            return new ManagementPolicyData(id, name, resourceType, systemData, lastModifiedOn, rules != null ? new ManagementPolicySchema(rules?.ToList()) : null);
        }

        /// <summary> Initializes a new instance of BlobInventoryPolicyData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="lastModifiedOn"> Returns the last modified date and time of the blob inventory policy. </param>
        /// <param name="policy"> The storage account blob inventory policy object. It is composed of policy rules. </param>
        /// <returns> A new <see cref="Storage.BlobInventoryPolicyData"/> instance for mocking. </returns>
        public static BlobInventoryPolicyData BlobInventoryPolicyData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, DateTimeOffset? lastModifiedOn = null, BlobInventoryPolicySchema policy = null)
        {
            return new BlobInventoryPolicyData(id, name, resourceType, systemData, lastModifiedOn, policy);
        }

        /// <summary> Initializes a new instance of StoragePrivateLinkResource. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="groupId"> The private link resource group id. </param>
        /// <param name="requiredMembers"> The private link resource required member names. </param>
        /// <param name="requiredZoneNames"> The private link resource Private link DNS zone name. </param>
        /// <returns> A new <see cref="Models.StoragePrivateLinkResource"/> instance for mocking. </returns>
        public static StoragePrivateLinkResource StoragePrivateLinkResource(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string groupId = null, IEnumerable<string> requiredMembers = null, IEnumerable<string> requiredZoneNames = null)
        {
            requiredMembers ??= new List<string>();
            requiredZoneNames ??= new List<string>();

            return new StoragePrivateLinkResource(id, name, resourceType, systemData, groupId, requiredMembers?.ToList(), requiredZoneNames?.ToList());
        }

        /// <summary> Initializes a new instance of ObjectReplicationPolicyData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="policyId"> A unique id for object replication policy. </param>
        /// <param name="enabledOn"> Indicates when the policy is enabled on the source account. </param>
        /// <param name="sourceAccount"> Required. Source account name. It should be full resource id if allowCrossTenantReplication set to false. </param>
        /// <param name="destinationAccount"> Required. Destination account name. It should be full resource id if allowCrossTenantReplication set to false. </param>
        /// <param name="rules"> The storage account object replication rules. </param>
        /// <returns> A new <see cref="Storage.ObjectReplicationPolicyData"/> instance for mocking. </returns>
        public static ObjectReplicationPolicyData ObjectReplicationPolicyData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string policyId = null, DateTimeOffset? enabledOn = null, string sourceAccount = null, string destinationAccount = null, IEnumerable<ObjectReplicationPolicyRule> rules = null)
        {
            rules ??= new List<ObjectReplicationPolicyRule>();

            return new ObjectReplicationPolicyData(id, name, resourceType, systemData, policyId, enabledOn, sourceAccount, destinationAccount, rules?.ToList());
        }

        /// <summary> Initializes a new instance of EncryptionScopeData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="source"> The provider for the encryption scope. Possible values (case-insensitive):  Microsoft.Storage, Microsoft.KeyVault. </param>
        /// <param name="state"> The state of the encryption scope. Possible values (case-insensitive):  Enabled, Disabled. </param>
        /// <param name="createdOn"> Gets the creation date and time of the encryption scope in UTC. </param>
        /// <param name="lastModifiedOn"> Gets the last modification date and time of the encryption scope in UTC. </param>
        /// <param name="keyVaultProperties"> The key vault properties for the encryption scope. This is a required field if encryption scope 'source' attribute is set to 'Microsoft.KeyVault'. </param>
        /// <param name="requireInfrastructureEncryption"> A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest. </param>
        /// <returns> A new <see cref="Storage.EncryptionScopeData"/> instance for mocking. </returns>
        public static EncryptionScopeData EncryptionScopeData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, EncryptionScopeSource? source = null, EncryptionScopeState? state = null, DateTimeOffset? createdOn = null, DateTimeOffset? lastModifiedOn = null, EncryptionScopeKeyVaultProperties keyVaultProperties = null, bool? requireInfrastructureEncryption = null)
        {
            return new EncryptionScopeData(id, name, resourceType, systemData, source, state, createdOn, lastModifiedOn, keyVaultProperties, requireInfrastructureEncryption);
        }

        /// <summary> Initializes a new instance of EncryptionScopeKeyVaultProperties. </summary>
        /// <param name="keyUri"> The object identifier for a key vault key object. When applied, the encryption scope will use the key referenced by the identifier to enable customer-managed key support on this encryption scope. </param>
        /// <param name="currentVersionedKeyIdentifier"> The object identifier of the current versioned Key Vault Key in use. </param>
        /// <param name="lastKeyRotationTimestamp"> Timestamp of last rotation of the Key Vault Key. </param>
        /// <returns> A new <see cref="Models.EncryptionScopeKeyVaultProperties"/> instance for mocking. </returns>
        public static EncryptionScopeKeyVaultProperties EncryptionScopeKeyVaultProperties(Uri keyUri = null, string currentVersionedKeyIdentifier = null, DateTimeOffset? lastKeyRotationTimestamp = null)
        {
            return new EncryptionScopeKeyVaultProperties(keyUri, currentVersionedKeyIdentifier, lastKeyRotationTimestamp);
        }
    }
}
