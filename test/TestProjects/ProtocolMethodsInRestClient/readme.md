# Accessibility

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)\ProtocolMethodsInRestClient.json
security: AzureKey
security-header-name: Fake-Subscription-Key 
protocol-method-list:
  - Create
  - Delete
```