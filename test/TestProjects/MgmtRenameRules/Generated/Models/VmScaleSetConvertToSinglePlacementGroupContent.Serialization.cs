// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtRenameRules.Models
{
    public partial class VmScaleSetConvertToSinglePlacementGroupContent : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ActivePlacementGroupId))
            {
                writer.WritePropertyName("activePlacementGroupId"u8);
                writer.WriteStringValue(ActivePlacementGroupId);
            }
            writer.WriteEndObject();
        }
    }
}
