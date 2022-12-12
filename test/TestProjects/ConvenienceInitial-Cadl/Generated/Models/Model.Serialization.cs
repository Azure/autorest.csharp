// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace ConvenienceInitialInCadl.Models
{
    public partial class Model
    {
        internal static Model DeserializeModel(JsonElement element)
        {
            string id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new Model(id);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static Model FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeModel(document.RootElement);
        }
    }
}
