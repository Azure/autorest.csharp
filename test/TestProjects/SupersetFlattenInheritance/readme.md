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
   CustomModel1s: NonResource # the model of CustomModel1 does not have an id, therefore it cannot be a resource
   CustomModel2s: NonResource # the model of CustomModel2 does not have an id, therefore it cannot be a resource
   ResourceModel2s: NonResource # the model of ResourceModel2 contains id, but it comes from a flattened properties, therefore it should not be a resource
   TrackedResourceModel2s: NonResource # the model of TrackedResourceModel2 contains id, but it comes from a flattened properties, therefore it should not be a resource
   NonResourceModel1s: NonResource
   SubResourceModel1s: NonResource # this model only contains an id, but no type or name
   SubResourceModel2s: NonResource # this model only contains an id, but no type or name
   WritableSubResourceModel1s: NonResource # this model only contains an id, but no type or name
   WritableSubResourceModel2s: NonResource # this model only contains an id, but no type or name
operation-group-to-parent:
   CustomModel1s: resourceGroups
   CustomModel2s: resourceGroups
   ResourceModel2s: resourceGroups
   TrackedResourceModel2s: resourceGroups
   NonResourceModel1s: resourceGroups
   SubResourceModel1s: resourceGroups
   SubResourceModel2s: resourceGroups
   WritableSubResourceModel1s: resourceGroups
   WritableSubResourceModel2s: resourceGroups
```
