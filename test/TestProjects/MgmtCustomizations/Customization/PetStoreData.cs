// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtCustomizations
{
    [CodeGenMemberSerializationHooks(nameof(Id), DeserializationValueHook = nameof(ReadIdValue))]
    public partial class PetStoreData : ResourceData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void ReadIdValue(JsonProperty property, ref ResourceIdentifier id)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;
            var rawId = property.Value.GetString();
            if (rawId == "")
                return;
            id = new ResourceIdentifier(rawId);
        }
    }
}
