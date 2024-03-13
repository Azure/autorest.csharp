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
model ExtendedModelSolution1 extends BaseModelSolution1 {
    extendedValue?: string;
}

@usage(Usage.input)
@access(Access.public)
model BaseModelSolution1 {
    baseValue?: string;
    baseDict?: Record<DummyModel>;
}

@usage(Usage.input)
@access(Access.public)
model NestedModelSolution1 {
    innerModel?: InnerModelSolution1;
}

@usage(Usage.input)
@access(Access.public)
model InnerModelSolution1 {
    property1?: int32;
    property2?: int32;
}

@usage(Usage.input)
@access(Access.public)
model DummyModel {
    property?: string;
}