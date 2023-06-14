// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace MgmtCollectionParent.Models
{
    public partial class StageDetails
    {
        internal static StageDetails DeserializeStageDetails(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<StageStatus> stageStatus = default;
            Optional<StageName> stageName = default;
            Optional<string> displayName = default;
            Optional<DateTimeOffset> startTime = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("stageStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    stageStatus = new StageStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("stageName"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    stageName = new StageName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("displayName"u8))
                {
                    displayName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("startTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    startTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new StageDetails(Optional.ToNullable(stageStatus), Optional.ToNullable(stageName), displayName.Value, Optional.ToNullable(startTime));
        }
    }
}
