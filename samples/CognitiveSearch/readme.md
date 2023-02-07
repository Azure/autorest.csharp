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

suppress-abstract-base-class:
- Analyzer
- CharFilter
- CognitiveServicesAccount
- DataChangeDetectionPolicy
- DataDeletionDetectionPolicy
- ScoringFunction
- Similarity
- Skill
- TokenFilter
- Tokenizer

directive:
- from: searchservice.json
  where: $.definitions.SearchError
  transform: $["x-ms-client-name"] = "SearchServiceError"
```
