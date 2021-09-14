# ExactMatchFlattenInheritance

This project is for testing flatten properties.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: ExactMatchFlattenInheritance
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/AzureResourceFlattenProperties.json
namespace: ExactMatchFlattenInheritance
operation-group-to-resource:
  AzureResourceFlattenModel2s: NonResource
  AzureResourceFlattenModel3s: NonResource
  AzureResourceFlattenModel4s: NonResource
  AzureResourceFlattenModel5s: NonResource
operation-group-to-parent:
  AzureResourceFlattenModel2s: resourceGroups
  AzureResourceFlattenModel3s: resourceGroups
  AzureResourceFlattenModel4s: resourceGroups
  AzureResourceFlattenModel5s: resourceGroups
# need the following to trigger flattening
payload-flattening-threshold: 2
```
