// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace MgmtCustomizations.Models
{
    [CodeGenSerialization(nameof(Size), SerializationValueHook = nameof(SerializeSizeProperty), DeserializationValueHook = nameof(DeserializeSizeProperty))]
    [CodeGenSerialization(nameof(DateOfBirth), SerializationValueHook = nameof(SerializeDateOfBirthProperty))]
    [CodeGenSerialization(nameof(Color), new string[] { "properties", "color" }, SerializationValueHook = nameof(SerializeColorProperty), DeserializationValueHook = nameof(DeserializeColorProperty))]
    [CodeGenSerialization(nameof(Tags), "tags")]
    public abstract partial class Pet
    {
        /// <summary> The size of the pet. Despite we write type string here, in the real payload of this request, it is actually sending using a number, therefore the type in this swagger here is wrong and we need to fix it using customization code. </summary>
        public int Size { get; set; }

        /// <summary> Pet date of birth. </summary>
        public DateTimeOffset? DateOfBirth { get; set; }

        /// <summary> The color of the pet. </summary>
        public string Color { get; set; }

        /// <summary> Additional information about the pet. </summary>
        public IDictionary<string, string> Tags { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeSizeProperty(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(Size.ToString());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeSizeProperty(JsonProperty property, ref int size)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            if (int.TryParse(property.Value.GetString(), out var value))
            {
                size = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeDateOfBirthProperty(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(DateOfBirth.Value, "yyyy-MM-dd HH:mm");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeColorProperty(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(Color.ToString());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeColorProperty(JsonProperty property, ref string color)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            color = property.Value.GetString();
        }
    }
}
