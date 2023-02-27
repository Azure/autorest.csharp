// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class SettingNameExtensions
    {
        public static string ToSerialString(this SettingName value) => value switch
        {
            SettingName.AutoLogon => "AutoLogon",
            SettingName.FirstLogonCommands => "FirstLogonCommands",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SettingName value.")
        };

        public static SettingName ToSettingName(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AutoLogon")) return SettingName.AutoLogon;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "FirstLogonCommands")) return SettingName.FirstLogonCommands;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SettingName value.");
        }
    }
}
