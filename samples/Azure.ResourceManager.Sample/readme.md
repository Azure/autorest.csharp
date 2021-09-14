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
   VirtualMachineExtensionImages: Microsoft.Compute/locations/publishers/artifacttypes/types/versions
   VirtualMachineImages: Microsoft.Compute/locations/publishers/artifacttypes/offers/skus/versions
   Usage: Microsoft.Compute/locations/usages
   VirtualMachineSizes: Microsoft.Compute/locations/vmSizes
   VirtualMachineScaleSetRollingUpgrades: Microsoft.Compute/virtualMachineScaleSets/rollingUpgrades
   LogAnalytics: Microsoft.Compute/locations/logAnalytics
operation-group-to-resource:
   VirtualMachineExtensionImages: VirtualMachineExtensionImage
   VirtualMachineImages: VirtualMachineImage
   VirtualMachineSizes: NonResource
   VirtualMachineScaleSetRollingUpgrades: VirtualMachineScaleSetRollingUpgrade
   LogAnalytics: NonResource
operation-group-to-parent:
   Usage: subscriptions
   LogAnalytics: subscriptions
   VirtualMachineExtensionImages: subscriptions
   VirtualMachineImages: subscriptions
   VirtualMachineSizes: subscriptions
   VirtualMachineScaleSetVMExtensions: Microsoft.Compute/virtualMachineScaleSets
   VirtualMachineScaleSetRollingUpgrades: Microsoft.Compute/virtualMachineScaleSets
request-path-to-resource:
   /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/rollingUpgrades/latest: VirtualMachineScaleSetRollingUpgrade
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
      from: RollingUpgradeStatusInfo
      to: VirtualMachineScaleSetRollingUpgrade
```
