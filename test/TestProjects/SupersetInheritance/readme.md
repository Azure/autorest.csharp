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
```
