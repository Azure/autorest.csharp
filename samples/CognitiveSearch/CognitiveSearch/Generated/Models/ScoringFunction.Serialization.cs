// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ScoringFunction : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type);
            writer.WritePropertyName("fieldName");
            writer.WriteStringValue(FieldName);
            writer.WritePropertyName("boost");
            writer.WriteNumberValue(Boost);
            if (Optional.IsDefined(Interpolation))
            {
                writer.WritePropertyName("interpolation");
                writer.WriteStringValue(Interpolation.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }

        internal static ScoringFunction DeserializeScoringFunction(JsonElement element)
        {
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "distance": return DistanceScoringFunction.DeserializeDistanceScoringFunction(element);
                    case "freshness": return FreshnessScoringFunction.DeserializeFreshnessScoringFunction(element);
                    case "magnitude": return MagnitudeScoringFunction.DeserializeMagnitudeScoringFunction(element);
                    case "tag": return TagScoringFunction.DeserializeTagScoringFunction(element);
                }
            }
            string type = default;
            string fieldName = default;
            double boost = default;
            Optional<ScoringFunctionInterpolation> interpolation = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fieldName"))
                {
                    fieldName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boost"))
                {
                    boost = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("interpolation"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    interpolation = property.Value.GetString().ToScoringFunctionInterpolation();
                    continue;
                }
            }
            return new ScoringFunction(type, fieldName, boost, Optional.ToNullable(interpolation));
        }
    }
}
