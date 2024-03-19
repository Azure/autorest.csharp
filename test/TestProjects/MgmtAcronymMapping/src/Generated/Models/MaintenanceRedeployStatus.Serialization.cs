// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using MgmtAcronymMapping;

namespace MgmtAcronymMapping.Models
{
    public partial class MaintenanceRedeployStatus
    {
        internal static MaintenanceRedeployStatus DeserializeMaintenanceRedeployStatus(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? isCustomerInitiatedMaintenanceAllowed = default;
            DateTimeOffset? preMaintenanceWindowStartTime = default;
            DateTimeOffset? preMaintenanceWindowEndTime = default;
            DateTimeOffset? maintenanceWindowStartTime = default;
            DateTimeOffset? maintenanceWindowEndTime = default;
            MaintenanceOperationResultCodeType? lastOperationResultCode = default;
            string lastOperationMessage = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("isCustomerInitiatedMaintenanceAllowed"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isCustomerInitiatedMaintenanceAllowed = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("preMaintenanceWindowStartTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    preMaintenanceWindowStartTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("preMaintenanceWindowEndTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    preMaintenanceWindowEndTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("maintenanceWindowStartTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maintenanceWindowStartTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("maintenanceWindowEndTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maintenanceWindowEndTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastOperationResultCode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastOperationResultCode = property.Value.GetString().ToMaintenanceOperationResultCodeType();
                    continue;
                }
                if (property.NameEquals("lastOperationMessage"u8))
                {
                    lastOperationMessage = property.Value.GetString();
                    continue;
                }
            }
            return new MaintenanceRedeployStatus(
                isCustomerInitiatedMaintenanceAllowed,
                preMaintenanceWindowStartTime,
                preMaintenanceWindowEndTime,
                maintenanceWindowStartTime,
                maintenanceWindowEndTime,
                lastOperationResultCode,
                lastOperationMessage);
        }
    }
}
