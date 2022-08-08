using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using NUnit.Framework;

namespace AutoRest.CSharp.Generation.Writers.Tests
{
    public class LowLevelModelWriterTests
    {
        [TestCaseSource(nameof(InputBasicCase))]
        public void InputBasic(string expectedModelCodes)
        {
            // refer to the original CADL file: https://github.com/annelo-msft/azure-sdk-for-net/blob/cadl-models-roundtrip-basic/sdk/template/Azure.Template/src/Generated/Models/RoundTripModel.cs
            var model = new ModelTypeProvider(
                new InputModelType("InputModel", "Cadl.TestServer.InputBasic", "public",
                    new List<InputModelProperty>{
                        new InputModelProperty("requiredString", "requiredString", "Required string, illustrating a reference type property.", InputPrimitiveType.String, true, true, false),
                        new InputModelProperty("requiredInt", "requiredInt", "Required int, illustrating a value type property.", InputPrimitiveType.Int32, true, true, false)
                    },
                    null, null, null),
                new TypeFactory(null),
                "test",
                null);

            ValidateGeneratedModelCodes(model, expectedModelCodes);
        }

        [TestCaseSource(nameof(PrimitivePropertiesCase))]
        public void PrimitiveProperties(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/main/packages/cadl-ranch-specs/http/models/primitive-properties/main.cadl
            var model = new ModelTypeProvider(
                new InputModelType("PrimitivePropertyModel", "Cadl.TestServer.PrimitiveProperties", "public",
                    new List<InputModelProperty>{
                        new InputModelProperty("requiredString", "requiredString", "", InputPrimitiveType.String, true, false, false),
                        new InputModelProperty("requiredInt", "requiredInt", "", InputPrimitiveType.Int32, true, false, false),
                        new InputModelProperty("requiredLong", "requiredLong", "", InputPrimitiveType.Int64, true, false, false),
                        new InputModelProperty("requiredSafeInt", "requiredSafeInt", "", InputPrimitiveType.Int64, true, false, false),
                        new InputModelProperty("requiredFloat", "requiredFloat", "", InputPrimitiveType.Float32, true, false, false),
                        new InputModelProperty("requiredDouble", "requiredDouble", "", InputPrimitiveType.Float64, true, false, false),
                        new InputModelProperty("requiredBodyDateTime", "requiredBodyDateTime", "Illustrate a zonedDateTime body parameter, serialized as (https://datatracker.ietf.org/doc/html/rfc3339)", InputPrimitiveType.DateTimeISO8601, true, false, false),
                        new InputModelProperty("requiredDuration", "requiredDuration", "", InputPrimitiveType.DurationISO8601, true, false, false),
                        new InputModelProperty("requiredBoolean", "requiredBoolean", "", InputPrimitiveType.Boolean, true, false, false)
                    },
                    null, null, null),
                new TypeFactory(null),
                "test",
                null);

            ValidateGeneratedCodes(model, expectedModelCodes, expectedSerializationCodes);
        }

        [TestCaseSource(nameof(PrimitiveCollectionPropertiesCase))]
        public void PrimitiveCollectionProperties(string expectedModelCodes, string expectedSerializationCodes)
        {

            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/main/packages/cadl-ranch-specs/http/models/primitive-properties/main.cadl
            var model = new ModelTypeProvider(
                new InputModelType("RoundTripModel", "Cadl.TestServer.CollectionPropertiesBasic", "public",
                    new List<InputModelProperty>{
                        new InputModelProperty("requiredStringList", "requiredStringList", "Required collection of strings, illustrating a collection of reference types.", new InputListType("requiredStringList", InputPrimitiveType.String), true, false, false),
                        new InputModelProperty("requiredIntList", "requiredIntList", "Required collection of ints, illustrating a collection of value types.", new InputListType("requiredIntList", InputPrimitiveType.Int32), true, false, false),
                    },
                    null, null, null),
                new TypeFactory(null),
                "test",
                null);

            ValidateGeneratedCodes(model, expectedModelCodes, expectedSerializationCodes);
        }


        private void ValidateGeneratedCodes(ModelTypeProvider model, string modelCodes, string serializationCodes)
        {
            ValidateGeneratedModelCodes(model, modelCodes);
            ValidateGeneratedSerializationCodes(model, serializationCodes);
        }

        private void ValidateGeneratedModelCodes(ModelTypeProvider model, string modelCodes)
        {
            var codeWriter = new CodeWriter();
            LowLevelModelWriter.WriteType(codeWriter, model);
            var codes = codeWriter.ToString();
            Assert.AreEqual(modelCodes, codes);
        }

