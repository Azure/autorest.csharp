# ReferenceTypes
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: ReferenceTypes
require: $(this-folder)/../../../readme.md
azure-arm: true
arm-core: true
input-file:
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ac3be41ee22ada179ab7b970e98f1289188b3bae/specification/common-types/resource-management/v2/types.json
  - $(this-folder)/nonReferenceTypes.json
namespace: Azure.ReferenceTypes

directive:
  - remove-model: "AzureEntityResource"
  - remove-model: "ProxyResource"
  - remove-model: "ResourceModelWithAllowedPropertySet"
  - remove-model: "Identity"
  - remove-model: "Operation"
  - remove-model: "OperationListResult"
  - remove-model: "OperationStatusResult"
  - remove-model: "locationData"
  - from: types.json
    where: $.definitions['Resource']
    transform: >
      $["x-ms-mgmt-referenceType"] = true
  - from: types.json
    where: $.definitions['TrackedResource']
    transform: >
      $["x-ms-mgmt-referenceType"] = true
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-ms-mgmt-propertyReferenceType"] = true
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-namespace"] = "Azure.ResourceManager.Fake.Models"
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-accessibility"] = "public"
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-csharp-formats"] = "json"
  - from: types.json
    where: $.definitions.*
    transform: >
      $["x-csharp-usage"] = "model,input,output"
  - from: types.json
    where: $.definitions.*.properties[?(@.enum)]
    transform: >
      $["x-namespace"] = "Azure.ResourceManager.Fake.Models"
  - from: types.json
    where: $.definitions.*.properties[?(@.enum)]
    transform: >
      $["x-accessibility"] = "public"
#  - from: types.json
#    where: $.definitions.Operation.properties.display
#    transform: >
#      $["x-csharp-usage"] = "model,input,output"
#  - from: types.json
#    where: $.definitions.Operation.properties.display
#    transform: >
#      $["x-namespace"] = "Azure.ResourceManager.Fake.Models"
```
