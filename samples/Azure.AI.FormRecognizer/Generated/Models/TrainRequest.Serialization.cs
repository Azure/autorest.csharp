// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class TrainRequest : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("source"u8);
            writer.WriteStringValue(Source);
            if (Optional.IsDefined(SourceFilter))
            {
                writer.WritePropertyName("sourceFilter"u8);
                writer.WriteObjectValue(SourceFilter);
            }
            if (Optional.IsDefined(UseLabelFile))
            {
                writer.WritePropertyName("useLabelFile"u8);
                writer.WriteBooleanValue(UseLabelFile.Value);
            }
            writer.WriteEndObject();
        }
    }
}
