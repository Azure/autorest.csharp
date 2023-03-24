import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using Azure.Core;

@service(
    {
        title: "EnumPropertiesBasicClient",
        version: "1.0.0"
    }
)
@server("http://localhost:3000", "TestServer endpoint")
@doc("Illustrates input models with required enum type properties.")

namespace TypeSpec.EnumPropertiesBasic;

@doc("The language to translate the input text into.")
@knownValues(TranslationLanguageValues)
scalar TranslationLanguage extends string;

@doc("The supported languages to translate input text into.")
enum TranslationLanguageValues
{
  @doc("Translate to English")
  English,
  
  @doc("Translate to Spanish")
  Spanish,
  
  @doc("Translate to Mandarin")
  Mandarin,

  // Value without @doc decorator, to test this case.
  Undocumented
}

@doc("Represents the days of the week using a standard, non-string enum.")
enum DayOfTheWeek {
  Monday,
  Tuesday,
  @doc("Wednesday is documented to test this case.")
  Wednesday,
  Thursday,
  Friday,
  Saturday,
  Sunday
}

@doc("Represents the days of the week using a standard, non-string enum.")
@fixed
enum FixedDayOfTheWeek {
  Monday,
  Tuesday,
  @doc("Wednesday is documented to test this case.")
  Wednesday,
  Thursday,
  Friday,
  Saturday,
  Sunday
}

@doc("Input model with enum properties.")
model InputModel {

  @doc("Required standard enum value.")
  Day : DayOfTheWeek;

  @doc("Required fixed enum value.")
  FixedDay : FixedDayOfTheWeek;
  // @doc("Required string enum value.")
  Language: TranslationLanguage;
  Title: EnumWithStringValue;
  // Grade: EnumWithNumberValue;
}

@doc("Represents the simple enum with enum string value.")
enum EnumWithStringValue {
  One: "1",
  Two: "2",
  Three: "3"
}

// @doc("Represents the simple enum with enum number value.")
// enum EnumWithNumberValue {
//   One: 1,
//   Two: 2,
//   Three: 3
// }

// @doc("Output model with enum properties")
// model OutputModel {

//   @doc("Required standard enum value.")
//   Day : DayOfTheWeek;

//   @doc("Required string enum value.")
//   Language: TranslationLanguage;
// }

// @doc("Round-trip model with enum properties")
// model RoundTripModel {

//   @doc("Required standard enum value.")
//   Day : DayOfTheWeek;

//   @doc("Required string enum value.")
//   Language: TranslationLanguage;
// }

@doc("ErrorResponse")
@error
model ErrorResponse {
  code: int32;
  message: string;
}

@route("/models")
@post
op sendEnumPropertyModel(@body input: InputModel): Response<200>|ErrorResponse ;

// @route("/models")
// @get
// op getEnumPropertModel(): OkResponse<OutputModel> |ErrorResponse;

// @route("/models")
// @put
// op setEnumPropertModel(@body input: RoundTripModel): OkResponse<RoundTripModel> | ErrorResponse;