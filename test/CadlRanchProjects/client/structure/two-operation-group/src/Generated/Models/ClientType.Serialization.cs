// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Client.Structure.Service.TwoOperationGroup.Models
{
    internal static partial class ClientTypeExtensions
    {
        public static string ToSerialString(this ClientType value) => value switch
        {
            ClientType.Default => "default",
            ClientType.MultiClient => "multi-client",
            ClientType.RenamedOperation => "renamed-operation",
            ClientType.TwoOperationGroup => "two-operation-group",
            ClientType.ClientOperationGroup => "client-operation-group",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ClientType value.")
        };

        public static ClientType ToClientType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "default")) return ClientType.Default;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "multi-client")) return ClientType.MultiClient;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "renamed-operation")) return ClientType.RenamedOperation;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "two-operation-group")) return ClientType.TwoOperationGroup;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "client-operation-group")) return ClientType.ClientOperationGroup;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ClientType value.");
        }
    }
}
