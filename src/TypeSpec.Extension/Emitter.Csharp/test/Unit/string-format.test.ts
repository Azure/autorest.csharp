import { TestHost } from "@typespec/compiler/testing";
import { getAllHttpServices } from "@typespec/http";
import assert, { deepStrictEqual } from "assert";
import { beforeEach, describe, it } from "vitest";
import { createModel } from "../../src/lib/client-model-builder.js";
import {
    InputEnumType,
    InputModelType,
    InputPrimitiveType
} from "../../src/type/input-type.js";
import {
    createEmitterContext,
    createEmitterTestHost,
    createNetSdkContext,
    navigateModels,
    typeSpecCompile
} from "./utils/test-util.js";

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
        const sdkContext = createNetSdkContext(context);
        const root = createModel(sdkContext);
        deepStrictEqual(
            {
                Kind: "url",
                Encode: undefined
            } as InputPrimitiveType,
            root.Clients[0].Operations[0].Parameters[1].Type
        );
    });

    it("scalar url as model property", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model Foo {
                @doc("The source url.")
                source: url;
            }
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createNetSdkContext(context);
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        navigateModels(sdkContext, services[0].namespace, modelMap, enumMap);
        const foo = modelMap.get("Foo");
        assert(foo !== undefined);
        deepStrictEqual(
            {
                Kind: "url",
                Encode: undefined
            } as InputPrimitiveType,
            foo.Properties[0].Type
        );
    });
});
