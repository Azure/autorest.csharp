// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace model_flattening.Models
{
    public partial class FlattenedProductProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (PName != null)
            {
                writer.WritePropertyName("p.name");
                writer.WriteStringValue(PName);
            }
            if (Type != null)
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(Type);
            }
            if (ProvisioningStateValues != null)
            {
                writer.WritePropertyName("provisioningStateValues");
                writer.WriteStringValue(ProvisioningStateValues.Value.ToString());
            }
            if (ProvisioningState != null)
            {
                writer.WritePropertyName("provisioningState");
                writer.WriteStringValue(ProvisioningState);
            }
            writer.WriteEndObject();
        }
        internal static FlattenedProductProperties DeserializeFlattenedProductProperties(JsonElement element)
        {
            FlattenedProductProperties result = new FlattenedProductProperties();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("p.name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.PName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("provisioningStateValues"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ProvisioningStateValues = new FlattenedProductPropertiesProvisioningStateValues(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("provisioningState"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ProvisioningState = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
