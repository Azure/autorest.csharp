// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class TokenInfo : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Token != null)
            {
                writer.WritePropertyName("token");
                writer.WriteStringValue(Token);
            }
            if (StartOffset != null)
            {
                writer.WritePropertyName("startOffset");
                writer.WriteNumberValue(StartOffset.Value);
            }
            if (EndOffset != null)
            {
                writer.WritePropertyName("endOffset");
                writer.WriteNumberValue(EndOffset.Value);
            }
            if (Position != null)
            {
                writer.WritePropertyName("position");
                writer.WriteNumberValue(Position.Value);
            }
            writer.WriteEndObject();
        }
        internal static TokenInfo DeserializeTokenInfo(JsonElement element)
        {
            TokenInfo result = new TokenInfo();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("token"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Token = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("startOffset"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.StartOffset = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("endOffset"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.EndOffset = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("position"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Position = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
