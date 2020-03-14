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
            writer.WritePropertyName("source");
            writer.WriteStringValue(Source);
            if (SourceFilter != null)
            {
                writer.WritePropertyName("sourceFilter");
                writer.WriteObjectValue(SourceFilter);
            }
            if (UseLabelFile != null)
            {
                writer.WritePropertyName("useLabelFile");
                writer.WriteBooleanValue(UseLabelFile.Value);
            }
            writer.WriteEndObject();
        }
    }
}
