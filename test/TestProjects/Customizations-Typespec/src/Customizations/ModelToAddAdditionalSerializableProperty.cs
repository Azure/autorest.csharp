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

        /// <summary>
        /// Required int.
        /// This property is mocking this scenario:
        /// In the SDK, this property is defined as int, but in the actual traffic, this property comes as a string.
        /// We use this attribute to fix its serialization and deserialization using the following two methods
        /// </summary>
        [CodeGenMemberSerializationHooks(SerializationValueHookMethodName = nameof(WriteRequiredInt), DeserializationHookMethodName = nameof(DeserializeRequiredInt))]
        public int RequiredInt { get; set; }

        private void WriteRequiredInt(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(RequiredInt.ToString());
        }

        private static void DeserializeRequiredInt(JsonProperty property, ref int requiredInt)
        {
            requiredInt = int.Parse(property.Value.GetRawText());
        }
    }
}
