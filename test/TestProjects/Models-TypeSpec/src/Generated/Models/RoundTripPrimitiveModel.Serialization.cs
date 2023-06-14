// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    public partial class RoundTripPrimitiveModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredString"u8);
            writer.WriteStringValue(RequiredString);
            writer.WritePropertyName("requiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("requiredInt64"u8);
            writer.WriteNumberValue(RequiredInt64);
            writer.WritePropertyName("requiredSafeInt"u8);
            writer.WriteNumberValue(RequiredSafeInt);
            writer.WritePropertyName("requiredFloat"u8);
            writer.WriteNumberValue(RequiredFloat);
            writer.WritePropertyName("required_Double"u8);
            writer.WriteNumberValue(RequiredDouble);
            writer.WritePropertyName("requiredBoolean"u8);
            writer.WriteBooleanValue(RequiredBoolean);
            writer.WritePropertyName("requiredDateTimeOffset"u8);
            writer.WriteStringValue(RequiredDateTimeOffset, "O");
            writer.WritePropertyName("requiredTimeSpan"u8);
            writer.WriteStringValue(RequiredTimeSpan, "P");
            writer.WritePropertyName("requiredCollectionWithNullableFloatElement"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredCollectionWithNullableFloatElement)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteNumberValue(item.Value);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static RoundTripPrimitiveModel DeserializeRoundTripPrimitiveModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredString = default;
            int requiredInt = default;
            long requiredInt64 = default;
            long requiredSafeInt = default;
            float requiredFloat = default;
            double requiredDouble = default;
            bool requiredBoolean = default;
            DateTimeOffset requiredDateTimeOffset = default;
            TimeSpan requiredTimeSpan = default;
            IList<float?> requiredCollectionWithNullableFloatElement = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredString"u8))
                {
                    requiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredInt"u8))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredInt64"u8))
                {
                    requiredInt64 = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("requiredSafeInt"u8))
                {
                    requiredSafeInt = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("requiredFloat"u8))
                {
                    requiredFloat = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("required_Double"u8))
                {
                    requiredDouble = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("requiredBoolean"u8))
                {
                    requiredBoolean = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("requiredDateTimeOffset"u8))
                {
                    requiredDateTimeOffset = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("requiredTimeSpan"u8))
                {
                    requiredTimeSpan = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("requiredCollectionWithNullableFloatElement"u8))
                {
                    List<float?> array = new List<float?>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetSingle());
                        }
                    }
                    requiredCollectionWithNullableFloatElement = array;
                    continue;
                }
            }
            return new RoundTripPrimitiveModel(requiredString, requiredInt, requiredInt64, requiredSafeInt, requiredFloat, requiredDouble, requiredBoolean, requiredDateTimeOffset, requiredTimeSpan, requiredCollectionWithNullableFloatElement);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static RoundTripPrimitiveModel FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRoundTripPrimitiveModel(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
