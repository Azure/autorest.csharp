// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class PathHierarchyTokenizerV2 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Delimiter != null)
            {
                writer.WritePropertyName("delimiter");
                writer.WriteStringValue(Delimiter.Value);
            }
            if (Replacement != null)
            {
                writer.WritePropertyName("replacement");
                writer.WriteStringValue(Replacement.Value);
            }
            if (MaxTokenLength != null)
            {
                writer.WritePropertyName("maxTokenLength");
                writer.WriteNumberValue(MaxTokenLength.Value);
            }
            if (ReverseTokenOrder != null)
            {
                writer.WritePropertyName("reverse");
                writer.WriteBooleanValue(ReverseTokenOrder.Value);
            }
            if (NumberOfTokensToSkip != null)
            {
                writer.WritePropertyName("skip");
                writer.WriteNumberValue(NumberOfTokensToSkip.Value);
            }
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WriteEndObject();
        }

        internal static PathHierarchyTokenizerV2 DeserializePathHierarchyTokenizerV2(JsonElement element)
        {
            PathHierarchyTokenizerV2 result;
            char? delimiter = default;
            char? replacement = default;
            int? maxTokenLength = default;
            bool? reverse = default;
            int? skip = default;
            string odatatype = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("delimiter"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    delimiter = property.Value.GetChar();
                    continue;
                }
                if (property.NameEquals("replacement"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    replacement = property.Value.GetChar();
                    continue;
                }
                if (property.NameEquals("maxTokenLength"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxTokenLength = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("reverse"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    reverse = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("skip"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    skip = property.Value.GetInt32();
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
            result = new PathHierarchyTokenizerV2(delimiter, replacement, maxTokenLength, reverse, skip, odatatype, name);
            return result;
        }
    }
}
