// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class BaseModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(OptionalString))
            {
                writer.WritePropertyName("optionalString"u8);
                writer.WriteStringValue(OptionalString);
            }
            writer.WriteEndObject();
        }

        internal static BaseModel DeserializeBaseModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> optionalString = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("optionalString"u8))
                {
                    optionalString = property.Value.GetString();
                    continue;
                }
            }
            return new BaseModel(optionalString.Value);
        }
    }
}
