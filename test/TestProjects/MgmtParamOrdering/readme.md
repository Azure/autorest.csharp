# ExactMatchInheritance
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: MgmtParamOrdering
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/MgmtParamOrdering.json
namespace: MgmtParamOrdering
modelerfour:
  lenient-model-deduplication: true

operation-group-to-resource-type:
   VirtualMachineExtensionImages: Microsoft.Compute/locations/publishers/vmextension
operation-group-to-parent:
   VirtualMachineExtensionImages: subscriptions
```
