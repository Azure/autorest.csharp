import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Versioning;
using Azure.ClientGenerator.Core;
using Azure.Core;

@versioned(Versions)
@service(#{
    title: "hello world"
})
@doc("This is a sample typespec project.")
@server(
    "{unbrandedTypeSpecUrl}",
    "Endpoint Service",
    {
        unbrandedTypeSpecUrl: string,
    }
)
@useAuth(
    ApiKeyAuth<ApiKeyLocation.header, "my-api-key">
)
namespace CustomizedTypeSpec;

enum Versions {
    @useDependency(Azure.Core.Versions.v1_0_Preview_1)
    "2022-05-15-preview"
}

@doc("float fixed enum")
@fixed
enum FloatFixedEnum {
    One: 1.1,
    Two: 2.2,
    Four: 4.4,
}

@doc("int fixed enum")
@fixed
enum IntFixedEnum {
    One: 1,
    Two: 2,
    Four: 4,
}

@doc("Simple enum")
@fixed
enum StringFixedEnum {
    One: "1",
    Two: "2",
    Four: "4",
}

@doc("Int based extensible enum")
union IntExtensibleEnum {
    int32,
    One: 1,
    Two: 2,
    Four: 4,
}

@doc("Float based extensible enum")
union FloatExtensibleEnum {
    float32,
    One: 1.0,
    Two: 2.0,
    Four: 4.0,
}

@doc("Extensible enum")
union StringExtensibleEnum {
    string,
    One: "1",
    Two: "2",
    Four: "4",
}

@doc("A model with a few properties of literal types")
model Thing {
    @doc("name of the Thing")
    name: string;

    @doc("required Union")
    requiredUnion: string | string[] | int32;

    @doc("required literal string")
    requiredLiteralString: "accept";

    @doc("required literal int")
    requiredLiteralInt: 123;

    @doc("required literal float")
    requiredLiteralFloat: 1.23;

    @doc("required literal bool")
    requiredLiteralBool: false;

    @doc("optional literal string")
    optionalLiteralString?: "reject";

    @doc("optional literal int")
    optionalLiteralInt?: 456;

    @doc("optional literal float")
    optionalLiteralFloat?: 4.56;

    @doc("optional literal bool")
    optionalLiteralBool?: true;

    @doc("description with xml <|endoftext|>")
    requiredBadDescription: string;

    @doc("optional nullable collection")
    optionalNullableList?: int32[] | null;

    @doc("required nullable collection")
    requiredNullableList: int32[] | null;
}

@doc("A model with a few required nullable properties")
model ModelWithRequiredNullableProperties {
    @doc("required nullable primitive type")
    requiredNullablePrimitive: int32 | null;

    @doc("required nullable extensible enum type")
    requiredExtensibleEnum: StringExtensibleEnum | null;

    @doc("required nullable fixed enum type")
    requiredFixedEnum: StringFixedEnum | null;
}

@doc("this is not a friendly model but with a friendly name")
@friendlyName("Friend")
model NotFriend {
    @doc("name of the NotFriend")
    name: string;

    format?: ModelWithFormat;
}

@doc("this is a model with a projected name")
@clientName("ProjectedModel")
model ModelWithProjectedName {
    @doc("name of the ModelWithProjectedName")
    name: string;
}

@doc("this is a roundtrip model")
model RoundTripModel {
    @doc("Required string, illustrating a reference type property.")
    requiredString: string;

    @doc("Required int, illustrating a value type property.")
    requiredInt: int32;

    @doc("Required readonly int")
    @visibility(Lifecycle.Read)
    requiredReadonlyInt: int32;
}

union DaysOfWeekExtensibleEnum {
    string,
    Monday: "Monday",
    Tuesday: "Tuesday",
    Wednesday: "Wednesday",
    Thursday: "Thursday",
    Friday: "Friday",
    Saturday: "Saturday",
    Sunday: "Sunday",
}

model ModelWithFormat {
    @doc("url format")
    sourceUrl: url;

    @doc("uuid format")
    guid: uuid;
}

@route("/hello")
@doc("Return hi")
@get
op sayHi(
    @header headParameter: string,
    @query queryParameter: string,
    @query optionalQuery?: string
): Thing;

@route("/againHi")
@doc("Return hi again")
@get
@convenientAPI(true)
op helloAgain(
    @header p1: string,
    @body action: RoundTripModel,
    @header contentType: "text/plain",
    @path p2: string
): RoundTripModel;

@route("/noContentType")
@doc("Return hi again")
@get
@convenientAPI(false)
op noContentType(
    @header p1: string,
    @body action: RoundTripModel,
    @path p2: string
): RoundTripModel;

@route("/demoHi")
@doc("Return hi in demo2")
@get
@convenientAPI(true)
op helloDemo2(): Thing;

@route("/literal")
@doc("Create with literal value")
@post
@convenientAPI(true)
op createLiteral(@body body: Thing): Thing;

@route("/helloLiteral")
@doc("Send literal parameters")
@get
@convenientAPI(true)
op helloLiteral(@header p1: "test", @path p2: 123, @query p3: true): Thing;

@route("/top")
@doc("top level method")
@get
@convenientAPI(true)
op topAction(@path action: utcDateTime): Thing;

@route("/top2")
@doc("top level method2")
@get
@convenientAPI(false)
op topAction2(): Thing;

@route("/patch")
@doc("top level patch")
@patch
@convenientAPI(true)
op patchAction(@body body: Thing): Thing;

@route("/anonymousBody")
@doc("body parameter without body decorator")
@post
@convenientAPI(true)
op anonymousBody(...Thing): Thing;

@route("/friendlyName")
@doc("Model can have its friendly name")
@post
@convenientAPI(true)
op friendlyModel(...NotFriend): NotFriend;

op addTimeHeader(
    @header("Repeatability-First-Sent") repeatabilityFirstSent?: utcDateTime 
): void;

@route("/projectedName")
@doc("Model can have its projected name")
@post
@convenientAPI(true)
op projectedNameModel(...ModelWithProjectedName): ModelWithProjectedName;

@route("/returnsAnonymousModel")
@doc("return anonymous model")
@post
@convenientAPI(true)
op returnsAnonymousModel(): {@body body:{}};

@get
@route("/unknown-value")
@doc("get extensible enum")
op getUnknownValue(): DaysOfWeekExtensibleEnum;

@doc("When set protocol false and convenient true, then the protocol method should be internal")
@route("internalProtocol")
@post
@convenientAPI(true)
@protocolAPI(false)
op internalProtocol(@body body: Thing): Thing;

@doc("When set protocol false and convenient true, the convenient method should be generated even it has the same signature as protocol one")
@route("stillConvenient")
@get
@convenientAPI(true)
@protocolAPI(false)
op stillConvenient(): void;

@route("/headAsBoolean")
@doc("head as boolean.")
@head
@convenientAPI(true)
op headAsBoolean(@path id: string): void;
