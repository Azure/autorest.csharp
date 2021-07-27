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
  Skus: Microsoft.Storage/skus
  Usages: Microsoft.Storage/locations/usages
  PrivateLinkResources: Microsoft.Storage/storageAccounts/privateLinkResources
operation-group-to-resource:
  StorageAccounts: StorageAccount
operation-group-to-parent:
  Skus: subscriptions
  BlobContainers: Microsoft.Storage/storageAccounts
  FileShares: Microsoft.Storage/storageAccounts
  Usages: subscriptions
  StorageAccounts: resourceGroups
  PrivateLinkResources: Microsoft.Storage/storageAccounts
singleton-resource: BlobService;FileService
directive:
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
    # overwrite "type" of "maxpagesize"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers"].get.parameters[4].type
    transform: return "integer"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares"].get.parameters[4].type
    transform: return "integer"
```
