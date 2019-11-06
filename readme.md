# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
use-extension:
  "@autorest/modelerfour": "~4.0.20"

pipeline:
  modelerfour:
    input: openapi-document/multi-api/identity
  modelerfour/new-transform:
    input: modelerfour
  # serialize-tester:
  #   input: modelerfour/new-transform
  # serialize-tester/emitter:
  #   input: serialize-tester
  #   scope: output-scope
  name-modifier:
    input: modelerfour/new-transform
  type-resolver:
    input: name-modifier
  model-creator:
    input: type-resolver
  model-creator/emitter:
    input: model-creator
    scope: output-scope

output-scope:
  output-artifact: source-file-csharp
```
