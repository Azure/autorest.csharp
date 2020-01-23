// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class CognitiveServicesAccount : Azure.Core.IUtf8JsonSerializable
    {
        void Azure.Core.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            if (Description != null)
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            writer.WriteEndObject();
        }
        internal static CognitiveSearch.Models.CognitiveServicesAccount DeserializeCognitiveServicesAccount(System.Text.Json.JsonElement element)
        {
            if (element.TryGetProperty("@odata.type", out System.Text.Json.JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "#Microsoft.Azure.Search.CognitiveServicesByKey": return CognitiveSearch.Models.CognitiveServicesAccountKey.DeserializeCognitiveServicesAccountKey(element);
                    case "#Microsoft.Azure.Search.DefaultCognitiveServices": return CognitiveSearch.Models.DefaultCognitiveServicesAccount.DeserializeDefaultCognitiveServicesAccount(element);
                }
            }
            CognitiveSearch.Models.CognitiveServicesAccount result = new CognitiveSearch.Models.CognitiveServicesAccount();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"))
                {
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    if (property.Value.ValueKind == System.Text.Json.JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Description = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
