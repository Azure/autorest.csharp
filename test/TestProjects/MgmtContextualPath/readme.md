# MgmtContextualPath

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtContextualPath.json
namespace: MgmtContextualPath
# temp
operation-group-to-contextual-path:
  Fakes: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}
  RGFakes: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/rgFakes/{fakeName}
  RGChildResources: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/rgFakes/{fakeName}/childResources/{childName}
  FakeTupleResources: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/rgFakes/{fakeName}/versions/{version}/tupleResources/{tupleName}
  ExplicitSingletonResources: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/rgFakes/{fakeName}/explicitSingletonResources/default
# operation-group-to-resource-type:
#   Quotas: something
# operation-group-to-resource:
#   Quotas: NonResource
operation-group-to-parent:
  FakeTupleResources: Microsoft.Fake/rgFakes
  ExplicitSingletonResources: Microsoft.Fake/rgFakes
```
