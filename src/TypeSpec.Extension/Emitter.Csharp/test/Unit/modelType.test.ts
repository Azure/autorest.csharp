import { TestHost } from "@typespec/compiler/testing";
import assert from "assert";
import { createModel } from "../../src/lib/clientModelBuilder.js";
import { CodeModel } from "../../src/type/codeModel.js";
import {
    typeSpecCompile,
    createEmitterContext,
    createEmitterTestHost,
    navigateModels
} from "./utils/TestUtil.js";
import isEqual from "lodash.isequal";
import { InputEnumType, InputModelType } from "../../src/type/inputType.js";
import { createSdkContext } from "@azure-tools/typespec-client-generator-core";
import { getAllHttpServices } from "@typespec/http";

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
model Dog extends Pet{
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

    it("Discriminator property is enum with no enum value defined", async () => {
        const program = await typeSpecCompile(
            `
        @doc("Int based extensible enum")
        enum PetKind {
            Cat,
            Dog,
        }
        @doc("The base Pet model")
        @discriminator("kind")
        model Pet {
            @doc("The kind of the pet")
            kind: PetKind;
            @doc("The name of the pet")
            name: string;
        }

        @doc("The cat")
        model Cat extends Pet{
            kind: PetKind.Cat;

            @doc("Meow")
            meow: string;
        }

        @doc("The dog")
        model Dog extends Pet{
            kind: PetKind.Dog;

            @doc("Woof")
            woof: string;
        }

        op test(@body input: Pet): Pet;
        `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        navigateModels(sdkContext, services[0].namespace, modelMap, enumMap);
        const pet = modelMap.get("Pet");
        assert(pet !== undefined);
        // assert the discriminator property name
        assert(
            isEqual("kind", pet?.DiscriminatorPropertyName),
            `Discriminator property name is not correct, got ${pet?.DiscriminatorPropertyName}`
        );
        // assert we have a property corresponding to the discriminator property above on the base model
        const discriminatorProperty = pet?.Properties.find(
            (p) => p.Name === pet?.DiscriminatorPropertyName
        );
        assert(
            isEqual(
                {
                    Name: "kind",
                    SerializedName: "kind",
                    Description: "The kind of the pet",
                    Type: {
                        Name: "PetKind",
                        Namespace: "Azure.Csharp.Testing",
                        Accessibility: undefined,
                        Deprecated: undefined,
                        Description: "Int based extensible enum",
                        EnumValueType: "String",
                        AllowedValues: [
                            {
                                Name: "Cat",
                                Value: "Cat",
                                Description: undefined
                            },
                            {
                                Name: "Dog",
                                Value: "Dog",
                                Description: undefined
                            }
                        ],
                        IsExtensible: true,
                        IsNullable: false
                    },
                    IsRequired: true,
                    IsReadOnly: false,
                    IsDiscriminator: true
                },
                discriminatorProperty
            ),
            `Discriminator property is not correct, got ${JSON.stringify(
                discriminatorProperty
            )}`
        );

        // verify derived model Cat
        const cat = modelMap.get("Cat");
        assert(cat !== undefined);
        assert(cat.DiscriminatorValue === "Cat");
        assert(cat.BaseModel === pet);
        // assert we will NOT have a DiscriminatorPropertyName on the derived models
        assert(
            cat.DiscriminatorPropertyName === undefined,
            "Cat model should not have the discriminator property name"
        );
        // assert we will NOT have a property corresponding to the discriminator property on the derived models
        const catDiscriminatorProperty = cat.Properties.find(
            (p) => p.Name === pet.DiscriminatorPropertyName
        );
        assert(
            catDiscriminatorProperty === undefined,
            "Cat model should not have the discriminator property"
        );

        // verify derived model Dog
        const dog = modelMap.get("Dog");
        assert(dog !== undefined);
        assert(dog.DiscriminatorValue === "Dog");
        assert(dog.BaseModel === pet);
        // assert we will NOT have a DiscriminatorPropertyName on the derived models
        assert(
            dog.DiscriminatorPropertyName === undefined,
            "Dog model should not have the discriminator property name"
        );
        // assert we will NOT have a property corresponding to the discriminator property on the derived models
        const dogDiscriminatorProperty = dog.Properties.find(
            (p) => p.Name === pet.DiscriminatorPropertyName
        );
        assert(
            dogDiscriminatorProperty === undefined,
            "Dog model should not have the discriminator property"
        );
    });

    it("Discriminator property is enum with enum value defined", async () => {
        const program = await typeSpecCompile(
            `
        @doc("Int based extensible enum")
        enum PetKind {
            Cat : "cat",
            Dog : "dog",
        }
        @doc("The base Pet model")
        @discriminator("kind")
        model Pet {
            @doc("The kind of the pet")
            kind: PetKind;
            @doc("The name of the pet")
            name: string;
        }

        @doc("The cat")
        model Cat extends Pet{
            kind: PetKind.Cat;

            @doc("Meow")
            meow: string;
        }

        @doc("The dog")
        model Dog extends Pet{
            kind: PetKind.Dog;

            @doc("Woof")
            woof: string;
        }

        op test(@body input: Pet): Pet;
        `,
            runner
        );
        const context = createEmitterContext(program);
        const sdkContext = createSdkContext(context);
        const [services] = getAllHttpServices(program);
        const modelMap = new Map<string, InputModelType>();
        const enumMap = new Map<string, InputEnumType>();
        navigateModels(sdkContext, services[0].namespace, modelMap, enumMap);
        const pet = modelMap.get("Pet");
        assert(pet !== undefined);
        // assert the discriminator property name
        assert(
            isEqual("kind", pet?.DiscriminatorPropertyName),
            `Discriminator property name is not correct, got ${pet?.DiscriminatorPropertyName}`
        );
        // assert we have a property corresponding to the discriminator property above on the base model
        const discriminatorProperty = pet?.Properties.find(
            (p) => p.Name === pet?.DiscriminatorPropertyName
        );
        assert(
            isEqual(
                {
                    Name: "kind",
                    SerializedName: "kind",
                    Description: "The kind of the pet",
                    Type: {
                        Name: "PetKind",
                        Namespace: "Azure.Csharp.Testing",
                        Accessibility: undefined,
                        Deprecated: undefined,
                        Description: "Int based extensible enum",
                        EnumValueType: "String",
                        AllowedValues: [
                            {
                                Name: "Cat",
                                Value: "cat",
                                Description: undefined
                            },
                            {
                                Name: "Dog",
                                Value: "dog",
                                Description: undefined
                            }
                        ],
                        IsExtensible: true,
                        IsNullable: false
                    },
                    IsRequired: true,
                    IsReadOnly: false,
                    IsDiscriminator: true
                },
                discriminatorProperty
            ),
            `Discriminator property is not correct, got ${JSON.stringify(
                discriminatorProperty
            )}`
        );

        // verify derived model Cat
        const cat = modelMap.get("Cat");
        assert(cat !== undefined);
        assert(cat.DiscriminatorValue === "cat");
        assert(cat.BaseModel === pet);
        // assert we will NOT have a DiscriminatorPropertyName on the derived models
        assert(
            cat.DiscriminatorPropertyName === undefined,
            "Cat model should not have the discriminator property name"
        );
        // assert we will NOT have a property corresponding to the discriminator property on the derived models
        const catDiscriminatorProperty = cat.Properties.find(
            (p) => p.Name === pet.DiscriminatorPropertyName
        );
        assert(
            catDiscriminatorProperty === undefined,
            "Cat model should not have the discriminator property"
        );

        // verify derived model Dog
        const dog = modelMap.get("Dog");
        assert(dog !== undefined);
        assert(dog.DiscriminatorValue === "dog");
        assert(dog.BaseModel === pet);
        // assert we will NOT have a DiscriminatorPropertyName on the derived models
        assert(
            dog.DiscriminatorPropertyName === undefined,
            "Dog model should not have the discriminator property name"
        );
        // assert we will NOT have a property corresponding to the discriminator property on the derived models
        const dogDiscriminatorProperty = dog.Properties.find(
            (p) => p.Name === pet.DiscriminatorPropertyName
        );
        assert(
            dogDiscriminatorProperty === undefined,
            "Dog model should not have the discriminator property"
        );
    });
});
