# MgmtParent

### AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/MgmtCollectionParent.json
namespace: MgmtCollectionParent
model-namespace: false
public-clients: false
head-as-boolean: false
modelerfour:
  lenient-model-deduplication: true

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/locations/{location}/orders/{orderName}

mgmt-debug:
  show-request-path: true
```
