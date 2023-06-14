// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace ModelWithConverterUsage.Models
{
    [JsonConverter(typeof(InputModelConverter))]
    public partial class InputModel : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(InputModelProperty))
            {
                writer.WritePropertyName("Input_Model_Property"u8);
                writer.WriteStringValue(InputModelProperty);
            }
            writer.WriteEndObject();
        }

        internal partial class InputModelConverter : JsonConverter<InputModel>
        {
            public override void Write(Utf8JsonWriter writer, InputModel model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override InputModel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
