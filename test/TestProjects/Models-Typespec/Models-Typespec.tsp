import "@typespec/rest";
import "@typespec/http";
import "@typespec/openapi";
import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";

@service(
    {
        title: "Models in CADL",
        version: "0.1.0"
    }
)
@server(
    "{endpoint}",
    "Endpoint Service",
    {
        endpoint: string,
    }
)
@doc("CADL project to test various types of models.")
namespace ModelsInCadl;

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ClientGenerator.Core;
using Azure.Core;

@doc("Base model")
model BaseModel {
  @doc("Optional property on base")
  optionalPropertyOnBase?: string;
}

@doc("Derived model")
model DerivedModel extends BaseModel {
  @doc("Required collection")
  requiredCollection: CollectionItem[];
}

@discriminator("discriminatorProperty")
@doc("Base model with discriminator property.")
model BaseModelWithDiscriminator {
  @doc("Optional property on base")
  optionalPropertyOnBase?: string;

  @doc("Required property on base")
  requiredPropertyOnBase: int32;
}

@doc("Deriver model with discriminator property.")
model DerivedModelWithDiscriminatorA extends BaseModelWithDiscriminator {
  discriminatorProperty: "A";

  @doc("Required string.")
  requiredString: string;
}

@doc("Deriver model with discriminator property.")
model DerivedModelWithDiscriminatorB extends BaseModelWithDiscriminator {
  discriminatorProperty: "B";

  @doc("Required int.")
  requiredInt: int32;
}


@doc("Collection item model")
model CollectionItem {
    @doc("Required model record")
    requiredModelRecord: Record<RecordItem>;
}

@doc("Record item model")
model RecordItem extends DerivedModel {
    
}

@doc("Fixed string enum")
@fixed
enum FixedStringEnum {
    One: "1",
    Two: "2",
    Four: "4"
}

@doc("Fixed int enum")
@fixed
@deprecated("deprecated for test")
enum FixedIntEnum {
    One: 1,
    Two: 2,
    Four: 4
}

// @doc("Fixed float enum")
// enum FixedFloatEnum {
//     One: 1.1,
//     Two: 2.1,
//     Four: 4.0
// }

@doc("Extensible enum")
@deprecated("deprecated for test")
enum ExtensibleEnum {
    One: "1",
    Two: "2",
    Four: "4"
}

@doc("Model used both as input and output")
model RoundTripModel extends BaseModel {
  @doc("Required string, illustrating a reference type property.")
  requiredString: string;

  @doc("Required int, illustrating a value type property.")
  requiredInt: int32;

  @doc("Required model with discriminator")
  requiredModel: BaseModelWithDiscriminator;

  @doc("Required fixed string enum")
  requiredFixedStringEnum: FixedStringEnum;

  @doc("Required fixed int enum")
  requiredFixedIntEnum: FixedIntEnum;

//   @doc("Required fixed float enum")
//   requiredFixedFloatEnum: FixedFloatEnum;

  @doc("Required extensible enum")
  requiredExtensibleEnum: ExtensibleEnum;

  @doc("Required collection")
  requiredCollection: CollectionItem[];

  @doc("Required int record")
  requiredIntRecord: Record<int32>;

  @doc("Required string record")
  requiredStringRecord: Record<string>;

  @doc("Required Model Record")
  requiredModelRecord: Record<RecordItem>;
}

@doc("Model used both as input and output with primitive types")
model RoundTripPrimitiveModel extends BaseModel {
  @doc("Required string, illustrating a reference type property.")
  requiredString: string;

  @doc("Required int, illustrating a value type property.")
  requiredInt: int32;

  @doc("Required int64, illustrating a value type property.")
  requiredInt64: int64;

  @doc("Required safeint, illustrating a value type property.")
  requiredSafeInt: safeint;

  @doc("Required float, illustrating a value type property.")
  requiredFloat: float32;

  @doc("Required double, illustrating a value type property.")
  required_Double: float64;

  @doc("Required bolean, illustrating a value type property.")
  requiredBoolean: boolean;

  @doc("Required date time offset, illustrating a reference type property.")
  requiredDateTimeOffset: zonedDateTime;

  @doc("Required time span, illustrating a value type property.")
  requiredTimeSpan: duration;

  @doc("Required collection of which the element is a nullable float")
  requiredCollectionWithNullableFloatElement: (float32 | null) [];
}

