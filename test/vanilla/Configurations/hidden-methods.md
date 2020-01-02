# Hidden Methods

> see https://aka.ms/autorest

## Configuration

``` yaml
input-file: ../../../node_modules/@microsoft.azure/autorest.testserver/swagger/body-complex.json
payload-flattening-threshold: 1
directive:
  - from: code-model-v1
    where-operation: basic_putValid
    transform: >-
      $.hidden = true;
      $.excludeFromInterface = true;
```