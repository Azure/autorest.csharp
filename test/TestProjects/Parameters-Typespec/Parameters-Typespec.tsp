import "@typespec/rest";
import "@typespec/http";
import "@typespec/versioning";
import "@typespec/openapi";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using Azure.ClientGenerator.Core;

@service(
    {
        title: "Text authoring",
        version: "2022-05-15-preview"
    }
)
namespace ParametersCadl;


@route("/parameterOrders")
namespace ParameterOrders {
    model Result {
        id: string
    }

    @convenientAPI(true)
    op Operation(@query start: int32, @query end?: int32): Result;

    @convenientAPI(true)
    @head
    op Operation2(@query start?: int32, @query end: int32): Result;
}
