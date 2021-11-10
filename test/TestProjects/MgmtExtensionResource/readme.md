# MgmtExtensionResource

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/MgmtExtensionResource.json
namespace: MgmtExtensionResource
mgmt-debug:
  show-request-path: true
request-path-to-resource-name:
  /providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}: BuiltInPolicyDefinition
```
