import "@typespec/rest";
import "@typespec/http";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;
using Azure.Core;

// NOTE: These features are missing:
// - Security definition for apiKey

@server(
  "{Endpoint}/language",
  "Language Service",
  {
    Endpoint: Endpoint,
  }
)

@service(
    {
        title: "Microsoft Cognitive Language Service - Analyze Text Authoring",
        version: "2022-05-15-preview"
    }
)
@useDependency(Azure.Core.Versions.v1_0_Preview_1)
@route("/authoring/analyze-text/")
namespace LroOperation;

@doc("The endpoint to use.")
scalar Endpoint extends string;

// Model types
@resource("Pet")
model Pet {
  @key
  @visibility("read")
  name: string;
  tag?: string;

  @minValue(0)
  @maxValue(20)
  age: int32;
}

interface Projects {
    @doc("Creates a new pet or updates an existing one.")
    createOrUpdate is LongRunningResourceCreateOrUpdate<Pet>;
}