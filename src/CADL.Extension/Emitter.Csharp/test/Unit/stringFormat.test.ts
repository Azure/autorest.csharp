import { TestHost } from "@typespec/compiler/testing";
import assert, { deepStrictEqual } from "assert";
import isEqual from "lodash.isequal";
import { createEmitterContext, createEmitterTestHost, typeSpecCompile } from "./utils/TestUtil.js";
import { createSdkContext } from "@azure-tools/typespec-client-generator-core";
import { getAllHttpServices } from "@typespec/http";
import { loadOperation } from "../../src/lib/operation.js";
import { InputEnumType, InputModelType } from "../../src/type/inputType.js";

describe("Test string format", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });
    
    it("scalar url as parameter", async () => {
        const program = await typeSpecCompile(
            `
            op test(@path sourceUrl: url): void;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        const operation = loadOperation(context, services[0].operations[0], "", [], services[0].namespace, modelMap, enumMap);
        console.log(operation.Parameters[0].Type);
        assert(
            isEqual(
                { Name: 'url', Kind: 'Uri', IsNullable: false },
                operation.Parameters[0].Type
            )
        );
    });

    it("scalar url as model property", async () => {

    });

    it("format on operation parameter", async () => {
        const program = await typeSpecCompile(
            `
            op test(@path @format("Uri")sourceUrl: string): void;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        const operation = loadOperation(context, services[0].operations[0], "", [], services[0].namespace, modelMap, enumMap);
        console.log(operation.Parameters[0].Type);
        assert(
            isEqual(
                { Name: 'string', Kind: 'Uri', IsNullable: false },
                operation.Parameters[0].Type
            )
        );
    });

    it("format on model property", async () => {
        
    });
});