// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a virtual machine scale set sku. NOTE: If the new VM SKU is not supported on the hardware the scale set is currently on, you need to deallocate the VMs in the scale set before you modify the SKU name.
    /// Serialized Name: Sku
    /// </summary>
    public partial class MgmtRenameRulesSku
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.MgmtRenameRulesSku
        ///
        /// </summary>
        public MgmtRenameRulesSku()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.MgmtRenameRulesSku
        ///
        /// </summary>
        /// <param name="name">
        /// The sku name.
        /// Serialized Name: Sku.name
        /// </param>
        /// <param name="tier">
        /// Specifies the tier of virtual machines in a scale set.&lt;br /&gt;&lt;br /&gt; Possible Values:&lt;br /&gt;&lt;br /&gt; **Standard**&lt;br /&gt;&lt;br /&gt; **Basic**
        /// Serialized Name: Sku.tier
        /// </param>
        /// <param name="capacity">
        /// Specifies the number of virtual machines in the scale set.
        /// Serialized Name: Sku.capacity
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal MgmtRenameRulesSku(string name, string tier, long? capacity, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            Tier = tier;
            Capacity = capacity;
            _rawData = rawData;
        }

        /// <summary>
        /// The sku name.
        /// Serialized Name: Sku.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the tier of virtual machines in a scale set.&lt;br /&gt;&lt;br /&gt; Possible Values:&lt;br /&gt;&lt;br /&gt; **Standard**&lt;br /&gt;&lt;br /&gt; **Basic**
        /// Serialized Name: Sku.tier
        /// </summary>
        public string Tier { get; set; }
        /// <summary>
        /// Specifies the number of virtual machines in the scale set.
        /// Serialized Name: Sku.capacity
        /// </summary>
        public long? Capacity { get; set; }
    }
}
