import "@typespec/rest";
import "@typespec/http";
import "@typespec/versioning";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";
import "@typespec/versioning";

using TypeSpec.Http;
using Azure.ClientGenerator.Core;
using TypeSpec.Versioning;

@versioned(Versions)
@service(#{
    title: "This service does not define an endpoint. The generated code will add one."
})
namespace ParametersTypeSpec;

enum Versions {
    @useDependency(Azure.Core.Versions.v1_0_Preview_1)
    "2022-05-15-preview"
}

@route("/parameterOrders")
namespace ParameterOrders {
    model Result {
        id: string
    }

    @convenientAPI(true)
    op Operation(@query start: int32, @query end?: int32, @query("api-version") apiVersion: string): Result;

    @convenientAPI(true)
    @head
    op Operation2(@query start?: int32, @query end: int32): Result;
}
