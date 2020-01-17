// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    public partial class DocumentErrorError : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
        internal static DocumentErrorError DeserializeDocumentErrorError(JsonElement element)
        {
            DocumentErrorError result = new DocumentErrorError();
            foreach (var property in element.EnumerateObject())
            {
            }
            return result;
        }
    }
}
