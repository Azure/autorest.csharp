# CognitiveSearch

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: CognitiveServices
require: $(this-folder)/../../readme.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/e606243e5297312781dd7dbfd7ab76d2329cc088/specification/search/data-plane/Azure.Search/preview/2019-05-06-preview/searchindex.json
  - https://github.com/Azure/azure-rest-api-specs/blob/e606243e5297312781dd7dbfd7ab76d2329cc088/specification/search/data-plane/Azure.Search/preview/2019-05-06-preview/searchservice.json
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
