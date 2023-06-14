// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace FirstTestTypeSpec.Models
{
    public partial class Thing : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("requiredUnion"u8);
            writer.WriteStringValue(RequiredUnion);
            writer.WritePropertyName("requiredLiteralString"u8);
            writer.WriteStringValue(RequiredLiteralString.ToString());
            writer.WritePropertyName("requiredLiteralInt"u8);
            writer.WriteNumberValue(RequiredLiteralInt.ToSerialInt32());
            writer.WritePropertyName("requiredLiteralFloat"u8);
            writer.WriteNumberValue(RequiredLiteralFloat.ToSerialSingle());
            writer.WritePropertyName("requiredLiteralBool"u8);
            writer.WriteBooleanValue(RequiredLiteralBool);
            if (Optional.IsDefined(OptionalLiteralString))
            {
                writer.WritePropertyName("optionalLiteralString"u8);
                writer.WriteStringValue(OptionalLiteralString.Value.ToString());
            }
            if (Optional.IsDefined(OptionalLiteralInt))
            {
                writer.WritePropertyName("optionalLiteralInt"u8);
                writer.WriteNumberValue(OptionalLiteralInt.Value.ToSerialInt32());
            }
            if (Optional.IsDefined(OptionalLiteralFloat))
            {
                writer.WritePropertyName("optionalLiteralFloat"u8);
                writer.WriteNumberValue(OptionalLiteralFloat.Value.ToSerialSingle());
            }
            if (Optional.IsDefined(OptionalLiteralBool))
            {
                writer.WritePropertyName("optionalLiteralBool"u8);
                writer.WriteBooleanValue(OptionalLiteralBool.Value);
            }
            writer.WritePropertyName("requiredBadDescription"u8);
            writer.WriteStringValue(RequiredBadDescription);
            writer.WriteEndObject();
        }

        internal static Thing DeserializeThing(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string requiredUnion = default;
            ThingRequiredLiteralString requiredLiteralString = default;
            ThingRequiredLiteralInt requiredLiteralInt = default;
            ThingRequiredLiteralFloat requiredLiteralFloat = default;
            bool requiredLiteralBool = default;
            Optional<ThingOptionalLiteralString> optionalLiteralString = default;
            Optional<ThingOptionalLiteralInt> optionalLiteralInt = default;
            Optional<ThingOptionalLiteralFloat> optionalLiteralFloat = default;
            Optional<bool> optionalLiteralBool = default;
            string requiredBadDescription = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredUnion"u8))
                {
                    requiredUnion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredLiteralString"u8))
                {
                    requiredLiteralString = new ThingRequiredLiteralString(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requiredLiteralInt"u8))
                {
                    requiredLiteralInt = new ThingRequiredLiteralInt(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("requiredLiteralFloat"u8))
                {
                    requiredLiteralFloat = new ThingRequiredLiteralFloat(property.Value.GetSingle());
                    continue;
                }
                if (property.NameEquals("requiredLiteralBool"u8))
                {
                    requiredLiteralBool = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("optionalLiteralString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalLiteralString = new ThingOptionalLiteralString(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("optionalLiteralInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalLiteralInt = new ThingOptionalLiteralInt(property.Value.GetInt32());
                    continue;
                }
                if (property.NameEquals("optionalLiteralFloat"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalLiteralFloat = new ThingOptionalLiteralFloat(property.Value.GetSingle());
                    continue;
                }
                if (property.NameEquals("optionalLiteralBool"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    optionalLiteralBool = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("requiredBadDescription"u8))
                {
                    requiredBadDescription = property.Value.GetString();
                    continue;
                }
            }
            return new Thing(name, requiredUnion, requiredLiteralString, requiredLiteralInt, requiredLiteralFloat, requiredLiteralBool, Optional.ToNullable(optionalLiteralString), Optional.ToNullable(optionalLiteralInt), Optional.ToNullable(optionalLiteralFloat), Optional.ToNullable(optionalLiteralBool), requiredBadDescription);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static Thing FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeThing(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
