# ExactMatchInheritance
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: MgmtSingleton
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/MgmtSingleton.json
namespace: MgmtSingleton
operation-group-to-resource-type:
  SingletonResources: Microsoft.Billing/parentResources/singletonResources
  SingletonResources2: Microsoft.Billing/parentResources/singletonResources2
operation-group-to-parent:
  SingletonResources: Microsoft.Billing/parentResources
operation-group-to-resource:
  SingletonResources: SingletonResource
  SingletonResources2: SingletonResource2
singleton-resource: SingletonResource2
```
