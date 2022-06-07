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
  
# the remover will remove this since this is not internally used or a reference type if we do not have this configuration
keep-orphaned-models:
- LocationFormatObject
```
