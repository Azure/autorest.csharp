// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class DataDeletionDetectionPolicy : Azure.Core.IUtf8JsonSerializable
    {
        void Azure.Core.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }
        internal static CognitiveSearch.Models.DataDeletionDetectionPolicy DeserializeDataDeletionDetectionPolicy(System.Text.Json.JsonElement element)
        {
            if (element.TryGetProperty("@odata.type", out System.Text.Json.JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.SoftDeleteColumnDeletionDetectionPolicy": return CognitiveSearch.Models.SoftDeleteColumnDeletionDetectionPolicy.DeserializeSoftDeleteColumnDeletionDetectionPolicy(element);
                }
            }
            CognitiveSearch.Models.DataDeletionDetectionPolicy result = new CognitiveSearch.Models.DataDeletionDetectionPolicy();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
