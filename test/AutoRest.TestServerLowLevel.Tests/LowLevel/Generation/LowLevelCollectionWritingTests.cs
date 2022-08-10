using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using NUnit.Framework;

namespace AutoRest.TestServerLowLevel.Tests.LowLevel.Generation
{
    public class LowLevelCollectionWritingTests
    {
        [TestCaseSource(nameof(PrimitiveCollectionPropertiesCase))]
        public void PrimitiveCollectionProperties(string expectedModelCodes, string expectedSerializationCodes)
        {
            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/main/packages/cadl-ranch-specs/http/models/primitive-properties/main.cadl
            var model = new ModelTypeProvider(
                new InputModelType("RoundTripModel", "Cadl.TestServer.CollectionPropertiesBasic.Models", "public",
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

        [TestCaseSource(nameof(ModelTypeCollectionPropertiesCase))]
        public void ModelTypeCollectionProperties(string expectedModelCodes, string expectedSerializationCodes)
        {
            IReadOnlyDictionary<InputEnumType, EnumType> EnumFactory(TypeFactory typeFactory)
                => new Dictionary<InputEnumType, EnumType>();

            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/main/packages/cadl-ranch-specs/http/models/collections-models/main.cadl#L36-L44
            var elementModelType = new InputModelType("SimpleModel", "Cadl.TestServer.ModelCollectionProperties.Models", "public",
                    new List<InputModelProperty>{
                        new InputModelProperty("requiredString", "requiredString", "Required string.", InputPrimitiveType.String, true, true, false),
                        new InputModelProperty("requiredInt", "requiredInt", "Required int.", InputPrimitiveType.Int32, true, true, false)
                    },
                null, null, null);
            var collectionModelType = new InputModelType("ModelCollectionModel", "Cadl.TestServer.ModelCollectionProperties.Models", "public",
                new List<InputModelProperty>{
                        new InputModelProperty("requiredModelCollection", "requiredModelCollection", "Required collection of models.", new InputListType("requiredModelCollection", elementModelType), true, false, false),
                        new InputModelProperty("optionalModelCollection", "optionalModelCollection", "Optional collection of models.", new InputListType("optionalModelCollection", elementModelType), false, false, false),
                },
                null, null, null);
            IReadOnlyDictionary<InputModelType, ModelTypeProvider> ModelsFactory(TypeFactory typeFactory)
            {
                var dict = new Dictionary<InputModelType, ModelTypeProvider>();
                dict.Add(elementModelType, new ModelTypeProvider(elementModelType, typeFactory, "test", null));
                dict.Add(collectionModelType, new ModelTypeProvider(collectionModelType, typeFactory, "test", null));
                return dict;
            }

            IReadOnlyList<LowLevelClient> RestClientsFactory(TypeFactory typeFactory)
                => new List<LowLevelClient>();

            var library = new DpgOutputLibrary(EnumFactory, ModelsFactory, RestClientsFactory, default);
            Assert.True(library.Models.Where(m => m.Declaration.Name == "ModelCollectionModel").Any());
            foreach (var model in library.Models)
            {
                if (model.Declaration.Name == "ModelCollectionModel")
                {
                    ValidateGeneratedCodes(model, expectedModelCodes, expectedSerializationCodes);
                }
            }
        }

        [TestCaseSource(nameof(ModelType2DCollectionPropertiesCase))]
        public void ModelType2DCollectionProperties(string expectedModelCodes, string expectedSerializationCodes)
        {
            IReadOnlyDictionary<InputEnumType, EnumType> EnumFactory(TypeFactory typeFactory)
                => new Dictionary<InputEnumType, EnumType>();

            // refer to the original CADL file: https://github.com/Azure/cadl-ranch/blob/main/packages/cadl-ranch-specs/http/models/collections-models/main.cadl#L36-L44
            var elementModelType = new InputModelType("SimpleModel", "Cadl.TestServer.ModelCollectionProperties.Models", "public",
                    new List<InputModelProperty>{
                        new InputModelProperty("requiredString", "requiredString", "Required string.", InputPrimitiveType.String, true, true, false),
                        new InputModelProperty("requiredInt", "requiredInt", "Required int.", InputPrimitiveType.Int32, true, true, false)
                    },
                null, null, null);
            var collectionModelType = new InputModelType("ModelCollectionModel", "Cadl.TestServer.ModelCollectionProperties.Models", "public",
                new List<InputModelProperty>{
                        new InputModelProperty("required2DCollection", "required2DCollection", "Required collection of models.", new InputListType("required2DCollection", new InputListType("requiredModelCollection", elementModelType)), true, false, false),
                        new InputModelProperty("optional2DCollection", "optional2DCollection", "Optional collection of models.", new InputListType("optional2DCollection", new InputListType("optionalModelCollection", elementModelType)), false, false, false),
                },
                null, null, null);
            IReadOnlyDictionary<InputModelType, ModelTypeProvider> ModelsFactory(TypeFactory typeFactory)
            {
                var dict = new Dictionary<InputModelType, ModelTypeProvider>();
                dict.Add(elementModelType, new ModelTypeProvider(elementModelType, typeFactory, "test", null));
                dict.Add(collectionModelType, new ModelTypeProvider(collectionModelType, typeFactory, "test", null));
                return dict;
            }

            IReadOnlyList<LowLevelClient> RestClientsFactory(TypeFactory typeFactory)
                => new List<LowLevelClient>();

            var library = new DpgOutputLibrary(EnumFactory, ModelsFactory, RestClientsFactory, default);
            Assert.True(library.Models.Where(m => m.Declaration.Name == "ModelCollectionModel").Any());
            foreach (var model in library.Models)
            {
                if (model.Declaration.Name == "ModelCollectionModel")
                {
                    ValidateGeneratedCodes(model, expectedModelCodes, expectedSerializationCodes);
                }
            }
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

namespace Cadl.TestServer.CollectionPropertiesBasic.Models
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

namespace Cadl.TestServer.CollectionPropertiesBasic.Models
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

internal static global::Cadl.TestServer.CollectionPropertiesBasic.Models.RoundTripModel DeserializeRoundTripModel(global::System.Text.Json.JsonElement element)
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
return new global::Cadl.TestServer.CollectionPropertiesBasic.Models.RoundTripModel(requiredStringList, requiredIntList);}

internal global::Azure.Core.RequestContent ToRequestContent()
{
var content = new global::Azure.Core.Utf8JsonRequestContent();
content.JsonWriter.WriteObjectValue(this);
return content;
}

internal static global::Cadl.TestServer.CollectionPropertiesBasic.Models.RoundTripModel FromResponse(global::Azure.Response response)
{
using var document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return DeserializeRoundTripModel(document.RootElement);
}
}
}
"
            }
        };
        private static readonly object[] ModelTypeCollectionPropertiesCase =
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

namespace Cadl.TestServer.ModelCollectionProperties.Models
{
public partial class ModelCollectionModel
{
/// <summary> Required collection of models. </summary>
public global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel> RequiredModelCollection{ get; }

/// <summary> Optional collection of models. </summary>
public global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel> OptionalModelCollection{ get; }

/// <summary> Initializes a new instance of ModelCollectionModel. </summary>
/// <param name=""requiredModelCollection""> Required collection of models. </param>
/// <exception cref=""global::System.ArgumentNullException""> <paramref name=""requiredModelCollection""/> is null. </exception>
public ModelCollectionModel(global::System.Collections.Generic.IEnumerable<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel> requiredModelCollection)
{
global::Azure.Core.Argument.AssertNotNull(requiredModelCollection, nameof(requiredModelCollection));

RequiredModelCollection = requiredModelCollection.ToList();
}
/// <summary> Initializes a new instance of ModelCollectionModel. </summary>
/// <param name=""requiredModelCollection""> Required collection of models. </param>
/// <exception cref=""global::System.ArgumentNullException""> <paramref name=""requiredModelCollection""/> is null. </exception>
internal ModelCollectionModel(global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel> requiredModelCollection)
{
global::Azure.Core.Argument.AssertNotNull(requiredModelCollection, nameof(requiredModelCollection));

RequiredModelCollection = requiredModelCollection;
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

namespace Cadl.TestServer.ModelCollectionProperties.Models
{
public partial class ModelCollectionModel: global::Azure.Core.IUtf8JsonSerializable
{
void global::Azure.Core.IUtf8JsonSerializable.Write(global::System.Text.Json.Utf8JsonWriter writer)
{
writer.WriteStartObject();
writer.WritePropertyName(""requiredModelCollection"");
writer.WriteStartArray();
foreach (var item in RequiredModelCollection)
{
writer.WriteObjectValue(item)
}
writer.WriteEndArray();
writer.WriteEndObject();
}

internal static global::Cadl.TestServer.ModelCollectionProperties.Models.ModelCollectionModel DeserializeModelCollectionModel(global::System.Text.Json.JsonElement element)
{
global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel> requiredModelCollection = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(""requiredModelCollection"")){
global::System.Collections.Generic.List<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel> array = new global::System.Collections.Generic.List<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel>();
foreach (var item in property.Value.EnumerateArray())
{
array.Add(global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel.DeserializeSimpleModel(item));}
requiredModelCollection = array;
continue;
}
}
return new global::Cadl.TestServer.ModelCollectionProperties.Models.ModelCollectionModel(requiredModelCollection);}

internal global::Azure.Core.RequestContent ToRequestContent()
{
var content = new global::Azure.Core.Utf8JsonRequestContent();
content.JsonWriter.WriteObjectValue(this);
return content;
}

internal static global::Cadl.TestServer.ModelCollectionProperties.Models.ModelCollectionModel FromResponse(global::Azure.Response response)
{
using var document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return DeserializeModelCollectionModel(document.RootElement);
}
}
}
"
            }
        };

        private static readonly object[] ModelType2DCollectionPropertiesCase =
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

