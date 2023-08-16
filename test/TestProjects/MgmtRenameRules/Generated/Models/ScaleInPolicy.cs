// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a scale-in policy for a virtual machine scale set.
    /// Serialized Name: ScaleInPolicy
    /// </summary>
    internal partial class ScaleInPolicy
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.ScaleInPolicy
        ///
        /// </summary>
        public ScaleInPolicy()
        {
            Rules = new ChangeTrackingList<VirtualMachineScaleSetScaleInRule>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.ScaleInPolicy
        ///
        /// </summary>
        /// <param name="rules">
        /// The rules to be followed when scaling-in a virtual machine scale set. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Default** When a virtual machine scale set is scaled in, the scale set will first be balanced across zones if it is a zonal scale set. Then, it will be balanced across Fault Domains as far as possible. Within each Fault Domain, the virtual machines chosen for removal will be the newest ones that are not protected from scale-in. &lt;br&gt;&lt;br&gt; **OldestVM** When a virtual machine scale set is being scaled-in, the oldest virtual machines that are not protected from scale-in will be chosen for removal. For zonal virtual machine scale sets, the scale set will first be balanced across zones. Within each zone, the oldest virtual machines that are not protected will be chosen for removal. &lt;br&gt;&lt;br&gt; **NewestVM** When a virtual machine scale set is being scaled-in, the newest virtual machines that are not protected from scale-in will be chosen for removal. For zonal virtual machine scale sets, the scale set will first be balanced across zones. Within each zone, the newest virtual machines that are not protected will be chosen for removal. &lt;br&gt;&lt;br&gt;
        /// Serialized Name: ScaleInPolicy.rules
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ScaleInPolicy(IList<VirtualMachineScaleSetScaleInRule> rules, Dictionary<string, BinaryData> rawData)
        {
            Rules = rules;
            _rawData = rawData;
        }

        /// <summary>
        /// The rules to be followed when scaling-in a virtual machine scale set. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **Default** When a virtual machine scale set is scaled in, the scale set will first be balanced across zones if it is a zonal scale set. Then, it will be balanced across Fault Domains as far as possible. Within each Fault Domain, the virtual machines chosen for removal will be the newest ones that are not protected from scale-in. &lt;br&gt;&lt;br&gt; **OldestVM** When a virtual machine scale set is being scaled-in, the oldest virtual machines that are not protected from scale-in will be chosen for removal. For zonal virtual machine scale sets, the scale set will first be balanced across zones. Within each zone, the oldest virtual machines that are not protected will be chosen for removal. &lt;br&gt;&lt;br&gt; **NewestVM** When a virtual machine scale set is being scaled-in, the newest virtual machines that are not protected from scale-in will be chosen for removal. For zonal virtual machine scale sets, the scale set will first be balanced across zones. Within each zone, the newest virtual machines that are not protected will be chosen for removal. &lt;br&gt;&lt;br&gt;
        /// Serialized Name: ScaleInPolicy.rules
        /// </summary>
        public IList<VirtualMachineScaleSetScaleInRule> Rules { get; }
    }
}
