// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;

namespace MgmtAcronymMapping.Models
{
    public partial class RollbackStatusInfo
    {
        internal static RollbackStatusInfo DeserializeRollbackStatusInfo(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int successfullyRolledbackInstanceCount = default;
            int failedRolledbackInstanceCount = default;
            ApiError rollbackError = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("successfullyRolledbackInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    successfullyRolledbackInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedRolledbackInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failedRolledbackInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("rollbackError"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rollbackError = ApiError.DeserializeApiError(property.Value);
                    continue;
                }
            }
            return new RollbackStatusInfo(successfullyRolledbackInstanceCount, failedRolledbackInstanceCount, rollbackError);
        }
    }
}
