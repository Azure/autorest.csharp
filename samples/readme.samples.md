# Samples AutoRest Configuration

``` yaml
require: $(this-folder)/../readme.md
output-folder: $(this-folder)/$(title)/$(title)
clear-output-folder: false
```

``` yaml $(include-csproj) != 'disable'
pipeline:
  csharpproj:
    input: modelerfour/identity
  csharpproj/emitter:
    input: csharpproj
    scope: output-scope
```

``` yaml $(dotnet-build) != 'disable'
pipeline:
  csharpgen/emitter/command:
    input: csharpgen/emitter
    run: dotnet build $(title).csproj --verbosity quiet /nologo
```