// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ScoringFunction : Azure.Core.IUtf8JsonSerializable
    {
        void Azure.Core.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type);
            writer.WritePropertyName("fieldName");
            writer.WriteStringValue(FieldName);
            writer.WritePropertyName("boost");
            writer.WriteNumberValue(Boost);
            if (Interpolation != null)
            {
                writer.WritePropertyName("interpolation");
                writer.WriteStringValue(Interpolation.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }
        internal static CognitiveSearch.Models.ScoringFunction DeserializeScoringFunction(System.Text.Json.JsonElement element)
        {
            if (element.TryGetProperty("type", out System.Text.Json.JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "distance": return CognitiveSearch.Models.DistanceScoringFunction.DeserializeDistanceScoringFunction(element);
                    case "freshness": return CognitiveSearch.Models.FreshnessScoringFunction.DeserializeFreshnessScoringFunction(element);
                    case "magnitude": return CognitiveSearch.Models.MagnitudeScoringFunction.DeserializeMagnitudeScoringFunction(element);
                    case "tag": return CognitiveSearch.Models.TagScoringFunction.DeserializeTagScoringFunction(element);
                }
            }
            CognitiveSearch.Models.ScoringFunction result = new CognitiveSearch.Models.ScoringFunction();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    result.Type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fieldName"))
                {
                    result.FieldName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boost"))
                {
                    result.Boost = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("interpolation"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Interpolation = property.Value.GetString().ToScoringFunctionInterpolation();
                    continue;
                }
            }
            return result;
        }
    }
}
