// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class LeaseContainerContent : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("action"u8);
            writer.WriteStringValue(Action.ToString());
            if (Optional.IsDefined(LeaseId))
            {
                writer.WritePropertyName("leaseId"u8);
                writer.WriteStringValue(LeaseId);
            }
            if (Optional.IsDefined(BreakPeriod))
            {
                writer.WritePropertyName("breakPeriod"u8);
                writer.WriteNumberValue(BreakPeriod.Value);
            }
            if (Optional.IsDefined(LeaseDuration))
            {
                writer.WritePropertyName("leaseDuration"u8);
                writer.WriteNumberValue(LeaseDuration.Value);
            }
            if (Optional.IsDefined(ProposedLeaseId))
            {
                writer.WritePropertyName("proposedLeaseId"u8);
                writer.WriteStringValue(ProposedLeaseId);
            }
            writer.WriteEndObject();
        }
    }
}
