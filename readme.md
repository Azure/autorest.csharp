# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
use-extension:
  "@autorest/remodeler" : "~2.0.4"

pipeline:
  remodeler:
    input: openapi-document/multi-api/identity
  csharp-v3:
    input: remodeler
  csharp-v3/emitter:
    input: csharp-v3
    scope: output-info

output-info:
  output-artifact: source-file-csharp

#     emitter:
#     input: csharp-v3
#     scope: output-info
#     # output-artifact: source-file-csharp

# output-info:
#   # is-object: false
#   output-artifact: source-file-csharp
#   # output-artifact:
#   #   - source-file-csharp
#   #   - source-file-csproj
#   #   - source-file-powershell
#   #   - source-file-other
#   #   - binary-file
#   #   - preserved-files
```
