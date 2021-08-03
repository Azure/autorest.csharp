# ReferenceTypes
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: ReferenceTypes
require: $(this-folder)/../../../readme.md
azure-arm: true
input-file: $(this-folder)/ReferenceTypes.json
namespace: Azure.ReferenceTypes

directive:
  from: types.json
  where: $.definitions.*
  transform: >
    $["x-ms-mgmt-referenceType"] = true
```
