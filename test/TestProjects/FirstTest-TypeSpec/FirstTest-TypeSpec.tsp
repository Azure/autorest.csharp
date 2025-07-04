import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;
using Azure.Core;
using Azure.ClientGenerator.Core;
using Azure.ResourceManager;
using Azure.Core.Traits;

@versioned(Versions)
@service(#{
    title: "hello world"
})
@doc("This is a sample typespec project.")
@server(
    "{firstTestTypeSpecUrl}",
    "Endpoint Service",
    {
        firstTestTypeSpecUrl: string,
    }
)
@useAuth(
    OAuth2Auth<[AuthFlow]> | ApiKeyAuth<ApiKeyLocation.header, "x-ms-api-key">
)
namespace FirstTestTypeSpec;

@doc("The auth flow model")
model AuthFlow {
    type: OAuth2FlowType.clientCredentials;
    tokenUrl: "https://api.example.com/oauth2/token";
    refreshUrl: "https://api.example.com/oauth2/refresh";
    scopes: ["https://api.example.com/.default"];
}

enum Versions {
    @useDependency(Azure.Core.Versions.v1_0_Preview_1)
    "2022-05-15-preview"
  }

@doc("float fixed enum")
enum FloatFixedEnum {
    One: 1.1,
    Two: 2.2,
    Four: 4.4,
}

@doc("int fixed enum")
enum IntFixedEnum {
    One: 1,
    Two: 2,
    Four: 4,
}

@doc("Simple enum")
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

    @doc("required float property")
    requiredFloatProperty: float;

    @doc("optional float property")
    optionalFloatProperty?: float;

    @doc("optional arm id.")
    optionalResourceId?: Azure.Core.armResourceIdentifier<[]>;
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

    @doc("Required collection of enums")
    requiredCollection: StringFixedEnum[];

    @doc("Required dictionary of enums")
    requiredDictionary: Record<StringExtensibleEnum>;

    @doc("Required model")
    requiredModel: Thing;

    @doc("this is an int based extensible enum")
    intExtensibleEnum?: IntExtensibleEnum;

    @doc("this is a collection of int based extensible enum")
    intExtensibleEnumCollection?: IntExtensibleEnum[];

    @doc("this is a float based extensible enum")
    floatExtensibleEnum?: FloatExtensibleEnum;

    @doc("this is a collection of float based extensible enum")
    floatExtensibleEnumCollection?: FloatExtensibleEnum[];

    @doc("this is a float based fixed enum")
    floatFixedEnum?: FloatFixedEnum;

    @doc("this is a collection of float based fixed enum")
    floatFixedEnumCollection?: FloatFixedEnum[];

    @doc("this is a int based fixed enum")
    intFixedEnum?: IntFixedEnum;

    @doc("this is a collection of int based fixed enum")
    intFixedEnumCollection?: IntFixedEnum[];

    @doc("this is a string based fixed enum")
    stringFixedEnum?: StringFixedEnum;

    @doc("required unknown")
    requiredUnknown: unknown;

    @doc("optional unknown")
    optionalUnknown?: unknown;

    @doc("required record of unknown")
    requiredRecordUnknown: Record<unknown>;

    @doc("optional record of unknown")
    optionalRecordUnknown?: Record<unknown>;

    @doc("required readonly record of unknown")
    @visibility(Lifecycle.Read)
    readOnlyRequiredRecordUnknown: Record<unknown>;

    @doc("optional readonly record of unknown")
    @visibility(Lifecycle.Read)
    readOnlyOptionalRecordUnknown?: Record<unknown>;

    @doc("this is a model with required nullable properties")
    modelWithRequiredNullable: ModelWithRequiredNullableProperties;

    @doc("this is a list of union types")
    unionList: (string | int32 | ModelForUnion | ModelForUnion[])[];

    @doc("this is a record of unknown to be changed to BinaryData in customized code")
    binaryDataRecord?: Record<unknown>;
}

