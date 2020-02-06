// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DocumentError : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
        internal static DocumentError DeserializeDocumentError(JsonElement element)
        {
            DocumentError result = new DocumentError();
            foreach (var property in element.EnumerateObject())
            {
            }
            return result;
        }
    }
}
rror result = new DocumentError();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("error"))
                {
                    result.Error = DocumentError.DeserializeDocumentError(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
