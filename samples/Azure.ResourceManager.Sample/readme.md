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
   VirtualMachineImages: NonResource
   VirtualMachineSizes: NonResource
   VirtualMachineScaleSetRollingUpgrades: VirtualMachineScaleSetRollingUpgrade
   LogAnalytics: NonResource
operation-group-to-parent:
   Usage: subscriptions
   LogAnalytics: subscriptions
   VirtualMachineExtensionImages: subscriptions
   VirtualMachineImages: subscriptions
   VirtualMachineSizes: subscriptions
   VirtualMachineExtensions: Microsoft.Compute/virtualMachines
   VirtualMachineScaleSetVMExtensions: Microsoft.Compute/virtualMachineScaleSets/virtualMachines
   VirtualMachineScaleSetRollingUpgrades: Microsoft.Compute/virtualMachineScaleSets
operation-group-is-extension: VirtualMachineScaleSetVMExtensions;VirtualMachineExtensions
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
  ## we need to unify all the paths by changing `virtualmachines` to `virtualMachines` so that every path could have consistent casing
  - from: swagger-document
    where: $.paths
    transform: >
      for (var key in $) {
          const newKey = key.replace('virtualmachines', 'virtualMachines');
          if (newKey !== key) {
              $[newKey] = $[key]
              delete $[key]
          }
      }
```
