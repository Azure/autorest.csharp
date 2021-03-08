// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace TenantOnly
{
    internal partial class InstructionListResult
    {
        internal static InstructionListResult DeserializeInstructionListResult(JsonElement element)
        {
            Optional<IReadOnlyList<Instruction>> value = default;
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
                    List<Instruction> array = new List<Instruction>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Instruction.DeserializeInstruction(item));
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
            return new InstructionListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
