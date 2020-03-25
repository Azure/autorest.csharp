# CognitiveSearch

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: CognitiveServices
require: $(this-folder)/../../readme.md
input-file:
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/search/data-plane/Azure.Search/preview/2019-05-06-preview/searchindex.json
  - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/search/data-plane/Azure.Search/preview/2019-05-06-preview/searchservice.json
namespace: Azure.CognitiveSearch
```

## Swagger workarounds

SearchError is duplicated between two swaggers, rename one of them

``` yaml
directive:
- from: searchindex.json
  where: $.definitions.SearchError
  transform: $["x-ms-client-name"] = "IndexSearchError"
```
