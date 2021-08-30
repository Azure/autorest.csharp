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
   VirtualMachineExtensionImages: Microsoft.Compute/locations/publishers/vmextension
   VirtualMachineImages: Microsoft.Compute/locations/publishers/vmimage
   Usage: Microsoft.Compute/locations/usages
   VirtualMachineSizes: Microsoft.Compute/locations/vmSizes
   VirtualMachineScaleSetRollingUpgrades: Microsoft.Compute/virtualMachineScaleSets/rollingUpgrades
   LogAnalytics: Microsoft.Compute/locations/logAnalytics
operation-group-to-resource:
   VirtualMachineExtensionImages: NonResource
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
   VirtualMachineScaleSetRollingUpgrades: Microsoft.Compute/virtualMachineScaleSets
   VirtualMachineScaleSetVMExtensions: Microsoft.Compute/virtualMachineScaleSets/virtualMachines
operation-group-to-contextual-path:
   VirtualMachineScaleSetRollingUpgrades: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/rollingUpgrades/latest
# operation-group-is-tuple: VirtualMachineImages
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
  ## first we need to unify all the paths by changing `virtualmachines` to `virtualMachines` so that every path could have consistent casing
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
  ## unify the variable names
  - from: swagger-document
    where: $.paths
    transform: >
      const key = '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines';
      const newKey = key.replace('virtualMachineScaleSetName', 'vmScaleSetName');
      const newVal = $[key];
      newVal.get.parameters[1].name = 'vmScaleSetName';
      delete $[key];
      $[newKey] = newVal;
```
