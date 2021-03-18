# AutoRest.CSharp
> see https://aka.ms/autorest

## Configuration
```yaml
use-extension:
  "@autorest/modelerfour": "4.17.2"
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

## Help
```yaml
help-content:
  csharp: # type: Help as defined in autorest-core/help.ts
    activationScope: csharp
    categoryFriendlyName: C# Generator
    settings:
    - key: library-name
      description: The name of your library. This is what will be displayed on NuGet.
      type: string
    - key: shared-source-folders
      description: Pass shared folder paths through here. Common values point to the shared generator assets and shared azure core assets in autorest.csharp
      type: string
    - key: public-clients
      description: Whether to generate public client. Defaults to `false`.
      type: bool
    - key: model-namespace
      description: Whether to add a separate namespace of Models, more specifically adding `{value-from-namespace-flag}.Models`. Defaults to `true`.
      type: bool
```
