// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtListMethods.Models
{
    public partial class UpdateWorkspaceQuotas
    {
        internal static UpdateWorkspaceQuotas DeserializeUpdateWorkspaceQuotas(JsonElement element)
        {
            Optional<string> id = default;
            Optional<string> type = default;
            Optional<long> limit = default;
            Optional<QuotaUnit> unit = default;
            Optional<Status> status = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("limit"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    limit = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("unit"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    unit = new QuotaUnit(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    status = new Status(property.Value.GetString());
                    continue;
                }
            }
            return new UpdateWorkspaceQuotas(id.Value, type.Value, Optional.ToNullable(limit), Optional.ToNullable(unit), Optional.ToNullable(status));
        }
    }
}
