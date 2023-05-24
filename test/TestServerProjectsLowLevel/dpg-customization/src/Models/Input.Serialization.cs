// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace dpg_customization_LowLevel.Models
{
    public partial class Input : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("hello");
            writer.WriteStringValue(Hello);
            writer.WriteEndObject();
        }

        internal static RequestContent ToRequestContent(Input input)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(input);
            return content;
        }
    }
}
