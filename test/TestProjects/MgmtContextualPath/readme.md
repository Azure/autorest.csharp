# MgmtContextualPath

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtContextualPath.json
namespace: MgmtContextualPath
# operation-group-to-resource-type:
#   Quotas: something
# operation-group-to-resource:
#   Quotas: NonResource
operation-group-to-parent:
  FakeTupleResources: Microsoft.Fake/rgFakes
  ImplicitSingletonResources: Microsoft.Fake/rgFakes
operation-group-to-singleton-resource:
  ExplicitSingletonResources: explicitSingletonResources/default
```
