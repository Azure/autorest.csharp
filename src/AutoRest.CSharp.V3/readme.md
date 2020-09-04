# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
use-extension:
  "@autorest/modelerfour": "4.15.407"
modelerfour:
  always-create-content-type-parameter: true
  flatten-models: true
  flatten-payloads: true
  group-parameters: true
pipeline:
  csharpgen:
    input: modelerfour/identity
  csharpgen/emitter:
    input: csharpgen
    scope: output-scope
output-scope:
  output-artifact: source-file-csharp
```
