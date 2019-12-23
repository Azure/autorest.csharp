// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class StringWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteStringValue(Field);
            }
            if (Empty != null)
            {
                writer.WritePropertyName("empty");
                writer.WriteStringValue(Empty);
            }
            if (NullProperty != null)
            {
                writer.WritePropertyName("null");
                writer.WriteStringValue(NullProperty);
            }
            writer.WriteEndObject();
        }
        internal static StringWrapper DeserializeStringWrapper(JsonElement element)
        {
            StringWrapper result = new StringWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("empty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Empty = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("null"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.NullProperty = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
