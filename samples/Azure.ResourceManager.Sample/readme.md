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
```
