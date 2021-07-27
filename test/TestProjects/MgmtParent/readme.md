# MgmtParent
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtParent.json
namespace: MgmtParent
model-namespace: false
public-clients: false
head-as-boolean: false
payload-flattening-threshold: 2
operation-group-to-resource-type:
   VirtualMachineExtensionImages: Microsoft.Compute/locations/publishers/vmextension
operation-group-to-resource:
   VirtualMachineExtensionImages: NonResource
operation-group-to-parent:
   VirtualMachineExtensionImages: subscriptions
modelerfour:
  lenient-model-deduplication: true
```
