# MgmtParent
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/MgmtScopeResource.json
namespace: MgmtScopeResource
operation-group-to-parent:
  PolicyAssignments: tenant
directive:
  # These methods can be replaced by using other methods in the same operation group, remove for Preview.
  - remove-operation: PolicyAssignments_DeleteById
  - remove-operation: PolicyAssignments_CreateById
  - remove-operation: PolicyAssignments_GetById
```
