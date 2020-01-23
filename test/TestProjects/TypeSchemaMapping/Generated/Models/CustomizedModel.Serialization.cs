// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace AutoRest.TestServer.Tests.TypeSchemaMapping
{
    internal partial class CustomizedModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (ModelProperty != null)
            {
                writer.WritePropertyName("ModelProperty");
                writer.WriteObjectValue(ModelProperty);
            }
            writer.WriteEndObject();
        }
        internal static CustomizedModel DeserializeCustomizedModel(JsonElement element)
        {
            CustomizedModel result = new CustomizedModel();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ModelProperty = property.Value.GetObject();
                    continue;
                }
            }
            return result;
        }
    }
}
