// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class HeaderActionParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("headerAction"u8);
            writer.WriteStringValue(HeaderAction.ToString());
            writer.WritePropertyName("headerName"u8);
            writer.WriteStringValue(HeaderName);
            if (Optional.IsDefined(Value))
            {
                writer.WritePropertyName("value"u8);
                writer.WriteStringValue(Value);
            }
            writer.WriteEndObject();
        }

        internal static HeaderActionParameters DeserializeHeaderActionParameters(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            HeaderActionParametersTypeName typeName = default;
            HeaderAction headerAction = default;
            string headerName = default;
            Optional<string> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new HeaderActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("headerAction"u8))
                {
                    headerAction = new HeaderAction(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("headerName"u8))
                {
                    headerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"u8))
                {
                    value = property.Value.GetString();
                    continue;
                }
            }
            return new HeaderActionParameters(typeName, headerAction, headerName, value.Value);
        }
    }
}
