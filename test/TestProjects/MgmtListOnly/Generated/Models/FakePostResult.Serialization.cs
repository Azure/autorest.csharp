// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtListOnly.Models
{
    public partial class FakePostResult
    {
        internal static FakePostResult DeserializeFakePostResult(JsonElement element)
        {
            Optional<string> bar = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("bar"))
                {
                    bar = property.Value.GetString();
                    continue;
                }
            }
            return new FakePostResult(bar.Value);
        }
    }
}
