﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers.Tests;
using AutoRest.CSharp.Output.Models.Types;
using NUnit.Framework;

namespace AutoRest.CSharp.Generation.Writers.Tests
{
    public class OptionalPropertyWritingTests : ModelGenerationTestBase
    {
        [TestCaseSource(nameof(RoundTripModelCase))]
        public void RoundTripModel(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/bed837a2e29e55569360206afa3393e044dfb070/packages/cadl-ranch-specs/http/models/optional-properties/main.cadl#L35-L38
            var model = new ModelTypeProvider(
                new InputModelType("RoundTripModel", "Cadl.TestServer.OptionalProperties.Models", "public", "Round-trip model with optional properties.", InputModelTypeUsage.RoundTrip,
                    OptionalProperties,
                    null, null, null),
                new TypeFactory(null),
                "test",
                null);

            ValidateGeneratedCodes(model, expectedModelCodes, expectedSerializationCodes);
        }

        [TestCaseSource(nameof(InputModelCase))]
        public void InputModel(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/bed837a2e29e55569360206afa3393e044dfb070/packages/cadl-ranch-specs/http/models/optional-properties/main.cadl#L15-L28
            var model = new ModelTypeProvider(
                new InputModelType("InputModel", "Cadl.TestServer.OptionalProperties.Models", "public", "Input model with optional properties.", InputModelTypeUsage.Input,
                    OptionalProperties,
                    null, null, null),
                new TypeFactory(null),
                "test",
                null);

            ValidateGeneratedCodes(model, expectedModelCodes, expectedSerializationCodes);
        }

        [TestCaseSource(nameof(OutputModelCase))]
        public void OutputModel(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/bed837a2e29e55569360206afa3393e044dfb070/packages/cadl-ranch-specs/http/models/optional-properties/main.cadl#L30-L33
            var model = new ModelTypeProvider(
                new InputModelType("OutputModel", "Cadl.TestServer.OptionalProperties.Models", "public", "Output model with optional properties.", InputModelTypeUsage.Output,
                    OptionalProperties,
                    null, null, null),
                new TypeFactory(null),
                "test",
                null);

            ValidateGeneratedCodes(model, expectedModelCodes, expectedSerializationCodes);
        }

        private static readonly IReadOnlyList<InputModelProperty> OptionalProperties = new List<InputModelProperty>{
            new InputModelProperty("optionalString", "optionalString", "Optional string, illustrating an optional reference type property.", InputPrimitiveType.String, false, false, false),
            new InputModelProperty("optionalInt", "optionalInt", "Optional int, illustrating an optional reference type property.", InputPrimitiveType.Int32, false, false, false),
            new InputModelProperty("optionalStringList", "optionalStringList", "Optional string collection.", new InputListType("optionalStringList", InputPrimitiveType.String), false, false, false),
            new InputModelProperty("optionalIntList", "optionalIntList", "Optional int collection.", new InputListType("optionalIntList", InputPrimitiveType.Int32), false, false, false),
        };

