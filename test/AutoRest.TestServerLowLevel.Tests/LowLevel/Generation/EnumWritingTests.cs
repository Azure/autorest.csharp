﻿using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using NUnit.Framework;

namespace AutoRest.CSharp.Generation.Writers.Tests
{
    public class EnumWritingTests : ModelGenerationTestBase
    {
        [TestCaseSource(nameof(ExtensibleEnumCase))]
        public void ExtensibleEnums(string expectedModelCodes)
        {
            var enumType = new EnumType(ExtensibleEnumType,
                    "Cadl.TestServer.EnumPropertiesBasic", "public",
                    CadlTypeFactory, null
                );
            ValidateGeneratedCodes(enumType, expectedModelCodes, "");
        }

        [TestCaseSource(nameof(FixedEnumCase))]
        public void FixedEnums(string expectedModelCodes, string expectedSerializationCodes)
        {
            // see cadl definition: https://github.com/Azure/cadl-ranch/blob/c4f41f483eac812527f7b6dc837bd22d255a18ed/packages/cadl-ranch-specs/http/models/enum-properties/main.cadl#L35-L45
            var enumType = new EnumType(FixedEnumType,
                "Cadl.TestServer.EnumPropertiesBasic", "public",
                CadlTypeFactory, null
            );
            ValidateGeneratedCodes(enumType, expectedModelCodes, expectedSerializationCodes);
        }

        [TestCaseSource(nameof(RoundTripEnumPropertiesCase))]
        public void RoundTripEnumProperties(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/c4f41f483eac812527f7b6dc837bd22d255a18ed/packages/cadl-ranch-specs/http/models/enum-properties/main.cadl#L67-L75
            var modelType = new InputModelType("RoundTripModel", "Cadl.TestServer.EnumPropertiesBasic", "public", null, null, "Round-trip model with enum properties", InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                    new List<InputModelProperty>{
                        new InputModelProperty("Day", "Day", string.Empty, "Required standard enum value.", FixedEnumType, null, true, false, false),
                        new InputModelProperty("Language", "Language", string.Empty, "Required string enum value.", ExtensibleEnumType, null, true, false, false)
                    },
                    null, new List<InputModelType>(), null, null, null, null);
            var library = new DpgOutputLibraryBuilder(new InputNamespace("Cadl.TestServer.EnumPropertiesBasic", [], [], [FixedEnumType, ExtensibleEnumType], [modelType], [], new InputAuth()), default).Build(true);

            ValidateGeneratedCodes("RoundTripModel", expectedModelCodes, expectedSerializationCodes, library);
        }

        [TestCaseSource(nameof(InputEnumPropertiesCase))]
        public void InputEnumProperties(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/c4f41f483eac812527f7b6dc837bd22d255a18ed/packages/cadl-ranch-specs/http/models/enum-properties/main.cadl#L47-L55
            var modelType = new InputModelType("InputModel", "Cadl.TestServer.EnumPropertiesBasic", "public", null, null, "Input model with enum properties", InputModelTypeUsage.Input,
                    new List<InputModelProperty>{
                        new InputModelProperty("Day", "Day", string.Empty, "Required standard enum value.", FixedEnumType, null, true, false, false),
                        new InputModelProperty("Language", "Language", string.Empty, "Required string enum value.", ExtensibleEnumType, null, true, false, false)
                    },
                    null, new List<InputModelType>(), null, null, null, null);
            var library = new DpgOutputLibraryBuilder(new InputNamespace("Cadl.TestServer.EnumPropertiesBasic", [], [], [FixedEnumType, ExtensibleEnumType], [modelType], [], new InputAuth()), default).Build(true);

            ValidateGeneratedCodes("InputModel", expectedModelCodes, expectedSerializationCodes, library);
        }

        [TestCaseSource(nameof(OutputEnumPropertiesCase))]
        public void OutputEnumProperties(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/c4f41f483eac812527f7b6dc837bd22d255a18ed/packages/cadl-ranch-specs/http/models/enum-properties/main.cadl#L57-L65
            var modelType = new InputModelType("OutputModel", "Cadl.TestServer.EnumPropertiesBasic", "public", null, null, "Output model with enum properties", InputModelTypeUsage.Output,
                    new List<InputModelProperty>{
                        new InputModelProperty("Day", "Day", string.Empty, "Required standard enum value.", FixedEnumType, null, true, false, false),
                        new InputModelProperty("Language", "Language", string.Empty, "Required string enum value.", ExtensibleEnumType, null, true, false, false)
                    },
                    null, new List<InputModelType>(), null, null, null, null);
            var library = new DpgOutputLibraryBuilder(new InputNamespace("Cadl.TestServer.EnumPropertiesBasic", [], [], [FixedEnumType, ExtensibleEnumType], [modelType], new List<InputClient>(), new InputAuth()), default).Build(true);

            ValidateGeneratedCodes("OutputModel", expectedModelCodes, expectedSerializationCodes, library);
        }

