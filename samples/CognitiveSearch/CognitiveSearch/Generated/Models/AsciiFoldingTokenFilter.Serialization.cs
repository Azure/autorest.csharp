// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class AsciiFoldingTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (PreserveOriginal != null)
            {
                writer.WritePropertyName("preserveOriginal");
                writer.WriteBooleanValue(PreserveOriginal.Value);
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static AsciiFoldingTokenFilter DeserializeAsciiFoldingTokenFilter(JsonElement element)
        {
            AsciiFoldingTokenFilter result = new AsciiFoldingTokenFilter();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("preserveOriginal"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.PreserveOriginal = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    result.Name = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
