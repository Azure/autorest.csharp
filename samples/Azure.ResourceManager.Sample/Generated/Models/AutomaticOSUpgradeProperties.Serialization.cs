// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    internal partial class AutomaticOSUpgradeProperties : IUtf8JsonSerializable, IModelJsonSerializable<AutomaticOSUpgradeProperties>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<AutomaticOSUpgradeProperties>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<AutomaticOSUpgradeProperties>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("automaticOSUpgradeSupported"u8);
            writer.WriteBooleanValue(AutomaticOSUpgradeSupported);
            writer.WriteEndObject();
        }

        AutomaticOSUpgradeProperties IModelJsonSerializable<AutomaticOSUpgradeProperties>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAutomaticOSUpgradeProperties(doc.RootElement, options);
        }

        BinaryData IModelSerializable<AutomaticOSUpgradeProperties>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        AutomaticOSUpgradeProperties IModelSerializable<AutomaticOSUpgradeProperties>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeAutomaticOSUpgradeProperties(document.RootElement, options);
        }

        internal static AutomaticOSUpgradeProperties DeserializeAutomaticOSUpgradeProperties(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool automaticOSUpgradeSupported = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("automaticOSUpgradeSupported"u8))
                {
                    automaticOSUpgradeSupported = property.Value.GetBoolean();
                    continue;
                }
            }
            return new AutomaticOSUpgradeProperties(automaticOSUpgradeSupported);
        }
    }
}
