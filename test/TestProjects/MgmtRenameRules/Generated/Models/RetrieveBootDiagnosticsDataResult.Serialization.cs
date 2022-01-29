// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    public partial class RetrieveBootDiagnosticsDataResult
    {
        internal static RetrieveBootDiagnosticsDataResult DeserializeRetrieveBootDiagnosticsDataResult(JsonElement element)
        {
            Optional<string> consoleScreenshotBlobUri = default;
            Optional<string> serialConsoleLogBlobUri = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("consoleScreenshotBlobUri"))
                {
                    consoleScreenshotBlobUri = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("serialConsoleLogBlobUri"))
                {
                    serialConsoleLogBlobUri = property.Value.GetString();
                    continue;
                }
            }
            return new RetrieveBootDiagnosticsDataResult(consoleScreenshotBlobUri.Value, serialConsoleLogBlobUri.Value);
        }
    }
}
