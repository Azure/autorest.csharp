// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtExactMatchInheritance;

namespace MgmtExactMatchInheritance.Models
{
    internal partial class ExactMatchModel1ListResult : IUtf8JsonSerializable, IModelJsonSerializable<ExactMatchModel1ListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ExactMatchModel1ListResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ExactMatchModel1ListResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        ExactMatchModel1ListResult IModelJsonSerializable<ExactMatchModel1ListResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeExactMatchModel1ListResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ExactMatchModel1ListResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ExactMatchModel1ListResult IModelSerializable<ExactMatchModel1ListResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeExactMatchModel1ListResult(document.RootElement, options);
        }

        internal static ExactMatchModel1ListResult DeserializeExactMatchModel1ListResult(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<ExactMatchModel1Data>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ExactMatchModel1Data> array = new List<ExactMatchModel1Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ExactMatchModel1Data.DeserializeExactMatchModel1Data(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new ExactMatchModel1ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
