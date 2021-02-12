# Azure.ResourceManager.Compute
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../readme.md
input-file: $(this-folder)/compute.json
namespace: Azure.ResourceManager.Compute
model-namespace: false
public-clients: false
head-as-boolean: false
payload-flattening-threshold: 2

modelerfour:
  lenient-model-deduplication: true
```
