// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class DataDeletionDetectionPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }

        internal static DataDeletionDetectionPolicy DeserializeDataDeletionDetectionPolicy(JsonElement element)
        {
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.SoftDeleteColumnDeletionDetectionPolicy": return SoftDeleteColumnDeletionDetectionPolicy.DeserializeSoftDeleteColumnDeletionDetectionPolicy(element);
                    default: return UnknownDataDeletionDetectionPolicy.DeserializeUnknownDataDeletionDetectionPolicy(element);
                }
            }
            throw new InvalidOperationException("Unable to find the discriminator '@odata.type' in JsonElement");
        }
    }
}
