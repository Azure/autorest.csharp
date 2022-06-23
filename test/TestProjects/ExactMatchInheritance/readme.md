# ExactMatchInheritance

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
title: ExactMatchInheritance
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/ExactMatchInheritance.json
namespace: ExactMatchInheritance
format-by-name-rules:
  'tenantId': 'uuid'
  'resourceType': 'resource-type'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
# the remover will remove this since this is not internally used or a reference type if we do not have this configuration
keep-orphaned-models:
- ExactMatchModel11
directive:
  - from: ExactMatchInheritance.json
    where: $.definitions.ExactMatchModel11.properties.type
    transform: >
       $["x-ms-client-name"] = "ResourceType";
  - from: ExactMatchInheritance.json
    where: $.definitions.ExactMatchModel1.properties.type1
    transform: >
       $["x-ms-format"] = "resource-type";
```
