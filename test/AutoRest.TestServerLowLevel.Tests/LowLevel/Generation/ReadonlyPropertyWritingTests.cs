using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using NUnit.Framework;

namespace AutoRest.CSharp.Generation.Writers.Tests
{
    public class ReadonlyPropertyWritingTests : ModelGenerationTestBase
    {
        [TestCaseSource(nameof(RoundTripModelCase))]
        public void RoundTripModel(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/main/packages/cadl-ranch-specs/http/models/readonly-properties/main.cadl
            var model = new InputModelType("RoundTripModel", "Cadl.TestServer.ReadonlyProperties.Models", "public", "Readonly model", InputModelTypeUsage.RoundTrip,
                    ReadOnlyProperties, null, null, null);

            var library = new DpgOutputLibraryBuilder(new InputNamespace("Cadl.TestServer.ReadonlyProperties.Models", null, new List<string>(),
                new List<InputEnumType>(), new List<InputModelType> { ReadonlyModel, model }, new List<InputClient>(), new InputAuth()), default).Build(true);

            ValidateGeneratedCodes("RoundTripModel", expectedModelCodes, expectedSerializationCodes, library);
        }

        [TestCaseSource(nameof(OutputModelCase))]
        public void OutputModel(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/dc6d00c98983f34b2f723c90fe840678a863438c/packages/cadl-ranch-specs/http/models/readonly-properties/main.cadl#L24-L65
            var model = new InputModelType("OutputModel", "Cadl.TestServer.ReadonlyProperties.Models", "public", "Readonly model", InputModelTypeUsage.Output,
                    ReadOnlyProperties, null, null, null);

            var library = new DpgOutputLibraryBuilder(new InputNamespace("Cadl.TestServer.ReadonlyProperties.Models", null, new List<string>(),
                new List<InputEnumType>(), new List<InputModelType> { ReadonlyModel, model }, new List<InputClient>(), new InputAuth()), default).Build(true);

            ValidateGeneratedCodes("OutputModel", expectedModelCodes, expectedSerializationCodes, library);
        }

        // below are test cases
        private static readonly InputModelType ReadonlyModel = new InputModelType("ReadonlyModel", "Cadl.TestServer.ReadonlyProperties.Models", "public", "Readonly model", InputModelTypeUsage.Output,
                    new List<InputModelProperty> { RequiredStringProperty }, null, null, null);

        private static readonly IReadOnlyList<InputModelProperty> ReadOnlyProperties = new List<InputModelProperty>{
            new InputModelProperty("requiredReadonlyString", "requiredReadonlyString", "Required string, illustrating a readonly reference type property.", InputPrimitiveType.String, true, true, false),
            new InputModelProperty("requiredReadonlyInt", "requiredReadonlyInt", "Required int, illustrating a readonly reference type property.", InputPrimitiveType.Int32, true, true, false),
            new InputModelProperty("optionalReadonlyString", "optionalReadonlyString", "Optional string, illustrating a readonly reference type property.", InputPrimitiveType.String, false, true, false),
            new InputModelProperty("optionalReadonlyInt", "optionalReadonlyInt", "Optional int, illustrating a readonly reference type property.", InputPrimitiveType.Int32, false, true, false),
            new InputModelProperty("requiredReadonlyModel", "requiredReadonlyModel", "Required readonly model.", ReadonlyModel, true, true, false),
            new InputModelProperty("optionalReadonlyModel", "optionalReadonlyModel", "Optional readonly model", ReadonlyModel, false, true, false),
            new InputModelProperty("requiredReadonlyStringList", "requiredReadonlyStringList", "Required readonly string collection.", new InputListType("requiredReadonlyStringList", InputPrimitiveType.String), true, true, false),
            new InputModelProperty("requiredReadonlyIntList", "requiredReadonlyIntList", "Required readonly int collection.", new InputListType("requiredReadonlyIntList", InputPrimitiveType.Int32), true, true, false),
            new InputModelProperty("optionalReadonlyStringList", "optionalReadonlyStringList", "Optional readonly string collection.", new InputListType("optionalReadonlyStringList", InputPrimitiveType.String), false, true, false),
            new InputModelProperty("optionalReadonlyIntList", "optionalReadonlyIntList", "Optional readonly int collection.", new InputListType("optionalReadonlyIntList", InputPrimitiveType.Int32), false, true, false),
        };

