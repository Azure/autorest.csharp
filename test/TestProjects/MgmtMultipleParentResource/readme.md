# MgmtParent
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtMultipleParentResource.json
namespace: MgmtMultipleParentResource
# payload-flattening-threshold: 2
# operation-group-to-resource-type:
#    VirtualMachineExtensionImages: Microsoft.Compute/locations/publishers/vmextension
# operation-group-to-resource:
#    VirtualMachineExtensionImages: VirtualMachineExtensionImage
operation-group-to-parent:
   Children: Microsoft.Compute/parents/subParents
   AnotherChildren: Microsoft.Compute/anotherParents
# operation-group-is-tuple: VirtualMachineExtensionImages
modelerfour:
  lenient-model-deduplication: true
```
