// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
                if (property.NameEquals("patchId"))
                {
                    patchId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("version"))
                {
                    version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("kbid"))
                {
                    kbid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("classifications"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                if (property.NameEquals("rebootBehavior"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    rebootBehavior = new SoftwareUpdateRebootBehavior(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("activityId"))
                {
                    activityId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("publishedDate"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    publishedDate = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastModifiedDateTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    lastModifiedDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("assessmentState"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
