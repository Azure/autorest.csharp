// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
                if (property.NameEquals("RequiredString"))
                {
                    requiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("RequiredInt"))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("RequiredStringList"))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredStringList = array;
                    continue;
                }
                if (property.NameEquals("RequiredIntList"))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredIntList = array;
                    continue;
                }
                if (property.NameEquals("NonRequiredString"))
                {
                    nonRequiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("NonRequiredInt"))
                {
                    nonRequiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("NonRequiredStringList"))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    nonRequiredStringList = array;
                    continue;
                }
                if (property.NameEquals("NonRequiredIntList"))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    nonRequiredIntList = array;
                    continue;
                }
                if (property.NameEquals("RequiredNullableString"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableString = null;
                        continue;
                    }
                    requiredNullableString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("RequiredNullableInt"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requiredNullableInt = null;
                        continue;
                    }
                    requiredNullableInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("RequiredNullableStringList"))
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
                if (property.NameEquals("RequiredNullableIntList"))
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
                if (property.NameEquals("NonRequiredNullableString"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableString = null;
                        continue;
                    }
                    nonRequiredNullableString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("NonRequiredNullableInt"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        nonRequiredNullableInt = null;
                        continue;
                    }
                    nonRequiredNullableInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("NonRequiredNullableStringList"))
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
                if (property.NameEquals("NonRequiredNullableIntList"))
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
                if (property.NameEquals("RequiredReadonlyInt"))
                {
                    requiredReadonlyInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("NonRequiredReadonlyInt"))
                {
                    nonRequiredReadonlyInt = property.Value.GetInt32();
                    continue;
                }
            }
            return new OutputModel(requiredString, requiredInt, requiredStringList, requiredIntList, nonRequiredString.Value, Optional.ToNullable(nonRequiredInt), Optional.ToList(nonRequiredStringList), Optional.ToList(nonRequiredIntList), requiredNullableString, requiredNullableInt, requiredNullableStringList, requiredNullableIntList, nonRequiredNullableString.Value, Optional.ToNullable(nonRequiredNullableInt), Optional.ToList(nonRequiredNullableStringList), Optional.ToList(nonRequiredNullableIntList), requiredReadonlyInt, Optional.ToNullable(nonRequiredReadonlyInt));
        }
    }
}
