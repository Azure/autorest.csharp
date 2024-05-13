// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace MgmtCustomizations.Models
{
    [CodeGenSerialization(nameof(Bark), new string[] { "properties", "dog", "bark" }, SerializationValueHook = nameof(SerializeBarkProperty))] // use this attribute to only customize the serialization of the property
    [CodeGenSerialization(nameof(Friend), new string[] { "properties", "dog", "friend" })]
    public partial class Dog : Pet
    {
        /// <summary> A dog can bark. </summary>
        public string Bark { get; set; }

        /// <summary> A dog can have friend. </summary>
        public Pet Friend { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeBarkProperty(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(Bark.ToUpperInvariant());
        }
    }
}