        private void ValidateGeneratedCodes(EnumType enumType, string modelCodes, string serializationCodes)
        {
            ValidateGeneratedModelCodes(enumType, modelCodes);
            ValidateGeneratedSerializationCodes(enumType, serializationCodes);
        }

        private void ValidateGeneratedModelCodes(EnumType enumType, string expected)
        {
            var codeWriter = new CodeWriter();
            new ModelWriter().WriteModel(codeWriter, enumType);
            var codes = codeWriter.ToString();
            Assert.AreEqual(expected, codes);
        }

        private void ValidateGeneratedSerializationCodes(EnumType enumType, string expected)
        {
            var codeWriter = new CodeWriter();
            new SerializationWriter().WriteSerialization(codeWriter, enumType);
            var codes = codeWriter.ToString();
            Assert.AreEqual(expected, codes);
        }

        static EnumWritingTests()
        {
            var extensibleEnumValues = new List<InputEnumTypeValue>();
            ExtensibleEnumType = new InputEnumType("TranslationLanguageValues", "Cadl.TestServer.EnumPropertiesBasic", "public", null, null, "The supported languages to translate input text into.", InputModelTypeUsage.Input | InputModelTypeUsage.Output, InputPrimitiveType.String, extensibleEnumValues, true);
            extensibleEnumValues.Add(new("English", "English", InputPrimitiveType.String, ExtensibleEnumType, null, "Translate to English"));
            extensibleEnumValues.Add(new("Spanish", "Spanish", InputPrimitiveType.String, ExtensibleEnumType, null, "Translate to Spanish"));
            extensibleEnumValues.Add(new("Mandarin", "Mandarin", InputPrimitiveType.String, ExtensibleEnumType, null, "Translate to Mandarin"));
            extensibleEnumValues.Add(new("Undocumented", "Undocumented", InputPrimitiveType.String, ExtensibleEnumType, null, null));
            var fixedEnumValues = new List<InputEnumTypeValue>();
            FixedEnumType = new InputEnumType("DayOfTheWeek", "Cadl.TestServer.EnumPropertiesBasic", "public", null, null, "Represents the days of the week using a standard, non-string enum.", InputModelTypeUsage.Input | InputModelTypeUsage.Output, InputPrimitiveType.String, fixedEnumValues, false);
            fixedEnumValues.Add(new("Monday", "Monday", InputPrimitiveType.String, FixedEnumType, null, null));
            fixedEnumValues.Add(new("Tuesday", "Tuesday", InputPrimitiveType.String, FixedEnumType, null, null));
            fixedEnumValues.Add(new("Wednesday", "Wednesday", InputPrimitiveType.String, FixedEnumType, null, null));
            fixedEnumValues.Add(new("Thursday", "Thursday", InputPrimitiveType.String, FixedEnumType, null, "Wednesday is documented to test this case."));
            fixedEnumValues.Add(new("Friday", "Friday", InputPrimitiveType.String, FixedEnumType, null, null));
            fixedEnumValues.Add(new("Saturday", "Saturday", InputPrimitiveType.String, FixedEnumType, null, null));
            fixedEnumValues.Add(new("Sunday", "Sunday", InputPrimitiveType.String, FixedEnumType, null, null));
        }


        private static readonly InputEnumType ExtensibleEnumType;

        private static readonly InputEnumType FixedEnumType;

