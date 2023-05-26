// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace MgmtCustomizations.Models
{
    public abstract partial class Pet
    {
        /// <summary> The size of the pet. Despite we write type string here, in the real payload of this request, it is actually sending using a number, therefore the type in this swagger here is wrong and we need to fix it using customization code. </summary>
        [CodeGenMemberSerializationHooks(nameof(SerializeSizeProperty), nameof(DeserializeSizeProperty))]
        public int Size { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializeSizeProperty(Utf8JsonWriter writer)
        {
            writer.WriteStringValue(Size.ToString());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeSizeProperty(JsonProperty property, ref Optional<int> size)
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
    }
}
