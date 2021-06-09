# ExactMatchInheritance
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: ExactMatchInheritance
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/ExactMatchInheritance.json
namespace: ExactMatchInheritance
operation-group-to-resource:
   ExactMatchModel2s: NonResource
   ExactMatchModel4s: NonResource
```
