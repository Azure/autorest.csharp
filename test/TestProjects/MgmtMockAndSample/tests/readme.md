# MgmtMockAndSample

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require: ../src/readme.md
testgen:
  mock: true
  sample: true
  skipped-operations: # only to test if the configuration works
  - Vaults_GetDeleted
  - Vaults_Update
```
