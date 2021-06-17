# Azure.Management.Storage

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../readme.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/e606243e5297312781dd7dbfd7ab76d2329cc088/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/blob.json
  - https://github.com/Azure/azure-rest-api-specs/blob/e606243e5297312781dd7dbfd7ab76d2329cc088/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/file.json
  - https://github.com/Azure/azure-rest-api-specs/blob/e606243e5297312781dd7dbfd7ab76d2329cc088/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/storage.json
namespace: Azure.Management.Storage

modelerfour:
  lenient-model-deduplication: true

operation-group-to-resource-type:
  Operations: Microsoft.Storage/operations
  Skus: Microsoft.Storage/skus
  Usages: Microsoft.Storage/locations/usages
  PrivateLinkResources: Microsoft.Storage/storageAccounts/privateLinkResources
operation-group-to-resource:
  Operations: NonResource
  StorageAccounts: StorageAccount
operation-group-to-parent:
  Operations: tenant
  Skus: subscriptions
  BlobContainers: Microsoft.Storage/storageAccounts
  FileShares: Microsoft.Storage/storageAccounts
  Usages: subscriptions
  StorageAccounts: resourceGroups
  PrivateLinkResources: StorageAccounts
directive:
  - rename-model:
      from: Operation
      to: RestApi
  - rename-model:
      from: BlobServiceProperties
      to: BlobService
  - rename-model:
      from: FileServiceProperties
      to: FileService
  - from: swagger-document
    where: $.definitions.FileShareItems.properties.value.items["$ref"]
    transform: return "#/definitions/FileShare"
  - from: swagger-document
    where: $.definitions.ListContainerItems.properties.value.items["$ref"]
    transform: return "#/definitions/BlobContainer"
```
