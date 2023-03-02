// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class MagnitudeScoringFunction : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("magnitude"u8);
            writer.WriteObjectValue(Parameters);
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type);
            writer.WritePropertyName("fieldName"u8);
            writer.WriteStringValue(FieldName);
            writer.WritePropertyName("boost"u8);
            writer.WriteNumberValue(Boost);
            if (Optional.IsDefined(Interpolation))
            {
                writer.WritePropertyName("interpolation"u8);
                writer.WriteStringValue(Interpolation.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }

        internal static MagnitudeScoringFunction DeserializeMagnitudeScoringFunction(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MagnitudeScoringParameters magnitude = default;
            string type = default;
            string fieldName = default;
            double boost = default;
            Optional<ScoringFunctionInterpolation> interpolation = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("magnitude"u8))
                {
                    magnitude = MagnitudeScoringParameters.DeserializeMagnitudeScoringParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fieldName"u8))
                {
                    fieldName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boost"u8))
                {
                    boost = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("interpolation"u8))
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
            return new MagnitudeScoringFunction(type, fieldName, boost, Optional.ToNullable(interpolation), magnitude);
        }
    }
}
