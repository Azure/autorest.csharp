// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtListOnly.Models
{
    internal partial class ResponseNotCalledValueListResult
    {
        internal static ResponseNotCalledValueListResult DeserializeResponseNotCalledValueListResult(JsonElement element)
        {
            IReadOnlyList<ResponseNotCalledValue> notValue = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("notValue"))
                {
                    List<ResponseNotCalledValue> array = new List<ResponseNotCalledValue>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ResponseNotCalledValue.DeserializeResponseNotCalledValue(item));
                    }
                    notValue = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new ResponseNotCalledValueListResult(notValue, nextLink.Value);
        }
    }
}
