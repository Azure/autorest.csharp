// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class CognitiveServicesAccount : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            writer.WriteEndObject();
        }

        internal static CognitiveServicesAccount DeserializeCognitiveServicesAccount(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("@odata.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.CognitiveServicesByKey": return CognitiveServicesAccountKey.DeserializeCognitiveServicesAccountKey(element);
                    case "#Microsoft.Azure.Search.DefaultCognitiveServices": return DefaultCognitiveServicesAccount.DeserializeDefaultCognitiveServicesAccount(element);
                }
            }
            return UnknownCognitiveServicesAccount.DeserializeUnknownCognitiveServicesAccount(element);
        }
    }
}
