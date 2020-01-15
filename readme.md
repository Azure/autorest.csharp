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
version: 3.0.6184
use-extension:
  "@autorest/modelerfour": "4.3.119"
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
