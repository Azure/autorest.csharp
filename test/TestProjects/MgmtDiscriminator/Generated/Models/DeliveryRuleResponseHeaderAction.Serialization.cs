// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtDiscriminator.Models
{
    public partial class DeliveryRuleResponseHeaderAction : IUtf8JsonSerializable, IModelJsonSerializable<DeliveryRuleResponseHeaderAction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DeliveryRuleResponseHeaderAction>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DeliveryRuleResponseHeaderAction>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("parameters"u8);
            writer.WriteObjectValue(Parameters);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name.ToString());
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Foo))
            {
                writer.WritePropertyName("foo"u8);
                writer.WriteStringValue(Foo);
            }
            writer.WriteEndObject();
        }

        DeliveryRuleResponseHeaderAction IModelJsonSerializable<DeliveryRuleResponseHeaderAction>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDeliveryRuleResponseHeaderAction(document.RootElement, options);
        }

        BinaryData IModelSerializable<DeliveryRuleResponseHeaderAction>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        DeliveryRuleResponseHeaderAction IModelSerializable<DeliveryRuleResponseHeaderAction>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeDeliveryRuleResponseHeaderAction(document.RootElement, options);
        }

        internal static DeliveryRuleResponseHeaderAction DeserializeDeliveryRuleResponseHeaderAction(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            HeaderActionParameters parameters = default;
            DeliveryRuleActionType name = default;
            Optional<string> foo = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("parameters"u8))
                {
                    parameters = HeaderActionParameters.DeserializeHeaderActionParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = new DeliveryRuleActionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("foo"u8))
                {
                    foo = property.Value.GetString();
                    continue;
                }
            }
            return new DeliveryRuleResponseHeaderAction(name, foo.Value, parameters);
        }
    }
}
