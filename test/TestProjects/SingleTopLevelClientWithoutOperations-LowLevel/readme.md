# TenantOnly
### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/SingleTopLevelClientWithoutOperations.json
data-plane: true
single-top-level-client: true
security: AzureKey
security-header-name: Fake-Subscription-Key
```