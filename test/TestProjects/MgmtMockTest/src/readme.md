# MgmtMockTest

## Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
title: MgmtMockTest
library-name: MgmtMockTest
require: $(this-folder)/../../../../readme.md
input-file:
- $(this-folder)/keyvault.json
- $(this-folder)/managedHsm.json
- $(this-folder)/providers.json
- $(this-folder)/authorization.json
clear-output-folder: true
namespace: MgmtMockTest
modelerfour:
  lenient-model-deduplication: true

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}
format-by-name-rules:
  'tenantId': 'uuid'
  'resourceType': 'resource-type'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
directive:
  - from: swagger-document
    where: $.paths
    transform: delete $['/subscriptions/{subscriptionId}/resources']
  - from: swagger-document
    where: $['definitions']['Sku']['properties']['family']
    transform: delete $['x-ms-client-default']
  - from: swagger-document
    where: $['definitions']['ManagedHsmSku']['properties']['family']
    transform: delete $['x-ms-client-default']
```
