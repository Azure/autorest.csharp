// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;

namespace AzureSample.ResourceManager.Storage.Models
{
    public partial class BlobRestoreStatus
    {
        internal static BlobRestoreStatus DeserializeBlobRestoreStatus(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BlobRestoreProgressStatus? status = default;
            string failureReason = default;
            string restoreId = default;
            BlobRestoreContent parameters = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = new BlobRestoreProgressStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("failureReason"u8))
                {
                    failureReason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("restoreId"u8))
                {
                    restoreId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("parameters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    parameters = BlobRestoreContent.DeserializeBlobRestoreContent(property.Value);
                    continue;
                }
            }
            return new BlobRestoreStatus(status, failureReason, restoreId, parameters);
        }
    }
}
