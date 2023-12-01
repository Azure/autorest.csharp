# MgmtCustomizations

### AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
azure-arm: true
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/MgmtCustomizations.json
namespace: MgmtCustomizations
model-namespace: false
public-clients: false
head-as-boolean: false
baseline-contract-folder: ../../BaselineContract/MgmtCustomizations

rename-mapping:
  Pet.dateOfBirth: -|date-time
```
