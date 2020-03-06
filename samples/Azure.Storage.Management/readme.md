# Azure.Storage.Management

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: Azure.Storage.Management
require: $(this-folder)/../readme.samples.md
input-file: 
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/blob.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/file.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/storage.json
namespace: Azure.Storage.Management
```

### Swagger tweaks to get things working

Workaround for https://github.com/Azure/autorest.modelerfour/issues/205

``` yaml
directive:
- from: swagger-document
  where: $.definitions.BlobServiceProperties.properties.properties
  transform: >
    $["x-ms-client-name"] = "BlobServiceProperties2"
```

``` yaml
directive:
- from: swagger-document
  where: $.definitions.FileServiceProperties.properties.properties
  transform: >
    $["x-ms-client-name"] = "FileServiceProperties2"
```
