# ResourceRename
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/resourceRename.json
namespace: ResourceRename
model-namespace: false
public-clients: false
head-as-boolean: false
payload-flattening-threshold: 2
resource-rename:
   SshPublicKeyResource : SshPublicKeyInfo
modelerfour:
  lenient-model-deduplication: true
```
