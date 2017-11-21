
# Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

# AutoRest extension configuration

``` yaml
use-extension:
  "@microsoft.azure/autorest.modeler": "2.3.38" # keep in sync with package.json's dev dependency in order to have meaningful tests

pipeline:
  csharp/imodeler1:
    input: openapi-document/identity
    output-artifact: code-model-v1
    scope: csharp
  csharp/commonmarker:
    input: imodeler1
    output-artifact: code-model-v1
  csharp/cm/transform:
    input: commonmarker
    output-artifact: code-model-v1
  csharp/cm/emitter:
    input: transform
    scope: scope-cm/emitter
  csharp/generate:
    plugin: csharp
    input: cm/transform
    output-artifact: source-file-csharp
  csharp/simplifier:
    plugin: csharp-simplifier
    input: generate
    output-artifact: source-file-csharp
  csharp/transform:
    input: simplifier
    output-artifact: source-file-csharp
    scope: scope-transform-string
  csharp/emitter:
    input: transform
    scope: scope-csharp/emitter

scope-csharp/emitter:
  input-artifact: source-file-csharp

output-artifact:
- source-file-csharp
```

## JSON-RPC client

``` yaml
pipeline:
  jsonrpcclient/imodeler1:
    input: openapi-document/identity
    output-artifact: code-model-v1
    scope: jsonrpcclient
  jsonrpcclient/generate:
    plugin: jsonrpcclient
    input: imodeler1
    output-artifact: source-file-jsonrpcclient
  jsonrpcclient/transform:
    input: generate
    output-artifact: source-file-jsonrpcclient
    scope: scope-transform-string
  jsonrpcclient/emitter:
    input: transform
    scope: scope-jsonrpcclient/emitter

scope-jsonrpcclient/emitter:
  input-artifact: source-file-jsonrpcclient
output-artifact:
- source-file-jsonrpcclient
```

## Help

``` yaml
help-content:
  csharp: # type: Help as defined in autorest-core/help.ts
    activationScope: csharp
    categoryFriendlyName: C# Generator
    settings:
    - key: azure-arm
      description: generate code in Azure flavor
    - key: fluent
      description: generate code in fluent flavor
    - key: namespace
      description: determines the root namespace to be used in generated code
      type: string
      required: true
    - key: license-header
      description: 'text to include as a header comment in generated files (magic strings: MICROSOFT_MIT, MICROSOFT_APACHE, MICROSOFT_MIT_NO_VERSION, MICROSOFT_APACHE_NO_VERSION, MICROSOFT_MIT_NO_CODEGEN)'
      type: string
    - key: payload-flattening-threshold
      description: max. number of properties in a request body. If the number of properties in the request body is less than or equal to this value, these properties will be represented as individual method arguments instead
      type: number
    - key: add-credentials
      description: include a credential property and constructor parameter supporting different authentication behaviors
    - key: override-client-name
      description: overrides the name of the client class (usually derived from $.info.title)
      type: string
    - key: use-internal-constructors
      description: generate constructors with internal instead of public visibility (useful for convenience layers)
    - key: sync-methods
      description: 'determines amount of synchronous wrappers to generate; default: essential'
      type: '"essential" | "all" | "none"'
    - key: use-datetimeoffset
      description: use DateTimeOffset instead of DateTime to model date/time types
    - key: client-side-validation
      description: 'whether to validate parameters at the client side (according to OpenAPI definition) before making a request; default: true'
      type: boolean
    - key: max-comment-columns
      description: maximum line width of comments before breaking into a new line
      type: number
    - key: output-file
      description: generate all code into the specified, single file (instead of the usual folder structure)
      type: string
    - key: sample-generation
      description: generate sample code from x-ms-examples (experimental)
```
