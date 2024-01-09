// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;

namespace FirstTestTypeSpec.Models
{
    public partial class ReturnsAnonymousModelResponse
    {
        internal static ReturnsAnonymousModelResponse DeserializeReturnsAnonymousModelResponse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            foreach (var property in element.EnumerateObject())
            {
            }
            return new ReturnsAnonymousModelResponse();
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ReturnsAnonymousModelResponse FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeReturnsAnonymousModelResponse(document.RootElement);
        }
    }
}
