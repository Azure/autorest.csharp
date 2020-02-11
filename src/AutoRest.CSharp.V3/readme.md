# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
# autorest-core version
use-extension:
  "@autorest/modelerfour": "4.6.191"
modelerfour:
  flatten-models: true
pipeline:
  csharpgen:
    input: modelerfour/identity
  csharpgen/emitter:
    input: csharpgen
    scope: output-scope
output-scope:
  output-artifact: source-file-csharp
```