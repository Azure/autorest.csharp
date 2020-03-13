// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class FieldValue : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type.ToSerialString());
            if (ValueString != null)
            {
                writer.WritePropertyName("valueString");
                writer.WriteStringValue(ValueString);
            }
            if (ValueDate != null)
            {
                writer.WritePropertyName("valueDate");
                writer.WriteStringValue(ValueDate);
            }
            if (ValueTime != null)
            {
                writer.WritePropertyName("valueTime");
                writer.WriteStringValue(ValueTime);
            }
            if (ValuePhoneNumber != null)
            {
                writer.WritePropertyName("valuePhoneNumber");
                writer.WriteStringValue(ValuePhoneNumber);
            }
            if (ValueNumber != null)
            {
                writer.WritePropertyName("valueNumber");
                writer.WriteNumberValue(ValueNumber.Value);
            }
            if (ValueInteger != null)
            {
                writer.WritePropertyName("valueInteger");
                writer.WriteNumberValue(ValueInteger.Value);
            }
            if (ValueArray != null)
            {
                writer.WritePropertyName("valueArray");
                writer.WriteStartArray();
                foreach (var item in ValueArray)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (ValueObject != null)
            {
                writer.WritePropertyName("valueObject");
                writer.WriteStartObject();
                foreach (var item in ValueObject)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Text != null)
            {
                writer.WritePropertyName("text");
                writer.WriteStringValue(Text);
            }
            if (BoundingBox != null)
            {
                writer.WritePropertyName("boundingBox");
                writer.WriteStartArray();
                foreach (var item in BoundingBox)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (Confidence != null)
            {
                writer.WritePropertyName("confidence");
                writer.WriteNumberValue(Confidence.Value);
            }
            if (Elements != null)
            {
                writer.WritePropertyName("elements");
                writer.WriteStartArray();
                foreach (var item in Elements)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Page != null)
            {
                writer.WritePropertyName("page");
                writer.WriteNumberValue(Page.Value);
            }
            writer.WriteEndObject();
        }

        internal static FieldValue DeserializeFieldValue(JsonElement element)
        {
            FieldValue result = new FieldValue();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    result.Type = property.Value.GetString().ToFieldValueType();
                    continue;
                }
                if (property.NameEquals("valueString"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ValueString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("valueDate"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ValueDate = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("valueTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ValueTime = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("valuePhoneNumber"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ValuePhoneNumber = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("valueNumber"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ValueNumber = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("valueInteger"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ValueInteger = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("valueArray"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ValueArray = new List<FieldValue>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.ValueArray.Add(DeserializeFieldValue(item));
                    }
                    continue;
                }
                if (property.NameEquals("valueObject"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ValueObject = new Dictionary<string, FieldValue>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        result.ValueObject.Add(property0.Name, DeserializeFieldValue(property0.Value));
                    }
                    continue;
                }
                if (property.NameEquals("text"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boundingBox"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.BoundingBox = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.BoundingBox.Add(item.GetSingle());
                    }
                    continue;
                }
                if (property.NameEquals("confidence"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Confidence = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("elements"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Elements = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Elements.Add(item.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("page"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Page = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
