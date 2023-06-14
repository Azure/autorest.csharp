// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Parameters.Spread.Models
{
    internal partial class SpreadWithMultipleParametersRequest : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("prop1"u8);
            writer.WriteStringValue(Prop1);
            writer.WritePropertyName("prop2"u8);
            writer.WriteStringValue(Prop2);
            writer.WritePropertyName("prop3"u8);
            writer.WriteStringValue(Prop3);
            writer.WritePropertyName("prop4"u8);
            writer.WriteStringValue(Prop4);
            writer.WritePropertyName("prop5"u8);
            writer.WriteStringValue(Prop5);
            writer.WritePropertyName("prop6"u8);
            writer.WriteStringValue(Prop6);
            writer.WriteEndObject();
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
