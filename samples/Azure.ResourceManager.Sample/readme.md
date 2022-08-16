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
keep-orphaned-models: AvailabilitySetSkuType

format-by-name-rules:
  'tenantId': 'uuid'
  'resourceType': 'resource-type'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

prepend-rp-prefix:
- UsageName

rename-mapping:
  SshPublicKey: SshPublicKeyInfo
  SshPublicKeyResource: SshPublicKey
  LogAnalyticsOperationResult: LogAnalytics
  RollingUpgradeStatusInfo: VirtualMachineScaleSetRollingUpgrade
  VirtualMachineExtension.properties.type: ExtensionType # the properties inside is required because this is a flattened property
  VirtualMachineExtensionUpdate.properties.type: ExtensionType # the properties inside is required because this is a flattened property
  VirtualMachineScaleSetExtension.properties.type: ExtensionType # the properties inside is required because this is a flattened property
  HyperVGenerationType: HyperVGeneration
  HyperVGenerationTypes: HyperVGeneration
  ImageListResult.value: Images

mgmt-debug:
  show-serialized-names: true

update-required-copy:
  VirtualMachineExtension: Publisher

directive:
  - from: sample.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/skus'].get['x-ms-pageable']['itemName'] = 'VmssSkus';

```
