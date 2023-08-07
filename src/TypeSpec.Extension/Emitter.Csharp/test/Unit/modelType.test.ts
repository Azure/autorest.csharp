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

describe("Discriminator property", () => {
    let runner: TestHost;

    beforeEach(async () => {
        runner = await createEmitterTestHost();
    });

    it("Base model has discriminator property", async () => {
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
        // assert the discriminator property name
        assert(
            isEqual("kind", petModel?.DiscriminatorPropertyName),
            `Discriminator property name is not correct, got ${petModel?.DiscriminatorPropertyName}`
        );
        // assert we have a property corresponding to the discriminator property above on the base model
        const discriminatorProperty = petModel?.Properties.find(
            (p) => p.Name === petModel?.DiscriminatorPropertyName
        );
        assert(
            isEqual(
                {
                    Name: "kind",
                    SerializedName: "kind",
                    Type: {
                        Name: "string",
                        Kind: "String",
                        IsNullable: false
                    },
                    IsNullable: false,
                    IsRequired: true,
                    IsReadOnly: false,
                    IsDiscriminator: true,
                    Description: "Discriminator"
                },
                discriminatorProperty
            ),
            `Discriminator property is not correct, got ${JSON.stringify(
                discriminatorProperty
            )}`
        );
        // assert we will NOT have a DiscriminatorPropertyName on the derived models
        assert(
            catModel?.DiscriminatorPropertyName === undefined,
            "Cat model should not have the discriminator property name"
        );
        assert(
            dogModel?.DiscriminatorPropertyName === undefined,
            "Dog model should not have the discriminator property name"
        );
        // assert we will NOT have a property corresponding to the discriminator property on the derived models
        const catDiscriminatorProperty = catModel?.Properties.find(
            (p) => p.Name === petModel?.DiscriminatorPropertyName
        );
        const dogDiscriminatorProperty = dogModel?.Properties.find(
            (p) => p.Name === petModel?.DiscriminatorPropertyName
        );
        assert(
            catDiscriminatorProperty === undefined,
            "Cat model should not have the discriminator property"
        );
        assert(
            dogDiscriminatorProperty === undefined,
            "Dog model should not have the discriminator property"
        );
    });
});
