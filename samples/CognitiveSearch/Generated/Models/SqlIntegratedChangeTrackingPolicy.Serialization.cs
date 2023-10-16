// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class SqlIntegratedChangeTrackingPolicy : IUtf8JsonSerializable, IModelJsonSerializable<SqlIntegratedChangeTrackingPolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<SqlIntegratedChangeTrackingPolicy>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<SqlIntegratedChangeTrackingPolicy>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }

        SqlIntegratedChangeTrackingPolicy IModelJsonSerializable<SqlIntegratedChangeTrackingPolicy>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeSqlIntegratedChangeTrackingPolicy(doc.RootElement, options);
        }

        BinaryData IModelSerializable<SqlIntegratedChangeTrackingPolicy>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        SqlIntegratedChangeTrackingPolicy IModelSerializable<SqlIntegratedChangeTrackingPolicy>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeSqlIntegratedChangeTrackingPolicy(document.RootElement, options);
        }

        internal static SqlIntegratedChangeTrackingPolicy DeserializeSqlIntegratedChangeTrackingPolicy(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string odataType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
            }
            return new SqlIntegratedChangeTrackingPolicy(odataType);
        }
    }
}
