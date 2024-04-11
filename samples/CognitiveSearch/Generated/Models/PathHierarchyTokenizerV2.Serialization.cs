// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class PathHierarchyTokenizerV2 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Delimiter))
            {
                writer.WritePropertyName("delimiter"u8);
                writer.WriteStringValue(Delimiter.Value);
            }
            if (Optional.IsDefined(Replacement))
            {
                writer.WritePropertyName("replacement"u8);
                writer.WriteStringValue(Replacement.Value);
            }
            if (Optional.IsDefined(MaxTokenLength))
            {
                writer.WritePropertyName("maxTokenLength"u8);
                writer.WriteNumberValue(MaxTokenLength.Value);
            }
            if (Optional.IsDefined(ReverseTokenOrder))
            {
                writer.WritePropertyName("reverse"u8);
                writer.WriteBooleanValue(ReverseTokenOrder.Value);
            }
            if (Optional.IsDefined(NumberOfTokensToSkip))
            {
                writer.WritePropertyName("skip"u8);
                writer.WriteNumberValue(NumberOfTokensToSkip.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static PathHierarchyTokenizerV2 DeserializePathHierarchyTokenizerV2(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            char? delimiter = default;
            char? replacement = default;
            int? maxTokenLength = default;
            bool? reverse = default;
            int? skip = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("delimiter"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    delimiter = property.Value.GetChar();
                    continue;
                }
                if (property.NameEquals("replacement"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    replacement = property.Value.GetChar();
                    continue;
                }
                if (property.NameEquals("maxTokenLength"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxTokenLength = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("reverse"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    reverse = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("skip"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    skip = property.Value.GetInt32();
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
            return new PathHierarchyTokenizerV2(
                odataType,
                name,
                delimiter,
                replacement,
                maxTokenLength,
                reverse,
                skip);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static new PathHierarchyTokenizerV2 FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializePathHierarchyTokenizerV2(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal override RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
