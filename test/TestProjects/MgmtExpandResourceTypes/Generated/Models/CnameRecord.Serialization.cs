// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtExpandResourceTypes.Models
{
    internal partial class CnameRecord : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Cname))
            {
                writer.WritePropertyName("cname"u8);
                writer.WriteStringValue(Cname);
            }
            writer.WriteEndObject();
        }

        internal static CnameRecord DeserializeCnameRecord(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> cname = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("cname"u8))
                {
                    cname = property.Value.GetString();
                    continue;
                }
            }
            return new CnameRecord(cname.Value);
        }
    }
}
