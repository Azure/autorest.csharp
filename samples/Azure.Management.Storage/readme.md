# Azure.Storage.Management

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../readme.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/7586a4893bbafd6d1f90b983bc091c7abf3eed59/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/blob.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7586a4893bbafd6d1f90b983bc091c7abf3eed59/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/file.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7586a4893bbafd6d1f90b983bc091c7abf3eed59/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/storage.json
namespace: Azure.Management.Storage
payload-flattening-threshold: 2
```
