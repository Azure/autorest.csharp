// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace _Azure.Lro.RpcLegacy.Models
{
    public partial class JobResult
    {
        internal static JobResult DeserializeJobResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string jobId = default;
            string comment = default;
            JobStatus status = default;
            Optional<IReadOnlyList<ErrorResponse>> errors = default;
            Optional<IReadOnlyList<string>> results = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("jobId"u8))
                {
                    jobId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("comment"u8))
                {
                    comment = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new JobStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ErrorResponse> array = new List<ErrorResponse>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ErrorResponse.DeserializeErrorResponse(item));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("results"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    results = array;
                    continue;
                }
            }
            return new JobResult(jobId, comment, status, Optional.ToList(errors), Optional.ToList(results));
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static JobResult FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeJobResult(document.RootElement);
        }
    }
}