        private static readonly object[] ExtensibleEnumCase =
        {

            new object[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Cadl.TestServer.EnumPropertiesBasic
{
/// <summary> The supported languages to translate input text into. </summary>
public readonly partial struct TranslationLanguageValues: global::System.IEquatable<global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues>
{
private readonly string _value;

/// <summary> Initializes a new instance of <see cref=""TranslationLanguageValues""/>. </summary>
/// <exception cref=""global::System.ArgumentNullException""> <paramref name=""value""/> is null. </exception>
public TranslationLanguageValues(string value)
{
_value = value?? throw new global::System.ArgumentNullException(nameof(value));
}

private const string EnglishValue = ""English"";
private const string SpanishValue = ""Spanish"";
private const string MandarinValue = ""Mandarin"";
private const string UndocumentedValue = ""Undocumented"";

/// <summary> Translate to English. </summary>
public static global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues English{ get; } = new global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues(EnglishValue);
/// <summary> Translate to Spanish. </summary>
public static global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues Spanish{ get; } = new global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues(SpanishValue);
/// <summary> Translate to Mandarin. </summary>
public static global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues Mandarin{ get; } = new global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues(MandarinValue);
/// <summary> Undocumented. </summary>
public static global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues Undocumented{ get; } = new global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues(UndocumentedValue);
/// <summary> Determines if two <see cref=""TranslationLanguageValues""/> values are the same. </summary>
public static bool operator ==(global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues left, global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues right) => left.Equals(right);
/// <summary> Determines if two <see cref=""TranslationLanguageValues""/> values are not the same. </summary>
public static bool operator !=(global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues left, global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues right) => !left.Equals(right);
/// <summary> Converts a <see cref=""string""/> to a <see cref=""TranslationLanguageValues""/>. </summary>
public static implicit operator global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues(string value) => new global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues(value);

/// <inheritdoc />
[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
public override bool Equals(object obj) => obj is global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues other && Equals(other);
/// <inheritdoc />
public bool Equals(global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues other) => string.Equals(_value, other._value, global::System.StringComparison.InvariantCultureIgnoreCase);

/// <inheritdoc />
[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
public override int GetHashCode() => _value != null ? global::System.StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
/// <inheritdoc />
public override string ToString() => _value;
}
}
"
            }
        };

        private static readonly object[] FixedEnumCase =
        {
            new object[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Cadl.TestServer.EnumPropertiesBasic
{
/// <summary> Represents the days of the week using a standard, non-string enum. </summary>
public enum DayOfTheWeek{
/// <summary> Monday. </summary>
Monday,
/// <summary> Tuesday. </summary>
Tuesday,
/// <summary> Wednesday. </summary>
Wednesday,
/// <summary> Wednesday is documented to test this case. </summary>
Thursday,
/// <summary> Friday. </summary>
Friday,
/// <summary> Saturday. </summary>
Saturday,
/// <summary> Sunday. </summary>
Sunday}
}
",
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Cadl.TestServer.EnumPropertiesBasic
{
internal static partial class DayOfTheWeekExtensions
{
public static string ToSerialString(this DayOfTheWeek value) => value switch
{
DayOfTheWeek.Monday => ""Monday"",
DayOfTheWeek.Tuesday => ""Tuesday"",
DayOfTheWeek.Wednesday => ""Wednesday"",
DayOfTheWeek.Thursday => ""Thursday"",
DayOfTheWeek.Friday => ""Friday"",
DayOfTheWeek.Saturday => ""Saturday"",
DayOfTheWeek.Sunday => ""Sunday"",
_ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, ""Unknown DayOfTheWeek value."")
};

public static DayOfTheWeek ToDayOfTheWeek(this string value)
{
if (global::System.StringComparer.OrdinalIgnoreCase.Equals(value, ""Monday"")) return DayOfTheWeek.Monday;
if (global::System.StringComparer.OrdinalIgnoreCase.Equals(value, ""Tuesday"")) return DayOfTheWeek.Tuesday;
if (global::System.StringComparer.OrdinalIgnoreCase.Equals(value, ""Wednesday"")) return DayOfTheWeek.Wednesday;
if (global::System.StringComparer.OrdinalIgnoreCase.Equals(value, ""Thursday"")) return DayOfTheWeek.Thursday;
if (global::System.StringComparer.OrdinalIgnoreCase.Equals(value, ""Friday"")) return DayOfTheWeek.Friday;
if (global::System.StringComparer.OrdinalIgnoreCase.Equals(value, ""Saturday"")) return DayOfTheWeek.Saturday;
if (global::System.StringComparer.OrdinalIgnoreCase.Equals(value, ""Sunday"")) return DayOfTheWeek.Sunday;
throw new global::System.ArgumentOutOfRangeException(nameof(value), value, ""Unknown DayOfTheWeek value."");
}
}
}
"
            }
        };

        private static readonly object[] RoundTripEnumPropertiesCase =
        {
            new[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Cadl.TestServer.EnumPropertiesBasic
{
/// <summary> Round-trip model with enum properties. </summary>
public partial class RoundTripModel
{
/// <summary> Initializes a new instance of RoundTripModel. </summary>
/// <param name=""day""> Required standard enum value. </param>
/// <param name=""language""> Required string enum value. </param>
public RoundTripModel(global::Cadl.TestServer.EnumPropertiesBasic.DayOfTheWeek day,global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues language)
{
Day = day;
Language = language;
}

/// <summary> Required standard enum value. </summary>
public global::Cadl.TestServer.EnumPropertiesBasic.DayOfTheWeek Day{ get; set; }

/// <summary> Required string enum value. </summary>
public global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues Language{ get; set; }
}
}
",
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Cadl.TestServer.EnumPropertiesBasic
{
public partial class RoundTripModel: global::Azure.Core.IUtf8JsonSerializable
{
void global::Azure.Core.IUtf8JsonSerializable.Write(global::System.Text.Json.Utf8JsonWriter writer)
{
writer.WriteStartObject();
writer.WritePropertyName(""Day"");
writer.WriteStringValue(Day.ToSerialString());
writer.WritePropertyName(""Language"");
writer.WriteStringValue(Language.ToString());
writer.WriteEndObject();
}

internal static global::Cadl.TestServer.EnumPropertiesBasic.RoundTripModel DeserializeRoundTripModel(global::System.Text.Json.JsonElement element)
{
global::Cadl.TestServer.EnumPropertiesBasic.DayOfTheWeek day = default;
global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues language = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(""Day"")){
day = property.Value.GetString().ToDayOfTheWeek();
continue;
}
if(property.NameEquals(""Language"")){
language = new global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues(property.Value.GetString());
continue;
}
}
return new global::Cadl.TestServer.EnumPropertiesBasic.RoundTripModel(day, language);}

internal global::Azure.Core.RequestContent ToRequestContent()
{
var content = new global::Azure.Core.Utf8JsonRequestContent();
content.JsonWriter.WriteObjectValue(this);
return content;
}

internal static global::Cadl.TestServer.EnumPropertiesBasic.RoundTripModel FromResponse(global::Azure.Response response)
{
using var document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return DeserializeRoundTripModel(document.RootElement);
}
}
}
"
            }
        };

