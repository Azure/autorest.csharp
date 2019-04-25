
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

### Temporary: Turn `modelAsString` into `oldModelAsString` in order to maintain old behavior for now (Use `--opt-in-extensible-enums` to opt in)

``` yaml !$(opt-in-extensible-enums)
directive:
  - from: swagger-document
    where: $..*[?(typeof @.modelAsString === "boolean" && typeof @.oldModelAsString !== "boolean")]
    transform: $.oldModelAsString = $.modelAsString
```

# AutoRest extension configuration

``` yaml

skip-simplifier-on-namespace: 
  - System.Security.Permissions

pipeline:
  agoda-extension/emitter:
    scope: scope-agoda-extension/emitter 
    output-artifact: some-file-generated-by-agoda-extension
  
scope-agoda-extension/emitter:
  input-artifact: some-file-generated-by-agoda-extension

output-artifact:
- some-file-generated-by-agoda-extension
```