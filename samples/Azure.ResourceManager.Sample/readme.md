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

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}

mgmt-debug:
  show-request-path: true
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
