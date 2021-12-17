# Accessibility

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/../Accessibility-LowLevel/Accessibility-LowLevel.json
data-plane: true
security: AADToken
security-header-name: Your-Subscription-Key
security-scopes: https://test.azure.com/.default
```