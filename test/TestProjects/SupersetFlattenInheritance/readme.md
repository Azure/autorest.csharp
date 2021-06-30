# Superset Flatten Inheritance

This project contains a set of swagger definitions regarding resource inheritance with flatten properties.

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
title: SuperSet Of Flatten Properties
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/AzureResource.json
namespace: SupersetFlattenInheritance
operation-group-to-resource:
   NonResourceModel1s: NonResource
operation-group-to-parent:
   NonResourceModel1s: resourceGroups
```
