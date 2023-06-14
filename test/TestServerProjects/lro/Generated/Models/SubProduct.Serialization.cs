// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace lro.Models
{
    public partial class SubProduct : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(ProvisioningState))
            {
                writer.WritePropertyName("provisioningState"u8);
                writer.WriteStringValue(ProvisioningState);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static SubProduct DeserializeSubProduct(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> id = default;
            Optional<string> provisioningState = default;
            Optional<SubProductPropertiesProvisioningStateValues> provisioningStateValues = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("provisioningStateValues"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningStateValues = new SubProductPropertiesProvisioningStateValues(property0.Value.GetString());
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new SubProduct(id.Value, provisioningState.Value, Optional.ToNullable(provisioningStateValues));
        }
    }
}
