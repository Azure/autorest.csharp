# ExactMatchInheritance

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
title: MgmtResourceName
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/MgmtResourceName.json
namespace: MgmtResourceName
no-resource-suffix:
  - Disk
  - Memory


directive:
  - rename-model:
      from: NetworkResource
      to: Network
  - rename-model:
      from: MemoryResource
      to: Memory
```
