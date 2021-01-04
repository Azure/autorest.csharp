# AppConfiguration
### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
shared-source-folders:
  - $(this-folder)/../../src/assets/Generator.Shared
  - $(this-folder)/../../src/assets/Azure.Core.Shared
namespace: Azure.AppConfiguration
pipeline:
  csharpproj:
    input: modelerfour/identity
  csharpproj/emitter:
    input: csharpproj
    scope: output-scope
```