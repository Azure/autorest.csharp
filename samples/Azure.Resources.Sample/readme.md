# Azure.Resources.Sample
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../readme.md
title: ResourceManagementClient
# library-name: Resources
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2021-01-01/subscriptions.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/dataPolicyManifests.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policyAssignments.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policyDefinitions.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2020-09-01/policySetDefinitions.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/preview/2020-07-01-preview/policyExemptions.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2020-10-01/deploymentScripts.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Features/stable/2021-07-01/features.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Authorization/stable/2016-09-01/locks.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Resources/stable/2016-09-01/links.json
    # - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/91ac14531f0d05b3d6fcf4a817ea0defde59fe63/specification/resources/resource-manager/Microsoft.Solutions/stable/2019-07-01/managedapplications.json
namespace: Azure.ResourceManager.Resources
model-namespace: false
public-clients: false
head-as-boolean: false
# clear-output-folder: true
modelerfour:
    lenient-model-deduplication: true
skip-csproj: true
payload-flattening-threshold: 2
operation-group-to-resource-type:
  DeploymentOperations: Microsoft.Resources/deployments/operations
  ResourceLinks: Microsoft.Resources/links
  Deployments: Microsoft.Resources/deployments
  DataPolicyManifests: Microsoft.Authorization/dataPolicyManifests
operation-group-to-resource:
  DeploymentOperations: DeploymentOperation
  ResourceLinks: ResourceLink
  Deployments: DeploymentExtended
  DeploymentScripts: DeploymentScript
  ApplicationDefinitions: ApplicationDefinition
  DataPolicyManifests: DataPolicyManifest
operation-group-to-parent:
  Deployments: tenant
  PolicyAssignments: tenant
  PolicyDefinitions: tenant
  PolicySetDefinitions: tenant
  PolicyExemptions: tenant
  DeploymentScripts: resourceGroups
  ManagementLocks: resourceGroups
  ResourceLinks: tenant
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
  - remove-operation: Providers_Unregister
  - remove-operation: Providers_Register
  - remove-operation: Providers_List
  - remove-operation: Providers_ListAtTenantScope
  - remove-operation: Providers_Get
  - remove-operation: Providers_GetAtTenantScope
  - remove-operation: Providers_RegisterAtManagementGroupScope
  - remove-operation: Providers_ProviderPermissions
  - remove-operation: ProviderResourceTypes_List
  - remove-operation: Resources_MoveResources
  - remove-operation: Resources_ValidateMoveResources
  - remove-operation: Resources_List
  - remove-operation: Resources_CheckExistence
  - remove-operation: Resources_Delete
  - remove-operation: Resources_CreateOrUpdate
  - remove-operation: Resources_Update
  - remove-operation: Resources_Get
  - remove-operation: Resources_CheckExistenceById
  - remove-operation: Resources_CreateOrUpdateById
  - remove-operation: Resources_UpdateById
  - remove-operation: Resources_GetById
  - remove-operation: Resources_DeleteById
  - remove-operation: Resources_ListByResourceGroup
  - remove-operation: ResourceGroups_CheckExistence
  - remove-operation: ResourceGroups_CreateOrUpdate
  - remove-operation: ResourceGroups_Delete
  - remove-operation: ResourceGroups_Get
  - remove-operation: ResourceGroups_Update
  - remove-operation: ResourceGroups_List
  - remove-operation: ResourceGroups_ExportTemplate
  - remove-operation: Tags_DeleteValue
  - remove-operation: Tags_CreateOrUpdateValue
  - remove-operation: Tags_CreateOrUpdate
  - remove-operation: Tags_Delete
  - remove-operation: Tags_List
  - remove-operation: Tags_CreateOrUpdateAtScope
  - remove-operation: Tags_UpdateAtScope
  - remove-operation: Tags_GetAtScope
  - remove-operation: Tags_DeleteAtScope
  - remove-operation: Subscriptions_ListLocations
  - remove-operation: Subscriptions_Get
  - remove-operation: Subscriptions_List
  - remove-operation: Tenants_List
  - remove-operation: checkResourceName
  - remove-operation: Features_ListAll
  - remove-operation: Features_List
  - remove-operation: Features_Get
  - remove-operation: Features_Register
  - remove-operation: Features_Unregister
  # These methods can be replaced by using other methods in the same operation group, remove for Preview.
  - remove-operation: PolicyAssignments_DeleteById
  - remove-operation: PolicyAssignments_CreateById
  - remove-operation: PolicyAssignments_GetById
  # The input of CreateOrUpdateAtTenantScope/CreateOrUpdateAtManagementGroupScope is using ScopedDeployment, slightly different from the Deployment used by CreateOrUpdateAtScope/CreateOrUpdateAtSubscriptionScope/CreateOrUpdate(AtResourceGroupScope). The only difference is that location property is required in ScopeDeployment. Let's just use the general AtScope methods for Preview.
  - remove-operation: Deployments_DeleteAtTenantScope
  - remove-operation: Deployments_CheckExistenceAtTenantScope
  - remove-operation: Deployments_CreateOrUpdateAtTenantScope
  - remove-operation: Deployments_GetAtTenantScope
  - remove-operation: Deployments_CancelAtTenantScope
  - remove-operation: Deployments_ValidateAtTenantScope
  - remove-operation: Deployments_ExportTemplateAtTenantScope
  - remove-operation: Deployments_ListAtTenantScope
  - remove-operation: Deployments_DeleteAtManagementGroupScope
  - remove-operation: Deployments_CheckExistenceAtManagementGroupScope
  - remove-operation: Deployments_CreateOrUpdateAtManagementGroupScope
  - remove-operation: Deployments_GetAtManagementGroupScope
  - remove-operation: Deployments_CancelAtManagementGroupScope
  - remove-operation: Deployments_ValidateAtManagementGroupScope
  - remove-operation: Deployments_ExportTemplateAtManagementGroupScope
  - remove-operation: Deployments_ListAtManagementGroupScope
  - remove-operation: Deployments_DeleteAtSubscriptionScope
  - remove-operation: Deployments_CheckExistenceAtSubscriptionScope
  - remove-operation: Deployments_CreateOrUpdateAtSubscriptionScope
  - remove-operation: Deployments_GetAtSubscriptionScope
  - remove-operation: Deployments_CancelAtSubscriptionScope
  - remove-operation: Deployments_ValidateAtSubscriptionScope
  - remove-operation: Deployments_ExportTemplateAtSubscriptionScope
  - remove-operation: Deployments_ListAtSubscriptionScope
  - remove-operation: Deployments_Delete
  - remove-operation: Deployments_CheckExistence
  - remove-operation: Deployments_CreateOrUpdate
  - remove-operation: Deployments_Get
  - remove-operation: Deployments_Cancel
  - remove-operation: Deployments_Validate
  - remove-operation: Deployments_ExportTemplate
  - remove-operation: Deployments_ListByResourceGroup
  - rename-operation:
      from: Deployments_WhatIf
      to: Deployments_WhatIfAtResourceGroupScope
```

## Swagger workarounds

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.DeploymentOperationProperties
  transform: >
    $.properties.statusMessage["x-nullable"] = true;
````
