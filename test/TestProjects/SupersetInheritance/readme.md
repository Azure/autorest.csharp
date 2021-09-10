# SupersetInheritance
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: SupersetInheritance
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/SupersetInheritance.json
namespace: SupersetInheritance
operation-group-to-resource:
   SupersetModel2s: NonResource
   SupersetModel3s: NonResource
operation-group-to-parent:
   SupersetModel2s: resourceGroups
   SupersetModel3s: resourceGroups
request-path-is-non-resource:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}
```
