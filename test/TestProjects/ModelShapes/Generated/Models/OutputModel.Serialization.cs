// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace ModelShapes.Models
{
    public partial class OutputModel
    {
        internal static OutputModel DeserializeOutputModel(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string requiredString = default;
            int requiredInt = default;
            IReadOnlyList<string> requiredStringList = default;
            IReadOnlyList<int> requiredIntList = default;
            Optional<string> nonRequiredString = default;
            Optional<int> nonRequiredInt = default;
            Optional<IReadOnlyList<string>> nonRequiredStringList = default;
            Optional<IReadOnlyList<int>> nonRequiredIntList = default;
            string requiredNullableString = default;
            int? requiredNullableInt = default;
            IReadOnlyList<string> requiredNullableStringList = default;
            IReadOnlyList<int> requiredNullableIntList = default;
            Optional<string> nonRequiredNullableString = default;
            Optional<int?> nonRequiredNullableInt = default;
            Optional<IReadOnlyList<string>> nonRequiredNullableStringList = default;
            Optional<IReadOnlyList<int>> nonRequiredNullableIntList = default;
            int requiredReadonlyInt = default;
            Optional<int> nonRequiredReadonlyInt = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("RequiredString"u8))
                {
                    requiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("RequiredInt"u8))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("RequiredStringList"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredStringList = array;
                    continue;
                }
                if (property.NameEquals("RequiredIntList"u8))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredIntList = array;
                    continue;
                }
                if (property.NameEquals("NonRequiredString"u8))
                {
                    nonRequiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("NonRequiredInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nonRequiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("NonRequiredStringList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    nonRequiredStringList = array;
                    continue;
                }
                if (property.NameEquals("NonRequiredIntList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    nonRequiredIntList = array;
                    continue;
                }
                if (property.NameEquals("RequiredNullableString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableString = null;
                        continue;
                    }
                    requiredNullableString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("RequiredNullableInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableInt = null;
                        continue;
                    }
                    requiredNullableInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("RequiredNullableStringList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableStringList = null;
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredNullableStringList = array;
                    continue;
                }
                if (property.NameEquals("RequiredNullableIntList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableIntList = null;
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredNullableIntList = array;
                    continue;
                }
                if (property.NameEquals("NonRequiredNullableString"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableString = null;
                        continue;
                    }
                    nonRequiredNullableString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("NonRequiredNullableInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableInt = null;
                        continue;
                    }
                    nonRequiredNullableInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("NonRequiredNullableStringList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableStringList = null;
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    nonRequiredNullableStringList = array;
                    continue;
                }
                if (property.NameEquals("NonRequiredNullableIntList"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableIntList = null;
                        continue;
                    }
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    nonRequiredNullableIntList = array;
                    continue;
                }
                if (property.NameEquals("RequiredReadonlyInt"u8))
                {
                    requiredReadonlyInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("NonRequiredReadonlyInt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nonRequiredReadonlyInt = property.Value.GetInt32();
                    continue;
                }
            }
            return new OutputModel(requiredString, requiredInt, requiredStringList, requiredIntList, nonRequiredString.Value, Optional.ToNullable(nonRequiredInt), Optional.ToList(nonRequiredStringList), Optional.ToList(nonRequiredIntList), requiredNullableString, requiredNullableInt, requiredNullableStringList, requiredNullableIntList, nonRequiredNullableString.Value, Optional.ToNullable(nonRequiredNullableInt), Optional.ToList(nonRequiredNullableStringList), Optional.ToList(nonRequiredNullableIntList), requiredReadonlyInt, Optional.ToNullable(nonRequiredReadonlyInt));
        }
    }
}
