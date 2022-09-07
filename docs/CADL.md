# Design of CADL Support

## Basic Terms
- CADL pipeline: the process and components of C# code generation from REST API specification written in [CADL](https://github.com/microsoft/cadl)
- Swagger pipeline: the process and components of C# code generation from cloud services API specification written in [OpenAPI](https://swagger.io/) 
- generator: autorest.csharp per se, last part of both pipelines that is directly responsible for code generation 
- generator input: file or stream with input for autorest.csharp, produced by previous part in the pipeline
- CADL C# Emitter: part of the CADL pipeline. Emitters are used by CADL compiler to output result of its work.
- CodeModel.yaml: generator input in Swagger pipeline
- CodeModel: deserialized object representation of CodeModel.yaml in autorest.csharp
- cadl.json: generator input in CADL pipeline produced by CADL emitter
- InputModel: deserialized object representation of cadl.json in autorest.csharp

## CADL Pipeline Overview

C# code generation CADL pipeline consists of two major components: CADL compiler that inputs API specification and outputs cadl.json using [CADL C# Emitter](https://github.com/Azure/autorest.csharp/tree/feature/v3/src/CADL.Extension/Emitter.Csharp), and autorest.csharp (a.k.a [generator](https://github.com/Azure/autorest.csharp/tree/feature/v3/src/AutoRest.CSharp)) that inputs cadl.json and outputs C# files that contain cloud service clients and models. cadl.json doesn't have explicit specification. Instead, it is assumed that InputModel types defined in [TS](https://github.com/Azure/autorest.csharp/tree/feature/v3/src/CADL.Extension/Emitter.Csharp/src/type) and in [C#](https://github.com/Azure/autorest.csharp/tree/feature/v3/src/AutoRest.CSharp/Common/Input) match each other. 

## Unification of CADL and Swagger pipelines

In Swagger pipeline, generator input is defined by [CodeModel specification](https://github.com/Azure/autorest/blob/main/packages/libs/codemodel/.resources/all-in-one/json/code-model.json) and is written in YAML. 

```mermaid
flowchart TB
    subgraph G1 [ ]
      C02(Custom Decorators) --> C10 & C20
      C00[/CADL input/]:::input --> C10
      C01[/Sidecar configuration/]:::input --> C10 & C11 & C21
      C10((CADL Compiler)) --> C20
      C11(Language-agnostic\noverrides) --> C10
      C20((CADL C# Emitter)) --> C30
      C21(C# specific\noverrides) --> C20
    end
    C30[/cadl.json/]:::input --> C40
    C01 --> C50 & C61 & C90
    subgraph G3 [ ]
      C41[/Source input model/]:::input --> C50
      C40(Input model):::data --> C50
      C50((OutputLibrary)) --> C60
      C60(Output model):::data --> C70
      C61(Code writers) --> C70
      C70((CodeGenTarget)) --> C80
      C80(Generated\nC# Code):::data ---> C90
      C90((Roslyn\npost-processing))
    end
    subgraph G2 [ ]
      S00[/Swagger input/]:::input --> S10
      S02[/autorest.md/]:::input --> S10
      S10((autorest + M4)) --> S30
      S40(CodeModel):::data --> S50
      S02 --> S41(CodeModel Overrides) -->  S50
      S50((CodeModelTransformer))--> S60
      S60(Modified\nCodeModel):::data --> S70
      S70((CodeModelConverter)) --> C40
    end
    S02 --> C50 & C61 & C90
    S30[/CodeModel.yaml/]:::input --> S40

    classDef input fill:#cfa;
    classDef data fill:#f96;
```