        // below are test cases
        private static readonly object[] RoundTripModelCase =
        {
            new string[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Cadl.TestServer.OptionalProperties.Models
{
/// <summary> Round-trip model with optional properties. </summary>
public partial class RoundTripModel
{
/// <summary> Initializes a new instance of RoundTripModel. </summary>
public RoundTripModel()
{
OptionalStringList = new global::Azure.Core.ChangeTrackingList<string>();
OptionalIntList = new global::Azure.Core.ChangeTrackingList<int>();
}
/// <summary> Initializes a new instance of RoundTripModel. </summary>
/// <param name=""optionalString""> Optional string, illustrating an optional reference type property. </param>
/// <param name=""optionalInt""> Optional int, illustrating an optional reference type property. </param>
/// <param name=""optionalStringList""> Optional string collection. </param>
/// <param name=""optionalIntList""> Optional int collection. </param>
internal RoundTripModel(string optionalString,int optionalInt,global::System.Collections.Generic.IList<string> optionalStringList,global::System.Collections.Generic.IList<int> optionalIntList)
{
OptionalString = optionalString;
OptionalInt = optionalInt;
OptionalStringList = optionalStringList;
OptionalIntList = optionalIntList;
}

/// <summary> Optional string, illustrating an optional reference type property. </summary>
public string OptionalString{ get; set; }

/// <summary> Optional int, illustrating an optional reference type property. </summary>
public int OptionalInt{ get; set; }

/// <summary> Optional string collection. </summary>
public global::System.Collections.Generic.IList<string> OptionalStringList{ get; }

/// <summary> Optional int collection. </summary>
public global::System.Collections.Generic.IList<int> OptionalIntList{ get; }
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

namespace Cadl.TestServer.OptionalProperties.Models
{
public partial class RoundTripModel: global::Azure.Core.IUtf8JsonSerializable
{
void global::Azure.Core.IUtf8JsonSerializable.Write(global::System.Text.Json.Utf8JsonWriter writer)
{
writer.WriteStartObject();
if (global::Azure.Core.Optional.IsDefined(OptionalString))
{
writer.WritePropertyName(""optionalString"");
writer.WriteStringValue(OptionalString);
}
if (global::Azure.Core.Optional.IsDefined(OptionalInt))
{
writer.WritePropertyName(""optionalInt"");
writer.WriteNumberValue(OptionalInt);
}
if (global::Azure.Core.Optional.IsCollectionDefined(OptionalStringList))
{
writer.WritePropertyName(""optionalStringList"");
writer.WriteStartArray();
foreach (var item in OptionalStringList)
{
writer.WriteStringValue(item);
}
writer.WriteEndArray();
}
if (global::Azure.Core.Optional.IsCollectionDefined(OptionalIntList))
{
writer.WritePropertyName(""optionalIntList"");
writer.WriteStartArray();
foreach (var item in OptionalIntList)
{
writer.WriteNumberValue(item);
}
writer.WriteEndArray();
}
writer.WriteEndObject();
}

internal static global::Cadl.TestServer.OptionalProperties.Models.RoundTripModel DeserializeRoundTripModel(global::System.Text.Json.JsonElement element)
{
global::Azure.Core.Optional<string> optionalString = default;
global::Azure.Core.Optional<int> optionalInt = default;
global::Azure.Core.Optional<global::System.Collections.Generic.IList<string>> optionalStringList = default;
global::Azure.Core.Optional<global::System.Collections.Generic.IList<int>> optionalIntList = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(""optionalString"")){
optionalString = property.Value.GetString();
continue;
}
if(property.NameEquals(""optionalInt"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
optionalInt = property.Value.GetInt32();
continue;
}
if(property.NameEquals(""optionalStringList"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
global::System.Collections.Generic.List<string> array = new global::System.Collections.Generic.List<string>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetString());}
optionalStringList = array;
continue;
}
if(property.NameEquals(""optionalIntList"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
global::System.Collections.Generic.List<int> array = new global::System.Collections.Generic.List<int>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetInt32());}
optionalIntList = array;
continue;
}
}
return new global::Cadl.TestServer.OptionalProperties.Models.RoundTripModel(optionalString, optionalInt, global::Azure.Core.Optional.ToList(optionalStringList), global::Azure.Core.Optional.ToList(optionalIntList));}

internal global::Azure.Core.RequestContent ToRequestContent()
{
var content = new global::Azure.Core.Utf8JsonRequestContent();
content.JsonWriter.WriteObjectValue(this);
return content;
}

internal static global::Cadl.TestServer.OptionalProperties.Models.RoundTripModel FromResponse(global::Azure.Response response)
{
using var document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return DeserializeRoundTripModel(document.RootElement);
}
}
}
"
            }
        };

