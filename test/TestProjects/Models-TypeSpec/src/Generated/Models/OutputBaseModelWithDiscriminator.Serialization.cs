// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;

namespace ModelsTypeSpec.Models
{
    public partial class OutputBaseModelWithDiscriminator
    {
        internal static OutputBaseModelWithDiscriminator DeserializeOutputBaseModelWithDiscriminator(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "first": return FirstDerivedOutputModel.DeserializeFirstDerivedOutputModel(element);
                    case "second": return SecondDerivedOutputModel.DeserializeSecondDerivedOutputModel(element);
                }
            }
            return UnknownOutputBaseModelWithDiscriminator.DeserializeUnknownOutputBaseModelWithDiscriminator(element);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static OutputBaseModelWithDiscriminator FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeOutputBaseModelWithDiscriminator(document.RootElement);
        }
    }
}
