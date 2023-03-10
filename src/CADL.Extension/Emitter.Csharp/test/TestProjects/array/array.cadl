import "@typespec/rest";
import "@typespec/http";

using TypeSpec.Http;

@service(
    {
        title: "ArrayBasicClient",
        version: "1.0.0"
    }
)
@server("http://localhost:3000", "TestServer endpoint")
@doc("Illustrates input, output, and round-trip models with required enum type properties.")

namespace TypeSpec.TestServer.ArrayBasic;

// Model types
model Pet {
  name: string;
  tag?: string;
  age: int32;
}

@doc("Error")
@error
model Error {
  code: int32;
  message: string;
}

@doc("Manage your pets. You can delete or get the Pet from pet store.")
@summary("Manage your pets.")
@route("/pets")
@doc("List pets.")
op list(@query nextLink?: string): Pet[] | Error;
