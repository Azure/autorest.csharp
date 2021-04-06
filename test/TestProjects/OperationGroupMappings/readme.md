# OperationGroupMappings
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
   AvailabilitySets: Microsoft.Compute/availabilitySets
operation-group-to-resource:
   AvailabilitySets: AvailabilitySet
```
