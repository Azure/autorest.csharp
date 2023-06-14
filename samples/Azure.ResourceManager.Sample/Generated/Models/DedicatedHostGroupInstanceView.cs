// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The DedicatedHostGroupInstanceView.
    /// Serialized Name: DedicatedHostGroupInstanceView
    /// </summary>
    internal partial class DedicatedHostGroupInstanceView
    {
        /// <summary> Initializes a new instance of DedicatedHostGroupInstanceView. </summary>
        internal DedicatedHostGroupInstanceView()
        {
            Hosts = new ChangeTrackingList<DedicatedHostInstanceViewWithName>();
        }

        /// <summary> Initializes a new instance of DedicatedHostGroupInstanceView. </summary>
        /// <param name="hosts">
        /// List of instance view of the dedicated hosts under the dedicated host group.
        /// Serialized Name: DedicatedHostGroupInstanceView.hosts
        /// </param>
        internal DedicatedHostGroupInstanceView(IReadOnlyList<DedicatedHostInstanceViewWithName> hosts)
        {
            Hosts = hosts;
        }

        /// <summary>
        /// List of instance view of the dedicated hosts under the dedicated host group.
        /// Serialized Name: DedicatedHostGroupInstanceView.hosts
        /// </summary>
        public IReadOnlyList<DedicatedHostInstanceViewWithName> Hosts { get; }
    }
}
