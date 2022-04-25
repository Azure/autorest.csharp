# SupersetInheritance

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
title: SupersetInheritance
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/SupersetInheritance.json
namespace: SupersetInheritance

# the remover will remove this since this is not internally used or a reference type if we do not have this configuration
keep-orphaned-models:
- SupersetModel5
```
