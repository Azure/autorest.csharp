# MgmtContextualPath

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtContextualPath.json
namespace: MgmtContextualPath
operation-group-to-resource-type:
  ImplicitSingletonResources: Microsoft.Fake/rgFakes/implicitSingletonResources
# operation-group-to-resource:
#   Quotas: NonResource
operation-group-to-contextual-path:
  ExplicitSingletonResources: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/rgFakes/{fakeName}/explicitSingletonResources/default
operation-group-to-parent:
  FakeTupleResources: Microsoft.Fake/rgFakes
  ImplicitSingletonResources: Microsoft.Fake/rgFakes
  ImplicitChildOfExplicitSingletonResources: Microsoft.Fake/rgFakes/explicitSingletonResources
operation-group-to-singleton-resource:
  ExplicitSingletonResources: explicitSingletonResources/default
```