namespace Cadl.TestServer.ModelCollectionProperties.Models
{
public partial class ModelCollectionModel
{
/// <summary> Required collection of models. </summary>
public global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel>> Required2DCollection{ get; }

/// <summary> Optional collection of models. </summary>
public global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel>> Optional2DCollection{ get; }

/// <summary> Initializes a new instance of ModelCollectionModel. </summary>
/// <param name=""required2DCollection""> Required collection of models. </param>
/// <exception cref=""global::System.ArgumentNullException""> <paramref name=""required2DCollection""/> is null. </exception>
public ModelCollectionModel(global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel>> required2DCollection)
{
global::Azure.Core.Argument.AssertNotNull(required2DCollection, nameof(required2DCollection));

Required2DCollection = required2DCollection.ToList();
}
/// <summary> Initializes a new instance of ModelCollectionModel. </summary>
/// <param name=""required2DCollection""> Required collection of models. </param>
/// <exception cref=""global::System.ArgumentNullException""> <paramref name=""required2DCollection""/> is null. </exception>
internal ModelCollectionModel(global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel>> required2DCollection)
{
global::Azure.Core.Argument.AssertNotNull(required2DCollection, nameof(required2DCollection));

Required2DCollection = required2DCollection;
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

namespace Cadl.TestServer.ModelCollectionProperties.Models
{
public partial class ModelCollectionModel: global::Azure.Core.IUtf8JsonSerializable
{
void global::Azure.Core.IUtf8JsonSerializable.Write(global::System.Text.Json.Utf8JsonWriter writer)
{
writer.WriteStartObject();
writer.WritePropertyName(""required2DCollection"");
writer.WriteStartArray();
foreach (var item in Required2DCollection)
{
writer.WriteStartArray();
foreach (var item0 in item)
{
writer.WriteObjectValue(item0)
}
writer.WriteEndArray();
}
writer.WriteEndArray();
writer.WriteEndObject();
}

internal static global::Cadl.TestServer.ModelCollectionProperties.Models.ModelCollectionModel DeserializeModelCollectionModel(global::System.Text.Json.JsonElement element)
{
global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel>> required2DCollection = default;
foreach (var property in element.EnumerateObject())
{
if(property.NameEquals(""required2DCollection"")){
global::System.Collections.Generic.List<global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel>> array = new global::System.Collections.Generic.List<global::System.Collections.Generic.IList<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel>>();
foreach (var item in property.Value.EnumerateArray())
{
global::System.Collections.Generic.List<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel> array0 = new global::System.Collections.Generic.List<global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel>();
foreach (var item0 in item.EnumerateArray())
{
array0.Add(global::Cadl.TestServer.ModelCollectionProperties.Models.SimpleModel.DeserializeSimpleModel(item0));}
array.Add(array0);}
required2DCollection = array;
continue;
}
}
return new global::Cadl.TestServer.ModelCollectionProperties.Models.ModelCollectionModel(required2DCollection);}

internal global::Azure.Core.RequestContent ToRequestContent()
{
var content = new global::Azure.Core.Utf8JsonRequestContent();
content.JsonWriter.WriteObjectValue(this);
return content;
}

internal static global::Cadl.TestServer.ModelCollectionProperties.Models.ModelCollectionModel FromResponse(global::Azure.Response response)
{
using var document = global::System.Text.Json.JsonDocument.Parse(response.Content);
return DeserializeModelCollectionModel(document.RootElement);
}
}
}
"
            }
        };
    }
}
