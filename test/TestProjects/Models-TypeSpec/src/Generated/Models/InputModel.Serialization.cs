// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    public partial class InputModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("requiredString"u8);
            writer.WriteStringValue(RequiredString);
            writer.WritePropertyName("requiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("requiredModel"u8);
            writer.WriteObjectValue(RequiredModel);
            writer.WritePropertyName("requiredIntCollection"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredIntCollection)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("requiredStringCollection"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredStringCollection)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("requiredModelCollection"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredModelCollection)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("requiredModelRecord"u8);
            writer.WriteStartObject();
            foreach (var item in RequiredModelRecord)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
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
            writer.WritePropertyName("requiredCollectionWithNullableBooleanElement"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredCollectionWithNullableBooleanElement)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteBooleanValue(item.Value);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
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
