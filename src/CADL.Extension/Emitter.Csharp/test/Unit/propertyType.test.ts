import { TestHost } from "@cadl-lang/compiler/testing";
import assert, { AssertionError, deepStrictEqual } from "assert";
import { createModel } from "../../src/lib/clientModelBuilder.js";
import { CodeModel } from "../../src/type/CodeModel.js";
import {
    cadlCompile,
    createEmitterContext,
    createEmitterTestHost
} from "./utils/TestUtil.js";
import {
    InputDictionaryType,
    InputEnumType,
    InputListType,
    InputLiteralType,
    InputModelType,
    InputPrimitiveType,
    InputType,
    InputUnionType
} from "../../src/type/InputType.js";
import isEqual from "lodash.isequal";
import {
    EmitContext,
    isGlobalNamespace,
    Namespace,
    navigateTypesInNamespace,
    Program,
    Type
} from "@cadl-lang/compiler";
import { getInputType } from "../../src/lib/model.js";

describe("Test GetInputType for array", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("array as request", async () => {
        const program = await cadlCompile(
            `
        op test(@body input: string[]): string[];
      `,
            runner
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        deepStrictEqual(
            root.Clients[0].Operations[0].Parameters[0].Type.Name,
            "Array"
        );
        assert(
            isEqual(
                {
                    Name: "Array",
                    ElementType: {
                        Name: "string",
                        Kind: "String",
                        IsNullable: false
                    },
                    IsNullable: false
                },
                root.Clients[0].Operations[0].Parameters[0].Type
            )
        );
    });

    it("array as response", async () => {
        const program = await cadlCompile(
            `
        op test(): string[];
      `,
            runner
        );
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        deepStrictEqual(
            root.Clients[0].Operations[0].Responses[0].BodyType?.Name,
            "Array"
        );
        assert(
            isEqual(
                {
                    Name: "Array",
                    ElementType: {
                        Name: "string",
                        Kind: "String",
                        IsNullable: false
                    },
                    IsNullable: false
                },
                root.Clients[0].Operations[0].Responses[0].BodyType
            )
        );
    });
});

describe("Test GetInputType for enum", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("Fixed string enum", async () => {
        const program = await cadlCompile(
            `
        #suppress "@azure-tools/cadl-azure-core/use-extensible-enum" "Enums should be defined without the @fixed decorator."
        @doc("fixed string enum")
        @fixed
        enum SimpleEnum {
            One: "1",
            Two: "2",
            Four: "4"
        }
        #suppress "@azure-tools/cadl-azure-core/use-standard-operations" "Operation 'test' should be defined using a signature from the Azure.Core namespace."
        @doc("test fixed enum.")
        op test(@doc("fixed enum as input.")@body input: SimpleEnum): string[];
      `,
            runner,
            true,
            true
        );
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        assert(
            isEqual(
                {
                    Name: "SimpleEnum",
                    Namespace: "Azure.Csharp.Testing",
                    Accessibility: undefined,
                    Deprecated: undefined,
                    Description: "fixed string enum",
                    EnumValueType: "String",
                    AllowedValues: [
                        { Name: "One", Value: "1", Description: undefined },
                        { Name: "Two", Value: "2", Description: undefined },
                        { Name: "Four", Value: "4", Description: undefined }
                    ],
                    IsExtensible: false,
                    IsNullable: false,
                    Usage: "Input"
                },
                root.Clients[0].Operations[0].Parameters[0].Type
            )
        );
        const type = root.Clients[0].Operations[0].Parameters[0]
            .Type as InputEnumType;
        assert(type.EnumValueType !== undefined);
        deepStrictEqual(type.Name, "SimpleEnum");
        deepStrictEqual(type.IsExtensible, false);
    });
    it("Fixed int enum", async () => {
        const program = await cadlCompile(
            `
      #suppress "@azure-tools/cadl-azure-core/use-extensible-enum" "Enums should be defined without the @fixed decorator."
      @doc("Fixed int enum")
      @fixed
      enum FixedIntEnum {
          One: 1,
          Two: 2,
          Four: 4
      }
      #suppress "@azure-tools/cadl-azure-core/use-standard-operations" "Operation 'test' should be defined using a signature from the Azure.Core namespace."
      @doc("test fixed enum.")
      op test(@doc("fixed enum as input.")@body input: FixedIntEnum): string[];
    `,
            runner,
            true,
            true
        );
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        assert(
            isEqual(
                {
                    Name: "FixedIntEnum",
                    Namespace: "Azure.Csharp.Testing",
                    Accessibility: undefined,
                    Deprecated: undefined,
                    Description: "Fixed int enum",
                    EnumValueType: "Int32",
                    AllowedValues: [
                        { Name: "One", Value: 1, Description: undefined },
                        { Name: "Two", Value: 2, Description: undefined },
                        { Name: "Four", Value: 4, Description: undefined }
                    ],
                    IsExtensible: false,
                    IsNullable: false,
                    Usage: "Input"
                },
                root.Clients[0].Operations[0].Parameters[0].Type
            )
        );
        const type = root.Clients[0].Operations[0].Parameters[0]
            .Type as InputEnumType;
        assert(type.EnumValueType !== undefined);
        deepStrictEqual(type.Name, "FixedIntEnum");
        deepStrictEqual(type.IsExtensible, false);
    });

    it("extensible enum", async () => {
        const program = await cadlCompile(
            `
        @doc("Extensible enum")
        enum ExtensibleEnum {
            One: "1",
            Two: "2",
            Four: "4"
        }
        op test(@body input: ExtensibleEnum): string[];
      `,
            runner
        );
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        assert(
            isEqual(
                {
                    Name: "ExtensibleEnum",
                    Namespace: "Azure.Csharp.Testing",
                    Accessibility: undefined,
                    Deprecated: undefined,
                    Description: "Extensible enum",
                    EnumValueType: "String",
                    AllowedValues: [
                        { Name: "One", Value: "1", Description: undefined },
                        { Name: "Two", Value: "2", Description: undefined },
                        { Name: "Four", Value: "4", Description: undefined }
                    ],
                    IsExtensible: true,
                    IsNullable: false,
                    Usage: "Input"
                },
                root.Clients[0].Operations[0].Parameters[0].Type
            )
        );
        const type = root.Clients[0].Operations[0].Parameters[0]
            .Type as InputEnumType;
        assert(type.EnumValueType !== undefined);
        deepStrictEqual(type.Name, "ExtensibleEnum");
        deepStrictEqual((type as InputEnumType).IsExtensible, true);
    });
});

function emitUnreferencedModels(program: Program, namespace: Namespace) {
    // if (options.omitUnreachableTypes) {
    //     return;
    // }
    const modelMap = new Map<string, InputModelType>();
    const enumMap = new Map<string, InputEnumType>();
    const computeModel = (x: Type) =>
        getInputType(program, x, modelMap, enumMap);
    const skipSubNamespaces = isGlobalNamespace(program, namespace);
    navigateTypesInNamespace(
        namespace,
        {
            model: (x) => {
                x.name !== "" && x.kind === "Model" && computeModel(x);
            },
            scalar: (x) => {
                computeModel(x);
            },
            enum: (x) => {
                computeModel(x);
            },
            union: (x) => {
                x.name !== undefined && computeModel(x);
            }
        },
        { skipSubNamespaces }
    );
}
