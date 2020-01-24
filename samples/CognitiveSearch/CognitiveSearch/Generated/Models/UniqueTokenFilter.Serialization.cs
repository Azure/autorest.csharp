// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class UniqueTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (OnlyOnSamePosition != null)
            {
                writer.WritePropertyName("onlyOnSamePosition");
                writer.WriteBooleanValue(OnlyOnSamePosition.Value);
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }
        internal static UniqueTokenFilter DeserializeUniqueTokenFilter(JsonElement element)
        {
            UniqueTokenFilter result = new UniqueTokenFilter();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("onlyOnSamePosition"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.OnlyOnSamePosition = property.Value.GetBoolean();
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
