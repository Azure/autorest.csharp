# MgmtParent
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtMultipleParentResource.json
namespace: MgmtMultipleParentResource
operation-group-to-parent:
   Children: Microsoft.Compute/parents/subParents
   AnotherChildren: Microsoft.Compute/anotherParents
operation-group-is-extension: Children;AnotherChildren
modelerfour:
  lenient-model-deduplication: true
```
