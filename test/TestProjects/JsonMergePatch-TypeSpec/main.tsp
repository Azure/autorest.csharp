import "@typespec/http";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Versioning;
using Azure.Core;
using Azure.ClientGenerator.Core;

@doc("Test for merge-patch+json content-type")
@service({
    title: "Patch Service",
})
@versioned(Versions)
namespace Payload.JsonMergePatch;

enum Versions {
    @useDependency(Azure.Core.Versions.v1_0_Preview_1)
    v1_1: "v1.1"
  }

@doc("It is the model used by Resource model")
@access(Access.public)
@usage(Usage.input)
model IntValueModel extends BaseModel{
    requiredIntValue: int32;
    optionalIntValue?: int32;

    kind: BaseModelKind.intValue;
}

@doc("It is the model used by Resource model")
@access(Access.public)
@usage(Usage.input)
model StringValueModel extends BaseModel{
    requiredStringValue: string;
    optionalStringValue?: string;

    kind: BaseModelKind.string;
}

@doc("It is the model used by Resource model")
@access(Access.public)
@usage(Usage.input)
model ComplexModel {
    arrayOfInt?: int32[];
    arrayOfModel?: BaseModel[];
    arrayOfIntArray?: int32[][];
    arrayOfModelArray?: BaseModel[][];

    dictOfInt?: Record<int32>;
    dictOfModel?: Record<BaseModel>;
    dictOfIntDict?: Record<Record<int32>>;
    dictOfModelDict?: Record<Record<BaseModel>>;
}

@doc("Base model")
@discriminator("kind")
@access(Access.public)
@usage(Usage.input)
model BaseModel {
    requiredValue: unknown;
    optionalValue?: unknown;

    kind: BaseModelKind;
}

@access(Access.public)
@usage(Usage.input)
model NormalExtendedModel extends NormalBaseModel {
    extendedValue?: string;
}

@access(Access.public)
@usage(Usage.input)
model NormalBaseModel {
    normalValue?: string;
}

@doc("Type of base model")
enum BaseModelKind {
    @doc("The base model kind is an integer value")
    intValue,
    @doc("The base model kind is a string value")
    string
}

@doc("It is the model used by Resource model")
@route("/test")
op Hello(): void;
