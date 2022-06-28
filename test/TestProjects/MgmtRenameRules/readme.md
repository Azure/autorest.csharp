# MgmtRenameRules

### AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/MgmtRenameRules.json
namespace: MgmtRenameRules
model-namespace: false
public-clients: false
head-as-boolean: false
modelerfour:
  lenient-model-deduplication: true

keep-orphaned-models:
- VmDiskType

rename-rules:
  Os: OS
  Ip: IP
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  VMScaleSet: VmScaleSet

format-by-name-rules:
  'tenantId': 'uuid'
  'resourceType': 'resource-type'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  
rename-mapping:
  SshPublicKey: SshPublicKeyInfo
  SshPublicKeyResource: SshPublicKey
  LogAnalyticsOperationResult: LogAnalytics
  RollingUpgradeStatusInfo: VirtualMachineScaleSetRollingUpgrade
  UpgradeOperationHistoricalStatusInfo.type: ResourceType
```
