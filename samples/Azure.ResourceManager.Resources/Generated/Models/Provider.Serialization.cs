// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class Provider
    {
        internal static Provider DeserializeProvider(JsonElement element)
        {
            Optional<string> @namespace = default;
            Optional<string> registrationState = default;
            Optional<string> registrationPolicy = default;
            Optional<IReadOnlyList<ProviderResourceType>> resourceTypes = default;
            Optional<ProviderAuthorizationConsentState> providerAuthorizationConsentState = default;
            ResourceIdentifier id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("namespace"))
                {
                    @namespace = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("registrationState"))
                {
                    registrationState = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("registrationPolicy"))
                {
                    registrationPolicy = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("resourceTypes"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ProviderResourceType> array = new List<ProviderResourceType>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ProviderResourceType.DeserializeProviderResourceType(item));
                    }
                    resourceTypes = array;
                    continue;
                }
                if (property.NameEquals("providerAuthorizationConsentState"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    providerAuthorizationConsentState = new ProviderAuthorizationConsentState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new Provider(id, @namespace.Value, registrationState.Value, registrationPolicy.Value, Optional.ToList(resourceTypes), Optional.ToNullable(providerAuthorizationConsentState));
        }
    }
}
