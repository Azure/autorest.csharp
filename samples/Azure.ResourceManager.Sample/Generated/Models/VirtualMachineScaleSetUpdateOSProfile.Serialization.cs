// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VirtualMachineScaleSetUpdateOSProfile : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(CustomData))
            {
                writer.WritePropertyName("customData"u8);
                writer.WriteStringValue(CustomData);
            }
            if (Optional.IsDefined(WindowsConfiguration))
            {
                writer.WritePropertyName("windowsConfiguration"u8);
                writer.WriteObjectValue(WindowsConfiguration);
            }
            if (Optional.IsDefined(LinuxConfiguration))
            {
                writer.WritePropertyName("linuxConfiguration"u8);
                writer.WriteObjectValue(LinuxConfiguration);
            }
            if (Optional.IsCollectionDefined(Secrets))
            {
                writer.WritePropertyName("secrets"u8);
                writer.WriteStartArray();
                foreach (var item in Secrets)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
    }
}
