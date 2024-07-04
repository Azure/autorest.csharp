// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace CustomizedTypeSpec.Models
{
    /// <summary> this is a roundtrip model. </summary>
    [CodeGenType("RoundTripModel")]
    [CodeGenSerialization(nameof(RequiredString), "requiredSuperString")]
    [CodeGenSerialization(nameof(RequiredSuperInt), SerializationValueHook = nameof(SerializationMethodHook))]
    public partial class SuperRoundTripModel
    {
        /// <summary> Required string, illustrating a reference type property. </summary>
        [CodeGenMember("RequiredInt")]
        public int RequiredSuperInt { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializationMethodHook(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteNumberValue(7);
        }
    }
}
