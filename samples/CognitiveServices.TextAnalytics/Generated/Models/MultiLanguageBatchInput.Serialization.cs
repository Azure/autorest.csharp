// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class MultiLanguageBatchInput : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("documents"u8);
            writer.WriteStartArray();
            foreach (var item in Documents)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
