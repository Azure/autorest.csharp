// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    public partial class BlobRestoreStatus
    {
        internal static BlobRestoreStatus DeserializeBlobRestoreStatus(JsonElement element)
        {
            Optional<BlobRestoreProgressStatus> status = default;
            Optional<string> failureReason = default;
            Optional<string> restoreId = default;
            Optional<BlobRestoreParameters> parameters = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    status = new BlobRestoreProgressStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("failureReason"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    failureReason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("restoreId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    restoreId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("parameters"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    parameters = BlobRestoreParameters.DeserializeBlobRestoreParameters(property.Value);
                    continue;
                }
            }
            return new BlobRestoreStatus(Optional.ToNullable(status), failureReason.Value, restoreId.Value, parameters.Value);
        }
    }
}
