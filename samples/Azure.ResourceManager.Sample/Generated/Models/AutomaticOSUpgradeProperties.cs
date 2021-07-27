// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Describes automatic OS upgrade properties on the image. </summary>
    public partial class AutomaticOSUpgradeProperties
    {
        /// <summary> Initializes a new instance of AutomaticOSUpgradeProperties. </summary>
        /// <param name="automaticOSUpgradeSupported"> Specifies whether automatic OS upgrade is supported on the image. </param>
        public AutomaticOSUpgradeProperties(bool automaticOSUpgradeSupported)
        {
            AutomaticOSUpgradeSupported = automaticOSUpgradeSupported;
        }

        /// <summary> Specifies whether automatic OS upgrade is supported on the image. </summary>
        public bool AutomaticOSUpgradeSupported { get; set; }
    }
}
