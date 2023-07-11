// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Language.Authoring.Models
{
    public partial class SwapDeploymentsJob
    {
        internal static SwapDeploymentsJob DeserializeSwapDeploymentsJob(JsonElement element)
        {
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
            return new SwapDeploymentsJob(jobId, createdDateTime, lastUpdatedDateTime, expirationDateTime, status, warnings, errors, id);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static SwapDeploymentsJob FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeSwapDeploymentsJob(document.RootElement);
        }
    }
}
