// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies the software license type that will be applied to the VMs deployed on the dedicated host. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **Windows_Server_Hybrid** &lt;br&gt;&lt;br&gt; **Windows_Server_Perpetual** &lt;br&gt;&lt;br&gt; Default: **None**
    /// Serialized Name: DedicatedHostLicenseTypes
    /// </summary>
    public enum DedicatedHostLicenseType
    {
        /// <summary>
        /// None
        /// Serialized Name: DedicatedHostLicenseTypes.None
        /// </summary>
        None,
        /// <summary>
        /// Windows_Server_Hybrid
        /// Serialized Name: DedicatedHostLicenseTypes.Windows_Server_Hybrid
        /// </summary>
        WindowsServerHybrid,
        /// <summary>
        /// Windows_Server_Perpetual
        /// Serialized Name: DedicatedHostLicenseTypes.Windows_Server_Perpetual
        /// </summary>
        WindowsServerPerpetual
    }
}
