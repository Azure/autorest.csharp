// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class ComponentsSchemasFacetresultAdditionalproperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
        internal static ComponentsSchemasFacetresultAdditionalproperties DeserializeComponentsSchemasFacetresultAdditionalproperties(JsonElement element)
        {
            ComponentsSchemasFacetresultAdditionalproperties result = new ComponentsSchemasFacetresultAdditionalproperties();
            foreach (var property in element.EnumerateObject())
            {
            }
            return result;
        }
    }
}
