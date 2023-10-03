// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Experimental.Core.Serialization;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class OpenAIFile
    {
        internal static OpenAIFile DeserializeOpenAIFile(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            OpenAIFileObject @object = default;
            long bytes = default;
            DateTimeOffset createdAt = default;
            string filename = default;
            string purpose = default;
            OpenAIFileStatus status = default;
            OptionalProperty<string> statusDetails = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = new OpenAIFileObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("bytes"u8))
                {
                    bytes = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("createdAt"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("filename"u8))
                {
                    filename = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("purpose"u8))
                {
                    purpose = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new OpenAIFileStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("status_details"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        statusDetails = null;
                        continue;
                    }
                    statusDetails = property.Value.GetString();
                    continue;
                }
            }
            return new OpenAIFile(id, @object, bytes, createdAt, filename, purpose, status, statusDetails.Value);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="result"> The result to deserialize the model from. </param>
        internal static OpenAIFile FromResponse(PipelineResponse result)
        {
            using var document = JsonDocument.Parse(result.Content);
            return DeserializeOpenAIFile(document.RootElement);
        }
    }
}
