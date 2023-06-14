// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtParamOrdering.Models
{
    /// <summary> Specifies information about the availability set that the virtual machine should be assigned to. Only tags may be updated. </summary>
    public partial class AvailabilitySetPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of AvailabilitySetPatch. </summary>
        public AvailabilitySetPatch()
        {
        }

        /// <summary> Update Domain count. </summary>
        public int? PlatformUpdateDomainCount { get; set; }
        /// <summary> Fault Domain count. </summary>
        public int? PlatformFaultDomainCount { get; set; }
    }
}
