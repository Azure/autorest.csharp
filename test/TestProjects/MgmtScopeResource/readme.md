# MgmtParent
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
title: ResourceManagementClient
require: $(this-folder)/../../../readme.md
input-file: 
  - $(this-folder)/PolicyAssignments.json
  - $(this-folder)/Deployments.json
namespace: MgmtScopeResource
# Parameter flatten is needed by the merged WhatIf() method of Deployments as the request body parameter is ScopedDeploymentWhatIf for WhatIfAtTenantScope() and WhatIfAtManagementGroupScope() and DeploymentWhatIf for WhatIfAtSubscriptionScope and WhatIf(AtResourceGroupScope). Both parameters contains location and properties of DeploymentWhatIfProperties. The only difference is that location is required in ScopedDeploymentWhatIf and optional in DeploymentWhatIf. After flattened, all WhatIf methods can take the same types of parameters so we can merged them into one method with merge-operations although the requirement of non-null location for WhatIfAtTenantScope() and WhatIfAtManagementGroupScope() is lost.
payload-flattening-threshold: 2
operation-group-to-resource-type:
  Deployments: Microsoft.Resources/deployments
  DeploymentOperations: Microsoft.Resources/deployments/operations
operation-group-to-resource:
  DeploymentOperations: DeploymentOperation
  Deployments: DeploymentExtended
operation-group-to-parent:
  Deployments: tenant
  PolicyAssignments: tenant
merge-operations:
  WhatIf: Deployments_WhatIf_POST;Deployments_WhatIfAtTenantScope_POST;Deployments_WhatIfAtManagementGroupScope_POST;Deployments_WhatIfAtSubscriptionScope_POST
directive:
  # These methods can be replaced by using other methods in the same operation group, remove for Preview.
  - remove-operation: PolicyAssignments_DeleteById
  - remove-operation: PolicyAssignments_CreateById
  - remove-operation: PolicyAssignments_GetById
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
  - remove-operation: DeploymentOperations_GetAtTenantScope
  - remove-operation: DeploymentOperations_ListAtTenantScope
  - remove-operation: DeploymentOperations_GetAtManagementGroupScope
  - remove-operation: DeploymentOperations_ListAtManagementGroupScope
  - remove-operation: DeploymentOperations_GetAtSubscriptionScope
  - remove-operation: DeploymentOperations_ListAtSubscriptionScope
  - remove-operation: DeploymentOperations_Get
  - remove-operation: DeploymentOperations_List
```
