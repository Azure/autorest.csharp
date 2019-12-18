// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models.V20160229
{
    public partial class ByteWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field != null)
            {
                writer.WritePropertyName("field");
                writer.WriteBase64StringValue(Field);
            }
            writer.WriteEndObject();
        }
        internal static ByteWrapper DeserializeByteWrapper(JsonElement element)
        {
            var result = new ByteWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field = property.Value.GetBytesFromBase64();
                    continue;
                }
            }
            return result;
        }
    }
}
