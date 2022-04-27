# Azure.ResourceManager.Sample

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../readme.md
input-file: $(this-folder)/sample.json
namespace: Azure.ResourceManager.Sample
model-namespace: false
public-clients: false
head-as-boolean: false
modelerfour:
  lenient-model-deduplication: true
keep-orphaned-models: AvailabilitySetSkuTypes

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
  - from: swagger-document
    where: $.definitions
    transform: >
      $.VirtualMachineImageResource.properties.location["x-ms-format"] = "azure-location";
      $.VirtualMachineScaleSetListOSUpgradeHistory.properties.etag["x-ms-format"] = "etag";
      $.VirtualMachineScaleSetSku.properties.resourceType["x-ms-format"] = "resource-type";
```
