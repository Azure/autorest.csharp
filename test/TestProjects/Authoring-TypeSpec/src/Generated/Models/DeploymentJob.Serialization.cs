// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace AuthoringTypeSpec.Models
{
    public partial class DeploymentJob : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("jobId"u8);
            writer.WriteStringValue(JobId);
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status.ToString());
            writer.WritePropertyName("warnings"u8);
            writer.WriteStartArray();
            foreach (var item in Warnings)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("errors"u8);
            JsonSerializer.Serialize(writer, Errors); writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeDeploymentJob(doc.RootElement, options);
        }

        internal static DeploymentJob DeserializeDeploymentJob(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string jobId = default;
            DateTimeOffset createdDateTime = default;
            DateTimeOffset lastUpdatedDateTime = default;
            DateTimeOffset expirationDateTime = default;
            JobStatus status = default;
            IReadOnlyList<JobWarning> warnings = default;
            ResponseError errors = default;
            string id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("jobId"u8))
                {
                    jobId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("createdDateTime"u8))
                {
                    createdDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastUpdatedDateTime"u8))
                {
                    lastUpdatedDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("expirationDateTime"u8))
                {
                    expirationDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new JobStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("warnings"u8))
                {
                    List<JobWarning> array = new List<JobWarning>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(JobWarning.DeserializeJobWarning(item));
                    }
                    warnings = array;
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    errors = JsonSerializer.Deserialize<ResponseError>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new DeploymentJob(jobId, createdDateTime, lastUpdatedDateTime, expirationDateTime, status, warnings, errors, id);
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDeploymentJob(doc.RootElement, options);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static DeploymentJob FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDeploymentJob(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
