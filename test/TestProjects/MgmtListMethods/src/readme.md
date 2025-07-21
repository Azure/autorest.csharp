# MgmtListMethods

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../../readme.md
input-file: $(this-folder)/../mgmtListMethods.json
namespace: MgmtListMethods
use-model-reader-writer: true

override-operation-name:
  FakeParentWithAncestorWithNonResChWithLocs_ListBySubscription: GetFakeParentWithAncestorWithNonResourceChWithLoc
```
