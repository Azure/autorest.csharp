# CognitiveSearch

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: CognitiveServices
require: $(this-folder)/../../readme.md
# https://github.com/Azure/azure-rest-api-specs/blob/master/specification/search/data-plane/Microsoft.Azure.Search.Data/stable/2019-05-06/searchindex.json
# https://github.com/Azure/azure-rest-api-specs/blob/master/specification/search/data-plane/Microsoft.Azure.Search.Service/stable/2019-05-06/searchservice.json
input-file:
    - $(this-folder)/searchindex.json
    - $(this-folder)/searchservice.json
namespace: Azure.CognitiveSearch
```

### Swagger tweaks to get things working

The swagger uses `{ type: "number", format: "int64" }` but it should be `{ type: "integer", format: "int64" }` per https://swagger.io/docs/specification/data-models/data-types/#numbers.

``` yaml
directive:
- from: swagger-document
  where: $..properties[*]
  transform: >
    if ($.format === "int64") { $.type = "integer"; }
    return $;
```

The swagger and the codegen both use the name `request` which is problematic.

``` yaml
directive:
- from: swagger-document
  where: $.paths["/indexes('{indexName}')/search.analyze"].post.parameters[1]
  transform: >
    $["x-ms-client-name"] = "request_todo";
    return $;
```
