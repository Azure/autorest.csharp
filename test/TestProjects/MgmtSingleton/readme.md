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
request-path-to-singleton-resource:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}/singletonResources2: singletonResources2/default
```