        private static readonly object[] InputModelCase =
        {
            new string[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Cadl.TestServer.OptionalProperties.Models
{
/// <summary> Input model with optional properties. </summary>
public partial class InputModel
{
/// <summary> Initializes a new instance of InputModel. </summary>
public InputModel()
{
OptionalStringList = new global::Azure.Core.ChangeTrackingList<string>();
OptionalIntList = new global::Azure.Core.ChangeTrackingList<int>();
}

/// <summary> Optional string, illustrating an optional reference type property. </summary>
public string OptionalString{ get; set; }

/// <summary> Optional int, illustrating an optional reference type property. </summary>
public int OptionalInt{ get; set; }

/// <summary> Optional string collection. </summary>
public global::System.Collections.Generic.IList<string> OptionalStringList{ get; }

/// <summary> Optional int collection. </summary>
public global::System.Collections.Generic.IList<int> OptionalIntList{ get; }
}
}
",
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Cadl.TestServer.OptionalProperties.Models
{
public partial class InputModel: global::Azure.Core.IUtf8JsonSerializable
{
void global::Azure.Core.IUtf8JsonSerializable.Write(global::System.Text.Json.Utf8JsonWriter writer)
{
writer.WriteStartObject();
if (global::Azure.Core.Optional.IsDefined(OptionalString))
{
writer.WritePropertyName(""optionalString"");
writer.WriteStringValue(OptionalString);
}
if (global::Azure.Core.Optional.IsDefined(OptionalInt))
{
writer.WritePropertyName(""optionalInt"");
writer.WriteNumberValue(OptionalInt);
}
if (global::Azure.Core.Optional.IsCollectionDefined(OptionalStringList))
{
writer.WritePropertyName(""optionalStringList"");
writer.WriteStartArray();
foreach (var item in OptionalStringList)
{
writer.WriteStringValue(item);
}
writer.WriteEndArray();
}
if (global::Azure.Core.Optional.IsCollectionDefined(OptionalIntList))
{
writer.WritePropertyName(""optionalIntList"");
writer.WriteStartArray();
foreach (var item in OptionalIntList)
{
writer.WriteNumberValue(item);
}
writer.WriteEndArray();
}
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

        private static readonly object[] OutputModelCase =
        {
            new string[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Cadl.TestServer.OptionalProperties.Models
{
/// <summary> Output model with optional properties. </summary>
public partial class OutputModel
{
/// <summary> Initializes a new instance of OutputModel. </summary>
internal OutputModel()
{
OptionalStringList = new List<string>(0).AsReadOnly();
OptionalIntList = new List<int>(0).AsReadOnly();
}
/// <summary> Initializes a new instance of OutputModel. </summary>
/// <param name=""optionalString""> Optional string, illustrating an optional reference type property. </param>
/// <param name=""optionalInt""> Optional int, illustrating an optional reference type property. </param>
/// <param name=""optionalStringList""> Optional string collection. </param>
/// <param name=""optionalIntList""> Optional int collection. </param>
internal OutputModel(string optionalString,int optionalInt,global::System.Collections.Generic.IReadOnlyList<string> optionalStringList,global::System.Collections.Generic.IReadOnlyList<int> optionalIntList)
{
OptionalString = optionalString;
OptionalInt = optionalInt;
OptionalStringList = optionalStringList;
OptionalIntList = optionalIntList;
}

/// <summary> Optional string, illustrating an optional reference type property. </summary>
public string OptionalString{ get; }

/// <summary> Optional int, illustrating an optional reference type property. </summary>
public int OptionalInt{ get; }

/// <summary> Optional string collection. </summary>
public global::System.Collections.Generic.IReadOnlyList<string> OptionalStringList{ get; }

/// <summary> Optional int collection. </summary>
public global::System.Collections.Generic.IReadOnlyList<int> OptionalIntList{ get; }
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

namespace Cadl.TestServer.OptionalProperties.Models
{
public partial class OutputModel
{
internal static global::Cadl.TestServer.OptionalProperties.Models.OutputModel DeserializeOutputModel(global::System.Text.Json.JsonElement element)
{
global::Azure.Core.Optional<string> optionalString = default;
global::Azure.Core.Optional<int> optionalInt = default;
global::Azure.Core.Optional<global::System.Collections.Generic.IReadOnlyList<string>> optionalStringList = default;
global::Azure.Core.Optional<global::System.Collections.Generic.IReadOnlyList<int>> optionalIntList = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(""optionalString"")){
optionalString = property.Value.GetString();
continue;
}
if(property.NameEquals(""optionalInt"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
optionalInt = property.Value.GetInt32();
continue;
}
if(property.NameEquals(""optionalStringList"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
global::System.Collections.Generic.List<string> array = new global::System.Collections.Generic.List<string>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetString());}
optionalStringList = array;
continue;
}
if(property.NameEquals(""optionalIntList"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
global::System.Collections.Generic.List<int> array = new global::System.Collections.Generic.List<int>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetInt32());}
optionalIntList = array;
continue;
}
}
return new global::Cadl.TestServer.OptionalProperties.Models.OutputModel(optionalString, optionalInt, global::Azure.Core.Optional.ToList(optionalStringList), global::Azure.Core.Optional.ToList(optionalIntList));}

internal static global::Cadl.TestServer.OptionalProperties.Models.OutputModel FromResponse(global::Azure.Response response)
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
