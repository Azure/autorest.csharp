# ExactMatchInheritance

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
title: MgmtParamOrdering
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/MgmtParamOrdering.json
namespace: MgmtParamOrdering
modelerfour:
  lenient-model-deduplication: true

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}
mgmt-debug:
  show-request-path: true
```
