# MgmtScopeResource

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

request-path-to-resource-data:
  # model of this has id, type and name, but its type has the type of `object` instead of `string`
  /{linkId}: ResourceLink
operation-to-parent:
  ResourceLinks_ListAtSourceScope: /{linkId}
  # setting these to the same parent will automatically merge these operations
  Deployments_WhatIfAtTenantScope: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  Deployments_WhatIfAtSubscriptionScope: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  Deployments_WhatIfAtManagementGroupScope: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
  Deployments_WhatIf: /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}
request-path-to-resource-type:
  /{linkId}: Microsoft.Resources/links
request-path-to-scope-resource-types:
  /{scope}/providers/Microsoft.Resources/deployments/{deploymentName}:
    - subscriptions
    - resourceGroups
    - managementGroups
    - tenant
  /{scope}/providers/Microsoft.Resources/deployments:
    - subscriptions
    - resourceGroups
    - managementGroups
    - tenant
override-operation-name:
  ResourceLinks_ListAtSourceScope: GetAll
operation-positions:
  ResourceLinks_ListAtSourceScope: collection
directive:
  # PolicyDefinition resource has the corresponding method written using `scope`, therefore the "ById" methods are no longer required. Remove those
  - remove-operation: FakePolicyAssignments_DeleteById
  - remove-operation: FakePolicyAssignments_CreateById
  - remove-operation: FakePolicyAssignments_GetById
  - from: Links.json
    where: $.definitions.ResourceLink.properties.type
    transform: >
       $["x-ms-client-name"] = "ResourceType";
       $["type"] = "string";
```
