# MgmtScenarioTest

## Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: MgmtScenarioTest
namespace: MgmtScenarioTest
require:
- $(this-folder)/../specification/readme.md
- $(this-folder)/../../../../readme.md
clear-output-folder: true
model-namespace: true

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}
```
