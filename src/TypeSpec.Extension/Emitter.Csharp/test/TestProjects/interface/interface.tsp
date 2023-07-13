import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using Azure.ClientGenerator.Core;

@service(
    {
        title: "MultiInterfaceClient",
        version: "1.0.0"
    }
)
@server("http://localhost:3000", "TestServer endpoint")
@doc("Illustrates clients generated from a TypeSpec with multiple interfaces.")
namespace TypeSpec.TestServer.MultiInterfaceClient;

@doc("Simple model.")
model Dog {
  @doc("Name")
  name: string;
}

@doc("Simple model.")
model Cat {
  @doc("Name")
  name: string;
}

@route("/dogs")
interface dogs {
  @doc("Illustrate grouping operations on subclient.")
  @get
  @convenientAPI(true)
  getDogsConvenient(): Dog;

  @doc("Illustrate grouping operations on subclient.")
  @route("/models")
  @put
  setDogs(@body input: Dog): Dog;
}

@route("/cats")
interface cats {
  @doc("Illustrate grouping operations on subclient.")
  @get
  getCats(): Cat;

  @doc("Illustrate grouping operations on subclient.")
  @put
  setCats(@body input: Cat): Cat;
}
