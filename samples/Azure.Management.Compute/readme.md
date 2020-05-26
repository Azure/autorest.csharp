# Azure.Management.Compute

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require:
  - $(this-folder)/../../readme.md
  - https://github.com/Azure/azure-rest-api-specs/blob/d9cf7c7ed3d674ebd482836e82b274014245ae67/specification/compute/resource-manager/readme.md
namespace: Azure.Management.Compute
payload-flattening-threshold: 2

modelerfour:
  lenient-model-deduplication: true
```
