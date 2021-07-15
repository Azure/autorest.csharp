# MgmtParent
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtListMethods.json
namespace: MgmtListMethods
operation-group-to-resource-type:
  OneResources: Microsoft.Fake/oneResources
  SecondResources: Microsoft.Fake/fakes/secondResources
operation-group-to-parent:
  OneResources: resourceGroups
  SecondResources: Microsoft.Fake/fakes
operation-group-is-extension: OneResources;SecondResources
```
