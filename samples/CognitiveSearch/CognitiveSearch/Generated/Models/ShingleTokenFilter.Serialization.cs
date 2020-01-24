// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ShingleTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (MaxShingleSize != null)
            {
                writer.WritePropertyName("maxShingleSize");
                writer.WriteNumberValue(MaxShingleSize.Value);
            }
            if (MinShingleSize != null)
            {
                writer.WritePropertyName("minShingleSize");
                writer.WriteNumberValue(MinShingleSize.Value);
            }
            if (OutputUnigrams != null)
            {
                writer.WritePropertyName("outputUnigrams");
                writer.WriteBooleanValue(OutputUnigrams.Value);
            }
            if (OutputUnigramsIfNoShingles != null)
            {
                writer.WritePropertyName("outputUnigramsIfNoShingles");
                writer.WriteBooleanValue(OutputUnigramsIfNoShingles.Value);
            }
            if (TokenSeparator != null)
            {
                writer.WritePropertyName("tokenSeparator");
                writer.WriteStringValue(TokenSeparator);
            }
            if (FilterToken != null)
            {
                writer.WritePropertyName("filterToken");
                writer.WriteStringValue(FilterToken);
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static ShingleTokenFilter DeserializeShingleTokenFilter(JsonElement element)
        {
            ShingleTokenFilter result = new ShingleTokenFilter();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxShingleSize"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MaxShingleSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("minShingleSize"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MinShingleSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("outputUnigrams"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.OutputUnigrams = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("outputUnigramsIfNoShingles"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.OutputUnigramsIfNoShingles = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("tokenSeparator"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.TokenSeparator = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("filterToken"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.FilterToken = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
