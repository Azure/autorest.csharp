# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Setup
- [NodeJS](https://nodejs.org/en/) (10.x.x or 12.x.x)
- `npm install` (at root)
- `npm install -g @autorest/autorest`
- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0) (3.0.100)
- [PowerShell Core](https://github.com/PowerShell/PowerShell/releases/latest)
- [Java](https://www.java.com/en/download/) (for V2 testserver)

## Build
- `dotnet build` (at root)
- `./eng/Generate.ps1` (at root in PowerShell Core)

## Configuration
```yaml
# autorest-core version
version: 3.0.6205
use-extension:
  "@autorest/modelerfour": "4.5.176"
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

```yaml $(include-csproj)
pipeline:
  csharpproj:
    input: modelerfour/identity
  csharpproj/emitter:
    input: csharpproj
    scope: output-scope
  csharpproj/emitter/command:
    input:
    - csharpgen/emitter
    - csharpproj/emitter
    run: dotnet build $(title).csproj --verbosity quiet /nologo
```
