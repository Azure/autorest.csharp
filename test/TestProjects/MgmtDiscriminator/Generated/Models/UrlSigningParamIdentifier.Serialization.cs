// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class UrlSigningParamIdentifier : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("paramIndicator"u8);
            writer.WriteStringValue(ParamIndicator.ToString());
            writer.WritePropertyName("paramName"u8);
            writer.WriteStringValue(ParamName);
            writer.WriteEndObject();
        }

        internal static UrlSigningParamIdentifier DeserializeUrlSigningParamIdentifier(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ParamIndicator paramIndicator = default;
            string paramName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("paramIndicator"u8))
                {
                    paramIndicator = new ParamIndicator(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("paramName"u8))
                {
                    paramName = property.Value.GetString();
                    continue;
                }
            }
            return new UrlSigningParamIdentifier(paramIndicator, paramName);
        }
    }
}
