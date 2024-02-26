// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtExtensionResource.Models
{
    public partial class ParameterDefinitionsValue : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (ParameterType.HasValue)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ParameterType.Value.ToString());
            }
            if (!(AllowedValues is ChangeTrackingList<BinaryData> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("allowedValues"u8);
                writer.WriteStartArray();
                foreach (var item in AllowedValues)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item);
#else
                    using (JsonDocument document = JsonDocument.Parse(item))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                writer.WriteEndArray();
            }
            if (DefaultValue != null)
            {
                writer.WritePropertyName("defaultValue"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(DefaultValue);
#else
                using (JsonDocument document = JsonDocument.Parse(DefaultValue))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (Metadata != null)
            {
                writer.WritePropertyName("metadata"u8);
                writer.WriteObjectValue(Metadata);
            }
            writer.WriteEndObject();
        }

        internal static ParameterDefinitionsValue DeserializeParameterDefinitionsValue(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ParameterType type = default;
            IList<BinaryData> allowedValues = default;
            BinaryData defaultValue = default;
            ParameterDefinitionsValueMetadata metadata = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new ParameterType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("allowedValues"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<BinaryData> array = new List<BinaryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(BinaryData.FromString(item.GetRawText()));
                        }
                    }
                    allowedValues = array;
                    continue;
                }
                if (property.NameEquals("defaultValue"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    defaultValue = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("metadata"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    metadata = ParameterDefinitionsValueMetadata.DeserializeParameterDefinitionsValueMetadata(property.Value);
                    continue;
                }
            }
            return new ParameterDefinitionsValue(type, allowedValues ?? new ChangeTrackingList<BinaryData>(), defaultValue, metadata);
        }
    }
}
