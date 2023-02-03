import { TestHost } from "@cadl-lang/compiler/testing";
import assert, { AssertionError, deepStrictEqual } from "assert";
import { createModel } from "../../src/emitter.js";
import { CodeModel } from "../../src/type/CodeModel.js";
import { cadlCompile, createEmitterTestHost } from "./utils/TestUtil.js";
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
import isEqual from 'lodash.isequal';

describe("compiler: array", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("array as request", async () => {
        const program = await cadlCompile(`
        op test(@body input: string[]): string[];
      `, runner)
        const root: CodeModel = createModel(program, false);
        deepStrictEqual(root.Clients[0].Operations[0].Parameters[0].Type.Name, "Array");
        assert(isEqual({
          Name: 'Array',
          ElementType: { Name: 'string', Kind: 'String', IsNullable: false },
          IsNullable: false
        }, root.Clients[0].Operations[0].Parameters[0].Type))
      });

    it("array as response", async () => {
        const program = await cadlCompile(`
        op test(): string[];
      `, runner)
        const root: CodeModel = createModel(program, false);
        deepStrictEqual(root.Clients[0].Operations[0].Responses[0].BodyType?.Name, "Array");
        assert(isEqual({
          Name: 'Array',
          ElementType: { Name: 'string', Kind: 'String', IsNullable: false },
          IsNullable: false
        }, root.Clients[0].Operations[0].Responses[0].BodyType))
      });
});

describe("compiler: enum", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    // it("Fixed enum", async () => {
    //     const program = await cadlCompile(`
    //     @doc("Simple enum")
    //     @fixed
    //     enum SimpleEnum {
    //         One: "1",
    //         Two: "2",
    //         Four: "4"
    //     }
    //     op test(@body input: SimpleEnum): string[];
    //   `, runner, true, true)
    //     const root: CodeModel = createModel(program, false);
    //     const type = root.Clients[0].Operations[0].Parameters[0].Type as InputEnumType;
    //     assert(type.EnumValueType !== undefined);
    //     deepStrictEqual(type.Name, "SimpleEnum");
    //     deepStrictEqual(type.IsExtensible, false);
    //   });

    it("extensible enum", async () => {
        const program = await cadlCompile(`
        @doc("Extensible enum")
        enum ExtensibleEnum {
            One: "1",
            Two: "2",
            Four: "4"
        }
        op test(@body input: ExtensibleEnum): string[];
      `, runner)
        const root: CodeModel = createModel(program, false);
        assert(isEqual({
          Name: 'ExtensibleEnum',
          Namespace: 'Azure.Csharp.Testing',
          Accessibility: undefined,
          Deprecated: undefined,
          Description: 'Extensible enum',
          EnumValueType: 'String',
          AllowedValues: [
            { Name: 'One', Value: '1', Description: undefined },
            { Name: 'Two', Value: '2', Description: undefined },
            { Name: 'Four', Value: '4', Description: undefined }
          ],
          IsExtensible: true,
          IsNullable: false,
          Usage: 'None'
        }, root.Clients[0].Operations[0].Parameters[0].Type))
        const type = root.Clients[0].Operations[0].Parameters[0].Type as InputEnumType;
        assert(type.EnumValueType !== undefined);
        deepStrictEqual(type.Name, "ExtensibleEnum");
        deepStrictEqual((type as InputEnumType).IsExtensible, true);
      });
});