import { TestHost } from "@typespec/compiler/testing";
import assert, { deepStrictEqual } from "assert";
import { createModel } from "../../src/lib/clientModelBuilder.js";
import { CodeModel } from "../../src/type/codeModel.js";
import {
    typeSpecCompile,
    createEmitterContext,
    createEmitterTestHost
} from "./utils/TestUtil.js";
import { InputEnumType } from "../../src/type/inputType.js";
import isEqual from "lodash.isequal";

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
                        IsConfident: true,
                        IsNullable: false
                    },
                    IsNullable: false
                },
                root.Clients[0].Operations[0].Parameters[0].Type
            )
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
                        IsConfident: true,
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
                        {
                            Name: "One",
                            Value: "1",
                            Description: "Enum value one"
                        },
                        {
                            Name: "Two",
                            Value: "2",
                            Description: "Enum value two"
                        },
                        {
                            Name: "Four",
                            Value: "4",
                            Description: "Enum value four"
                        }
                    ],
                    IsExtensible: false,
                    IsConfident: true,
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
        const root: CodeModel = createModel(context);
        assert(
            isEqual(
                {
                    Name: "FixedIntEnum",
                    Namespace: "Azure.Csharp.Testing",
                    Accessibility: undefined,
                    Deprecated: undefined,
                    Description: "Fixed int enum",
                    EnumValueType: "Float32",
                    AllowedValues: [
                        {
                            Name: "One",
                            Value: 1,
                            Description: "Enum value one"
                        },
                        {
                            Name: "Two",
                            Value: 2,
                            Description: "Enum value two"
                        },
                        {
                            Name: "Four",
                            Value: 4,
                            Description: "Enum value four"
                        }
                    ],
                    IsExtensible: false,
                    IsConfident: true,
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
        const program = await typeSpecCompile(
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
                    IsConfident: true,
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
