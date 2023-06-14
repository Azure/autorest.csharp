// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    internal partial class DeploymentWhatIfSettings : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ResultFormat))
            {
                writer.WritePropertyName("resultFormat"u8);
                writer.WriteStringValue(ResultFormat.Value.ToSerialString());
            }
            writer.WriteEndObject();
        }
    }
}
