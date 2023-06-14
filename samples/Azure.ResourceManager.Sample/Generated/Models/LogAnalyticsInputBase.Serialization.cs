// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class LogAnalyticsInputBase : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("blobContainerSasUri"u8);
            writer.WriteStringValue(BlobContainerSasUri.AbsoluteUri);
            writer.WritePropertyName("fromTime"u8);
            writer.WriteStringValue(FromTime, "O");
            writer.WritePropertyName("toTime"u8);
            writer.WriteStringValue(ToTime, "O");
            if (Optional.IsDefined(GroupByThrottlePolicy))
            {
                writer.WritePropertyName("groupByThrottlePolicy"u8);
                writer.WriteBooleanValue(GroupByThrottlePolicy.Value);
            }
            if (Optional.IsDefined(GroupByOperationName))
            {
                writer.WritePropertyName("groupByOperationName"u8);
                writer.WriteBooleanValue(GroupByOperationName.Value);
            }
            if (Optional.IsDefined(GroupByResourceName))
            {
                writer.WritePropertyName("groupByResourceName"u8);
                writer.WriteBooleanValue(GroupByResourceName.Value);
            }
            writer.WriteEndObject();
        }
    }
}
