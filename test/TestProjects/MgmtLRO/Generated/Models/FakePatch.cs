// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtLRO.Models
{
    /// <summary> Specifies information about the fake that the virtual machine should be assigned to. Only tags may be updated. </summary>
    public partial class FakePatch : UpdateResource
    {
        /// <summary>
        /// Initializes a new instance of global::MgmtLRO.Models.FakePatch
        ///
        /// </summary>
        public FakePatch()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtLRO.Models.FakePatch
        ///
        /// </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="platformUpdateDomainCount"> Update Domain count. </param>
        /// <param name="platformFaultDomainCount"> Fault Domain count. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FakePatch(IDictionary<string, string> tags, int? platformUpdateDomainCount, int? platformFaultDomainCount, Dictionary<string, BinaryData> rawData) : base(tags, rawData)
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
