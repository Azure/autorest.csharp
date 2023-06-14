// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes automatic OS upgrade properties on the image.
    /// Serialized Name: AutomaticOSUpgradeProperties
    /// </summary>
    internal partial class AutomaticOSUpgradeProperties
    {
        /// <summary> Initializes a new instance of AutomaticOSUpgradeProperties. </summary>
        /// <param name="automaticOSUpgradeSupported">
        /// Specifies whether automatic OS upgrade is supported on the image.
        /// Serialized Name: AutomaticOSUpgradeProperties.automaticOSUpgradeSupported
        /// </param>
        public AutomaticOSUpgradeProperties(bool automaticOSUpgradeSupported)
        {
            AutomaticOSUpgradeSupported = automaticOSUpgradeSupported;
        }

        /// <summary>
        /// Specifies whether automatic OS upgrade is supported on the image.
        /// Serialized Name: AutomaticOSUpgradeProperties.automaticOSUpgradeSupported
        /// </summary>
        public bool AutomaticOSUpgradeSupported { get; set; }
    }
}
