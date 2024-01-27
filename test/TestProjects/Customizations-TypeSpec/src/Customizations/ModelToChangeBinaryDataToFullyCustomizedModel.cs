// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace CustomizationsInTsp.Models
{
    public partial class ModelToChangeBinaryDataToFullyCustomizedModel
    {
        /// <summary>
        /// Required union
        /// </summary>
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(WriteRequiredUnion), DeserializationValueHook = nameof(ReadRequiredUnion))]
        public CustomizedValue RequiredBinaryData { get; set; }

        /// <summary>
        /// Optional union
        /// </summary>
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(WriteOptionalUnion), DeserializationValueHook = nameof(ReadOptionalUnion))]
        public CustomizedValue OptionalBinaryData { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteRequiredUnion(Utf8JsonWriter writer)
        {
            //if (RequiredBinaryData.IsString)
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadRequiredUnion(JsonProperty property, ref CustomizedValue value)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteOptionalUnion(Utf8JsonWriter writer)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadOptionalUnion(JsonProperty property, ref Optional<CustomizedValue> value)
        {

        }
    }
}
