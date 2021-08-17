# MgmtListMethods
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtListMethods.json
namespace: MgmtListMethods
operation-group-to-resource-type:
  Quotas: something
operation-group-to-resource:
  Quotas: NonResource
operation-group-to-parent:
  Quotas: subscriptions
```
