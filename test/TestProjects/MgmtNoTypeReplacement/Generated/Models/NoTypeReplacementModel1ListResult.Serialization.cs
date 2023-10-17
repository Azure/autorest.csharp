// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtNoTypeReplacement;

namespace MgmtNoTypeReplacement.Models
{
    internal partial class NoTypeReplacementModel1ListResult : IUtf8JsonSerializable, IModelJsonSerializable<NoTypeReplacementModel1ListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<NoTypeReplacementModel1ListResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<NoTypeReplacementModel1ListResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsCollectionDefined(Value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStartArray();
                foreach (var item in Value)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(NextLink))
            {
                writer.WritePropertyName("nextLink"u8);
                writer.WriteStringValue(NextLink);
            }
            writer.WriteEndObject();
        }

        NoTypeReplacementModel1ListResult IModelJsonSerializable<NoTypeReplacementModel1ListResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNoTypeReplacementModel1ListResult(document.RootElement, options);
        }

        BinaryData IModelSerializable<NoTypeReplacementModel1ListResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        NoTypeReplacementModel1ListResult IModelSerializable<NoTypeReplacementModel1ListResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeNoTypeReplacementModel1ListResult(document.RootElement, options);
        }

        internal static NoTypeReplacementModel1ListResult DeserializeNoTypeReplacementModel1ListResult(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<NoTypeReplacementModel1Data>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<NoTypeReplacementModel1Data> array = new List<NoTypeReplacementModel1Data>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NoTypeReplacementModel1Data.DeserializeNoTypeReplacementModel1Data(item));
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
            return new NoTypeReplacementModel1ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
