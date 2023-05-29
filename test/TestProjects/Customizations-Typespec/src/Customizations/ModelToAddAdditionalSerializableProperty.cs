// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CustomizationsInCadl.Models
{
    /// <summary> Model to add additional serializable property. </summary>
    public partial class ModelToAddAdditionalSerializableProperty
    {
        /// <summary> New property to serialize. </summary>
        [CodeGenMemberSerialization("additionalSerializableProperty")]
        public int AdditionalSerializableProperty { get; set; }

        /// <summary> New nullable property to serialize. </summary>
        [CodeGenMemberSerialization("additionalNullableSerializableProperty")]
        public int? AdditionalNullableSerializableProperty { get; set; }

        /// <summary>
        /// Required int.
        /// This property is mocking this scenario:
        /// In the SDK, this property is defined as int, but in the actual traffic, this property comes as a string.
        /// We use this attribute to fix its serialization and deserialization using the following two methods
        /// </summary>
        [CodeGenMemberSerializationHooks(SerializationValueHook = nameof(WriteRequiredIntValue), DeserializationValueHook = nameof(DeserializeRequiredIntValue))]
        public int RequiredInt { get; set; }

        /// <summary>
        /// Optional int.
        /// This property is mocking this scenario:
        /// We want to write null to the request when the value of this property is null.
        /// </summary>
        [CodeGenMemberSerializationHooks(SerializationHook = nameof(WriteOptionalInt))]
        public int? OptionalInt { get; set; }

        private void WriteOptionalInt(Utf8JsonWriter writer)
        {
            writer.WritePropertyName("optionalInt");
            if (OptionalInt.HasValue)
            {
                writer.WriteNumberValue(OptionalInt.Value);
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        private void WriteRequiredIntValue(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(RequiredInt.ToString());
        }

        private static void DeserializeRequiredIntValue(JsonProperty property, ref int requiredInt)
        {
            requiredInt = int.Parse(property.Value.GetRawText());
        }
    }
}
