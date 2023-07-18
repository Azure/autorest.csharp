import { TestHost } from "@typespec/compiler/testing";
import assert from "assert";
import { createModel } from "../../src/lib/clientModelBuilder.js";
import { CodeModel } from "../../src/type/codeModel.js";
import {
    typeSpecCompile,
    createEmitterContext,
    createEmitterTestHost
} from "./utils/TestUtil.js";
import isEqual from "lodash.isequal";

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

op test(@body input: Cat): Cat;
`,
            runner
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const catModel = models.find((m) => m.Name === "Cat");
        // assert Cat is not confident
        assert(isEqual(true, catModel?.IsConfident), `Cat should be confident`);
        // operation should not be confident as well
        const client = root.Clients[0];
        const operation = client.Operations[0];
        assert(
            isEqual(true, operation.IsConfident),
            `Operation should be confident`
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

op test(@body input: Cat): Cat;
`,
            runner
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const catModel = models.find((m) => m.Name === "Cat");
        // assert Cat is not confident
        assert(
            isEqual(false, catModel?.IsConfident),
            `Cat should not be confident`
        );
        // operation should not be confident as well
        const client = root.Clients[0];
        const operation = client.Operations[0];
        assert(
            isEqual(false, operation.IsConfident),
            `Operation should not be confident`
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

op test(@body input: Cat): Cat;
`,
            runner
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const catModel = models.find((m) => m.Name === "Cat");
        // assert Cat is not confident
        assert(
            isEqual(false, catModel?.IsConfident),
            `Cat should not be confident`
        );
        // operation should not be confident as well
        const client = root.Clients[0];
        const operation = client.Operations[0];
        assert(
            isEqual(false, operation.IsConfident),
            `Operation should not be confident`
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

    op test(@body input: Pet): Pet;
    `,
            runner
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const petModel = models.find((m) => m.Name === "Pet");
        const catModel = models.find((m) => m.Name === "Cat");
        const dogModel = models.find((m) => m.Name === "Dog");
        // assert the they are all confident
        assert(isEqual(true, petModel?.IsConfident), `Pet should be confident`);
        assert(isEqual(true, catModel?.IsConfident), `Cat should be confident`);
        assert(isEqual(true, dogModel?.IsConfident), `Dog should be confident`);
        // operation should be confident as well
        const client = root.Clients[0];
        const operation = client.Operations[0];
        assert(
            isEqual(true, operation.IsConfident),
            `Operation should be confident`
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
    op petOp(@body input: Pet): Pet;

    @route("/cat")
    op catOp(@body input: Cat): Cat;

    @route("/dog")
    op dogOp(@body input: Dog): Dog;
    `,
            runner
        );
        runner.compileAndDiagnose;
        const context = createEmitterContext(program);
        const root: CodeModel = createModel(context);
        const models = root.Models;
        const petModel = models.find((m) => m.Name === "Pet");
        const catModel = models.find((m) => m.Name === "Cat");
        const dogModel = models.find((m) => m.Name === "Dog");
        // assert the they are all confident
        assert(
            isEqual(false, petModel?.IsConfident),
            `Pet should not be confident because one of its derived types is not confident`
        );
        assert(
            isEqual(false, catModel?.IsConfident),
            `Cat should not be confident because it contains union types`
        );
        assert(
            isEqual(true, dogModel?.IsConfident),
            `Dog should still be confident`
        );
        // operation should be confident as well
        const client = root.Clients[0];
        const petOperation = client.Operations.find((o) => o.Name === "petOp");
        assert(petOperation !== undefined);
        assert(
            isEqual(false, petOperation.IsConfident),
            `petOp should not be confident`
        );
        const catOperation = client.Operations.find((o) => o.Name === "catOp");
        assert(catOperation !== undefined);
        assert(
            isEqual(false, catOperation.IsConfident),
            `catOp should not be confident`
        );
        const dogOperation = client.Operations.find((o) => o.Name === "dogOp");
        assert(dogOperation !== undefined);
        assert(
            isEqual(true, dogOperation.IsConfident),
            `dogOp should still be confident`
        );
    });
});
