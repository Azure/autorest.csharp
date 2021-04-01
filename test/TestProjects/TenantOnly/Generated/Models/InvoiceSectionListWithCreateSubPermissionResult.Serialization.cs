// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace TenantOnly
{
    internal partial class InvoiceSectionListWithCreateSubPermissionResult
    {
        internal static InvoiceSectionListWithCreateSubPermissionResult DeserializeInvoiceSectionListWithCreateSubPermissionResult(JsonElement element)
        {
            Optional<IReadOnlyList<InstructionProperties>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<InstructionProperties> array = new List<InstructionProperties>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InstructionProperties.DeserializeInstructionProperties(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new InvoiceSectionListWithCreateSubPermissionResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
