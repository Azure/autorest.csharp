# AutoRest.CSharp.V3
> see https://aka.ms/autorest

## Setup
- [NodeJS](https://nodejs.org/en/) (13.x.x)
- `npm install` (at root)
- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0) (3.0.100)
- [PowerShell Core](https://github.com/PowerShell/PowerShell/releases/latest)
- [Java](https://www.java.com/en/download/) (for V2 testserver)

## Build
- `dotnet build` (at root)
- `./eng/Generate.ps1` (at root in PowerShell Core)

## Configuration
```yaml
# autorest-core version
version: 3.0.6237
shared-source-folder: $(this-folder)/src/assets
save-code-model: true
use: $(this-folder)/artifacts/bin/AutoRest.CSharp.V3/Debug/netcoreapp3.0/
```
