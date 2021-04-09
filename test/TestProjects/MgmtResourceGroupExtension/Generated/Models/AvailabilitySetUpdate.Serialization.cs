// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtResourceGroupExtension
{
    internal partial class AvailabilitySetUpdate : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Updator))
            {
                writer.WritePropertyName("updator");
                writer.WriteStringValue(Updator);
            }
            writer.WriteEndObject();
        }
    }
}
