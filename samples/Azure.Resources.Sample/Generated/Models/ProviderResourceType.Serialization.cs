// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Resources.Sample
{
    public partial class ProviderResourceType
    {
        internal static ProviderResourceType DeserializeProviderResourceType(JsonElement element)
        {
            Optional<string> resourceType = default;
            Optional<IReadOnlyList<string>> locations = default;
            Optional<IReadOnlyList<ProviderExtendedLocation>> locationMappings = default;
            Optional<IReadOnlyList<Alias>> aliases = default;
            Optional<IReadOnlyList<string>> apiVersions = default;
            Optional<string> defaultApiVersion = default;
            Optional<IReadOnlyList<ApiProfile>> apiProfiles = default;
            Optional<string> capabilities = default;
            Optional<IReadOnlyDictionary<string, string>> properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceType"))
                {
                    resourceType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("locations"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    locations = array;
                    continue;
                }
                if (property.NameEquals("locationMappings"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ProviderExtendedLocation> array = new List<ProviderExtendedLocation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ProviderExtendedLocation.DeserializeProviderExtendedLocation(item));
                    }
                    locationMappings = array;
                    continue;
                }
                if (property.NameEquals("aliases"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<Alias> array = new List<Alias>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Alias.DeserializeAlias(item));
                    }
                    aliases = array;
                    continue;
                }
                if (property.NameEquals("apiVersions"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    apiVersions = array;
                    continue;
                }
                if (property.NameEquals("defaultApiVersion"))
                {
                    defaultApiVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("apiProfiles"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ApiProfile> array = new List<ApiProfile>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ApiProfile.DeserializeApiProfile(item));
                    }
                    apiProfiles = array;
                    continue;
                }
                if (property.NameEquals("capabilities"))
                {
                    capabilities = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    properties = dictionary;
                    continue;
                }
            }
            return new ProviderResourceType(resourceType.Value, Optional.ToList(locations), Optional.ToList(locationMappings), Optional.ToList(aliases), Optional.ToList(apiVersions), defaultApiVersion.Value, Optional.ToList(apiProfiles), capabilities.Value, Optional.ToDictionary(properties));
        }
    }
}
