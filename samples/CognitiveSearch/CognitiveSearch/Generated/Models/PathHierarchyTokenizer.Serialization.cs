// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class PathHierarchyTokenizer : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Delimiter != null)
            {
                writer.WritePropertyName("delimiter");
                writer.WriteStringValue(Delimiter.Value.ToString());
            }
            if (Replacement != null)
            {
                writer.WritePropertyName("replacement");
                writer.WriteStringValue(Replacement.Value.ToString());
            }
            if (BufferSize != null)
            {
                writer.WritePropertyName("bufferSize");
                writer.WriteNumberValue(BufferSize.Value);
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
        internal static PathHierarchyTokenizer DeserializePathHierarchyTokenizer(JsonElement element)
        {
            PathHierarchyTokenizer result = new PathHierarchyTokenizer();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("delimiter"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Delimiter = property.Value.GetString()?[0];
                    continue;
                }
                if (property.NameEquals("replacement"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Replacement = property.Value.GetString()?[0];
                    continue;
                }
                if (property.NameEquals("bufferSize"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.BufferSize = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("reverse"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ReverseTokenOrder = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("skip"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.NumberOfTokensToSkip = property.Value.GetInt32();
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
