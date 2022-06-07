# ResourceRename

## AutoRest Configuration

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
modelerfour:
  lenient-model-deduplication: true

# the remover will remove this since this is not internally used or a reference type if we do not have this configuration
keep-orphaned-models:
- AnyObjectTests

directive:
  - rename-model:
      from: SshPublicKeyResource
      to: SshPublicKeyInfo
  - from: resourceRename.json
    where: $.definitions.AnyObjectTests.properties.anyObjectDictionary
    transform: >
      delete $.additionalProperties
```
