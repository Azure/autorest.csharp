// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using MgmtRenameRules;

namespace MgmtRenameRules.Models
{
    internal partial class ImageListResult
    {
        internal static ImageListResult DeserializeImageListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyList<ImageData> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    List<ImageData> array = new List<ImageData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ImageData.DeserializeImageData(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new ImageListResult(value, nextLink.Value);
        }
    }
}