        private static readonly object[] InputEnumPropertiesCase =
        {
            new[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Cadl.TestServer.EnumPropertiesBasic
{
/// <summary> Input model with enum properties. </summary>
public partial class InputModel
{
/// <summary> Initializes a new instance of InputModel. </summary>
/// <param name=""day""> Required standard enum value. </param>
/// <param name=""language""> Required string enum value. </param>
public InputModel(global::Cadl.TestServer.EnumPropertiesBasic.DayOfTheWeek day,global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues language)
{
Day = day;
Language = language;
}

/// <summary> Required standard enum value. </summary>
public global::Cadl.TestServer.EnumPropertiesBasic.DayOfTheWeek Day{ get; }

/// <summary> Required string enum value. </summary>
public global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues Language{ get; }
}
}
",
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Cadl.TestServer.EnumPropertiesBasic
{
public partial class InputModel: global::Azure.Core.IUtf8JsonSerializable
{
void global::Azure.Core.IUtf8JsonSerializable.Write(global::System.Text.Json.Utf8JsonWriter writer)
{
writer.WriteStartObject();
writer.WritePropertyName(""Day"");
writer.WriteStringValue(Day.ToSerialString());
writer.WritePropertyName(""Language"");
writer.WriteStringValue(Language.ToString());
writer.WriteEndObject();
}

internal global::Azure.Core.RequestContent ToRequestContent()
{
var content = new global::Azure.Core.Utf8JsonRequestContent();
content.JsonWriter.WriteObjectValue(this);
return content;
}
}
}
"
            }
        };

        private static readonly object[] OutputEnumPropertiesCase =
        {
            new[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Cadl.TestServer.EnumPropertiesBasic
{
/// <summary> Output model with enum properties. </summary>
public partial class OutputModel
{
/// <summary> Initializes a new instance of OutputModel. </summary>
/// <param name=""day""> Required standard enum value. </param>
/// <param name=""language""> Required string enum value. </param>
internal OutputModel(global::Cadl.TestServer.EnumPropertiesBasic.DayOfTheWeek day,global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues language)
{
Day = day;
Language = language;
}

/// <summary> Required standard enum value. </summary>
public global::Cadl.TestServer.EnumPropertiesBasic.DayOfTheWeek Day{ get; }

/// <summary> Required string enum value. </summary>
public global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues Language{ get; }
}
}
",
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Cadl.TestServer.EnumPropertiesBasic
{
public partial class OutputModel
{
internal static global::Cadl.TestServer.EnumPropertiesBasic.OutputModel DeserializeOutputModel(global::System.Text.Json.JsonElement element)
{
global::Cadl.TestServer.EnumPropertiesBasic.DayOfTheWeek day = default;
global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues language = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(""Day"")){
day = property.Value.GetString().ToDayOfTheWeek();
continue;
}
if(property.NameEquals(""Language"")){
language = new global::Cadl.TestServer.EnumPropertiesBasic.TranslationLanguageValues(property.Value.GetString());
continue;
}
}
return new global::Cadl.TestServer.EnumPropertiesBasic.OutputModel(day, language);}

internal static global::Cadl.TestServer.EnumPropertiesBasic.OutputModel FromResponse(global::Azure.Response response)
{
using var document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return DeserializeOutputModel(document.RootElement);
}
}
}
"
            }
        };
    }
}
