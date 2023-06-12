// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtDiscriminator.Models
{
    public partial class UrlRewriteActionParameters : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("sourcePattern"u8);
            writer.WriteStringValue(SourcePattern);
            writer.WritePropertyName("destination"u8);
            writer.WriteStringValue(Destination);
            if (Optional.IsDefined(PreserveUnmatchedPath))
            {
                writer.WritePropertyName("preserveUnmatchedPath"u8);
                writer.WriteBooleanValue(PreserveUnmatchedPath.Value);
            }
            writer.WriteEndObject();
        }

        internal static UrlRewriteActionParameters DeserializeUrlRewriteActionParameters(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            UrlRewriteActionParametersTypeName typeName = default;
            string sourcePattern = default;
            string destination = default;
            Optional<bool> preserveUnmatchedPath = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new UrlRewriteActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourcePattern"u8))
                {
                    sourcePattern = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destination"u8))
                {
                    destination = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("preserveUnmatchedPath"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    preserveUnmatchedPath = property.Value.GetBoolean();
                    continue;
                }
            }
            return new UrlRewriteActionParameters(typeName, sourcePattern, destination, Optional.ToNullable(preserveUnmatchedPath));
        }
    }
}
