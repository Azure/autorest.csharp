# ExactMatchInheritance

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
title: ExactMatchInheritance
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/ExactMatchInheritance.json
namespace: ExactMatchInheritance
directive:
  - from: ExactMatchInheritance.json
    where: $.definitions.ExactMatchModel11.properties.type
    transform: >
       $["x-ms-format"] = "resourceType";
```
