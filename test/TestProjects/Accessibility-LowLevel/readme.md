# Accessibility

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)\Accessibility-LowLevel.json
low-level-client: true
credential-types: AzureKeyCredential
credential-header-name: Fake-Subscription-Key
```