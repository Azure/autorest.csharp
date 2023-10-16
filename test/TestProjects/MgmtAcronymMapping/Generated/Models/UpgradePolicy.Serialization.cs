// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtAcronymMapping.Models
{
    public partial class UpgradePolicy : IUtf8JsonSerializable, IModelJsonSerializable<UpgradePolicy>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<UpgradePolicy>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<UpgradePolicy>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Mode))
            {
                writer.WritePropertyName("mode"u8);
                writer.WriteStringValue(Mode.Value.ToSerialString());
            }
            if (Optional.IsDefined(RollingUpgradePolicy))
            {
                writer.WritePropertyName("rollingUpgradePolicy"u8);
                writer.WriteObjectValue(RollingUpgradePolicy);
            }
            if (Optional.IsDefined(AutomaticOSUpgradePolicy))
            {
                writer.WritePropertyName("automaticOSUpgradePolicy"u8);
                writer.WriteObjectValue(AutomaticOSUpgradePolicy);
            }
            writer.WriteEndObject();
        }

        UpgradePolicy IModelJsonSerializable<UpgradePolicy>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeUpgradePolicy(doc.RootElement, options);
        }

        BinaryData IModelSerializable<UpgradePolicy>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        UpgradePolicy IModelSerializable<UpgradePolicy>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeUpgradePolicy(document.RootElement, options);
        }

        internal static UpgradePolicy DeserializeUpgradePolicy(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<UpgradeMode> mode = default;
            Optional<RollingUpgradePolicy> rollingUpgradePolicy = default;
            Optional<AutomaticOSUpgradePolicy> automaticOSUpgradePolicy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("mode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    mode = property.Value.GetString().ToUpgradeMode();
                    continue;
                }
                if (property.NameEquals("rollingUpgradePolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rollingUpgradePolicy = RollingUpgradePolicy.DeserializeRollingUpgradePolicy(property.Value);
                    continue;
                }
                if (property.NameEquals("automaticOSUpgradePolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    automaticOSUpgradePolicy = AutomaticOSUpgradePolicy.DeserializeAutomaticOSUpgradePolicy(property.Value);
                    continue;
                }
            }
            return new UpgradePolicy(Optional.ToNullable(mode), rollingUpgradePolicy.Value, automaticOSUpgradePolicy.Value);
        }
    }
}
