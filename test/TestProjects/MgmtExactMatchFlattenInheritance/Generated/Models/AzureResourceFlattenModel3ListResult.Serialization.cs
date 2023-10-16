// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtExactMatchFlattenInheritance.Models
{
    internal partial class AzureResourceFlattenModel3ListResult : IUtf8JsonSerializable, IModelJsonSerializable<AzureResourceFlattenModel3ListResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AzureResourceFlattenModel3ListResult>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AzureResourceFlattenModel3ListResult>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        AzureResourceFlattenModel3ListResult IModelJsonSerializable<AzureResourceFlattenModel3ListResult>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureResourceFlattenModel3ListResult(doc.RootElement, options);
        }

        BinaryData IModelSerializable<AzureResourceFlattenModel3ListResult>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        AzureResourceFlattenModel3ListResult IModelSerializable<AzureResourceFlattenModel3ListResult>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAzureResourceFlattenModel3ListResult(document.RootElement, options);
        }

        internal static AzureResourceFlattenModel3ListResult DeserializeAzureResourceFlattenModel3ListResult(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<AzureResourceFlattenModel3>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<AzureResourceFlattenModel3> array = new List<AzureResourceFlattenModel3>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(AzureResourceFlattenModel3.DeserializeAzureResourceFlattenModel3(item));
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
            return new AzureResourceFlattenModel3ListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
