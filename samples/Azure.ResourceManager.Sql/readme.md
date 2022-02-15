# Azure.ResourceManager.Sql
### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
azure-arm: true
require: $(this-folder)/../../readme.md
title: SqlManagementClient
library-name: Resources
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01-legacy/backups_legacy.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01/connectionPolicies.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01/dataMasking.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01/geoBackupPolicies.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01/metrics.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01-legacy/replicationLinks_legacy.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01/serverCommunicationLinks.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01/serviceObjectives.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01-legacy/sql.core_legacy.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/stable/2014-04-01-legacy/usages_legacy.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/BlobAuditing.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseAdvisors.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseAutomaticTuning.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseColumns.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseRecommendedActions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseSchemas.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseSecurityAlertPolicies.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseTables.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseVulnerabilityAssesmentRuleBaselines.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseVulnerabilityAssessments.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DatabaseVulnerabilityAssessmentScans.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DataWarehouseUserActivities.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/DeletedServers.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ElasticPoolOperations.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ElasticPools.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/EncryptionProtectors.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/FailoverGroups.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/FirewallRules.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/InstanceFailoverGroups.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/InstancePools.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/JobAgents.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/JobCredentials.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/JobExecutions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/Jobs.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/JobStepExecutions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/JobSteps.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/JobTargetExecutions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/JobTargetGroups.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/JobVersions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/LocationCapabilities.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/LongTermRetentionBackups.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/LongTermRetentionManagedInstanceBackups.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/LongTermRetentionPolicies.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/MaintenanceWindowOptions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/MaintenanceWindows.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedBackupShortTermRetentionPolicies.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseColumns.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseQueries.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseRestoreDetails.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabases.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseSchemas.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseSecurityAlertPolicies.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseSecurityEvents.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseSensitivityLabels.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseTables.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseTransparentDataEncryption.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseVulnerabilityAssessmentRuleBaselines.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseVulnerabilityAssessments.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedDatabaseVulnerabilityAssessmentScans.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceAdministrators.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceAzureADOnlyAuthentications.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceEncryptionProtectors.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceKeys.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceLongTermRetentionPolicies.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceOperations.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstancePrivateEndpointConnections.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstancePrivateLinkResources.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstances.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceTdeCertificates.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedInstanceVulnerabilityAssessments.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ManagedServerSecurityAlertPolicies.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/Operations.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/OperationsHealth.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/PrivateEndpointConnections.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/PrivateLinkResources.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/RecoverableManagedDatabases.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/RestorePoints.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/SensitivityLabels.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerAdvisors.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerAutomaticTuning.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerAzureADAdministrators.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerAzureADOnlyAuthentications.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerDevOpsAudit.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerDnsAliases.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerKeys.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerOperations.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerSecurityAlertPolicies.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerTrustGroups.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/ServerVulnerabilityAssessments.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/SqlAgent.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/SubscriptionUsages.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/SyncAgents.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/SyncGroups.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/SyncMembers.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/TdeCertificates.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/TimeZones.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/VirtualClusters.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/VirtualNetworkRules.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/WorkloadClassifiers.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2020-11-01-preview/WorkloadGroups.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/TransparentDataEncryptions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/BackupShortTermRetentionPolicies.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/Databases.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/DatabaseExtensions.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/DatabaseOperations.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/DatabaseUsages.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/LedgerDigestUploads.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/OutboundFirewallRules.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/ReplicationLinks.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/RestorableDroppedDatabases.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/RestorableDroppedManagedDatabases.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/Servers.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/Microsoft.Sql/preview/2021-02-01-preview/Usages.json
namespace: Azure.ResourceManager.Sql
model-namespace: false
public-clients: false
head-as-boolean: false
# clear-output-folder: true
modelerfour:
    lenient-model-deduplication: true
skip-csproj: true
# require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/50a94ccd66f49aed78efa24ceefd0d5c1186c8db/specification/sql/resource-manager/readme.md
show-request-path: true
request-path-to-resource-name:
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataMaskingPolicies/{dataMaskingPolicyName}/rules/{dataMaskingRuleName}: DataMaskingRule
request-path-to-parent:
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/currentSensitivityLabels: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}
operation-group-to-resource:
    RecoverableDatabases: RecoverableDatabase
    RestorableDroppedDatabases: RestorableDroppedDatabase
    RecommendedElasticPools: RecommendedElasticPool
    ReplicationLinks: ReplicationLink
    ServiceObjectives: ServiceObjective
    ElasticPoolActivities: NonResource
    ElasticPoolDatabaseActivities: NonResource
    ServiceTierAdvisors: ServiceTierAdvisor
    TransparentDataEncryptionActivities: NonResource
    ServerUsages: NonResource
    DatabaseUsages: NonResource
    VirtualClusters: VirtualCluster
    RestorableDroppedManagedDatabases: RestorableDroppedManagedDatabase
    RestorePoints: RestorePoint
    DatabaseOperations: DatabaseOperation
    ElasticPoolOperations: ElasticPoolOperation
    ManagedDatabaseVulnerabilityAssessmentScans: VulnerabilityAssessmentScanRecord
    RecoverableManagedDatabases: RecoverableManagedDatabase
    Usages: Usage
    PrivateLinkResources: PrivateLinkResource
    ManagedInstanceOperations: ManagedInstanceOperation
    ManagedDatabaseRestoreDetails: ManagedDatabaseRestoreDetailsResult
    DatabaseAutomaticTuning: DatabaseAutomaticTuning
    JobExecutions: JobExecution
    JobStepExecutions: JobExecution
    JobTargetExecutions: JobExecution
    JobVersions: JobVersion
    ServerAutomaticTuning: ServerAutomaticTuning
    ServerDnsAliases: ServerDnsAlias
