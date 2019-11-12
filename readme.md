# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
use-extension:
  "@autorest/modelerfour": "~4.0.39"

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
  cs-namer:
    input: modelerfour/new-transform
  cs-typer:
    input: cs-namer
  cs-modeler:
    input: cs-typer
  cs-modeler/emitter:
    input: cs-modeler
    scope: output-scope
  cs-operator:
    input: cs-typer
  cs-operator/emitter:
    input: cs-operator
    scope: output-scope
  cs-asseter:
    input: cs-typer
  cs-asseter/emitter:
    input: cs-asseter
    scope: output-scope
  cs-asseter/emitter/command:
    input:
    - cs-modeler/emitter
    - cs-operator/emitter
    - cs-asseter/emitter
    run: dotnet build $(title).csproj --verbosity quiet /nologo

output-scope:
  output-artifact: source-file-csharp
```
