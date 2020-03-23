// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class StemmerTokenFilter : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("language");
            writer.WriteStringValue(Language.ToSerialString());
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static StemmerTokenFilter DeserializeStemmerTokenFilter(JsonElement element)
        {
            StemmerTokenFilterLanguage language = default;
            string odatatype = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("language"))
                {
                    language = property.Value.GetString().ToStemmerTokenFilterLanguage();
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
            return new StemmerTokenFilter(language, odatatype, name);
        }
    }
}
