// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class AzureActiveDirectoryApplicationCredentials : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("applicationId"u8);
            writer.WriteStringValue(ApplicationId);
            if (Optional.IsDefined(ApplicationSecret))
            {
                writer.WritePropertyName("applicationSecret"u8);
                writer.WriteStringValue(ApplicationSecret);
            }
            writer.WriteEndObject();
        }

        internal static AzureActiveDirectoryApplicationCredentials DeserializeAzureActiveDirectoryApplicationCredentials(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string applicationId = default;
            Optional<string> applicationSecret = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("applicationId"u8))
                {
                    applicationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("applicationSecret"u8))
                {
                    applicationSecret = property.Value.GetString();
                    continue;
                }
            }
            return new AzureActiveDirectoryApplicationCredentials(applicationId, applicationSecret.Value);
        }
    }
}
