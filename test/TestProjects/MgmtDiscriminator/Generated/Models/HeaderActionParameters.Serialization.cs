// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
            writer.WritePropertyName("typeName");
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("headerAction");
            writer.WriteStringValue(HeaderAction.ToString());
            writer.WritePropertyName("headerName");
            writer.WriteStringValue(HeaderName);
            if (Optional.IsDefined(Value))
            {
                writer.WritePropertyName("value");
                writer.WriteStringValue(Value);
            }
            writer.WriteEndObject();
        }

        internal static HeaderActionParameters DeserializeHeaderActionParameters(JsonElement element)
        {
            HeaderActionParametersTypeName typeName = default;
            HeaderAction headerAction = default;
            string headerName = default;
            Optional<string> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"))
                {
                    typeName = new HeaderActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("headerAction"))
                {
                    headerAction = new HeaderAction(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("headerName"))
                {
                    headerName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    value = property.Value.GetString();
                    continue;
                }
            }
            return new HeaderActionParameters(typeName, headerAction, headerName, value.Value);
        }
    }
}
