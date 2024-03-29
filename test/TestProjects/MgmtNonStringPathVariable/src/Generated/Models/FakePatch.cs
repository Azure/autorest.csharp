// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace MgmtNonStringPathVariable.Models
{
    /// <summary> Specifies information about the fake that the virtual machine should be assigned to. Only tags may be updated. </summary>
    public partial class FakePatch : UpdateResource
    {
        /// <summary> Initializes a new instance of <see cref="FakePatch"/>. </summary>
        public FakePatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FakePatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="platformUpdateDomainCount"> Update Domain count. </param>
        /// <param name="platformFaultDomainCount"> Fault Domain count. </param>
        internal FakePatch(IDictionary<string, string> tags, int? platformUpdateDomainCount, int? platformFaultDomainCount) : base(tags)
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
