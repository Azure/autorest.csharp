# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
use-extension:
  "@autorest/modelerfour": "4.9.236"
modelerfour:
  flatten-models: true
  flatten-payloads: true
pipeline:
  csharpgen:
    input: modelerfour/identity
  csharpgen/emitter:
    input: csharpgen
    scope: output-scope
output-scope:
  output-artifact: source-file-csharp
```
