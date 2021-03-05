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
payload-flattening-threshold: 2
operation-group-to-resource-type:
   Operations: Microsoft.Compute/operations
   VirtualMachineExtensionImages: Microsoft.Compute/locations/publishers/vmextension
   VirtualMachineImages: Microsoft.Compute/locations/publishers/vmimage
   Usage: Microsoft.Compute/locations/usages
   VirtualMachineSizes: Microsoft.Compute/locations/vmSizes
   VirtualMachineScaleSetRollingUpgrades: Microsoft.Compute/virtualMachineScaleSets/rollingUpgrades
   LogAnalytics: Microsoft.Compute/locations/logAnalytics
operation-group-to-resource:
   Operations: Operation    
   VirtualMachineExtensionImages: VirtualMachineExtensionImage
   VirtualMachineImages: VirtualMachineImage
   Usage: Usage
   VirtualMachineSizes: VirtualMachineSize
   VirtualMachineScaleSetRollingUpgrades: VirtualMachineScaleSetRollingUpgrade
   LogAnalytics: LogAnalyticsOperationResult
resource-rename:
   LogAnalyticsOperationResult: LogAnalytics
   SshPublicKeyResource: SshPublicKey
modelerfour:
  lenient-model-deduplication: true
```
