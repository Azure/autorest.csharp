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

model PatchModel {
    requiredValue: string;
    optionalValue?: string;
}

@put
@convenientAPI(true)
op patch(@header contentType: "application/merge-patch+json", @body body: PatchModel): PatchModel;

@usage(Usage.input)
@access(Access.public)
model IntValueModel {
    requiredIntValue: int32;
    optionalIntValue?: int32;
}

@usage(Usage.input)
@access(Access.public)
model StringValueModel{
    requiredStringValue: string;
    optionalStringValue?: string;
}

@usage(Usage.input)
@access(Access.public)
model ExtendedModel extends BaseModel {
    extendedValue?: string;
}

@usage(Usage.input)
@access(Access.public)
model BaseModel {
    normalValue?: string;
}

@usage(Usage.input)
@access(Access.public)
model NestedModel {
    innerModel?: InnerModel;
}

@usage(Usage.input)
@access(Access.public)
model InnerModel {
    property1?: int32;
    property2?: int32;
}