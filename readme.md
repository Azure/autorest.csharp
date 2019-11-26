# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
use-extension:
  "@autorest/modelerfour": "4.1.60"

pipeline:
  cs-modeler:
    input: modelerfour/identity
  cs-modeler/emitter:
    input: cs-modeler
    scope: output-scope
output-scope:
  output-artifact: source-file-csharp
```

```yaml $(include-csproj)
pipeline:
  cs-asseter:
    input: modelerfour/identity
  cs-asseter/emitter:
    input: cs-asseter
    scope: output-scope
  cs-asseter/emitter/command:
    input:
    - cs-modeler/emitter
    - cs-asseter/emitter
    run: dotnet build $(title).csproj --verbosity quiet /nologo
```
