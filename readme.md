# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
test-item: "cheese"
use-extension:
  "@autorest/remodeler" : "~2.0.4"

pipeline:
  remodeler:
    input: openapi-document/multi-api/identity
  csharp-v3:
    input: remodeler
  csharp-v3/emitter:
    input: csharp-v3
    scope: output-scope

output-scope:
  output-artifact: source-file-csharp
```
