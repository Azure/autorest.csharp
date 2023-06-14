// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class VirtualMachineSoftwarePatchProperties
    {
        internal static VirtualMachineSoftwarePatchProperties DeserializeVirtualMachineSoftwarePatchProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> patchId = default;
            Optional<string> name = default;
            Optional<string> version = default;
            Optional<string> kbid = default;
            Optional<IReadOnlyList<string>> classifications = default;
            Optional<SoftwareUpdateRebootBehavior> rebootBehavior = default;
            Optional<string> activityId = default;
            Optional<DateTimeOffset> publishedDate = default;
            Optional<DateTimeOffset> lastModifiedDateTime = default;
            Optional<PatchAssessmentState> assessmentState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("patchId"u8))
                {
                    patchId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("version"u8))
                {
                    version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("kbid"u8))
                {
                    kbid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("classifications"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    classifications = array;
                    continue;
                }
                if (property.NameEquals("rebootBehavior"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rebootBehavior = new SoftwareUpdateRebootBehavior(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("activityId"u8))
                {
                    activityId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("publishedDate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    publishedDate = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastModifiedDateTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastModifiedDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("assessmentState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    assessmentState = new PatchAssessmentState(property.Value.GetString());
                    continue;
                }
            }
            return new VirtualMachineSoftwarePatchProperties(patchId.Value, name.Value, version.Value, kbid.Value, Optional.ToList(classifications), Optional.ToNullable(rebootBehavior), activityId.Value, Optional.ToNullable(publishedDate), Optional.ToNullable(lastModifiedDateTime), Optional.ToNullable(assessmentState));
        }
    }
}
