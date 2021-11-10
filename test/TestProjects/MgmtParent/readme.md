# MgmtParent

### AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/mgmtParent.json
namespace: MgmtParent
model-namespace: false
public-clients: false
head-as-boolean: false
modelerfour:
  lenient-model-deduplication: true

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/hostGroups/{hostGroupName}
- /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}
mgmt-debug:
  show-request-path: true
```
