// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class Match : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("score");
            writer.WriteNumberValue(Score);
            writer.WritePropertyName("text");
            writer.WriteStringValue(Text);
            writer.WritePropertyName("offset");
            writer.WriteNumberValue(Offset);
            writer.WritePropertyName("length");
            writer.WriteNumberValue(Length);
            writer.WriteEndObject();
        }
        internal static Match DeserializeMatch(JsonElement element)
        {
            Match result = new Match();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("score"))
                {
                    result.Score = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("text"))
                {
                    result.Text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("offset"))
                {
                    result.Offset = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("length"))
                {
                    result.Length = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
