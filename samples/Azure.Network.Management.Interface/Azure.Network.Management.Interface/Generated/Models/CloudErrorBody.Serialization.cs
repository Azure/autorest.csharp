// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    internal partial class CloudErrorBody
    {
        internal static CloudErrorBody DeserializeCloudErrorBody(JsonElement element)
        {
            Optional<string> code = default;
            Optional<string> message = default;
            Optional<string> target = default;
            Optional<IReadOnlyList<CloudErrorBody>> details = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("target"))
                {
                    target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("details"))
                {
                    List<CloudErrorBody> array = new List<CloudErrorBody>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(DeserializeCloudErrorBody(item));
                        }
                    }
                    details = array;
                    continue;
                }
            }
            return new CloudErrorBody(code.HasValue ? code.Value : null, message.HasValue ? message.Value : null, target.HasValue ? target.Value : null, new ChangeTrackingList<CloudErrorBody>(details));
        }
    }
}
