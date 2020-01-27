// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class SqlIntegratedChangeTrackingPolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(OdataType);
            writer.WriteEndObject();
        }
        internal static SqlIntegratedChangeTrackingPolicy DeserializeSqlIntegratedChangeTrackingPolicy(JsonElement element)
        {
            SqlIntegratedChangeTrackingPolicy result = new SqlIntegratedChangeTrackingPolicy();
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
