# ExactMatchInheritance
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: ExactMatchInheritance
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/OmitOperationGroups.json
namespace: OmitOperationGroups
operation-group-to-resource:
   Model4s: NonResource
operation-groups-to-omit: Model1s
```
