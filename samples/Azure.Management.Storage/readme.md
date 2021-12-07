# Azure.Management.Storage

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../readme.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/35ebd5881bab5377e72b90e0c241fc598da95d4f/specification/storage/resource-manager/Microsoft.Storage/stable/2021-06-01/blob.json
  - https://github.com/Azure/azure-rest-api-specs/blob/35ebd5881bab5377e72b90e0c241fc598da95d4f/specification/storage/resource-manager/Microsoft.Storage/stable/2021-06-01/file.json
  - https://github.com/Azure/azure-rest-api-specs/blob/35ebd5881bab5377e72b90e0c241fc598da95d4f/specification/storage/resource-manager/Microsoft.Storage/stable/2021-06-01/storage.json
namespace: Azure.Management.Storage

modelerfour:
  lenient-model-deduplication: true
  seal-single-value-enum-by-default: true

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}

mgmt-debug:
  show-request-path: true

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
