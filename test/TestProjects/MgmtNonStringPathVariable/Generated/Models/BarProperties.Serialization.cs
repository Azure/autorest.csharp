// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtNonStringPathVariable.Models
{
    internal partial class BarProperties : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Buzz))
            {
                writer.WritePropertyName("buzz"u8);
                writer.WriteStringValue(Buzz.Value);
            }
            writer.WriteEndObject();
        }

        internal static BarProperties DeserializeBarProperties(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Guid> buzz = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("buzz"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    buzz = property.Value.GetGuid();
                    continue;
                }
            }
            return new BarProperties(Optional.ToNullable(buzz));
        }
    }
}
