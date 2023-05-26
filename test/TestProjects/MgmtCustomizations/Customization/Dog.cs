// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace MgmtCustomizations.Models
{
    public partial class Dog : Pet
    {
        /// <summary> A dog can bark. </summary>
        [CodeGenMemberSerialization("properties", "dog", "bark")] // use this attribute to let the serialization and deserialization have two extra layers "properties" and "dog"
        [CodeGenMemberSerializationHooks(nameof(SerializeBarkProperty), null)] // use this attribute to only customize the serialization of the property
        public string Bark { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeBarkProperty(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(Bark.ToUpperInvariant());
        }
    }
}
