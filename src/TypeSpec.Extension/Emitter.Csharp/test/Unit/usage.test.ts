import { TestHost } from "@typespec/compiler/testing";
import assert, { deepStrictEqual } from "assert";
import {
    createEmitterContext,
    createEmitterTestHost,
    typeSpecCompile
} from "./utils/TestUtil.js";
import {
    HttpOperation,
    getAllHttpServices,
    getHttpService
} from "@typespec/http";
import { ignoreDiagnostics } from "@typespec/compiler";
import { getUsages } from "../../src/lib/model.js";
import { createSdkContext } from "@azure-tools/typespec-client-generator-core";
import { createModel } from "../../src/lib/clientModelBuilder.js";
import { CodeModel } from "../../src/type/codeModel.js";
import { Usage } from "../../src/type/usage.js";

describe("Test getUsages", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("Get usage for body parameter type", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model Foo {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: Foo): void;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const usages = getUsages(sdkContext, services[0].operations);
        assert(usages.inputs.includes("Foo"));
    });

    it("Get usage for response body", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model Foo {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string): Foo;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const usages = getUsages(sdkContext, services[0].operations);
        assert(usages.outputs.includes("Foo"));
    });

    it("Get usage for the model in both input and output", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model Foo {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: Foo): Foo;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const usages = getUsages(sdkContext, services[0].operations);
        assert(usages.roundTrips.includes("Foo"));
    });

    it("Get usage for the model which is used in two operations", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            model Foo {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: Foo): void;
            op test2(@path id: string): Foo;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const usages = getUsages(sdkContext, services[0].operations);
        assert(usages.roundTrips.includes("Foo"));
    });

    it("Get usage for the model as the template argument", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model template.")
            model TemplateModel<T> {
                @doc("name of the model.")
                name: string;
                prop: T;
            }
            @doc("This is a model.")
            model Foo {
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: TemplateModel<Foo>): void;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const usages = getUsages(sdkContext, services[0].operations);
        assert(usages.inputs.includes("TemplateModel"));
        assert(usages.inputs.includes("Foo"));
    });

    it("Test the usage inheritance between base model and derived model", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a base model.")
            model BaseModel {
                @doc("name of the model.")
                base: string;
            }
            @doc("This is a model.")
            model Foo extends BaseModel{
                @doc("name of the Foo")
                name: string;
            }
            op test(@path id: string, @body foo: Foo): void;
            op test2(@path id: string): BaseModel;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const usages = getUsages(sdkContext, services[0].operations);
        // verify that the baseModel will not apply the usage of derived model.
        assert(usages.outputs.includes("BaseModel"));
        // verify that the derived model will inherit the usage of base model
        assert(usages.roundTrips.includes("Foo"));
    });

    it("Test the usage of models spread alias", async () => {
        const program = await typeSpecCompile(
            `
            alias FooAlias = {
                @path id: string;
                @doc("name of the Foo")
                name: string;
            };
            op test(...FooAlias): void;
      `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const usages = getUsages(sdkContext, services[0].operations);
        assert(usages.inputs.includes("TestRequest"));
    });

    it("Test the usage of body parameter of azure core operation.", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            @resource("items")
            model Foo {
                @doc("id of Foo")
                @key
                @visibility("read","create","query")
                id: string;
                @doc("name of Foo")
                name: string;
            }

            @doc("The item information.")
            model FooInfo {
                @doc("name of Foo")
                name: string;
            }

            @doc("this is a response model.")
            model BatchCreateFooListItemsRequest {
                @doc("The items to create")
                fooInfos: FooInfo[];
            }

            @doc("this is a response model.")
            model BatchCreateTextListItemsResponse {
                @doc("The item list.")
                fooList: Foo[];
            }
            interface TextLists{
                @doc("create items")
                addItems is ResourceAction<Foo, BatchCreateFooListItemsRequest, BatchCreateTextListItemsResponse>;
            }
      `,
            runner,
            true,
            true
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const usages = getUsages(sdkContext, services[0].operations);
        assert(usages.inputs.includes("BatchCreateFooListItemsRequest"));
        assert(usages.inputs.includes("FooInfo"));
        assert(usages.outputs.includes("BatchCreateTextListItemsResponse"));
    });

    it("Test the usage of body parameter and return type of azure core resource operation.", async () => {
        const program = await typeSpecCompile(
            `
            @doc("This is a model.")
            @resource("items")
            model Foo {
                @doc("id of Foo")
                @key
                @visibility("read","create","query")
                id: string;
                @doc("name of Foo")
                name: string;
            }

            interface FooClient{
                @doc("create Foo")
                createFoo is ResourceCreateOrUpdate<Foo>;
            }
      `,
            runner,
            true,
            true
        );

        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const usages = getUsages(sdkContext, services[0].operations);
        assert(usages.roundTrips.includes("Foo"));
    });
});
