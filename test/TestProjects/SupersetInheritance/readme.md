# SupersetInheritance
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: SupersetInheritance
require: $(this-folder)/../../../readme.md
azure-arm: true
model-namespace: false
input-file: $(this-folder)/SupersetInheritance.json
namespace: SupersetInheritance
operation-group-to-resource-type:
   OperationGroup1: Microsoft.Compute/operationGroup1
   OperationGroup2: Microsoft.Compute/operationGroup2
   OperationGroup3: Microsoft.Compute/operationGroup3
   OperationGroup4: Microsoft.Compute/operationGroup4
   OperationGroup5: Microsoft.Compute/operationGroup5
operation-group-to-resource:
   OperationGroup1: SupersetModel1
   OperationGroup2: SupersetModel2
   OperationGroup3: SupersetModel3
   OperationGroup4: SupersetModel4
   OperationGroup5: SupersetModel5
```
