import "@typespec/rest";
import "@typespec/http";

using TypeSpec.Http;

@service(
    {
        title: "HeadParameterClient",
        version: "1.0.0"
    }
)
@server("http://localhost:3000", "TestServer endpoint")
@doc("Illustrates clients generated from a Cadl with head parameter.")
namespace TypeSpec.HeadClient;

model Thing {
  @doc("name of the Thing")
  name: string;
}

@route("/head")
@get
op opWithHead(@body body: Thing, @header headParameter: string): void;

@route("/withContentTypehead")
@get
op opWithContentTypeHead(@body body: Thing, @header contentType: "text/plain"): void;