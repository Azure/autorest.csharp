// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtLRO.Models
{
    /// <summary> The instance view of a resource. </summary>
    public partial class FakeProperties
    {
        /// <summary> Initializes a new instance of FakeProperties. </summary>
        public FakeProperties()
        {
        }

        /// <summary> Initializes a new instance of FakeProperties. </summary>
        /// <param name="platformUpdateDomainCount"> Update Domain count. </param>
        /// <param name="platformFaultDomainCount"> Fault Domain count. </param>
        internal FakeProperties(int? platformUpdateDomainCount, int? platformFaultDomainCount)
        {
            PlatformUpdateDomainCount = platformUpdateDomainCount;
            PlatformFaultDomainCount = platformFaultDomainCount;
        }

        /// <summary> Update Domain count. </summary>
        public int? PlatformUpdateDomainCount { get; set; }
        /// <summary> Fault Domain count. </summary>
        public int? PlatformFaultDomainCount { get; set; }
    }
}
