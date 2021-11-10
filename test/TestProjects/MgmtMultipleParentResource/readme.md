# MgmtParent

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtMultipleParentResource.json
namespace: MgmtMultipleParentResource
modelerfour:
  lenient-model-deduplication: true
mgmt-debug:
  show-request-path: true
```
