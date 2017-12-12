# Custom Components

> see https://aka.ms/autorest

## Configuration

``` yaml
input-file: ../Swagger/tiny.yaml
components:
  operations:
  - operationId: Cowbell_GetImplementationAgnostic
    implementation: |-
      // language agnostic stub implementation:
      return null; // no cowbell to retrieve here
  - operationId: Cowbell_GetImplementationSpecific
    implementation:
      csharp: |-
        // C# specific stub implementation:
        return null; // no cowbell to retrieve here
      ruby: |-
        return nil // I don't speak Ruby
  - operationId: Cowbell_GetForwardTo
    forward-to: Cowbell_Get
    parameters:
      - in: query
        name: id
        required: true
        schema:
          type: integer
          format: int64
  - operationId: Cowbell_GetForwardToCustomArgs1
    forward-to: Cowbell_Get
    parameters: []
  - operationId: Cowbell_GetForwardToCustomArgs2
    forward-to: Cowbell_Get
    parameters:
      - in: path
        name: name
        required: true
        schema:
          type: string
      - in: query
        name: id
        required: true
        schema:
          type: integer
          format: int64
  - operationId: Cowbell_GetForwardToCustomArgs3
    forward-to: Cowbell_Get
    parameters:
      - in: path
        name: name
        required: true
        schema:
          type: string
      - in: query
        name: idx
        required: true
        schema:
          type: integer
          format: int64
  - operationId: Cowbell_GetForwardToCustomArgs4
    forward-to: Cowbell_Get
    parameters:
      - in: path
        name: name
        required: true
        schema:
          type: string
      - in: query
        name: id
        x-ms-client-name: idx
        required: true
        schema:
          type: integer
          format: int64
```