        private void ValidateGeneratedSerializationCodes(ModelTypeProvider model, string serializationCodes)
        {
            var codeWriter = new CodeWriter();
            SerializationWriter.WriteModelSerialization(codeWriter, model);
            var codes = codeWriter.ToString();
            Assert.AreEqual(serializationCodes, codes);
        }

        // Below are test cases
        private static readonly string[] InputBasicCase =
        {
            @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Cadl.TestServer.InputBasic
{
public partial class InputModel
{
/// <summary> Required string, illustrating a reference type property. </summary>
public string RequiredString{ get; }

/// <summary> Required int, illustrating a value type property. </summary>
public int RequiredInt{ get; }

/// <summary> Initializes a new instance of InputModel. </summary>
/// <param name=""requiredString""> Required string, illustrating a reference type property. </param>
/// <param name=""requiredInt""> Required int, illustrating a value type property. </param>
/// <exception cref=""global::System.ArgumentNullException""> <paramref name=""requiredString""/> is null. </exception>
public InputModel(string requiredString,int requiredInt)
{
global::Azure.Core.Argument.AssertNotNull(requiredString, nameof(requiredString));

RequiredString = requiredString;
RequiredInt = requiredInt;
}
}
}
"
        };

        private static readonly object[] PrimitivePropertiesCase =
        {
            new string[] { @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Cadl.TestServer.PrimitiveProperties
{
public partial class PrimitivePropertyModel
{
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

/// <summary> Initializes a new instance of PrimitivePropertyModel. </summary>
/// <param name=""requiredString""></param>
/// <param name=""requiredInt""></param>
/// <param name=""requiredLong""></param>
/// <param name=""requiredSafeInt""></param>
/// <param name=""requiredFloat""></param>
/// <param name=""requiredDouble""></param>
/// <param name=""requiredBodyDateTime""> Illustrate a zonedDateTime body parameter, serialized as (https://datatracker.ietf.org/doc/html/rfc3339). </param>
/// <param name=""requiredDuration""></param>
/// <param name=""requiredBoolean""></param>
/// <exception cref=""global::System.ArgumentNullException""> <paramref name=""requiredString""/> is null. </exception>
public PrimitivePropertyModel(string requiredString,int requiredInt,long requiredLong,long requiredSafeInt,float requiredFloat,double requiredDouble,global::System.DateTimeOffset requiredBodyDateTime,global::System.TimeSpan requiredDuration,bool requiredBoolean)
{
global::Azure.Core.Argument.AssertNotNull(requiredString, nameof(requiredString));

RequiredString = requiredString;
RequiredInt = requiredInt;
RequiredLong = requiredLong;
RequiredSafeInt = requiredSafeInt;
RequiredFloat = requiredFloat;
RequiredDouble = requiredDouble;
RequiredBodyDateTime = requiredBodyDateTime;
RequiredDuration = requiredDuration;
RequiredBoolean = requiredBoolean;
}
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
writer.WritePropertyName(""requiredString"");
writer.WriteStringValue(RequiredString);
writer.WritePropertyName(""requiredInt"");
writer.WriteNumberValue(RequiredInt);
writer.WritePropertyName(""requiredLong"");
writer.WriteNumberValue(RequiredLong);
writer.WritePropertyName(""requiredSafeInt"");
writer.WriteNumberValue(RequiredSafeInt);
writer.WritePropertyName(""requiredFloat"");
writer.WriteNumberValue(RequiredFloat);
writer.WritePropertyName(""requiredDouble"");
writer.WriteNumberValue(RequiredDouble);
writer.WritePropertyName(""requiredBodyDateTime"");
writer.WriteStringValue(RequiredBodyDateTime, ""O"");
writer.WritePropertyName(""requiredDuration"");
writer.WriteStringValue(RequiredDuration, ""P"");
writer.WritePropertyName(""requiredBoolean"");
writer.WriteBooleanValue(RequiredBoolean);
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
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(""requiredString"")){
requiredString = property.Value.GetString();
continue;
}
if(property.NameEquals(""requiredInt"")){
requiredInt = property.Value.GetInt32();
continue;
}
if(property.NameEquals(""requiredLong"")){
requiredLong = property.Value.GetInt64();
continue;
}
if(property.NameEquals(""requiredSafeInt"")){
requiredSafeInt = property.Value.GetInt64();
continue;
}
if(property.NameEquals(""requiredFloat"")){
requiredFloat = property.Value.GetSingle();
continue;
}
if(property.NameEquals(""requiredDouble"")){
requiredDouble = property.Value.GetDouble();
continue;
}
if(property.NameEquals(""requiredBodyDateTime"")){
requiredBodyDateTime = property.Value.GetDateTimeOffset(""O"");
continue;
}
if(property.NameEquals(""requiredDuration"")){
requiredDuration = property.Value.GetTimeSpan(""P"");
continue;
}
if(property.NameEquals(""requiredBoolean"")){
requiredBoolean = property.Value.GetBoolean();
continue;
}
}
return new global::Cadl.TestServer.PrimitiveProperties.PrimitivePropertyModel(requiredString, requiredInt, requiredLong, requiredSafeInt, requiredFloat, requiredDouble, requiredBodyDateTime, requiredDuration, requiredBoolean);}

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

        private static readonly object[] PrimitiveCollectionPropertiesCase =
        {
            new string[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Cadl.TestServer.CollectionPropertiesBasic
{
public partial class RoundTripModel
{
/// <summary> Required collection of strings, illustrating a collection of reference types. </summary>
public global::System.Collections.Generic.IList<string> RequiredStringList{ get; }

/// <summary> Required collection of ints, illustrating a collection of value types. </summary>
public global::System.Collections.Generic.IList<int> RequiredIntList{ get; }

/// <summary> Initializes a new instance of RoundTripModel. </summary>
/// <param name=""requiredStringList""> Required collection of strings, illustrating a collection of reference types. </param>
/// <param name=""requiredIntList""> Required collection of ints, illustrating a collection of value types. </param>
/// <exception cref=""global::System.ArgumentNullException""> <paramref name=""requiredStringList""/> or <paramref name=""requiredIntList""/> is null. </exception>
public RoundTripModel(global::System.Collections.Generic.IEnumerable<string> requiredStringList,global::System.Collections.Generic.IEnumerable<int> requiredIntList)
{
global::Azure.Core.Argument.AssertNotNull(requiredStringList, nameof(requiredStringList));
global::Azure.Core.Argument.AssertNotNull(requiredIntList, nameof(requiredIntList));

RequiredStringList = requiredStringList.ToList();
RequiredIntList = requiredIntList.ToList();
}
/// <summary> Initializes a new instance of RoundTripModel. </summary>
/// <param name=""requiredStringList""> Required collection of strings, illustrating a collection of reference types. </param>
/// <param name=""requiredIntList""> Required collection of ints, illustrating a collection of value types. </param>
/// <exception cref=""global::System.ArgumentNullException""> <paramref name=""requiredStringList""/> or <paramref name=""requiredIntList""/> is null. </exception>
internal RoundTripModel(global::System.Collections.Generic.IList<string> requiredStringList,global::System.Collections.Generic.IList<int> requiredIntList)
{
global::Azure.Core.Argument.AssertNotNull(requiredStringList, nameof(requiredStringList));
global::Azure.Core.Argument.AssertNotNull(requiredIntList, nameof(requiredIntList));

RequiredStringList = requiredStringList;
RequiredIntList = requiredIntList;
}
}
}
",
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Cadl.TestServer.CollectionPropertiesBasic
{
public partial class RoundTripModel: global::Azure.Core.IUtf8JsonSerializable
{
void global::Azure.Core.IUtf8JsonSerializable.Write(global::System.Text.Json.Utf8JsonWriter writer)
{
writer.WriteStartObject();
writer.WritePropertyName(""requiredStringList"");
writer.WriteStartArray();
foreach (var item in RequiredStringList)
{
writer.WriteStringValue(item);
}
writer.WriteEndArray();
writer.WritePropertyName(""requiredIntList"");
writer.WriteStartArray();
foreach (var item in RequiredIntList)
{
writer.WriteNumberValue(item);
}
writer.WriteEndArray();
writer.WriteEndObject();
}

internal static global::Cadl.TestServer.CollectionPropertiesBasic.RoundTripModel DeserializeRoundTripModel(global::System.Text.Json.JsonElement element)
{
global::System.Collections.Generic.IList<string> requiredStringList = default;
global::System.Collections.Generic.IList<int> requiredIntList = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(""requiredStringList"")){
global::System.Collections.Generic.List<string> array = new global::System.Collections.Generic.List<string>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetString());}
requiredStringList = array;
continue;
}
if(property.NameEquals(""requiredIntList"")){
global::System.Collections.Generic.List<int> array = new global::System.Collections.Generic.List<int>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetInt32());}
requiredIntList = array;
continue;
}
}
return new global::Cadl.TestServer.CollectionPropertiesBasic.RoundTripModel(requiredStringList, requiredIntList);}

internal global::Azure.Core.RequestContent ToRequestContent()
{
var content = new global::Azure.Core.Utf8JsonRequestContent();
content.JsonWriter.WriteObjectValue(this);
return content;
}

internal static global::Cadl.TestServer.CollectionPropertiesBasic.RoundTripModel FromResponse(global::Azure.Response response)
{
using var document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return DeserializeRoundTripModel(document.RootElement);
}
}
}
"
            }
        };
    }

}
