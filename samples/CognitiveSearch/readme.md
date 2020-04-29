# CognitiveSearch

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: CognitiveServices
require: $(this-folder)/../../readme.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/49fc16354df7211f8392c56884a3437138317d1f/specification/search/data-plane/Azure.Search/preview/2019-05-06-preview/searchindex.json
  - https://github.com/Azure/azure-rest-api-specs/blob/49fc16354df7211f8392c56884a3437138317d1f/specification/search/data-plane/Azure.Search/preview/2019-05-06-preview/searchservice.json
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
