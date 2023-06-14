// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ListAccountSasResponse
    {
        internal static ListAccountSasResponse DeserializeListAccountSasResponse(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> accountSasToken = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("accountSasToken"u8))
                {
                    accountSasToken = property.Value.GetString();
                    continue;
                }
            }
            return new ListAccountSasResponse(accountSasToken.Value);
        }
    }
}
