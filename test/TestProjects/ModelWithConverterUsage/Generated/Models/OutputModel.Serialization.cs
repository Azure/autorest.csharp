// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace ModelWithConverterUsage.Models
{
    [JsonConverter(typeof(OutputModelConverter))]
    public partial class OutputModel
    {
        internal static OutputModel DeserializeOutputModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> outputModelProperty = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Output_Model_Property"u8))
                {
                    outputModelProperty = property.Value.GetString();
                    continue;
                }
            }
            return new OutputModel(outputModelProperty.Value);
        }

        internal partial class OutputModelConverter : JsonConverter<OutputModel>
        {
            public override void Write(Utf8JsonWriter writer, OutputModel model, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
            public override OutputModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeOutputModel(document.RootElement);
            }
        }
    }
}