operation-group-to-resource-type:
    RecoverableDatabases: Microsoft.Sql/servers/recoverableDatabases
    RestorableDroppedDatabases: Microsoft.Sql/servers/restorableDroppedDatabases
    RecommendedElasticPools: Microsoft.Sql/servers/recommendedElasticPools
    ServiceObjectives: Microsoft.Sql/servers/serviceObjectives
    ElasticPoolActivities: Microsoft.Sql/servers/elasticPools/elasticPoolActivity
    ElasticPoolDatabaseActivities: Microsoft.Sql/servers/elasticPools/elasticPoolDatabaseActivity
    ServiceTierAdvisors: Microsoft.Sql/servers/databases/serviceTierAdvisors
    TransparentDataEncryptionActivities: Microsoft.Sql/servers/databases/transparentDataEncryption/operationResults
    ServerUsages: Microsoft.Sql/servers/usages
    DatabaseUsages: Microsoft.Sql/servers/databases/usages
    RestorableDroppedManagedDatabases: Microsoft.Sql/managedInstances/restorableDroppedDatabases
    DatabaseOperations: Microsoft.Sql/servers/databases/operations
    ElasticPoolOperations: Microsoft.Sql/servers/elasticPools/operations
    ManagedDatabaseVulnerabilityAssessmentScans: Microsoft.Sql/managedInstances/databases/
    RecoverableManagedDatabases: Microsoft.Sql/managedInstances/recoverableDatabases
    Usages: Microsoft.Sql/instancePools/usages
    PrivateLinkResources: Microsoft.Sql/servers/privateLinkResources
    ManagedInstanceOperations: Microsoft.Sql/managedInstances/operations
    ManagedDatabaseRestoreDetails: Microsoft.Sql/managedInstances/databases/restoreDetails
    JobStepExecutions: Microsoft.Sql/servers/jobAgents/jobs/executions/steps
    JobTargetExecutions: Microsoft.Sql/servers/jobAgents/jobs/executions/steps/targets
    JobVersions: Microsoft.Sql/servers/jobAgents/jobs/versions
operation-group-to-parent:
    DatabaseAutomaticTuning: Microsoft.Sql/servers/databases
    DatabaseVulnerabilityAssessments: Microsoft.Sql/servers/databases
    ManagedDatabaseVulnerabilityAssessments: Microsoft.Sql/managedInstances/databases
    DatabaseVulnerabilityAssessmentRuleBaselines: Microsoft.Sql/servers/databases/vulnerabilityAssessments
    JobStepExecutions: Microsoft.Sql/servers/jobAgents/jobs/executions
    JobTargetExecutions: Microsoft.Sql/servers/jobAgents/jobs/executions/steps
    ServerAutomaticTuning: Microsoft.Sql/servers
    MaintenanceWindows: Microsoft.Sql/servers/databases
operation-group-to-singleton-resource:
    DatabaseAutomaticTuning: automaticTuning/current
    ServerAutomaticTuning: automaticTuning/current
    MaintenanceWindows: maintenanceWindows/current
operation-group-is-extension: ManagedDatabaseVulnerabilityAssessments;JobStepExecutions;JobTargetExecutions;ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies
operation-group-is-tuple: DatabaseVulnerabilityAssessmentRuleBaselines
directive:
    # - rename-operation:
    #     from: JobTargetExecutions_ListByJobExecution
    #     to: JobExecutions_ListTargetExecutions
    # - rename-operation:
    #     from: JobSteps_ListByVersion
    #     to: JobVersions_ListSteps
    # - rename-operation:
    #     from: SensitivityLabels_ListCurrentByDatabase
    #     to: Databases_ListCurrentSensitivityLabels
    # - rename-operation:
    #     from: SensitivityLabels_ListRecommendedByDatabase
    #     to: Databases_ListRecommendedSensitivityLabels
    - rename-operation:
        from: ManagedDatabaseRecommendedSensitivityLabels_Update
        to: ManagedDatabaseSensitivityLabels_UpdateRecommended
    - rename-operation:
        from: RecommendedSensitivityLabels_Update
        to: SensitivityLabels_UpdateRecommended
    # - rename-operation:
    #     from: ManagedDatabaseVulnerabilityAssessments_Get
    #     to: DatabaseVulnerabilityAssessments_GetManaged
#     - rename-operation:
#         from: ManagedDatabaseVulnerabilityAssessments_Get
#         to: DatabaseVulnerabilityAssessments_GetManaged
#     - rename-operation:
#         from: ManagedDatabaseVulnerabilityAssessments_CreateOrUpdate
#         to: DatabaseVulnerabilityAssessments_CreateOrUpdateManaged
```
