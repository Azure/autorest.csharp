# Azure.Management.Storage

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../readme.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/cfa9e0f3df4553767d7915ec8f471ff7d4931ed1/specification/storage/resource-manager/Microsoft.Storage/stable/2021-06-01/blob.json
  - https://github.com/Azure/azure-rest-api-specs/blob/cfa9e0f3df4553767d7915ec8f471ff7d4931ed1/specification/storage/resource-manager/Microsoft.Storage/stable/2021-06-01/file.json
  - https://github.com/Azure/azure-rest-api-specs/blob/cfa9e0f3df4553767d7915ec8f471ff7d4931ed1/specification/storage/resource-manager/Microsoft.Storage/stable/2021-06-01/storage.json
namespace: Azure.Management.Storage

modelerfour:
  lenient-model-deduplication: true
  seal-single-value-enum-by-default: true

request-path-to-singleton-resource:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}: managementPolicies/default

request-path-to-parent:
  /subscriptions/{subscriptionId}/providers/Microsoft.Storage/deletedAccounts: /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
  /subscriptions/{subscriptionId}/providers/Microsoft.Storage/checkNameAvailability: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}

operation-positions:
  DeletedAccounts_List: collection
  StorageAccounts_CheckNameAvailability: collection

override-operation-name:
  DeletedAccounts_List: GetAll

format-by-name-rules:
  'tenantId': 'uuid'
  'resourceType': 'resource-type'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  BlobServiceProperties: BlobService
  FileServiceProperties: FileService

directive:
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
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/restoreBlobRanges"].post
    transform: $["x-ms-long-running-operation-options"]["enable-interim-state"] = true
```
