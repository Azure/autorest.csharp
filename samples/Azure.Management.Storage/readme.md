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
  BlobContainers: Microsoft.Storage/storageAccounts/blobServices/containers
  ImmutabilityPolicies: Microsoft.Storage/storageAccounts/blobServices/containers/immutabilityPolicies
  FileShares: Microsoft.Storage/storageAccounts/fileServices/shares
  PrivateLinkResources: Microsoft.Storage/storageAccounts/privateLinkResources
operation-group-to-resource:
  StorageAccounts: StorageAccount
operation-group-to-parent:
  Skus: subscriptions
  BlobServices: Microsoft.Storage/storageAccounts
  BlobContainers: Microsoft.Storage/storageAccounts/blobServices
  ImmutabilityPolicies: Microsoft.Storage/storageAccounts/blobServices/containers
  FileShares: Microsoft.Storage/storageAccounts
  Usages: subscriptions
  StorageAccounts: resourceGroups
  PrivateLinkResources: Microsoft.Storage/storageAccounts
operation-group-to-singleton-resource:
  BlobServices: blobServices/default
  ImmutabilityPolicies: immutabilityPolicies/default
  FileServices: fileServices/default
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
    #one level of resource hierarchy is swallowed, restoring it by introducing a new operation group
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}"].put.operationId
    transform: return "ImmutabilityPolicies_CreateOrUpdate"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}"].get.operationId
    transform: return "ImmutabilityPolicies_Get"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/{immutabilityPolicyName}"].delete.operationId
    transform: return "ImmutabilityPolicies_Delete"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default/lock"].post.operationId
    transform: return "ImmutabilityPolicies_Lock"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers/{containerName}/immutabilityPolicies/default/extend"].post.operationId
    transform: return "ImmutabilityPolicies_Extend"
```
