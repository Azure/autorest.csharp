// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class CopyAuthorizationResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("modelId"u8);
            writer.WriteStringValue(ModelId);
            writer.WritePropertyName("accessToken"u8);
            writer.WriteStringValue(AccessToken);
            writer.WritePropertyName("expirationDateTimeTicks"u8);
            writer.WriteNumberValue(ExpirationDateTimeTicks);
            writer.WriteEndObject();
        }

        internal static CopyAuthorizationResult DeserializeCopyAuthorizationResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string modelId = default;
            string accessToken = default;
            long expirationDateTimeTicks = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("modelId"u8))
                {
                    modelId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("accessToken"u8))
                {
                    accessToken = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("expirationDateTimeTicks"u8))
                {
                    expirationDateTimeTicks = property.Value.GetInt64();
                    continue;
                }
            }
            return new CopyAuthorizationResult(modelId, accessToken, expirationDateTimeTicks);
        }
    }
}
