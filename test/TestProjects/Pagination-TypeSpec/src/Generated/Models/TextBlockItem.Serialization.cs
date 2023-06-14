// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Pagination.Models
{
    public partial class TextBlockItem
    {
        internal static TextBlockItem DeserializeTextBlockItem(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string blockItemId = default;
            Optional<string> description = default;
            string text = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("blockItemId"u8))
                {
                    blockItemId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("text"u8))
                {
                    text = property.Value.GetString();
                    continue;
                }
            }
            return new TextBlockItem(blockItemId, description.Value, text);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static TextBlockItem FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeTextBlockItem(document.RootElement);
        }
    }
}
