import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

@service(
    {
        title: "ConfidentLevels in CADL",
        version: "0.1.0"
    }
)
@server(
    "{host}",
    "Endpoint Service",
    {
        host: string,
    }
)
@doc("CADL project to test various types of models.")
namespace ConfidentLevelsInTsp;

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ClientGenerator.Core;
using Azure.Core;

@doc("This is a model with union types")
model ModelWithUnionProperty {
    @doc("This is a union property")
    unionProperty: string | int32;
}

@doc("This is another model with union types")
model AnotherModelWithUnionProperty {
    @doc("This is a union property")
    unionProperty: string | string[];
}

@doc("This is a model without union types")
model UsualModel {
    @doc("The name")
    name: string;

    @doc("The age")
    age: int32;

    @doc("The size")
    size?: float64;
}

@doc("This is an operation that uses a model with union types in request body")
@route("/unions/properties/requests")
@convenientAPI(true)
op unionInRequestProperty(@body body: ModelWithUnionProperty): void;

@doc("This is an operation that uses a model with union types as response body")
@route("/unions/properties/responses")
@convenientAPI(true)
op unionInResponseProperty(@body body: UsualModel): AnotherModelWithUnionProperty;

@doc("Non-confident model that contains self reference")
model NonConfidentModelWithSelfReference {
    @doc("The name")
    name: string;
    @doc("The self reference")
    selfReference: NonConfidentModelWithSelfReference[];
    @doc("The non-confident part")
    unionProperty: string | int32[]; // put a union here so that it is not confident any more
}

@doc("This is an operation that uses a model with union types and self reference in request body")
@route("/unions/properties/requests/selfReferences")
@convenientAPI(true)
op unionWithSelfReference(@body input: NonConfidentModelWithSelfReference): void;

@doc("The model that contains self reference")
model NonConfidentModelWithIndirectSelfReference {
    @doc("The name")
    name: string;
    @doc("The self reference")
    reference?: IndirectSelfReferenceModel[];
}

@doc("Indirect self reference model")
model IndirectSelfReferenceModel {
    @doc("Something not important")
    something: string;
    @doc("Reference back")
    reference?: NonConfidentModelWithSelfReference;
    @doc("The non-confident part")
    unionProperty: string | int32[]; // put a union here so that it is not confident any more
}

@doc("This is an operation that uses a model with union types and indirect self reference in request body")
@route("/unions/properties/requests/indirectSelfReferences")
@convenientAPI(true)
op unionWithInderict(@body input: NonConfidentModelWithIndirectSelfReference): void;

@doc("This is a model with a property of literal type of numbers")
model ModelWithIntegerLiteralTypeProperty {
    @doc("The name")
    name: string;
    @doc("The id")
    id: 1;
}

@doc("This is a model with a property of literal type of numbers")
model ModelWithFloatLiteralTypeProperty {
    @doc("The name")
    name: string;
    @doc("The id")
    id: 3.141592;
}

@doc("This is an operation that uses a model with a property of literal type of numbers in request body")
@route("/literals/integers/requests")
@convenientAPI(true)
op literalOfInteger(@body input: ModelWithIntegerLiteralTypeProperty): void;
@doc("This is an operation that uses a model with a property of literal type of numbers in request body")
@route("/literals/floats/requests")
@convenientAPI(true)
op literalOfFloat(@body input: ModelWithFloatLiteralTypeProperty): void;

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

@doc("This is an operation that uses a model with discriminator in request body, this operation should be confident")
@route("/unions/properties/requests/discriminator")
@convenientAPI(true)
op confidentOperationWithDiscriminator(@body input: Pet): Pet;

@doc("The base Pet model polluted by union in derived type")
@discriminator("kind")
model PollutedPet {
    @doc("The name of the pet")
    name: string;
}
@doc("The dog with a union type")
model PollutedDog extends PollutedPet {
    kind: "dog";
    @doc("Woof")
    woof: string;
    @doc("Color, could be specified by a string or by an array of int as RGB")
    color: string | int32[];
}
@doc("The cat without a union type")
model UnpollutedCat extends PollutedPet {
    kind: "cat";
    @doc("Meow")
    meow: string;
}

@doc("This is an operation that uses the base type with a discriminator, but this operation is low confident because one of the derived type from the discriminated types has union types on it")
@route("/unions/properties/requests/discriminator/pollutedBase")
@convenientAPI(true)
op pollutedBaseMethod(@body input: PollutedPet): PollutedPet;
@doc("This is an operation that uses the model with a union type directly therefore this operation is not confident")
@route("/unions/properties/requests/discriminator/unpollutedDerived")
@convenientAPI(true)
op pollutedDerivedMethod(@body input: PollutedDog): PollutedDog;
@doc("This is an operation that is not using the model with a union type directly but since the base type is not confident and we would like it to be low confident, therefore this must be made internal as well")
@route("/unions/properties/requests/discriminator/pollutedDerived")
@convenientAPI(true)
op unpollutedDerivedMethod(@body input: UnpollutedCat): UnpollutedCat;
