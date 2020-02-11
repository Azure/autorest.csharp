# Tests AutoRest Configuration

``` yaml
require: $(this-folder)/../../readme.md
output-folder: $(this-folder)/$(title)
clear-output-folder: true
```

``` yaml
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