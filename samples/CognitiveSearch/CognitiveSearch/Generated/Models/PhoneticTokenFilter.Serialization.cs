// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class PhoneticTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Encoder != null)
            {
                writer.WritePropertyName("encoder");
                writer.WriteStringValue(Encoder.Value.ToSerialString());
            }
            if (ReplaceOriginalTokens != null)
            {
                writer.WritePropertyName("replace");
                writer.WriteBooleanValue(ReplaceOriginalTokens.Value);
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static PhoneticTokenFilter DeserializePhoneticTokenFilter(JsonElement element)
        {
            PhoneticTokenFilter result;
            PhoneticEncoder? encoder = default;
            bool? replace = default;
            string odatatype = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("encoder"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    encoder = property.Value.GetString().ToPhoneticEncoder();
                    continue;
                }
                if (property.NameEquals("replace"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    replace = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("@odata.type"))
                {
                    odatatype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            result = new PhoneticTokenFilter(encoder, replace, odatatype, name);
            return result;
        }
    }
}
