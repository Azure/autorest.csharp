import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-azure-core";

@service(
    {
        title: "Hello world",
        version: "0.1.0"
    }
)
namespace Demo.HelloWorld;

using TypeSpec.Http;
using Azure.Core;

@doc("Simple enum")
@fixed
enum SimpleEnum {
    One: "1",
    Two: "2",
    Four: "4"
}

@doc("Extensible enum Values")
enum ExtensibleEnum {
    One: "1",
    Two: "2",
    Four: "4"
}

// @doc("Extensible enum")
// @knownValues(ExtensibleEnumValues)
// model ExtensibleEnum is string {}

model Thing {
  @doc("name of the Thing")
  name: string;
}

model RoundTripModel {
  @doc("Required string, illustrating a reference type property.")
  requiredString: string;

  @doc("Required int, illustrating a value type property.")
  requiredInt: int32;

  @doc("Required collection of enums")
  requiredCollection: SimpleEnum[];

  @doc("Required dictionary of enums")
  requiredDictionary: Record<ExtensibleEnum>;
}

@doc("Hello world service")
@route("/hello")
namespace Hello.Demo {
    @doc("Return hi")
    @get
    op sayHi(): Thing;
}

namespace Hello.Demo2 {
    @route("/againHi")
    @doc("Return hi again")
    @get
    op helloAgain(@body action: RoundTripModel): Thing;

    @route("/demoHi")
    @doc("Return hi in demo2")
    @get
    op helloDemo2(): Thing;
}

@route("/top")
@doc("top level method")
@get
op topAction(@path @format("date") action: string): Thing;

@route("/top2")
@doc("top level method2")
@get
op topAction2(): Thing;

@route("/anonymousBody")
@doc("body parameter without body decorator")
@post
op anonymousBody( ...Thing ): Thing;
