# TypeSchemaMapping

## AutoRest Configuration

> see https://aka.ms/autorest

``` yaml
require: $(this-folder)/../../../readme.md
input-file: $(this-folder)/TypeSchemaMapping.json
namespace: TypeSchemaMapping
output-folder: $(this-folder)/SomeFolder/Generated
skip-csproj: true
project-folder: $(this-folder)
# relative path to output-folder also works
# project-folder: ../../
```
