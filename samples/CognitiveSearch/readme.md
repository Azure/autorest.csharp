# CognitiveSearch

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: CognitiveServices
generation1-convenience-client: true
require: $(this-folder)/../../readme.md
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/e606243e5297312781dd7dbfd7ab76d2329cc088/specification/search/data-plane/Azure.Search/preview/2019-05-06-preview/searchindex.json
  - https://github.com/Azure/azure-rest-api-specs/blob/e606243e5297312781dd7dbfd7ab76d2329cc088/specification/search/data-plane/Azure.Search/preview/2019-05-06-preview/searchservice.json
namespace: Azure.CognitiveSearch

directive:
- from: searchservice.json
  where: $.definitions.SearchError
  transform: $["x-ms-client-name"] = "SearchServiceError"
```

### Make Endpoint type as Uri

``` yaml
directive:
  from: swagger-document
  where: $.parameters.EndpointParameter
  transform: $.format = "url"
```