// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class Components1Fm1TvaSchemasFacetresultAdditionalproperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
        internal static Components1Fm1TvaSchemasFacetresultAdditionalproperties DeserializeComponents1Fm1TvaSchemasFacetresultAdditionalproperties(JsonElement element)
        {
            Components1Fm1TvaSchemasFacetresultAdditionalproperties result = new Components1Fm1TvaSchemasFacetresultAdditionalproperties();
            foreach (var property in element.EnumerateObject())
            {
            }
            return result;
        }
    }
}