@doc("This is a model only used in union types, please do not use it anywhere else.")
model ModelForUnion {
    @doc("name of the ModelForUnion")
    name: string;

    @doc("age of the ModelForUnion")
    age?: int32;
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

@doc("Hello world service")
@route("/hello")
namespace Hello.Demo {
    @doc("Return hi")
    @get
    op sayHi(
        @header headParameter: string,
        @query queryParameter: string,
        @query optionalQuery?: string
    ): Thing;
}

namespace Hello.Demo2 {
    @route("/againHi")
    @doc("Return hi again")
    @get
    op helloAgain(
        @header p1: string,
        @body action: RoundTripModel,
        @header contentType: "text/plain",
        @path p2: string
    ): RoundTripModel;

    @route("/noContentType")
    @doc("Return hi again")
    @get
    op noContentType(
        @header p1: string,
        @body action: RoundTripModel,
        @path p2: string
    ): RoundTripModel;

    @route("/demoHi")
    @doc("Return hi in demo2")
    @get
    op helloDemoAgain(): Thing;

    @route("/literal")
    @doc("Create with literal value")
    @post
    op createLiteral(@body body: Thing): Thing;

    @route("/helloLiteral")
    @doc("Send literal parameters")
    @get
    op helloLiteral(@header p1: "test", @path p2: 123, @query p3: true): Thing;
}

model ListBody {
    @doc("Metric dimension filter ")
    filter?: string;
}

@route("/top")
@doc("top level method")
@get
op topAction(@path action: utcDateTime): Thing;

@route("/top2")
@doc("top level method2")
@get
op topAction2(): Thing;

@route("/patch")
@doc("top level patch")
@patch
op patchAction(@body body: Thing): Thing;

@route("/anonymousBody")
@doc("body parameter without body decorator")
@post
op anonymousBody(...Thing): Thing;

@route("/friendlyName")
@doc("Model can have its friendly name")
@post
op friendlyModel(...NotFriend): NotFriend;

@convenientAPI(false)
op addTimeHeader(
    @header("Repeatability-First-Sent") repeatabilityFirstSent?: utcDateTime
): void;

@route("/stringFormat")
@doc("paramete has string format.")
@post
op stringFormat(@path subscriptionId: uuid, @body body: ModelWithFormat): void;


@route("/projectedName")
@doc("Model can have its projected name")
@post
op projectedNameModel(...ModelWithProjectedName): ModelWithProjectedName;

@route("/retunsAnonymousModel")
@doc("return anonymous model")
@post
op returnsAnonymousModel(): {@body body: {}};

@summary("This is a list operation with an optional body.")
@doc("List the metric values for a load test run.")
@route("/listWithOptionalBody")
@post
op listWithOptionalBody is Azure.Core.Foundations.Operation<
  {
    @doc("Metric dimension filter ")
    @bodyRoot
    body?: ListBody;
  },
  Page<Thing>
>;

// TODO: https://github.com/Azure/typespec-azure/issues/509 
namespace EnumTest {
    @put
    @route("/unknown-value")
    @doc("get extensible enum")
    @convenientAPI(false)
    op createUnknownValue(@body input: DaysOfWeekExtensibleEnum): void;
}

namespace ProtocolAndConvenient {
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
}

@route("/headAsBoolean")
@doc("head as boolean.")
@head
op headAsBoolean(@path id: string): void;


@route("/stringBody")
@doc("The body parameter type is string.")
@put
op stringBody(@body body: string): void;


@route("/boolBody")
@doc("The body parameter type is bool.")
@put
op boolBody(@body body: boolean): void;


@route("/dateTimeBody")
@doc("The body parameter type is datetime.")
@put
op dateTimeBody(@body body: utcDateTime): void;


@route("/returnString")
@doc("The return type is datetime.")
@put
op returnString(): string;

@route("/returnUnknown")
@put
op returnUnknown(
): {
  @statusCode statusCode: 200;
  @body
  body: unknown;
};

interface Entity {
    @route("/entity/doSomething")
    @doc("doSomething for entity")
    @get
    op doSomething(@path p2: string): Thing;
}

interface Glossary {
    @route("/glossary/doSomething")
    @doc("doSomething for glossary")
    @get
    op doSomething(@path id: string, @header h1: string): Thing;
}

@doc("extension")
model Extension extends Element {
  level: int8;
}

@doc("element")
model Element {
  extension?: Extension[];
}

@route("/recursiveExtension")
@doc("test parent reference child")
@put
op recursiveExtension(@body input: Extension): void;

@doc("extension")
model ThereLevelExtension extends ThereLevelElement {
  level: int8;
}

@doc("element")
model ThereLevelElement {
  extension?: ThereLevelExtension[];
}
@doc("FHIR extendible element")
model Extendible {
  @doc("Additional Content defined by implementations")
  extension?: ThereLevelExtension[];
}

@route("/threeLevelRecursive")
@doc("test three level recursive extension")
@put
op threeLevelRecursive(@body input: Extendible): void;

@doc("parentModel")
model BaseModel {
    level: int8;
}

@doc("ChildModel")
model ChildModel extends BaseModel {
  parent: BaseModel[];
}

@route("/recursiveModels")
@doc("test child reference parent")
@put
op recursiveModels(@body input: ChildModel): void;


@doc("containSelf")
model ContainSelf{
  self: ContainSelf;
}

@route("/containSelfModels")
@doc("test contain self models")
@put
op ContainSelfModels(@body input: ContainSelf): void;


@doc("enum with projected name")
@clientName("CsProjectedEnum")
enum ProjectedEnum {
    @clientName("CsOne")
    One: 1.1,
    Two: 2.2,
    Four: 4.4,
}
@route("/enumParameter")
@doc("test enum parameter.")
@get
op enumParameter(@path p1: ProjectedEnum ): void;


@doc("enum with projected name used in a model")
@clientName("CsProjectedEnumInModel")
enum ProjectedEnumInModel {
    @clientName("CsOne")
    One: 1.1,
    Two: 2.2,
    Four: 4.4,
}

model ModelWithProjectedEnum {
    @doc("enum with projected name used in a model")
    enumProperty: ProjectedEnumInModel;
}

@route("/bodyIsModelWithProjectedEnum")
@doc("test enum parameter.")
@put
op bodyIsModelWithProjectedEnum(@body body: ModelWithProjectedEnum ): void;

@route("/optionalDictionary")
@doc("test optional dictionary.")
@put
op optionalDictionary(@body body?: Record<int32>): void;

model AzureLocationModel
{
    location: azureLocation;
}
@route("/azureLocation")
@doc("test optional dictionary.")
@put
op azureLocationOp(@query location: azureLocation, @header regenLocation: azureLocation, @body body?: AzureLocationModel): void;

// TODO: remove below after duplicated polling operation case is added into cadl-ranch
@resource("resources")
model Resource {
  @visibility(Lifecycle.Read)
  id: string;

  @key
  @visibility(Lifecycle.Read)
  name: string;

  type: string;
}

model ExportedResource {
  id: string;
  name: string;
}

model ExportParams {
  @query
  projectFileVersion?: string;
}
interface ResourceOperations
  extends Azure.Core.ResourceOperations<NoRepeatableRequests &
      NoConditionalRequests &
      NoClientRequestId> {}

@route("/lro")
interface VersioningOp {
  @pollingOperation(ResourceOperations.GetResourceOperationStatus<Resource, ExportedResource>)
  export is ResourceOperations.LongRunningResourceAction<Resource, ExportParams, ExportedResource>;

  @pollingOperation(ResourceOperations.GetResourceOperationStatus<Resource, ExportedResource>)
  exportW is ResourceOperations.LongRunningResourceAction<Resource, ExportParams, ExportedResource>;
}
