# Azure.ResourceManager.Sample
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../readme.md
input-file: $(this-folder)/sample.json
namespace: Azure.ResourceManager.Sample
model-namespace: false
public-clients: false
head-as-boolean: false
operation-group-to-resource-type:
   Operations: Microsoft.Compute/operations
   VirtualMachineExtensionImages: Microsoft.Compute/locations/publishers/vmextension
   VirtualMachineImages: Microsoft.Compute/locations/publishers/vmimage
   Usage: Microsoft.Compute/locations/usages
   VirtualMachineSizes: Microsoft.Compute/locations/vmSizes
   VirtualMachineScaleSetRollingUpgrades: Microsoft.Compute/virtualMachineScaleSets/rollingUpgrades
   LogAnalytics: Microsoft.Compute/locations/logAnalytics
operation-group-to-resource:
   Operations: NonResource
   VirtualMachineExtensionImages: VirtualMachineExtensionImage
   VirtualMachineImages: VirtualMachineImage
#    Usage: NonResource
#    VirtualMachineSizes: NonResource
   VirtualMachineScaleSetRollingUpgrades: VirtualMachineScaleSetRollingUpgrade
   LogAnalytics: NonResource
operation-group-to-parent:
   Operations: tenant
   LogAnalytics: subscriptions
   Usage: subscriptions
   VirtualMachineSizes: subscriptions
   VirtualMachineExtensionImages: Microsoft.Compute/locations/publishers
   VirtualMachineImages: Microsoft.Compute/locations
   VirtualMachineScaleSetVMExtensions: Microsoft.Compute/virtualMachineScaleSets
   VirtualMachineScaleSetRollingUpgrades: Microsoft.Compute/virtualMachineScaleSets
operation-group-is-tuple: VirtualMachineImages;VirtualMachineExtensionImages
operation-group-is-extension: VirtualMachineScaleSetVMExtensions
modelerfour:
  lenient-model-deduplication: true
directive:
  - rename-model:
      from: SshPublicKey
      to: SshPublicKeyInfo
  - rename-model:
      from: LogAnalyticsOperationResult
      to: LogAnalytics
  - rename-model:
      from: SshPublicKeyResource
      to: SshPublicKey
  - rename-model:
      from: ComputeOperationValue
      to: RestApi
  - rename-model:
      from: RollingUpgradeStatusInfo
      to: VirtualMachineScaleSetRollingUpgrade
```
