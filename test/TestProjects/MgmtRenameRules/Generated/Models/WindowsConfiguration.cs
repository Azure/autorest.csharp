// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies Windows operating system settings on the virtual machine.
    /// Serialized Name: WindowsConfiguration
    /// </summary>
    public partial class WindowsConfiguration
    {
        /// <summary> Initializes a new instance of WindowsConfiguration. </summary>
        public WindowsConfiguration()
        {
            AdditionalUnattendContent = new ChangeTrackingList<AdditionalUnattendContent>();
        }

        /// <summary> Initializes a new instance of WindowsConfiguration. </summary>
        /// <param name="provisionVmAgent">
        /// Indicates whether virtual machine agent should be provisioned on the virtual machine. &lt;br&gt;&lt;br&gt; When this property is not specified in the request body, default behavior is to set it to true.  This will ensure that VM Agent is installed on the VM so that extensions can be added to the VM later.
        /// Serialized Name: WindowsConfiguration.provisionVMAgent
        /// </param>
        /// <param name="enableAutomaticUpdates">
        /// Indicates whether Automatic Updates is enabled for the Windows virtual machine. Default value is true. &lt;br&gt;&lt;br&gt; For virtual machine scale sets, this property can be updated and updates will take effect on OS reprovisioning.
        /// Serialized Name: WindowsConfiguration.enableAutomaticUpdates
        /// </param>
        /// <param name="timeZone">
        /// Specifies the time zone of the virtual machine. e.g. "Pacific Standard Time". &lt;br&gt;&lt;br&gt; Possible values can be [TimeZoneInfo.Id](https://docs.microsoft.com/en-us/dotnet/api/system.timezoneinfo.id?#System_TimeZoneInfo_Id) value from time zones returned by [TimeZoneInfo.GetSystemTimeZones](https://docs.microsoft.com/en-us/dotnet/api/system.timezoneinfo.getsystemtimezones).
        /// Serialized Name: WindowsConfiguration.timeZone
        /// </param>
        /// <param name="additionalUnattendContent">
        /// Specifies additional base-64 encoded XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup.
        /// Serialized Name: WindowsConfiguration.additionalUnattendContent
        /// </param>
        /// <param name="patchSettings">
        /// Specifies settings related to in-guest patching (KBs).
        /// Serialized Name: WindowsConfiguration.patchSettings
        /// </param>
        /// <param name="winRM">
        /// Specifies the Windows Remote Management listeners. This enables remote Windows PowerShell.
        /// Serialized Name: WindowsConfiguration.winRM
        /// </param>
        internal WindowsConfiguration(bool? provisionVmAgent, bool? enableAutomaticUpdates, string timeZone, IList<AdditionalUnattendContent> additionalUnattendContent, PatchSettings patchSettings, WinRMConfiguration winRM)
        {
            ProvisionVmAgent = provisionVmAgent;
            EnableAutomaticUpdates = enableAutomaticUpdates;
            TimeZone = timeZone;
            AdditionalUnattendContent = additionalUnattendContent;
            PatchSettings = patchSettings;
            WinRM = winRM;
        }

        /// <summary>
        /// Indicates whether virtual machine agent should be provisioned on the virtual machine. &lt;br&gt;&lt;br&gt; When this property is not specified in the request body, default behavior is to set it to true.  This will ensure that VM Agent is installed on the VM so that extensions can be added to the VM later.
        /// Serialized Name: WindowsConfiguration.provisionVMAgent
        /// </summary>
        public bool? ProvisionVmAgent { get; set; }
        /// <summary>
        /// Indicates whether Automatic Updates is enabled for the Windows virtual machine. Default value is true. &lt;br&gt;&lt;br&gt; For virtual machine scale sets, this property can be updated and updates will take effect on OS reprovisioning.
        /// Serialized Name: WindowsConfiguration.enableAutomaticUpdates
        /// </summary>
        public bool? EnableAutomaticUpdates { get; set; }
        /// <summary>
        /// Specifies the time zone of the virtual machine. e.g. "Pacific Standard Time". &lt;br&gt;&lt;br&gt; Possible values can be [TimeZoneInfo.Id](https://docs.microsoft.com/en-us/dotnet/api/system.timezoneinfo.id?#System_TimeZoneInfo_Id) value from time zones returned by [TimeZoneInfo.GetSystemTimeZones](https://docs.microsoft.com/en-us/dotnet/api/system.timezoneinfo.getsystemtimezones).
        /// Serialized Name: WindowsConfiguration.timeZone
        /// </summary>
        public string TimeZone { get; set; }
        /// <summary>
        /// Specifies additional base-64 encoded XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup.
        /// Serialized Name: WindowsConfiguration.additionalUnattendContent
        /// </summary>
        public IList<AdditionalUnattendContent> AdditionalUnattendContent { get; }
        /// <summary>
        /// Specifies settings related to in-guest patching (KBs).
        /// Serialized Name: WindowsConfiguration.patchSettings
        /// </summary>
        internal PatchSettings PatchSettings { get; set; }
        /// <summary>
        /// Specifies the mode of in-guest patching to IaaS virtual machine.&lt;br /&gt;&lt;br /&gt; Possible values are:&lt;br /&gt;&lt;br /&gt; **Manual** - You  control the application of patches to a virtual machine. You do this by applying patches manually inside the VM. In this mode, automatic updates are disabled; the property WindowsConfiguration.enableAutomaticUpdates must be false&lt;br /&gt;&lt;br /&gt; **AutomaticByOS** - The virtual machine will automatically be updated by the OS. The property WindowsConfiguration.enableAutomaticUpdates must be true. &lt;br /&gt;&lt;br /&gt; ** AutomaticByPlatform** - the virtual machine will automatically updated by the platform. The properties provisionVMAgent and WindowsConfiguration.enableAutomaticUpdates must be true
        /// Serialized Name: PatchSettings.patchMode
        /// </summary>
        public InGuestPatchMode? PatchMode
        {
            get => PatchSettings is null ? default : PatchSettings.PatchMode;
            set
            {
                if (PatchSettings is null)
                    PatchSettings = new PatchSettings();
                PatchSettings.PatchMode = value;
            }
        }

        /// <summary>
        /// Specifies the Windows Remote Management listeners. This enables remote Windows PowerShell.
        /// Serialized Name: WindowsConfiguration.winRM
        /// </summary>
        internal WinRMConfiguration WinRM { get; set; }
        /// <summary>
        /// The list of Windows Remote Management listeners
        /// Serialized Name: WinRMConfiguration.listeners
        /// </summary>
        public IList<WinRMListener> WinRMListeners
        {
            get
            {
                if (WinRM is null)
                    WinRM = new WinRMConfiguration();
                return WinRM.Listeners;
            }
        }
    }
}
