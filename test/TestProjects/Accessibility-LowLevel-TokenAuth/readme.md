# Accessibility

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/../Accessibility-LowLevel/Accessibility-LowLevel.json
low-level-client: true
credential-types: TokenCredential
credential-header-name: Your-Subscription-Key
credential-scopes: https://test.azure.com/.default
```