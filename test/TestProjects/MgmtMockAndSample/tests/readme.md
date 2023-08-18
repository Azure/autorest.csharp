# MgmtMockAndSample

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require: ../src/readme.md
include-x-ms-examples-original-file: false
mgmt-debug:
  skip-codegen: true
sample-gen:
  mock: true
  sample: true
  output-folder: $(this-folder)/Generated
  clear-output-folder: true
  skipped-operations: # only to test if the configuration works
  - Vaults_GetDeleted
  - Vaults_Update
```
