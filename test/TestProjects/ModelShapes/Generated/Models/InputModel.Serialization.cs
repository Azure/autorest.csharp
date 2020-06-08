// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace ModelShapes.Models
{
    public partial class InputModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("RequiredString");
            writer.WriteStringValue(RequiredString);
            writer.WritePropertyName("RequiredInt");
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("RequiredStringList");
            writer.WriteStartArray();
            foreach (var item in RequiredStringList)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("RequiredIntList");
            writer.WriteStartArray();
            foreach (var item in RequiredIntList)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (NonRequiredString != null)
            {
                writer.WritePropertyName("NonRequiredString");
                writer.WriteStringValue(NonRequiredString);
            }
            if (NonRequiredInt != null)
            {
                writer.WritePropertyName("NonRequiredInt");
                writer.WriteNumberValue(NonRequiredInt.Value);
            }
            if (NonRequiredStringList != null)
            {
                writer.WritePropertyName("NonRequiredStringList");
                writer.WriteStartArray();
                foreach (var item in NonRequiredStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (NonRequiredIntList != null)
            {
                writer.WritePropertyName("NonRequiredIntList");
                writer.WriteStartArray();
                foreach (var item in NonRequiredIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (RequiredNullableStringList != null)
            {
                writer.WritePropertyName("RequiredNullableStringList");
                writer.WriteStartArray();
                foreach (var item in RequiredNullableStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNullValue();
            }
            if (RequiredNullableIntList != null)
            {
                writer.WritePropertyName("RequiredNullableIntList");
                writer.WriteStartArray();
                foreach (var item in RequiredNullableIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNullValue();
            }
            writer.WriteEndObject();
        }
    }
}