@doc("Model used only as input")
model InputModel {
  @doc("Required string")
  requiredString: string;

  @doc("Required int")
  requiredInt: int32;

  @doc("Required model")
  requiredModel: BaseModel;

  @doc("Required primitive value type collection")
  requiredIntCollection: int32[];

  @doc("Required primitive reference type collection")
  requiredStringCollection: string[];

  @doc("Required model collection")
  requiredModelCollection: CollectionItem[];

  @doc("Required model record")
  requiredModelRecord: Record<RecordItem>;

  @doc("Required collection of which the element is a nullable float")
  requiredCollectionWithNullableFloatElement: (null | float32) [];

  @doc("Required collection of which the element is a nullable boolean")
  requiredCollectionWithNullableBooleanElement: (boolean | null) [];
}

@doc("Model used only as output")
model OutputModel {
  @doc("Required string")
  requiredString: string;

  @doc("Required int")
  requiredInt: int32;

  @doc("Required model")
  requiredModel: DerivedModel;

  @doc("Required collection")
  requiredCollection: CollectionItem[];

  @doc("Required model record")
  requiredModelRecord: Record<RecordItem>;
}

@doc("RoundTrip model with optional properties.")
@deprecated("deprecated for test")
model RoundTripOptionalModel {
  @doc("Optional string, illustrating an optional reference type property.")
  optionalString?: string;

  @doc("Optional int, illustrating an optional value type property.")
  optionalInt?: int32;

  @doc("Optional string collection.")
  optionalStringList?: string[];

  @doc("Optional int collection.")
  optionalIntList?: int32[];

  @doc("Optional model collection")
  optionalModelCollection?: CollectionItem[];

  @doc("Optional model.")
  optionalModel?: DerivedModel;

  @doc("Optional fixed string enum")
  optionalFixedStringEnum?: FixedStringEnum;

  @doc("Optional extensible enum")
  optionalExtensibleEnum?: ExtensibleEnum;

  @doc("Optional int record")
  optionalIntRecord?: Record<int32>;

  @doc("Optional string record")
  optionalStringRecord?: Record<string>;

  @doc("Optional model record")
  optionalModelRecord?: Record<RecordItem>;

  @doc("Optional plainDate")
  optionalPlainDate?: plainDate;

  @doc("Optional plainTime")
  optionalPlainTime?: plainTime;

  @doc("Optional collection of which the element is a nullable int")
  optionalCollectionWithNullableIntElement?: (int32 | null) [];
}

@doc("Output model with readonly properties.")
model RoundTripReadOnlyModel {
  @doc("Required string, illustrating a readonly reference type property.")
  @visibility("read")
  requiredReadonlyString: string;

  @doc("Required int, illustrating a readonly value type property.")
  @visibility("read")
  requiredReadonlyInt: int32;

  @doc("Optional string, illustrating a readonly reference type property.")
  @visibility("read")
  optionalReadonlyString?: string;

  @doc("Optional int, illustrating a readonly value type property.")
  @visibility("read")
  optionalReadonlyInt?: int32;

  @doc("Required readonly model.")
  @visibility("read")
  requiredReadonlyModel: DerivedModel;

  @doc("Optional readonly model.")
  @visibility("read")
  optionalReadonlyModel?: DerivedModel;

  @doc("Required readonly fixed string enum")
  @visibility("read")
  requiredReadonlyFixedStringEnum: FixedStringEnum;

  @doc("Required readonly extensible enum")
  @visibility("read")
  requiredReadonlyExtensibleEnum: ExtensibleEnum;

  @doc("Optional readonly fixed string enum")
  @visibility("read")
  optionalReadonlyFixedStringEnum: FixedStringEnum;

  @doc("Optional readonly extensible enum")
  @visibility("read")
  optionalReadonlyExtensibleEnum: ExtensibleEnum;

  @doc("Required readonly string collection.")
  @visibility("read")
  requiredReadonlyStringList: string[];

  @doc("Required readonly int collection.")
  @visibility("read")
  requiredReadonlyIntList: int32[];

  @doc("Required model collection")
  @visibility("read")
  requiredReadOnlyModelCollection: CollectionItem[];

  @doc("Required int record")
  @visibility("read")
  requiredReadOnlyIntRecord: Record<int32>;

  @doc("Required string record")
  @visibility("read")
  requiredStringRecord: Record<string>;

  @doc("Required model record")
  @visibility("read")
  requiredReadOnlyModelRecord: Record<RecordItem>;

  @doc("Optional readonly string collection.")
  @visibility("read")
  optionalReadonlyStringList?: string[];

  @doc("Optional readonly int collection.")
  @visibility("read")
  optionalReadonlyIntList?: int32[];

  @doc("Optional model collection")
  @visibility("read")
  optionalReadOnlyModelCollection?: CollectionItem[];

  @doc("Optional int record")
  optionalReadOnlyIntRecord: Record<int32>;

  @doc("Optional string record")
  optionalReadOnlyStringRecord: Record<string>;

  @doc("Optional model record")
  @visibility("read")
  optionalModelRecord?: Record<RecordItem>;

  @doc("Required collection of which the element is a nullable int")
  requiredCollectionWithNullableIntElement: (null | int32) [];

  @doc("Optional collection of which the element is a nullable boolean")
  optionalCollectionWithNullableBooleanElement?: (boolean | null) [];
}

