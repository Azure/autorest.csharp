# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
test-item: "cheese"
use-extension:
  "@autorest/modelerfour": "~4.0.4"

pipeline:
  modelerfour:
    input: openapi-document/multi-api/identity
  modelerfour/new-transform:
    input: modelerfour
  csharp-v3:
    input: modelerfour/new-transform
  csharp-v3/emitter:
    input: csharp-v3
    scope: output-scope

output-scope:
  output-artifact: source-file-csharp
```
