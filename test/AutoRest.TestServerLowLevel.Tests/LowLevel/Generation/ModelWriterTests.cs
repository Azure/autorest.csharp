// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models.Types;
using NUnit.Framework;

namespace AutoRest.CSharp.Generation.Writers.Tests
{
    public class LowLevelModelWriterTests : ModelGenerationTestBase
    {
        [TestCaseSource(nameof(RoundTripBasicCase))]
        public void RoundTripBasic(string expectedModelCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/c4f41f483eac812527f7b6dc837bd22d255a18ed/packages/cadl-ranch-specs/http/models/roundtrip-basic/main.cadl#L15-L23
            var input = new InputModelType("InputModel", "Cadl.TestServer.InputBasic", null, "public", null, "Round-trip Model", InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                new List<InputModelProperty> { RequiredStringProperty, RequiredIntProperty },
                null, new List<InputModelType>(), null, null, null, null);

            var model = new ModelTypeProvider(input, "test", null, null);
            ValidateGeneratedModelCodes(model, expectedModelCodes);
        }

        [TestCaseSource(nameof(InputBasicCase))]
        public void InputBasic(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/main/packages/cadl-ranch-specs/http/models/input-basic/main.cadl
            var input = new InputModelType("InputModel", "Cadl.TestServer.InputBasic", null, "public", null, "Input Model", InputModelTypeUsage.Input,
                new List<InputModelProperty> { RequiredStringProperty, RequiredIntProperty },
                null, new List<InputModelType>(), null, null, null, null);

            var model = new ModelTypeProvider(input, "test", null, null);
            ValidateGeneratedCodes(model, expectedModelCodes, expectedSerializationCodes);
        }

        [TestCaseSource(nameof(OutputBasicCase))]
        public void OutputBasic(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/c4f41f483eac812527f7b6dc837bd22d255a18ed/packages/cadl-ranch-specs/http/models/output-basic/main.cadl#L15-L23
            var input = new InputModelType("OutputModel", "Cadl.TestServer.OutputBasic", null, "public", null, "Output Model", InputModelTypeUsage.Output,
                new List<InputModelProperty> { RequiredStringProperty, RequiredIntProperty },
                null, new List<InputModelType>(), null, null, null, null);

            var model = new ModelTypeProvider(input, "test", null, null);
            ValidateGeneratedCodes(model, expectedModelCodes, expectedSerializationCodes);
        }

        [TestCaseSource(nameof(PrimitivePropertiesCase))]
        public void PrimitiveProperties(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/main/packages/cadl-ranch-specs/http/models/primitive-properties/main.cadl
            var input = new InputModelType("PrimitivePropertyModel", "Cadl.TestServer.PrimitiveProperties", null, "public", null,
                "Round-trip model with primitive properties to show serialization and deserialization of each.", InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                new List<InputModelProperty>{
                    new InputModelProperty("requiredString", "requiredString", string.Empty, string.Empty, InputPrimitiveType.String, null, true, false, false),
                    new InputModelProperty("requiredInt", "requiredInt", string.Empty, string.Empty, InputPrimitiveType.Int32, null, true, false, false),
                    new InputModelProperty("requiredLong", "requiredLong", string.Empty, string.Empty, InputPrimitiveType.Int64, null, true, false, false),
                    new InputModelProperty("requiredSafeInt", "requiredSafeInt", string.Empty, string.Empty, InputPrimitiveType.Int64, null, true, false, false),
                    new InputModelProperty("requiredFloat", "requiredFloat", string.Empty, string.Empty, InputPrimitiveType.Float32, null, true, false, false),
                    new InputModelProperty("requiredDouble", "requiredDouble", string.Empty, string.Empty, InputPrimitiveType.Float64, null, true, false, false),
                    new InputModelProperty("requiredBodyDateTime", "requiredBodyDateTime", string.Empty, "Illustrate a zonedDateTime body parameter, serialized as (https://datatracker.ietf.org/doc/html/rfc3339)", new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "dateTime", string.Empty, InputPrimitiveType.String), null, true, false, false),
                    new InputModelProperty("requiredDuration", "requiredDuration", string.Empty, string.Empty, new InputDurationType(DurationKnownEncoding.Iso8601, "dateTime", string.Empty, InputPrimitiveType.String), null, true, false, false),
                    new InputModelProperty("requiredBoolean", "requiredBoolean", string.Empty, string.Empty, InputPrimitiveType.Boolean, null, true, false, false),
                    new InputModelProperty("requiredBytes", "requiredBytes", string.Empty, string.Empty, InputPrimitiveType.Base64, null, true, false, false)
                },
                null, Array.Empty<InputModelType>(), null, null, null, null);

