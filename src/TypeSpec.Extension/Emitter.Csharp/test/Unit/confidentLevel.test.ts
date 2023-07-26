import { TestHost } from "@typespec/compiler/testing";
import assert from "assert";
import { createModel } from "../../src/lib/clientModelBuilder.js";
import { CodeModel } from "../../src/type/codeModel.js";
import {
    typeSpecCompile,
    createEmitterContext,
    createEmitterTestHost
} from "./utils/TestUtil.js";
import { ConvenienceMethodOmitReason } from "../../src/type/convenienceMethodOmitReason.js";

describe("Confidence on types", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("Normal types should be confident", async () => {
        const program = await typeSpecCompile(
            `
@doc("The cat")
model Cat {
    kind: "cat";

    @doc("Meow")
    meow: string;
}

@convenientAPI(true)
op test(@body input: Cat): Cat;
`,
            runner,
            { IsTCGCNeeded: true }
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const catModel = models.find((m) => m.Name === "Cat");
        // assert Cat exists
        assert(catModel !== undefined);
        // assert Cat is not confident
        assert(catModel.IsConfident === true, `Cat should be confident`);
        // operation should not be confident as well
        const client = root.Clients[0];
        const operation = client.Operations[0];
        assert(
            operation.GenerateConvenienceMethod === true,
            `The convenience method should be generated`
        );
        assert(
            operation.ConvenienceMethodOmitReason === undefined,
            `There should be no reason to omit this convenience method`
        );
    });

    it("Union types should never be confident", async () => {
        const program = await typeSpecCompile(
            `
@doc("The cat")
model Cat {
    kind: "cat";

    @doc("Meow")
    meow: string;

    @doc("Color, could be specified by a string or by an array of int as RGB")
    color: string | int32[];
}

@convenientAPI(true)
op test(@body input: Cat): Cat;
`,
            runner,
            { IsTCGCNeeded: true }
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const catModel = models.find((m) => m.Name === "Cat");
        // assert Cat exists
        assert(catModel !== undefined);
        // assert Cat is not confident
        assert(catModel.IsConfident === false, `Cat should not be confident`);
        // operation should not be confident as well
        const client = root.Clients[0];
        const operation = client.Operations[0];
        assert(
            operation.GenerateConvenienceMethod === true,
            `The convenience method should be generated`
        );
        assert(
            operation.ConvenienceMethodOmitReason ===
                ConvenienceMethodOmitReason.TypeNotConfident,
            `The convenience method should be omitted because of TypeNotConfident`
        );
    });

    it("Literal types of numbers should never be confident", async () => {
        const program = await typeSpecCompile(
            `
@doc("The cat")
model Cat {
    kind: "cat";

    @doc("Meow")
    meow: string;

    @doc("The id")
    id: 1;
}

@convenientAPI(true)
op test(@body input: Cat): Cat;
`,
            runner,
            { IsTCGCNeeded: true }
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const catModel = models.find((m) => m.Name === "Cat");
        // assert Cat exists
        assert(catModel !== undefined);
        // assert Cat is not confident
        assert(
            catModel.IsConfident === false,
            `Cat should not be confident because of the number literal`
        );
        // operation should not be confident as well
        const client = root.Clients[0];
        const operation = client.Operations[0];
        assert(
            operation.GenerateConvenienceMethod === true,
            `The convenience method should be generated`
        );
        assert(
            operation.ConvenienceMethodOmitReason ===
                ConvenienceMethodOmitReason.TypeNotConfident,
            `The convenience method should be omitted because of TypeNotConfident`
        );
    });

    it("Model types with discriminator should all be confident", async () => {
        const program = await typeSpecCompile(
            `
@doc("The base Pet model")
@discriminator("kind")
model Pet {
    @doc("The name of the pet")
    name: string;
}

@doc("The cat")
model Cat extends Pet {
    kind: "cat";

    @doc("Meow")
    meow: string;
}

@doc("The dog")
model Dog extends Pet {
    kind: "dog";

    @doc("Woof")
    woof: string;
}

@convenientAPI(true)
op test(@body input: Pet): Pet;
`,
            runner,
            { IsTCGCNeeded: true }
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const petModel = models.find((m) => m.Name === "Pet");
        const catModel = models.find((m) => m.Name === "Cat");
        const dogModel = models.find((m) => m.Name === "Dog");
        // assert they all exist
        assert(petModel !== undefined);
        assert(catModel !== undefined);
        assert(dogModel !== undefined);
        // assert they are all confident
        assert(petModel.IsConfident === true, `Pet should be confident`);
        assert(catModel.IsConfident === true, `Cat should be confident`);
        assert(dogModel.IsConfident === true, `Dog should be confident`);
        // operation should be confident as well
        const client = root.Clients[0];
        const operation = client.Operations[0];
        assert(
            operation.GenerateConvenienceMethod === true,
            `The convenience method should be generated`
        );
        assert(
            operation.ConvenienceMethodOmitReason === undefined,
            `The convenience method should have no reason to be omitted`
        );
    });

    it("IsConfident should be properly calculated when self reference exists", async () => {
        const program = await typeSpecCompile(
            `
@doc("The model that contains self reference")
model ModelWithSelfReference {
    @doc("The name")
    name: string;

    @doc("The self reference")
    selfReference: ModelWithSelfReference[];
}

@doc("Non-confident model that contains self reference")
model NonConfidentModelWithSelfReference {
    @doc("The name")
    name: string;

    @doc("The self reference")
    selfReference: NonConfidentModelWithSelfReference[];

    @doc("The non-confident part")
    unionProperty: string | int32[]; // put a union here so that it is not confident any more
}

@route("/test1")
@convenientAPI(true)
op test1(@body input: ModelWithSelfReference): void;

@route("/test2")
@convenientAPI(true)
op test2(@body input: NonConfidentModelWithSelfReference): void;
`,
            runner,
            { IsTCGCNeeded: true }
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const model = models.find((m) => m.Name === "ModelWithSelfReference");
        // assert it is confident
        assert(model !== undefined);
        assert(model.IsConfident === true, `This model should be confident`);
        const anotherModel = models.find(
            (m) => m.Name === "NonConfidentModelWithSelfReference"
        );
        // assert it is not confident
        assert(anotherModel !== undefined);
        assert(
            anotherModel.IsConfident === false,
            `This model should not be confident`
        );
        const client = root.Clients[0];
        const first = client.Operations.find((o) => o.Name === "test1");
        // the operation `test1` should be confident as well
        assert(first !== undefined);
        assert(
            first.GenerateConvenienceMethod === true,
            `The convenience method for first operation should be generated`
        );
        assert(
            first.ConvenienceMethodOmitReason === undefined,
            `The convenience method for first operation should have no reason to be omitted`
        );
        const second = client.Operations.find((o) => o.Name === "test2");
        // the operation `test2` should be confident as well
        assert(second !== undefined);
        assert(
            second.GenerateConvenienceMethod === true,
            `The convenience method for second operation should be generated`
        );
        assert(
            second.ConvenienceMethodOmitReason ===
                ConvenienceMethodOmitReason.TypeNotConfident,
            `The convenience method for second operation should have no reason to be omitted`
        );
    });

    it("IsConfident should be properly calculated when indirect self reference exists", async () => {
        const program = await typeSpecCompile(
            `
@doc("The model that contains self reference")
model NonConfidentModelWithSelfReference {
    @doc("The name")
    name: string;

    @doc("The self reference")
    reference: IndirectSelfReferenceModel[];
}

@doc("Indirect self reference model")
model IndirectSelfReferenceModel {
    @doc("Something not important")
    something: string;

    @doc("Reference back")
    reference: NonConfidentModelWithSelfReference;

    @doc("The non-confident part")
    unionProperty: string | int32[]; // put a union here so that it is not confident any more
}

@route("/test1")
@convenientAPI(true)
op test1(@body input: NonConfidentModelWithSelfReference): void;
`,
            runner,
            { IsTCGCNeeded: true }
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const anotherModel = models.find(
            (m) => m.Name === "NonConfidentModelWithSelfReference"
        );
        // assert it is not confident
        assert(anotherModel !== undefined);
        assert(
            anotherModel.IsConfident === false,
            `This model should not be confident`
        );
        const client = root.Clients[0];
        const operation = client.Operations.find((o) => o.Name === "test1");
        // the operation `test1` should be confident as well
        assert(operation !== undefined);
        assert(
            operation.GenerateConvenienceMethod === true,
            `The convenience method should be generated`
        );
        assert(
            operation.ConvenienceMethodOmitReason ===
                ConvenienceMethodOmitReason.TypeNotConfident,
            `The convenience method should be omitted because of TypeNotConfident`
        );
    });

    it("Base type with discriminator should be polluted to be not confident any more if a derived class is not", async () => {
        const program = await typeSpecCompile(
            `
@doc("The base Pet model")
@discriminator("kind")
model Pet {
    @doc("The name of the pet")
    name: string;
}

@doc("The cat")
model Cat extends Pet {
    kind: "cat";

    @doc("Meow")
    meow: string;

    @doc("Color, could be specified by a string or by an array of int as RGB")
    color: string | int32[];
}

@doc("The dog")
model Dog extends Pet {
    kind: "dog";

    @doc("Woof")
    woof: string;
}

@route("/")
@convenientAPI(true)
op petOp(@body input: Pet): Pet;

@route("/cat")
@convenientAPI(true)
op catOp(@body input: Cat): Cat;

@route("/dog")
@convenientAPI(true)
op dogOp(@body input: Dog): Dog;
`,
            runner,
            { IsTCGCNeeded: true }
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const petModel = models.find((m) => m.Name === "Pet");
        const catModel = models.find((m) => m.Name === "Cat");
        const dogModel = models.find((m) => m.Name === "Dog");
        // assert they all exist
        assert(petModel !== undefined);
        assert(catModel !== undefined);
        assert(dogModel !== undefined);
        // assert the they are all confident
        assert(
            petModel.IsConfident === false,
            `Pet should not be confident because one of its derived types is not confident`
        );
        assert(
            catModel.IsConfident === false,
            `Cat should not be confident because it contains union types`
        );
        assert(dogModel.IsConfident === true, `Dog should still be confident`);
        // operation should be confident as well
        const client = root.Clients[0];
        const petOperation = client.Operations.find((o) => o.Name === "petOp");
        assert(petOperation !== undefined);
        assert(
            petOperation.GenerateConvenienceMethod === true,
            `The convenience method for pet should be generated`
        );
        assert(
            petOperation.ConvenienceMethodOmitReason ===
                ConvenienceMethodOmitReason.TypeNotConfident,
            `The convenience method for pet should be omitted because of TypeNotConfident`
        );
        const catOperation = client.Operations.find((o) => o.Name === "catOp");
        assert(catOperation !== undefined);
        assert(
            catOperation.GenerateConvenienceMethod === true,
            `The convenience method for cat should be generated`
        );
        assert(
            catOperation.ConvenienceMethodOmitReason ===
                ConvenienceMethodOmitReason.TypeNotConfident,
            `The convenience method for cat should be omitted because of TypeNotConfident`
        );
        const dogOperation = client.Operations.find((o) => o.Name === "dogOp");
        assert(dogOperation !== undefined);
        assert(
            dogOperation.GenerateConvenienceMethod === true,
            `The convenience method for dog should be generated`
        );
        assert(
            dogOperation.ConvenienceMethodOmitReason === undefined,
            `The convenience method for dog should not be omitted`
        );
    });
});
