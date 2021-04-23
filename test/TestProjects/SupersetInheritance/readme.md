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
   OperationGroup2: NonResource
   OperationGroup3: NonResource
```