            var model = new ModelTypeProvider(input, "test", null, null);
            ValidateGeneratedCodes(model, expectedModelCodes, expectedSerializationCodes);
        }

        // Below are test cases
        private static readonly string[] RoundTripBasicCase =
        {
            @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Cadl.TestServer.InputBasic
{
/// <summary> Round-trip Model. </summary>
public partial class InputModel
{
/// <summary> Initializes a new instance of InputModel. </summary>
/// <param name=string.EmptyrequiredStringstring.Empty> Required string, illustrating a reference type property. </param>
/// <param name=string.EmptyrequiredIntstring.Empty> Required int, illustrating a value type property. </param>
/// <exception cref=string.Emptyglobal::System.ArgumentNullExceptionstring.Empty> <paramref name=string.EmptyrequiredStringstring.Empty/> is null. </exception>
public InputModel(string requiredString,int requiredInt)
{
global::Azure.Core.Argument.AssertNotNull(requiredString, nameof(requiredString));

RequiredString = requiredString;
RequiredInt = requiredInt;
}

/// <summary> Required string, illustrating a reference type property. </summary>
public string RequiredString{ get; set; }

/// <summary> Required int, illustrating a value type property. </summary>
public int RequiredInt{ get; set; }
}
}
"
        };

        private static readonly object[] InputBasicCase =
        {
            new[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Cadl.TestServer.InputBasic
{
/// <summary> Input Model. </summary>
public partial class InputModel
{
/// <summary> Initializes a new instance of InputModel. </summary>
/// <param name=string.EmptyrequiredStringstring.Empty> Required string, illustrating a reference type property. </param>
/// <param name=string.EmptyrequiredIntstring.Empty> Required int, illustrating a value type property. </param>
/// <exception cref=string.Emptyglobal::System.ArgumentNullExceptionstring.Empty> <paramref name=string.EmptyrequiredStringstring.Empty/> is null. </exception>
public InputModel(string requiredString,int requiredInt)
{
global::Azure.Core.Argument.AssertNotNull(requiredString, nameof(requiredString));

RequiredString = requiredString;
RequiredInt = requiredInt;
}

/// <summary> Required string, illustrating a reference type property. </summary>
public string RequiredString{ get; }

/// <summary> Required int, illustrating a value type property. </summary>
public int RequiredInt{ get; }
}
}
",
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Cadl.TestServer.InputBasic
{
public partial class InputModel: global::Azure.Core.IUtf8JsonSerializable
{
void global::Azure.Core.IUtf8JsonSerializable.Write(global::System.Text.Json.Utf8JsonWriter writer)
{
writer.WriteStartObject();
writer.WritePropertyName(string.EmptyrequiredStringstring.Empty);
writer.WriteStringValue(RequiredString);
writer.WritePropertyName(string.EmptyrequiredIntstring.Empty);
writer.WriteNumberValue(RequiredInt);
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

        private static readonly object[] OutputBasicCase =
        {
            new[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Cadl.TestServer.OutputBasic
{
/// <summary> Output Model. </summary>
public partial class OutputModel
{
/// <summary> Initializes a new instance of OutputModel. </summary>
/// <param name=string.EmptyrequiredStringstring.Empty> Required string, illustrating a reference type property. </param>
/// <param name=string.EmptyrequiredIntstring.Empty> Required int, illustrating a value type property. </param>
/// <exception cref=string.Emptyglobal::System.ArgumentNullExceptionstring.Empty> <paramref name=string.EmptyrequiredStringstring.Empty/> is null. </exception>
internal OutputModel(string requiredString,int requiredInt)
{
global::Azure.Core.Argument.AssertNotNull(requiredString, nameof(requiredString));

RequiredString = requiredString;
RequiredInt = requiredInt;
}

/// <summary> Required string, illustrating a reference type property. </summary>
public string RequiredString{ get; }

/// <summary> Required int, illustrating a value type property. </summary>
public int RequiredInt{ get; }
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

namespace Cadl.TestServer.OutputBasic
{
public partial class OutputModel
{
internal static global::Cadl.TestServer.OutputBasic.OutputModel DeserializeOutputModel(global::System.Text.Json.JsonElement element)
{
string requiredString = default;
int requiredInt = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(string.EmptyrequiredStringstring.Empty)){
requiredString = property.Value.GetString();
continue;
}
if(property.NameEquals(string.EmptyrequiredIntstring.Empty)){
requiredInt = property.Value.GetInt32();
continue;
}
}
return new global::Cadl.TestServer.OutputBasic.OutputModel(requiredString, requiredInt);}

internal static global::Cadl.TestServer.OutputBasic.OutputModel FromResponse(global::Azure.Response response)
{
using var document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return DeserializeOutputModel(document.RootElement);
}
}
}
"
            }
        };

        private static readonly object[] PrimitivePropertiesCase =
        {
            new[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Cadl.TestServer.PrimitiveProperties
{
/// <summary> Round-trip model with primitive properties to show serialization and deserialization of each. </summary>
public partial class PrimitivePropertyModel
{
/// <summary> Initializes a new instance of PrimitivePropertyModel. </summary>
/// <param name=string.EmptyrequiredStringstring.Empty></param>
/// <param name=string.EmptyrequiredIntstring.Empty></param>
/// <param name=string.EmptyrequiredLongstring.Empty></param>
/// <param name=string.EmptyrequiredSafeIntstring.Empty></param>
/// <param name=string.EmptyrequiredFloatstring.Empty></param>
/// <param name=string.EmptyrequiredDoublestring.Empty></param>
/// <param name=string.EmptyrequiredBodyDateTimestring.Empty> Illustrate a zonedDateTime body parameter, serialized as (https://datatracker.ietf.org/doc/html/rfc3339). </param>
/// <param name=string.EmptyrequiredDurationstring.Empty></param>
/// <param name=string.EmptyrequiredBooleanstring.Empty></param>
/// <param name=string.EmptyrequiredBytesstring.Empty></param>
/// <exception cref=string.Emptyglobal::System.ArgumentNullExceptionstring.Empty> <paramref name=string.EmptyrequiredStringstring.Empty/> or <paramref name=string.EmptyrequiredBytesstring.Empty/> is null. </exception>
public PrimitivePropertyModel(string requiredString,int requiredInt,long requiredLong,long requiredSafeInt,float requiredFloat,double requiredDouble,global::System.DateTimeOffset requiredBodyDateTime,global::System.TimeSpan requiredDuration,bool requiredBoolean,global::System.BinaryData requiredBytes)
{
global::Azure.Core.Argument.AssertNotNull(requiredString, nameof(requiredString));
global::Azure.Core.Argument.AssertNotNull(requiredBytes, nameof(requiredBytes));

RequiredString = requiredString;
RequiredInt = requiredInt;
RequiredLong = requiredLong;
RequiredSafeInt = requiredSafeInt;
RequiredFloat = requiredFloat;
RequiredDouble = requiredDouble;
RequiredBodyDateTime = requiredBodyDateTime;
RequiredDuration = requiredDuration;
RequiredBoolean = requiredBoolean;
RequiredBytes = requiredBytes;
}

public string RequiredString{ get; set; }

public int RequiredInt{ get; set; }

public long RequiredLong{ get; set; }

public long RequiredSafeInt{ get; set; }

public float RequiredFloat{ get; set; }

public double RequiredDouble{ get; set; }

/// <summary> Illustrate a zonedDateTime body parameter, serialized as (https://datatracker.ietf.org/doc/html/rfc3339). </summary>
public global::System.DateTimeOffset RequiredBodyDateTime{ get; set; }

public global::System.TimeSpan RequiredDuration{ get; set; }

public bool RequiredBoolean{ get; set; }

public global::System.BinaryData RequiredBytes{ get; set; }
}
}
",
            @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Cadl.TestServer.PrimitiveProperties
{
public partial class PrimitivePropertyModel: global::Azure.Core.IUtf8JsonSerializable
{
void global::Azure.Core.IUtf8JsonSerializable.Write(global::System.Text.Json.Utf8JsonWriter writer)
{
writer.WriteStartObject();
writer.WritePropertyName(string.EmptyrequiredStringstring.Empty);
writer.WriteStringValue(RequiredString);
writer.WritePropertyName(string.EmptyrequiredIntstring.Empty);
writer.WriteNumberValue(RequiredInt);
writer.WritePropertyName(string.EmptyrequiredLongstring.Empty);
writer.WriteNumberValue(RequiredLong);
writer.WritePropertyName(string.EmptyrequiredSafeIntstring.Empty);
writer.WriteNumberValue(RequiredSafeInt);
writer.WritePropertyName(string.EmptyrequiredFloatstring.Empty);
writer.WriteNumberValue(RequiredFloat);
writer.WritePropertyName(string.EmptyrequiredDoublestring.Empty);
writer.WriteNumberValue(RequiredDouble);
writer.WritePropertyName(string.EmptyrequiredBodyDateTimestring.Empty);
writer.WriteStringValue(RequiredBodyDateTime, string.EmptyOstring.Empty);
writer.WritePropertyName(string.EmptyrequiredDurationstring.Empty);
writer.WriteStringValue(RequiredDuration, string.EmptyPstring.Empty);
writer.WritePropertyName(string.EmptyrequiredBooleanstring.Empty);
writer.WriteBooleanValue(RequiredBoolean);
writer.WritePropertyName(string.EmptyrequiredBytesstring.Empty);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(RequiredBytes);
#else
global::System.Text.Json.JsonSerializer.Serialize(writer, global::System.Text.Json.JsonDocument.Parse(RequiredBytes.ToString()).RootElement);
#endif
writer.WriteEndObject();
}

internal static global::Cadl.TestServer.PrimitiveProperties.PrimitivePropertyModel DeserializePrimitivePropertyModel(global::System.Text.Json.JsonElement element)
{
string requiredString = default;
int requiredInt = default;
long requiredLong = default;
long requiredSafeInt = default;
float requiredFloat = default;
double requiredDouble = default;
global::System.DateTimeOffset requiredBodyDateTime = default;
global::System.TimeSpan requiredDuration = default;
bool requiredBoolean = default;
global::System.BinaryData requiredBytes = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(string.EmptyrequiredStringstring.Empty)){
requiredString = property.Value.GetString();
continue;
}
if(property.NameEquals(string.EmptyrequiredIntstring.Empty)){
requiredInt = property.Value.GetInt32();
continue;
}
if(property.NameEquals(string.EmptyrequiredLongstring.Empty)){
requiredLong = property.Value.GetInt64();
continue;
}
if(property.NameEquals(string.EmptyrequiredSafeIntstring.Empty)){
requiredSafeInt = property.Value.GetInt64();
continue;
}
if(property.NameEquals(string.EmptyrequiredFloatstring.Empty)){
requiredFloat = property.Value.GetSingle();
continue;
}
if(property.NameEquals(string.EmptyrequiredDoublestring.Empty)){
requiredDouble = property.Value.GetDouble();
continue;
}
if(property.NameEquals(string.EmptyrequiredBodyDateTimestring.Empty)){
requiredBodyDateTime = property.Value.GetDateTimeOffset(string.EmptyOstring.Empty);
continue;
}
if(property.NameEquals(string.EmptyrequiredDurationstring.Empty)){
requiredDuration = property.Value.GetTimeSpan(string.EmptyPstring.Empty);
continue;
}
if(property.NameEquals(string.EmptyrequiredBooleanstring.Empty)){
requiredBoolean = property.Value.GetBoolean();
continue;
}
if(property.NameEquals(string.EmptyrequiredBytesstring.Empty)){
requiredBytes = global::System.BinaryData.FromString(property.Value.GetRawText());
continue;
}
}
return new global::Cadl.TestServer.PrimitiveProperties.PrimitivePropertyModel(requiredString, requiredInt, requiredLong, requiredSafeInt, requiredFloat, requiredDouble, requiredBodyDateTime, requiredDuration, requiredBoolean, requiredBytes);}

internal global::Azure.Core.RequestContent ToRequestContent()
{
var content = new global::Azure.Core.Utf8JsonRequestContent();
content.JsonWriter.WriteObjectValue(this);
return content;
}

internal static global::Cadl.TestServer.PrimitiveProperties.PrimitivePropertyModel FromResponse(global::Azure.Response response)
{
using var document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return DeserializePrimitivePropertyModel(document.RootElement);
}
}
}
" }
        };
    }
}
