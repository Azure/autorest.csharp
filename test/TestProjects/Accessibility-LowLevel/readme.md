# Accessibility

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
input-file: $(this-folder)\Accessibility-LowLevel.json
low-level-client: true
credential-types: AzureKeyCredential
credential-header-name: Fake-Subscription-Key
```

``` yaml
directive:
- from: swagger-document
  where: $..[?(@.operationId=='Operation')]
  transform: >
    $['x-accessibility'] = "internal";
    $lib.log($);
```