@doc("Output model that has property of its own type")
model ErrorModel {
  @doc("Error message")
  @visibility("read")
  message: string;

  @doc("Required Record")
  @visibility("read")
  innerError?: ErrorModel;
}

@doc("Input model that has property of its own type")
model InputRecursiveModel {
  @doc("Message")
  message: string;

  @doc("Required Record")
  inner?: InputRecursiveModel;
}

@doc("Roundtrip model that has property of its own type")
model RoundTripRecursiveModel {
  @doc("Message")
  message: string;

  @doc("Required Record")
  inner?: RoundTripRecursiveModel;
}

@doc("Input model that has property of its own type")
@route("/inputToRoundTrip")
@doc("Input to RoundTrip")
@get
@convenientAPI(true)
op inputToRoundTrip(@body input: InputModel): RoundTripModel;

@route("/inputToRoundTripPrimitive")
@doc("Input to RoundTripPrimitive")
@get
@convenientAPI(true)
op inputToRoundTripPrimitive(@body input: InputModel): RoundTripPrimitiveModel;

@route("/inputToRoundTripOptional")
@doc("Input to RoundTripOptional")
@get
@convenientAPI(true)
op inputToRoundTripOptional(@body input: RoundTripOptionalModel): RoundTripOptionalModel;

@route("/inputToRoundTripReadOnly")
@doc("Input to RoundTripReadOnly")
@get
@convenientAPI(true)
@deprecated("deprecated for test")
op inputToRoundTripReadOnly(@body input: InputModel): RoundTripReadOnlyModel;

@route("/roundTripToOutput")
@doc("RoundTrip to Output")
@get
@convenientAPI(true)
op roundTripToOutput(@body input: RoundTripModel): OutputModel;

@route("/inputRecursive")
@doc("Input recursive model")
@post
@convenientAPI(true)
op InputRecursive(@body input: InputRecursiveModel): Response<200>|ErrorModel;

@route("/roundTripRecursive")
@doc("RoundTrip recursive model")
@put
@convenientAPI(true)
op roundTripRecursive(@body input: RoundTripRecursiveModel): RoundTripRecursiveModel;

@route("/selfReference")
@doc("Returns model that has property of its own type")
@get
@convenientAPI(true)
op selfReference(): ErrorModel;

@doc("Base model")
model NoUseBase {
  @doc("base model property")
  baseModelProp: string;
}

@doc("Derived model")
model RoundTripOnNoUse extends NoUseBase {
  @doc("Required collection")
  requiredCollection: CollectionItem[];
}

@doc("Returns RoundTripOnNoUse")
@get
@convenientAPI(true)
op roundTripToOutputWithNoUseBase(@body input: RoundTripOnNoUse): RoundTripOnNoUse;
