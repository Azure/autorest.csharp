# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
clear-output-folder: false
azure-track2-csharp: true

use-extension:
  "@autorest/remodeler" : "~2.0.4"

pipeline:
  csharp-v3:
    input: remodeler

output-artifact:
  - source-file-csharp
```
