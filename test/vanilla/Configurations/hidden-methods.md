# Hidden Methods

> see https://aka.ms/autorest

## Configuration

``` yaml
sync-methods: essential
base-folder: ../../../
input-file: node_modules/@microsoft.azure/autorest.testserver/swagger/body-complex.json
payload-flattening-threshold: 1
clear-output-folder: true
directive:
  - from: code-model-v1
    where: $.operations[*].methods[?(@.serializedName == 'basic_putValid')]
    transform: >-
      $.hidden = true;
      $.excludeFromInterface = true;
```

``` yaml $(tag) == 'vanilla'
output-folder: test/vanilla/Expected/AcceptanceTests/HiddenMethods/
csharp:
    namespace: Fixtures.AcceptanceTestsHiddenMethods
```