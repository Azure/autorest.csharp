// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies additional XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup. Contents are defined by setting name, component name, and the pass in which the content is applied.
    /// Serialized Name: AdditionalUnattendContent
    /// </summary>
    public partial class AdditionalUnattendContent
    {
        /// <summary> Initializes a new instance of AdditionalUnattendContent. </summary>
        public AdditionalUnattendContent()
        {
        }

        /// <summary> Initializes a new instance of AdditionalUnattendContent. </summary>
        /// <param name="passName">
        /// The pass name. Currently, the only allowable value is OobeSystem.
        /// Serialized Name: AdditionalUnattendContent.passName
        /// </param>
        /// <param name="componentName">
        /// The component name. Currently, the only allowable value is Microsoft-Windows-Shell-Setup.
        /// Serialized Name: AdditionalUnattendContent.componentName
        /// </param>
        /// <param name="settingName">
        /// Specifies the name of the setting to which the content applies. Possible values are: FirstLogonCommands and AutoLogon.
        /// Serialized Name: AdditionalUnattendContent.settingName
        /// </param>
        /// <param name="backupFrequency">
        /// Specifies the frequency for content backup
        /// Serialized Name: AdditionalUnattendContent.backupFrequency
        /// </param>
        internal AdditionalUnattendContent(PassName? passName, ComponentName? componentName, SettingName? settingName, int? backupFrequency)
        {
            PassName = passName;
            ComponentName = componentName;
            SettingName = settingName;
            BackupFrequency = backupFrequency;
        }

        /// <summary>
        /// The pass name. Currently, the only allowable value is OobeSystem.
        /// Serialized Name: AdditionalUnattendContent.passName
        /// </summary>
        public PassName? PassName { get; set; }
        /// <summary>
        /// The component name. Currently, the only allowable value is Microsoft-Windows-Shell-Setup.
        /// Serialized Name: AdditionalUnattendContent.componentName
        /// </summary>
        public ComponentName? ComponentName { get; set; }
        /// <summary>
        /// Specifies the name of the setting to which the content applies. Possible values are: FirstLogonCommands and AutoLogon.
        /// Serialized Name: AdditionalUnattendContent.settingName
        /// </summary>
        public SettingName? SettingName { get; set; }
        /// <summary>
        /// Specifies the frequency for content backup
        /// Serialized Name: AdditionalUnattendContent.backupFrequency
        /// </summary>
        public int? BackupFrequency { get; set; }
    }
}
