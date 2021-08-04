# ReferenceTypes
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: ReferenceTypes
require: $(this-folder)/../../../readme.md
azure-arm: true
arm-core: true
input-file:
  - $(this-folder)/referenceTypes.json
  - $(this-folder)/nonReferenceTypes.json
namespace: Azure.ReferenceTypes

directive:
  - from: referenceTypes.json
    where: $.definitions.*
    transform: >
      $["x-ms-mgmt-referenceType"] = true
  - from: referenceTypes.json
    where: $.definitions.*
    transform: >
      $["x-namespace"] = "Azure.ResourceManager.Resources.Models"
  - from: referenceTypes.json
    where: $.definitions.*
    transform: >
      $["x-accessibility"] = "public"
  - from: referenceTypes.json
    where: $.definitions.*[?(@.enum)]
    transform: >
      $["x-namespace"] = "Azure.ResourceManager.Resources.Models"
  - from: referenceTypes.json
    where: $.definitions.*[?(@.enum)]
    transform: >
      $["x-accessibility"] = "public"
```
