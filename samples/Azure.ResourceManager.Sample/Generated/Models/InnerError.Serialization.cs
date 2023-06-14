// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class InnerError
    {
        internal static InnerError DeserializeInnerError(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> exceptiontype = default;
            Optional<string> errordetail = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("exceptiontype"u8))
                {
                    exceptiontype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errordetail"u8))
                {
                    errordetail = property.Value.GetString();
                    continue;
                }
            }
            return new InnerError(exceptiontype.Value, errordetail.Value);
        }
    }
}
