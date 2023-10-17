// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtMockAndSample.Models
{
    internal partial class FirewallPolicyFilterRuleCollectionAction : IUtf8JsonSerializable, IModelJsonSerializable<FirewallPolicyFilterRuleCollectionAction>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<FirewallPolicyFilterRuleCollectionAction>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<FirewallPolicyFilterRuleCollectionAction>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ActionType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ActionType.Value.ToString());
            }
            writer.WriteEndObject();
        }

        FirewallPolicyFilterRuleCollectionAction IModelJsonSerializable<FirewallPolicyFilterRuleCollectionAction>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFirewallPolicyFilterRuleCollectionAction(document.RootElement, options);
        }

        BinaryData IModelSerializable<FirewallPolicyFilterRuleCollectionAction>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        FirewallPolicyFilterRuleCollectionAction IModelSerializable<FirewallPolicyFilterRuleCollectionAction>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeFirewallPolicyFilterRuleCollectionAction(document.RootElement, options);
        }

        internal static FirewallPolicyFilterRuleCollectionAction DeserializeFirewallPolicyFilterRuleCollectionAction(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<FirewallPolicyFilterRuleCollectionActionType> type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    type = new FirewallPolicyFilterRuleCollectionActionType(property.Value.GetString());
                    continue;
                }
            }
            return new FirewallPolicyFilterRuleCollectionAction(Optional.ToNullable(type));
        }
    }
}
