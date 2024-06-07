import { TestHost } from "@typespec/compiler/testing";
import assert, { deepStrictEqual } from "assert";
import { beforeEach, describe, it } from "vitest";
import { createModel } from "../../src/lib/client-model-builder.js";
import {
    InputEnumType,
    InputListType,
    InputTypeKind
} from "../../src/type/input-type.js";
import {
    createEmitterContext,
    createEmitterTestHost,
    createNetSdkContext,
    typeSpecCompile
} from "./utils/test-util.js";

describe("Test GetInputType for array", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("array as request", async () => {
        const program = await typeSpecCompile(
            `
        op test(@body input: string[]): string[];
      `,
            runner
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        deepStrictEqual(
            root.Clients[0].Operations[0].Parameters[0].Type.kind,
            InputTypeKind.Array
        );
        deepStrictEqual(
            {
                kind: InputTypeKind.Array,
                name: InputTypeKind.Array,
                elementType: {
                    kind: "string",
                    isNullable: false,
                    encode: undefined
                },
                isNullable: false
            } as InputListType,
            root.Clients[0].Operations[0].Parameters[0].Type
        );
    });

    it("array as response", async () => {
        const program = await typeSpecCompile(
            `
        op test(): string[];
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        deepStrictEqual(
            root.Clients[0].Operations[0].Responses[0].BodyType?.kind,
            InputTypeKind.Array
        );
        deepStrictEqual(
            {
                kind: InputTypeKind.Array,
                name: InputTypeKind.Array,
                elementType: {
                    kind: "string",
                    isNullable: false,
                    encode: undefined
                },
                isNullable: false
            } as InputListType,
            root.Clients[0].Operations[0].Responses[0].BodyType
        );
    });
});

describe("Test GetInputType for enum", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("Fixed string enum", async () => {
        const program = await typeSpecCompile(
            `
        #suppress "@azure-tools/typespec-azure-core/use-extensible-enum" "Enums should be defined without the @fixed decorator."
        @doc("fixed string enum")
        @fixed
        enum SimpleEnum {
            @doc("Enum value one")
            One: "1",
            @doc("Enum value two")
            Two: "2",
            @doc("Enum value four")
            Four: "4"
        }
        #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Operation 'test' should be defined using a signature from the Azure.Core namespace."
        @doc("test fixed enum.")
        op test(@doc("fixed enum as input.")@body input: SimpleEnum): string[];
      `,
            runner,
            { IsNamespaceNeeded: true, IsAzureCoreNeeded: true }
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        deepStrictEqual(
            {
                kind: "enum",
                name: "SimpleEnum",
                namespace: "Azure.Csharp.Testing",
                accessibility: undefined,
                deprecated: undefined,
                description: "fixed string enum",
                valueType: {
                    kind: "string",
                    isNullable: false,
                    encode: undefined
                },
                values: [
                    {
                        name: "One",
                        value: "1",
                        description: "Enum value one"
                    },
                    {
                        name: "Two",
                        value: "2",
                        description: "Enum value two"
                    },
                    {
                        name: "Four",
                        value: "4",
                        description: "Enum value four"
                    }
                ],
                isExtensible: false,
                isNullable: false,
                usage: "Input"
            } as InputEnumType,
            root.Clients[0].Operations[0].Parameters[0].Type,
            `Enum type is not correct, got ${JSON.stringify(
                root.Clients[0].Operations[0].Parameters[0].Type
            )}`
        );
        const type = root.Clients[0].Operations[0].Parameters[0]
            .Type as InputEnumType;
        assert(type.valueType !== undefined);
        deepStrictEqual(type.name, "SimpleEnum");
        deepStrictEqual(type.isExtensible, false);
    });
    it("Fixed int enum", async () => {
        const program = await typeSpecCompile(
            `
      #suppress "@azure-tools/typespec-azure-core/use-extensible-enum" "Enums should be defined without the @fixed decorator."
      @doc("Fixed int enum")
      @fixed
      enum FixedIntEnum {
          @doc("Enum value one")
          One: 1,
          @doc("Enum value two")
          Two: 2,
          @doc("Enum value four")
          Four: 4
      }
      #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Operation 'test' should be defined using a signature from the Azure.Core namespace."
      @doc("test fixed enum.")
      op test(@doc("fixed enum as input.")@body input: FixedIntEnum): string[];
    `,
            runner,
            { IsNamespaceNeeded: true, IsAzureCoreNeeded: true }
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        deepStrictEqual(
            {
                kind: "enum",
                name: "FixedIntEnum",
                namespace: "Azure.Csharp.Testing",
                accessibility: undefined,
                deprecated: undefined,
                description: "Fixed int enum",
                valueType: {
                    kind: "int32",
                    isNullable: false,
                    encode: undefined
                },
                values: [
                    {
                        name: "One",
                        value: 1,
                        description: "Enum value one"
                    },
                    {
                        name: "Two",
                        value: 2,
                        description: "Enum value two"
                    },
                    {
                        name: "Four",
                        value: 4,
                        description: "Enum value four"
                    }
                ],
                isExtensible: false,
                isNullable: false,
                usage: "Input"
            } as InputEnumType,
            root.Clients[0].Operations[0].Parameters[0].Type,
            `Enum type is not correct, got ${JSON.stringify(
                root.Clients[0].Operations[0].Parameters[0].Type
            )}`
        );
        const type = root.Clients[0].Operations[0].Parameters[0]
            .Type as InputEnumType;
        assert(type.valueType !== undefined);
        deepStrictEqual(type.name, "FixedIntEnum");
        deepStrictEqual(type.isExtensible, false);
    });

    it("fixed enum", async () => {
        const program = await typeSpecCompile(
            `
        @doc("Fixed enum")
        enum FixedEnum {
            One: "1",
            Two: "2",
            Four: "4"
        }
        op test(@body input: FixedEnum): string[];
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        deepStrictEqual(
            {
                kind: "enum",
                name: "FixedEnum",
                namespace: "Azure.Csharp.Testing",
                accessibility: undefined,
                deprecated: undefined,
                description: "Fixed enum",
                valueType: {
                    kind: "string",
                    isNullable: false,
                    encode: undefined
                },
                values: [
                    { name: "One", value: "1", description: undefined },
                    { name: "Two", value: "2", description: undefined },
                    { name: "Four", value: "4", description: undefined }
                ],
                isExtensible: false,
                isNullable: false,
                usage: "Input"
            } as InputEnumType,
            root.Clients[0].Operations[0].Parameters[0].Type,
            `Enum type is not correct, got ${JSON.stringify(
                root.Clients[0].Operations[0].Parameters[0].Type
            )}`
        );
        const type = root.Clients[0].Operations[0].Parameters[0]
            .Type as InputEnumType;
        assert(type.valueType !== undefined);
        deepStrictEqual(type.name, "FixedEnum");
        deepStrictEqual((type as InputEnumType).isExtensible, false);
    });
});
