# MgmtParent

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../../readme.md
input-file: $(this-folder)/../mgmtNonStringPathVariable.json
namespace: MgmtNonStringPathVariable
use-model-reader-writer: true

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fake/bars/{barName}
```
