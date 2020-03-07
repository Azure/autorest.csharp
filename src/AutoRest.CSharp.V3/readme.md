# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Configuration
```yaml
use-extension:
  "@autorest/modelerfour": "4.9.236"
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

``` yaml $(include-csproj) != 'disable'
pipeline:
  csharpproj:
    input: modelerfour/identity
  csharpproj/emitter:
    input: csharpproj
    scope: output-scope
```

``` yaml $(dotnet-build) != 'disable' && $(include-csproj) == 'disable'
pipeline:
  csharpgen/emitter/command:
    input: csharpgen/emitter
    run: dotnet build $(title).csproj --verbosity quiet /nologo
```

``` yaml $(dotnet-build) != 'disable' && $(include-csproj) != 'disable'
pipeline:
  csharpproj/emitter/command:
    input:
    - csharpgen/emitter
    - csharpproj/emitter
    run: dotnet build $(title).csproj --verbosity quiet /nologo
```