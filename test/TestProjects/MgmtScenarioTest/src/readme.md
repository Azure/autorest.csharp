# MgmtScenarioTest

## Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: MgmtScenarioTest
namespace: MgmtScenarioTest
require:
- C:\Users\dapzhang\Documents\workspace\azure-rest-api-specs\specification\appplatform\resource-manager\readme.md
- $(this-folder)/../../../../readme.md
clear-output-folder: true
model-namespace: true
tag: package-preview-2020-11

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}
```
