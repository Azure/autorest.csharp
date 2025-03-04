// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class EdgeNGramTokenizer : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(MinGram))
            {
                writer.WritePropertyName("minGram"u8);
                writer.WriteNumberValue(MinGram.Value);
            }
            if (Optional.IsDefined(MaxGram))
            {
                writer.WritePropertyName("maxGram"u8);
                writer.WriteNumberValue(MaxGram.Value);
            }
            if (Optional.IsCollectionDefined(TokenChars))
            {
                writer.WritePropertyName("tokenChars"u8);
                writer.WriteStartArray();
                foreach (var item in TokenChars)
                {
                    writer.WriteStringValue(item.ToSerialString());
                }
                writer.WriteEndArray();
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static EdgeNGramTokenizer DeserializeEdgeNGramTokenizer(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int? minGram = default;
            int? maxGram = default;
            IList<TokenCharacterKind> tokenChars = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("minGram"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minGram = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("maxGram"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxGram = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("tokenChars"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<TokenCharacterKind> array = new List<TokenCharacterKind>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString().ToTokenCharacterKind());
                    }
                    tokenChars = array;
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new EdgeNGramTokenizer(odataType, name, minGram, maxGram, tokenChars ?? new ChangeTrackingList<TokenCharacterKind>());
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new EdgeNGramTokenizer FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeEdgeNGramTokenizer(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
