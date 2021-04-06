# ModelNamespace
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: OperationGroupMappings
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/OperationGroupMappings.json
namespace: Azure.OperationGroupMappings
operation-group-to-resource-type:
   Operations: Microsoft.Compute/operations
operation-group-to-resource:
   Operations: RestApi
   AvailabilitySets: AvailabilitySet
model-to-resource:
   ComputeOperationValue : RestApi
```
