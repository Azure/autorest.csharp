# Azure.AI.DocumentTranslation

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
title: Azure.AI.DocumentTranslation
require: $(this-folder)/../../readme.md
input-file: https://github.com/Azure/azure-rest-api-specs/blob/3196a62202976da192d6da86f44b02246ca2aa97/specification/cognitiveservices/data-plane/TranslatorText/preview/v1.0-preview.1/TranslatorBatch.json
namespace: Azure.AI.DocumentTranslation
data-plane: true
security: AzureKey
security-header-name: Ocp-Apim-Subscription-Key
```

# Model endpoint parameter as a url, not a string.

```yaml
directive:
  - from: swagger-document
    where: $["x-ms-parameterized-host"].parameters[?(@["x-ms-parameter-location"]=='client'&&@.in=='path')]
    transform: >
      if ($.format === undefined) {
        $.format = "url";
      }
```