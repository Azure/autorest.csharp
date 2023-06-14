// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            writer.WritePropertyName("RequiredString"u8);
            writer.WriteStringValue(RequiredString);
            writer.WritePropertyName("RequiredInt"u8);
            writer.WriteNumberValue(RequiredInt);
            writer.WritePropertyName("RequiredStringList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredStringList)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("RequiredIntList"u8);
            writer.WriteStartArray();
            foreach (var item in RequiredIntList)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(NonRequiredString))
            {
                writer.WritePropertyName("NonRequiredString"u8);
                writer.WriteStringValue(NonRequiredString);
            }
            if (Optional.IsDefined(NonRequiredInt))
            {
                writer.WritePropertyName("NonRequiredInt"u8);
                writer.WriteNumberValue(NonRequiredInt.Value);
            }
            if (Optional.IsCollectionDefined(NonRequiredStringList))
            {
                writer.WritePropertyName("NonRequiredStringList"u8);
                writer.WriteStartArray();
                foreach (var item in NonRequiredStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(NonRequiredIntList))
            {
                writer.WritePropertyName("NonRequiredIntList"u8);
                writer.WriteStartArray();
                foreach (var item in NonRequiredIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            if (RequiredNullableString != null)
            {
                writer.WritePropertyName("RequiredNullableString"u8);
                writer.WriteStringValue(RequiredNullableString);
            }
            else
            {
                writer.WriteNull("RequiredNullableString");
            }
            if (RequiredNullableInt != null)
            {
                writer.WritePropertyName("RequiredNullableInt"u8);
                writer.WriteNumberValue(RequiredNullableInt.Value);
            }
            else
            {
                writer.WriteNull("RequiredNullableInt");
            }
            if (RequiredNullableStringList != null)
            {
                writer.WritePropertyName("RequiredNullableStringList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredNullableStringList)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("RequiredNullableStringList");
            }
            if (RequiredNullableIntList != null)
            {
                writer.WritePropertyName("RequiredNullableIntList"u8);
                writer.WriteStartArray();
                foreach (var item in RequiredNullableIntList)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("RequiredNullableIntList");
            }
            if (Optional.IsDefined(NonRequiredNullableString))
            {
                if (NonRequiredNullableString != null)
                {
                    writer.WritePropertyName("NonRequiredNullableString"u8);
                    writer.WriteStringValue(NonRequiredNullableString);
                }
                else
                {
                    writer.WriteNull("NonRequiredNullableString");
                }
            }
            if (Optional.IsDefined(NonRequiredNullableInt))
            {
                if (NonRequiredNullableInt != null)
                {
                    writer.WritePropertyName("NonRequiredNullableInt"u8);
                    writer.WriteNumberValue(NonRequiredNullableInt.Value);
                }
                else
                {
                    writer.WriteNull("NonRequiredNullableInt");
                }
            }
            if (Optional.IsCollectionDefined(NonRequiredNullableStringList))
            {
                if (NonRequiredNullableStringList != null)
                {
                    writer.WritePropertyName("NonRequiredNullableStringList"u8);
                    writer.WriteStartArray();
                    foreach (var item in NonRequiredNullableStringList)
                    {
                        writer.WriteStringValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("NonRequiredNullableStringList");
                }
            }
            if (Optional.IsCollectionDefined(NonRequiredNullableIntList))
            {
                if (NonRequiredNullableIntList != null)
                {
                    writer.WritePropertyName("NonRequiredNullableIntList"u8);
                    writer.WriteStartArray();
                    foreach (var item in NonRequiredNullableIntList)
                    {
                        writer.WriteNumberValue(item);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("NonRequiredNullableIntList");
                }
            }
            writer.WriteEndObject();
        }
    }
}
