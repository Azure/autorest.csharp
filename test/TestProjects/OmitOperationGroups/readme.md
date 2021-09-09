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
operation-group-to-resource-type:
  Model4s: Microsoft.Compute/model2s/model4s
operation-group-to-resource:
  Model4s: Model4
operation-groups-to-omit:
   Model1s
request-path-to-resource:
   /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/model2s/{model2sName}/model4s/default: Model4
```
