// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtLRO.Models
{
    /// <summary> Specifies information about the fake that the virtual machine should be assigned to. Only tags may be updated. </summary>
    public partial class FakePatch : UpdateResource
    {
        /// <summary> Initializes a new instance of FakePatch. </summary>
        public FakePatch()
        {
        }

        /// <summary> Update Domain count. </summary>
        public int? PlatformUpdateDomainCount { get; set; }
        /// <summary> Fault Domain count. </summary>
        public int? PlatformFaultDomainCount { get; set; }
    }
}