        private static readonly object[] RoundTripModelCase =
        {
            new string[]
            {
                @"// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Cadl.TestServer.ReadonlyProperties.Models
{
/// <summary> Readonly model. </summary>
public partial class RoundTripModel
{
/// <summary> Initializes a new instance of RoundTripModel. </summary>
public RoundTripModel()
{
RequiredReadonlyStringList = Array.Empty<string>();
RequiredReadonlyIntList = Array.Empty<int>();
OptionalReadonlyStringList = Array.Empty<string>();
OptionalReadonlyIntList = Array.Empty<int>();
}
/// <summary> Initializes a new instance of RoundTripModel. </summary>
/// <param name=""requiredReadonlyString""> Required string, illustrating a readonly reference type property. </param>
/// <param name=""requiredReadonlyInt""> Required int, illustrating a readonly reference type property. </param>
/// <param name=""optionalReadonlyString""> Optional string, illustrating a readonly reference type property. </param>
/// <param name=""optionalReadonlyInt""> Optional int, illustrating a readonly reference type property. </param>
/// <param name=""requiredReadonlyModel""> Required readonly model. </param>
/// <param name=""optionalReadonlyModel""> Optional readonly model. </param>
/// <param name=""requiredReadonlyStringList""> Required readonly string collection. </param>
/// <param name=""requiredReadonlyIntList""> Required readonly int collection. </param>
/// <param name=""optionalReadonlyStringList""> Optional readonly string collection. </param>
/// <param name=""optionalReadonlyIntList""> Optional readonly int collection. </param>
internal RoundTripModel(string requiredReadonlyString,int requiredReadonlyInt,string optionalReadonlyString,int? optionalReadonlyInt,global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel requiredReadonlyModel,global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel optionalReadonlyModel,global::System.Collections.Generic.IReadOnlyList<string> requiredReadonlyStringList,global::System.Collections.Generic.IReadOnlyList<int> requiredReadonlyIntList,global::System.Collections.Generic.IReadOnlyList<string> optionalReadonlyStringList,global::System.Collections.Generic.IReadOnlyList<int> optionalReadonlyIntList)
{
RequiredReadonlyString = requiredReadonlyString;
RequiredReadonlyInt = requiredReadonlyInt;
OptionalReadonlyString = optionalReadonlyString;
OptionalReadonlyInt = optionalReadonlyInt;
RequiredReadonlyModel = requiredReadonlyModel;
OptionalReadonlyModel = optionalReadonlyModel;
RequiredReadonlyStringList = requiredReadonlyStringList;
RequiredReadonlyIntList = requiredReadonlyIntList;
OptionalReadonlyStringList = optionalReadonlyStringList;
OptionalReadonlyIntList = optionalReadonlyIntList;
}

/// <summary> Required string, illustrating a readonly reference type property. </summary>
public string RequiredReadonlyString{ get; }

/// <summary> Required int, illustrating a readonly reference type property. </summary>
public int RequiredReadonlyInt{ get; }

/// <summary> Optional string, illustrating a readonly reference type property. </summary>
public string OptionalReadonlyString{ get; }

/// <summary> Optional int, illustrating a readonly reference type property. </summary>
public int? OptionalReadonlyInt{ get; }

/// <summary> Required readonly model. </summary>
public global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel RequiredReadonlyModel{ get; }

/// <summary> Optional readonly model. </summary>
public global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel OptionalReadonlyModel{ get; }

/// <summary> Required readonly string collection. </summary>
public global::System.Collections.Generic.IReadOnlyList<string> RequiredReadonlyStringList{ get; }

/// <summary> Required readonly int collection. </summary>
public global::System.Collections.Generic.IReadOnlyList<int> RequiredReadonlyIntList{ get; }

/// <summary> Optional readonly string collection. </summary>
public global::System.Collections.Generic.IReadOnlyList<string> OptionalReadonlyStringList{ get; }

/// <summary> Optional readonly int collection. </summary>
public global::System.Collections.Generic.IReadOnlyList<int> OptionalReadonlyIntList{ get; }
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

namespace Cadl.TestServer.ReadonlyProperties.Models
{
public partial class RoundTripModel: global::Azure.Core.IUtf8JsonSerializable
{
void global::Azure.Core.IUtf8JsonSerializable.Write(global::System.Text.Json.Utf8JsonWriter writer)
{
writer.WriteStartObject();
writer.WriteEndObject();
}

internal static global::Cadl.TestServer.ReadonlyProperties.Models.RoundTripModel DeserializeRoundTripModel(global::System.Text.Json.JsonElement element)
{
string requiredReadonlyString = default;
int requiredReadonlyInt = default;
global::Azure.Core.Optional<string> optionalReadonlyString = default;
global::Azure.Core.Optional<int?> optionalReadonlyInt = default;
global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel requiredReadonlyModel = default;
global::Azure.Core.Optional<global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel> optionalReadonlyModel = default;
global::System.Collections.Generic.IReadOnlyList<string> requiredReadonlyStringList = default;
global::System.Collections.Generic.IReadOnlyList<int> requiredReadonlyIntList = default;
global::Azure.Core.Optional<global::System.Collections.Generic.IReadOnlyList<string>> optionalReadonlyStringList = default;
global::Azure.Core.Optional<global::System.Collections.Generic.IReadOnlyList<int>> optionalReadonlyIntList = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(""requiredReadonlyString"")){
requiredReadonlyString = property.Value.GetString();
continue;
}
if(property.NameEquals(""requiredReadonlyInt"")){
requiredReadonlyInt = property.Value.GetInt32();
continue;
}
if(property.NameEquals(""optionalReadonlyString"")){
optionalReadonlyString = property.Value.GetString();
continue;
}
if(property.NameEquals(""optionalReadonlyInt"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
optionalReadonlyInt = null;
continue;}
optionalReadonlyInt = property.Value.GetInt32();
continue;
}
if(property.NameEquals(""requiredReadonlyModel"")){
requiredReadonlyModel = global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel.DeserializeReadonlyModel(property.Value);
continue;
}
if(property.NameEquals(""optionalReadonlyModel"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
optionalReadonlyModel = global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel.DeserializeReadonlyModel(property.Value);
continue;
}
if(property.NameEquals(""requiredReadonlyStringList"")){
global::System.Collections.Generic.List<string> array = new global::System.Collections.Generic.List<string>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetString());}
requiredReadonlyStringList = array;
continue;
}
if(property.NameEquals(""requiredReadonlyIntList"")){
global::System.Collections.Generic.List<int> array = new global::System.Collections.Generic.List<int>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetInt32());}
requiredReadonlyIntList = array;
continue;
}
if(property.NameEquals(""optionalReadonlyStringList"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
global::System.Collections.Generic.List<string> array = new global::System.Collections.Generic.List<string>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetString());}
optionalReadonlyStringList = array;
continue;
}
if(property.NameEquals(""optionalReadonlyIntList"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
global::System.Collections.Generic.List<int> array = new global::System.Collections.Generic.List<int>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetInt32());}
optionalReadonlyIntList = array;
continue;
}
}
return new global::Cadl.TestServer.ReadonlyProperties.Models.RoundTripModel(requiredReadonlyString, requiredReadonlyInt, optionalReadonlyString, global::Azure.Core.Optional.ToNullable(optionalReadonlyInt), requiredReadonlyModel, optionalReadonlyModel, requiredReadonlyStringList, requiredReadonlyIntList, global::Azure.Core.Optional.ToList(optionalReadonlyStringList), global::Azure.Core.Optional.ToList(optionalReadonlyIntList));}

internal global::Azure.Core.RequestContent ToRequestContent()
{
var content = new global::Azure.Core.Utf8JsonRequestContent();
content.JsonWriter.WriteObjectValue(this);
return content;
}

internal static global::Cadl.TestServer.ReadonlyProperties.Models.RoundTripModel FromResponse(global::Azure.Response response)
{
using var document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return DeserializeRoundTripModel(document.RootElement);
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

namespace Cadl.TestServer.ReadonlyProperties.Models
{
/// <summary> Readonly model. </summary>
public partial class OutputModel
{
/// <summary> Initializes a new instance of OutputModel. </summary>
internal OutputModel()
{
RequiredReadonlyStringList = Array.Empty<string>();
RequiredReadonlyIntList = Array.Empty<int>();
OptionalReadonlyStringList = Array.Empty<string>();
OptionalReadonlyIntList = Array.Empty<int>();
}
/// <summary> Initializes a new instance of OutputModel. </summary>
/// <param name=""requiredReadonlyString""> Required string, illustrating a readonly reference type property. </param>
/// <param name=""requiredReadonlyInt""> Required int, illustrating a readonly reference type property. </param>
/// <param name=""optionalReadonlyString""> Optional string, illustrating a readonly reference type property. </param>
/// <param name=""optionalReadonlyInt""> Optional int, illustrating a readonly reference type property. </param>
/// <param name=""requiredReadonlyModel""> Required readonly model. </param>
/// <param name=""optionalReadonlyModel""> Optional readonly model. </param>
/// <param name=""requiredReadonlyStringList""> Required readonly string collection. </param>
/// <param name=""requiredReadonlyIntList""> Required readonly int collection. </param>
/// <param name=""optionalReadonlyStringList""> Optional readonly string collection. </param>
/// <param name=""optionalReadonlyIntList""> Optional readonly int collection. </param>
internal OutputModel(string requiredReadonlyString,int requiredReadonlyInt,string optionalReadonlyString,int? optionalReadonlyInt,global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel requiredReadonlyModel,global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel optionalReadonlyModel,global::System.Collections.Generic.IReadOnlyList<string> requiredReadonlyStringList,global::System.Collections.Generic.IReadOnlyList<int> requiredReadonlyIntList,global::System.Collections.Generic.IReadOnlyList<string> optionalReadonlyStringList,global::System.Collections.Generic.IReadOnlyList<int> optionalReadonlyIntList)
{
RequiredReadonlyString = requiredReadonlyString;
RequiredReadonlyInt = requiredReadonlyInt;
OptionalReadonlyString = optionalReadonlyString;
OptionalReadonlyInt = optionalReadonlyInt;
RequiredReadonlyModel = requiredReadonlyModel;
OptionalReadonlyModel = optionalReadonlyModel;
RequiredReadonlyStringList = requiredReadonlyStringList;
RequiredReadonlyIntList = requiredReadonlyIntList;
OptionalReadonlyStringList = optionalReadonlyStringList;
OptionalReadonlyIntList = optionalReadonlyIntList;
}

/// <summary> Required string, illustrating a readonly reference type property. </summary>
public string RequiredReadonlyString{ get; }

/// <summary> Required int, illustrating a readonly reference type property. </summary>
public int RequiredReadonlyInt{ get; }

/// <summary> Optional string, illustrating a readonly reference type property. </summary>
public string OptionalReadonlyString{ get; }

/// <summary> Optional int, illustrating a readonly reference type property. </summary>
public int? OptionalReadonlyInt{ get; }

/// <summary> Required readonly model. </summary>
public global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel RequiredReadonlyModel{ get; }

/// <summary> Optional readonly model. </summary>
public global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel OptionalReadonlyModel{ get; }

/// <summary> Required readonly string collection. </summary>
public global::System.Collections.Generic.IReadOnlyList<string> RequiredReadonlyStringList{ get; }

/// <summary> Required readonly int collection. </summary>
public global::System.Collections.Generic.IReadOnlyList<int> RequiredReadonlyIntList{ get; }

/// <summary> Optional readonly string collection. </summary>
public global::System.Collections.Generic.IReadOnlyList<string> OptionalReadonlyStringList{ get; }

/// <summary> Optional readonly int collection. </summary>
public global::System.Collections.Generic.IReadOnlyList<int> OptionalReadonlyIntList{ get; }
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

namespace Cadl.TestServer.ReadonlyProperties.Models
{
public partial class OutputModel
{
internal static global::Cadl.TestServer.ReadonlyProperties.Models.OutputModel DeserializeOutputModel(global::System.Text.Json.JsonElement element)
{
string requiredReadonlyString = default;
int requiredReadonlyInt = default;
global::Azure.Core.Optional<string> optionalReadonlyString = default;
global::Azure.Core.Optional<int?> optionalReadonlyInt = default;
global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel requiredReadonlyModel = default;
global::Azure.Core.Optional<global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel> optionalReadonlyModel = default;
global::System.Collections.Generic.IReadOnlyList<string> requiredReadonlyStringList = default;
global::System.Collections.Generic.IReadOnlyList<int> requiredReadonlyIntList = default;
global::Azure.Core.Optional<global::System.Collections.Generic.IReadOnlyList<string>> optionalReadonlyStringList = default;
global::Azure.Core.Optional<global::System.Collections.Generic.IReadOnlyList<int>> optionalReadonlyIntList = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(""requiredReadonlyString"")){
requiredReadonlyString = property.Value.GetString();
continue;
}
if(property.NameEquals(""requiredReadonlyInt"")){
requiredReadonlyInt = property.Value.GetInt32();
continue;
}
if(property.NameEquals(""optionalReadonlyString"")){
optionalReadonlyString = property.Value.GetString();
continue;
}
if(property.NameEquals(""optionalReadonlyInt"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
optionalReadonlyInt = null;
continue;}
optionalReadonlyInt = property.Value.GetInt32();
continue;
}
if(property.NameEquals(""requiredReadonlyModel"")){
requiredReadonlyModel = global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel.DeserializeReadonlyModel(property.Value);
continue;
}
if(property.NameEquals(""optionalReadonlyModel"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
optionalReadonlyModel = global::Cadl.TestServer.ReadonlyProperties.Models.ReadonlyModel.DeserializeReadonlyModel(property.Value);
continue;
}
if(property.NameEquals(""requiredReadonlyStringList"")){
global::System.Collections.Generic.List<string> array = new global::System.Collections.Generic.List<string>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetString());}
requiredReadonlyStringList = array;
continue;
}
if(property.NameEquals(""requiredReadonlyIntList"")){
global::System.Collections.Generic.List<int> array = new global::System.Collections.Generic.List<int>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetInt32());}
requiredReadonlyIntList = array;
continue;
}
if(property.NameEquals(""optionalReadonlyStringList"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
global::System.Collections.Generic.List<string> array = new global::System.Collections.Generic.List<string>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetString());}
optionalReadonlyStringList = array;
continue;
}
if(property.NameEquals(""optionalReadonlyIntList"")){
if (property.Value.ValueKind == global::System.Text.Json.JsonValueKind.Null)
{
property.ThrowNonNullablePropertyIsNull();
continue;}
global::System.Collections.Generic.List<int> array = new global::System.Collections.Generic.List<int>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(item.GetInt32());}
optionalReadonlyIntList = array;
continue;
}
}
return new global::Cadl.TestServer.ReadonlyProperties.Models.OutputModel(requiredReadonlyString, requiredReadonlyInt, optionalReadonlyString, global::Azure.Core.Optional.ToNullable(optionalReadonlyInt), requiredReadonlyModel, optionalReadonlyModel, requiredReadonlyStringList, requiredReadonlyIntList, global::Azure.Core.Optional.ToList(optionalReadonlyStringList), global::Azure.Core.Optional.ToList(optionalReadonlyIntList));}

internal static global::Cadl.TestServer.ReadonlyProperties.Models.OutputModel FromResponse(global::Azure.Response response)
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
