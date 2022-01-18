# Azure.ResourceManager.Resources
### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
azure-arm: true
arm-core: true
require: $(this-folder)/../../readme.md
title: ResourceManagementClient
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-01-01/subscriptions.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/features.json
namespace: Azure.ResourceManager.OnlyCoreResource
model-namespace: false
public-clients: false
head-as-boolean: false
# clear-output-folder: true
modelerfour:
    lenient-model-deduplication: true
skip-csproj: true
payload-flattening-threshold: 2
operation-group-to-resource-type:
  ResourceLinks: Microsoft.Resources/links
  DataPolicyManifests: Microsoft.Authorization/dataPolicyManifests
  Providers: Microsoft.Resources/providers
  ProviderResourceTypes: Microsoft.Resources/providers/resourceTypes
  Resources: Microsoft.Resources/resources
  ResourceGroups: Microsoft.Resources/resourceGroups
operation-group-to-resource:
  ResourceLinks: ResourceLink
  DataPolicyManifests: DataPolicyManifest
  Providers: Provider
operation-group-to-parent:
  PolicyAssignments: tenant
  PolicyDefinitions: tenant
  PolicySetDefinitions: tenant
  PolicyExemptions: tenant
  ManagementLocks: tenant
  ResourceLinks: tenant
  Providers: tenant
  ProviderResourceTypes: Microsoft.Resources/providers
operation-groups-to-omit:
  Deployments;DeploymentOperations;Resources;ResourceGroups;Tags;Providers
# merge-operations:
#   WhatIf: Deployments_WhatIf_POST;Deployments_WhatIfAtTenantScope_POST;Deployments_WhatIfAtManagementGroupScope_POST;Deployments_WhatIfAtSubscriptionScope_POST
directive:
  - from: swagger-document
    where: $.paths
    transform: delete $["/providers/Microsoft.Resources/operations"]
  - from: swagger-document
    where: $.paths
    transform: delete $["/providers/Microsoft.Authorization/operations"]
  - from: swagger-document
    where: $.paths
    transform: delete $["/providers/Microsoft.Solutions/operations"]
  - from: features.json
    where: $.paths
    transform: delete $["/providers/Microsoft.Features/operations"]
  # - from: resources.json
  #   where: $.definitions
  #   transform: delete $["Provider"]
  # - from: resources.json
  #   where: $.definitions
  #   transform: delete $["ProviderResourceType"]
  # - from: resources.json
  #   where: $.definitions
  #   transform: delete $["ProviderExtendedLocation"]
  # Below operations are already in the Core SDK.
#   - remove-operation: Providers_Unregister
#   - remove-operation: Providers_Register
#   - remove-operation: Providers_List
#   - remove-operation: Providers_ListAtTenantScope
#   - remove-operation: Providers_Get
#   - remove-operation: Providers_GetAtTenantScope
#   - remove-operation: Providers_RegisterAtManagementGroupScope
#   - remove-operation: Providers_ProviderPermissions
#   - remove-operation: ProviderResourceTypes_List
#   - remove-operation: Resources_MoveResources
#   - remove-operation: Resources_ValidateMoveResources
#   - remove-operation: Resources_List
#   - remove-operation: Resources_CheckExistence
#   - remove-operation: Resources_Delete
#   - remove-operation: Resources_CreateOrUpdate
#   - remove-operation: Resources_Update
#   - remove-operation: Resources_Get
#   - remove-operation: Resources_CheckExistenceById
#   - remove-operation: Resources_CreateOrUpdateById
#   - remove-operation: Resources_UpdateById
#   - remove-operation: Resources_GetById
#   - remove-operation: Resources_DeleteById
#   - remove-operation: Resources_ListByResourceGroup
#   - remove-operation: ResourceGroups_CheckExistence
#   - remove-operation: ResourceGroups_CreateOrUpdate
#   - remove-operation: ResourceGroups_Delete
#   - remove-operation: ResourceGroups_Get
#   - remove-operation: ResourceGroups_Update
#   - remove-operation: ResourceGroups_List
#   - remove-operation: ResourceGroups_ExportTemplate
#   - remove-operation: Tags_DeleteValue
#   - remove-operation: Tags_CreateOrUpdateValue
#   - remove-operation: Tags_CreateOrUpdate
#   - remove-operation: Tags_Delete
#   - remove-operation: Tags_List
#   - remove-operation: Tags_CreateOrUpdateAtScope
#   - remove-operation: Tags_UpdateAtScope
#   - remove-operation: Tags_GetAtScope
#   - remove-operation: Tags_DeleteAtScope
#   - remove-operation: Subscriptions_ListLocations
#   - remove-operation: Subscriptions_Get
#   - remove-operation: Subscriptions_List
#   - remove-operation: Tenants_List
#   - remove-operation: checkResourceName
#   - remove-operation: Features_ListAll
#   - remove-operation: Features_List
#   - remove-operation: Features_Get
#   - remove-operation: Features_Register
#   - remove-operation: Features_Unregister
  # These methods can be replaced by using other methods in the same operation group, remove for Preview.
  - remove-operation: PolicyAssignments_DeleteById
  - remove-operation: PolicyAssignments_CreateById
  - remove-operation: PolicyAssignments_GetById
  # The input of CreateOrUpdateAtTenantScope/CreateOrUpdateAtManagementGroupScope is using ScopedDeployment, slightly different from the Deployment used by CreateOrUpdateAtScope/CreateOrUpdateAtSubscriptionScope/CreateOrUpdate(AtResourceGroupScope). The only difference is that location property is required in ScopeDeployment. Let's just use the general AtScope methods for Preview.
