import "@typespec/rest";
import "@typespec/http";
import "@typespec/openapi";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

@service(
    {
        title: "Array Query and Header",
        version: "0.1.0"
    }
)
@doc("CADL project to test array as query or header.")
@server(
    "{CollectionFormatCadlUrl}",
    "Endpoint Service",
    {
        CollectionFormatCadlUrl: string,
    }
)
namespace ArrayAsQueryOrHeader;

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ClientGenerator.Core;
using Azure.Core;

model Thing {
    @doc("the object name.")
    name: string;
}

@get
@route("/csvQuery")
@convenientAPI(true)
op csvQuery(@query({format: "csv"}) options?: string[]): Thing;

@get
@route("/multiQuery")
@convenientAPI(true)
op multiQuery(@query({format: "multi"}) options?: string[]): Thing;

@get
@route("/noFormatQuery")
@convenientAPI(true)
op noFormatQuery(@query options?: string[]): Thing;

@get
@route("/csvHeader")
@convenientAPI(true)
op csvHeader(@header({format: "csv"}) options?: string[]): Thing;

@get
@route("/noFormatHeader")
@convenientAPI(true)
op noFormatHeader(@header options?: string[]): Thing;
