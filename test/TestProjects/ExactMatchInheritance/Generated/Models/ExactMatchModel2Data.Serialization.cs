// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace ExactMatchInheritance
{
    public partial class ExactMatchModel2Data : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(New))
            {
                writer.WritePropertyName("new");
                writer.WriteStringValue(New);
            }
            writer.WriteEndObject();
        }

        internal static ExactMatchModel2Data DeserializeExactMatchModel2Data(JsonElement element)
        {
            Optional<string> @new = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("new"))
                {
                    @new = property.Value.GetString();
                    continue;
                }
            }
            return new ExactMatchModel2Data(@new.Value);
        }
    }
}
