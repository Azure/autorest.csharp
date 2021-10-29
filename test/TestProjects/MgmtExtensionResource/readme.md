# MgmtParent
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/MgmtExtensionResource.json
namespace: MgmtExtensionResource
operation-group-to-parent:
  PolicyDefinitions: tenant
```