#   - remove-operation: Deployments_DeleteAtTenantScope
#   - remove-operation: Deployments_CheckExistenceAtTenantScope
#   - remove-operation: Deployments_CreateOrUpdateAtTenantScope
#   - remove-operation: Deployments_GetAtTenantScope
#   - remove-operation: Deployments_CancelAtTenantScope
#   - remove-operation: Deployments_ValidateAtTenantScope
#   - remove-operation: Deployments_ExportTemplateAtTenantScope
#   - remove-operation: Deployments_ListAtTenantScope
#   - remove-operation: Deployments_DeleteAtManagementGroupScope
#   - remove-operation: Deployments_CheckExistenceAtManagementGroupScope
#   - remove-operation: Deployments_CreateOrUpdateAtManagementGroupScope
#   - remove-operation: Deployments_GetAtManagementGroupScope
#   - remove-operation: Deployments_CancelAtManagementGroupScope
#   - remove-operation: Deployments_ValidateAtManagementGroupScope
#   - remove-operation: Deployments_ExportTemplateAtManagementGroupScope
#   - remove-operation: Deployments_ListAtManagementGroupScope
#   - remove-operation: Deployments_DeleteAtSubscriptionScope
#   - remove-operation: Deployments_CheckExistenceAtSubscriptionScope
#   - remove-operation: Deployments_CreateOrUpdateAtSubscriptionScope
#   - remove-operation: Deployments_GetAtSubscriptionScope
#   - remove-operation: Deployments_CancelAtSubscriptionScope
#   - remove-operation: Deployments_ValidateAtSubscriptionScope
#   - remove-operation: Deployments_ExportTemplateAtSubscriptionScope
#   - remove-operation: Deployments_ListAtSubscriptionScope
#   - remove-operation: Deployments_Delete
#   - remove-operation: Deployments_CheckExistence
#   - remove-operation: Deployments_CreateOrUpdate
#   - remove-operation: Deployments_Get
#   - remove-operation: Deployments_Cancel
#   - remove-operation: Deployments_Validate
#   - remove-operation: Deployments_ExportTemplate
#   - remove-operation: Deployments_ListByResourceGroup
#   - remove-operation: DeploymentOperations_GetAtTenantScope
#   - remove-operation: DeploymentOperations_ListAtTenantScope
#   - remove-operation: DeploymentOperations_GetAtManagementGroupScope
#   - remove-operation: DeploymentOperations_ListAtManagementGroupScope
#   - remove-operation: DeploymentOperations_GetAtSubscriptionScope
#   - remove-operation: DeploymentOperations_ListAtSubscriptionScope
#   - remove-operation: DeploymentOperations_Get
#   - remove-operation: DeploymentOperations_List
  - remove-operation: ManagementLocks_CreateOrUpdateAtResourceGroupLevel
  - remove-operation: ManagementLocks_CreateOrUpdateAtResourceLevel
  - remove-operation: ManagementLocks_CreateOrUpdateAtSubscriptionLevel
  - remove-operation: ManagementLocks_DeleteAtResourceGroupLevel
  - remove-operation: ManagementLocks_DeleteAtResourceLevel
  - remove-operation: ManagementLocks_DeleteAtSubscriptionLevel
  - remove-operation: ManagementLocks_GetAtResourceGroupLevel
  - remove-operation: ManagementLocks_GetAtResourceLevel
  - remove-operation: ManagementLocks_GetAtSubscriptionLevel
  - remove-operation: ResourceLinks_ListAtSubscription
#   - remove-operation: Applications_GetById
#   - remove-operation: Applications_DeleteById
#   - remove-operation: Applications_CreateOrUpdateById
#   - remove-operation: Applications_UpdateById
#   - from: managedapplications.json
#     where: $["x-ms-paths"]
#     transform: delete $["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}?disambiguation_dummy"]
#     reason: The operations duplicate with the ones in /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}
#   - rename-operation:
#       from: Deployments_WhatIf
#       to: Deployments_WhatIfAtResourceGroupScope
#   - rename-operation:
#       from: DeploymentScripts_GetLogs
#       to: DeploymentScriptLogs_GetLogs
#   - rename-operation:
#       from: DeploymentScripts_GetLogsDefault
#       to: DeploymentScriptLogs_GetLogsDefault
```

## Swagger workarounds

### Add nullable annotations

<!-- ``` yaml
directive:
  from: swagger-document
  where: $.definitions.DeploymentOperationProperties
  transform: >
    $.properties.statusMessage["x-nullable"] = true; -->
````
