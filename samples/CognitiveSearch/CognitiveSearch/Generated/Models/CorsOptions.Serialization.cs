// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class CorsOptions : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("allowedOrigins");
            writer.WriteStartArray();
            foreach (var item in AllowedOrigins)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(MaxAgeInSeconds))
            {
                writer.WritePropertyName("maxAgeInSeconds");
                writer.WriteNumberValue(MaxAgeInSeconds.Value);
            }
            writer.WriteEndObject();
        }

        internal static CorsOptions DeserializeCorsOptions(JsonElement element)
        {
            IList<string> allowedOrigins = default;
            Optional<long> maxAgeInSeconds = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("allowedOrigins"))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    allowedOrigins = array;
                    continue;
                }
                if (property.NameEquals("maxAgeInSeconds"))
                {
                    maxAgeInSeconds = property.Value.GetInt64();
                    continue;
                }
            }
            return new CorsOptions(allowedOrigins, Optional.ToNullable(maxAgeInSeconds));
        }
    }
}
