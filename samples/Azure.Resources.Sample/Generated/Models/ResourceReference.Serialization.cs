// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Resources.Sample
{
    public partial class ResourceReference
    {
        internal static ResourceReference DeserializeResourceReference(JsonElement element)
        {
            Optional<string> id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new ResourceReference(id.Value);
        }
    }
}
