# MgmtParent

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
title: ResourceManagementClient
require: $(this-folder)/../../../readme.md
input-file: 
  - $(this-folder)/PolicyAssignments.json
  - $(this-folder)/Deployments.json
  - $(this-folder)/Links.json
namespace: MgmtScopeResource

mgmt-debug:
  show-request-path: true
list-exception:
- /{linkId}
request-path-to-resource-data:
  # model of this has id, type and name, but its type has the type of `object` instead of `string`
  /{linkId}: ResourceLink
request-path-to-parent:
  /{scope}/providers/Microsoft.Resources/links: /{linkId}
  # setting these to the same parent will automatically merge these operations
  /providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  /subscriptions/{subscriptionId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  /providers/Microsoft.Management/managementGroups/{groupId}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Resources/deployments/{deploymentName}/whatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
request-path-to-resource-type:
  /{linkId}: Microsoft.Resources/links
directive:
  - rename-operation:
      from: Deployments_WhatIfAtTenantScope
      to: WhatIf
  # PolicyDefinition resource has the corresponding method written using `scope`, therefore the "ById" methods are no longer required. Remove those
  - remove-operation: PolicyAssignments_DeleteById
  - remove-operation: PolicyAssignments_CreateById
  - remove-operation: PolicyAssignments_GetById
```
