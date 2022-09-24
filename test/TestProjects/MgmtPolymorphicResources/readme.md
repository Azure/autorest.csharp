# MgmtPolymorphicResources

### AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/MgmtPolymorphicResources.json
namespace: MgmtPolymorphicResources
model-namespace: false
public-clients: false
head-as-boolean: false

base-resource-name-mapping:
  VirtualMachineExtension: AbstractVirtualMachineExtension

generate-virtual-operations:
- Module_Get
- VirtualMachineScaleSetVMExtensions_Validate
```
