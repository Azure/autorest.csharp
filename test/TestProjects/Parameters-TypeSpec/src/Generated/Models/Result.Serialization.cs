// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace ParametersCadl.Models
{
    public partial class Result
    {
        internal static Result DeserializeResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new Result(id);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static Result FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeResult(document.RootElement);
        }
    }
}
