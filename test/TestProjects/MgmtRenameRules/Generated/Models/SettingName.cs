// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies the name of the setting to which the content applies. Possible values are: FirstLogonCommands and AutoLogon.
    /// Serialized Name: SettingNames
    /// </summary>
    public enum SettingName
    {
        /// <summary>
        /// AutoLogon
        /// Serialized Name: SettingNames.AutoLogon
        /// </summary>
        AutoLogon,
        /// <summary>
        /// FirstLogonCommands
        /// Serialized Name: SettingNames.FirstLogonCommands
        /// </summary>
        FirstLogonCommands
    }
}
