// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class : IUtf8JsonSerializable
    {
void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
    {
        writer.WriteStartObject();
        writer.WriteEndObject();
    }
    internal static Models.Deserialize(JsonElement element)
{
Models.result = new Models.();
foreach (var property in element.EnumerateObject())
{
}
return result;
}
}
}
