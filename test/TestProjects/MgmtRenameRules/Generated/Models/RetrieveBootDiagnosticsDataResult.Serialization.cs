// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class RetrieveBootDiagnosticsDataResult
    {
        internal static RetrieveBootDiagnosticsDataResult DeserializeRetrieveBootDiagnosticsDataResult(JsonElement element)
        {
            Optional<Uri> consoleScreenshotBlobUri = default;
            Optional<Uri> serialConsoleLogBlobUri = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("consoleScreenshotBlobUri"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        consoleScreenshotBlobUri = null;
                        continue;
                    }
                    consoleScreenshotBlobUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("serialConsoleLogBlobUri"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        serialConsoleLogBlobUri = null;
                        continue;
                    }
                    serialConsoleLogBlobUri = new Uri(property.Value.GetString());
                    continue;
                }
            }
            return new RetrieveBootDiagnosticsDataResult(consoleScreenshotBlobUri.Value, serialConsoleLogBlobUri.Value);
        }
    }
}
