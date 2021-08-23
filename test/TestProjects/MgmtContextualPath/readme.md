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
# operation-group-to-resource-type:
#   Quotas: something
# operation-group-to-resource:
#   Quotas: NonResource
# operation-group-to-parent:
#   Quotas: subscriptions
```
