// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    public partial class GuestConfigurationAssignmentData : IUtf8JsonSerializable, IModelJsonSerializable<GuestConfigurationAssignmentData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<GuestConfigurationAssignmentData>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<GuestConfigurationAssignmentData>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<GuestConfigurationAssignmentData>(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                ((IModelJsonSerializable<GuestConfigurationAssignmentProperties>)Properties).Serialize(writer, options);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location.Value);
            }
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static GuestConfigurationAssignmentData DeserializeGuestConfigurationAssignmentData(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<GuestConfigurationAssignmentProperties> properties = default;
            Optional<string> id = default;
            Optional<string> name = default;
            Optional<AzureLocation> location = default;
            Optional<ResourceType> type = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    properties = GuestConfigurationAssignmentProperties.DeserializeGuestConfigurationAssignmentProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("location"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new GuestConfigurationAssignmentData(id.Value, name.Value, Optional.ToNullable(location), Optional.ToNullable(type), properties.Value, rawData);
        }

        GuestConfigurationAssignmentData IModelJsonSerializable<GuestConfigurationAssignmentData>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<GuestConfigurationAssignmentData>(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeGuestConfigurationAssignmentData(doc.RootElement, options);
        }

        BinaryData IModelSerializable<GuestConfigurationAssignmentData>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<GuestConfigurationAssignmentData>(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        GuestConfigurationAssignmentData IModelSerializable<GuestConfigurationAssignmentData>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat<GuestConfigurationAssignmentData>(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeGuestConfigurationAssignmentData(doc.RootElement, options);
        }

        public static implicit operator RequestContent(GuestConfigurationAssignmentData model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator GuestConfigurationAssignmentData(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeGuestConfigurationAssignmentData(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
