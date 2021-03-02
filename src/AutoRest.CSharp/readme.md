# AutoRest.CSharp
> see https://aka.ms/autorest

## Configuration
```yaml
use-extension:
  "@autorest/modelerfour": "4.17.0"
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
shared-source-folders: $(this-folder)/Generator.Shared;$(this-folder)/Azure.Core.Shared
```

```yaml !$(skip-csproj)
pipeline:
  csharpproj:
    input: modelerfour/identity
  csharpproj/emitter:
    input: csharpproj
    scope: output-scope
```
