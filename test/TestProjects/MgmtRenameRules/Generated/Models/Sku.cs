// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary> Describes a virtual machine scale set sku. NOTE: If the new VM SKU is not supported on the hardware the scale set is currently on, you need to deallocate the VMs in the scale set before you modify the SKU name. </summary>
    public partial class Sku
    {
        /// <summary> Initializes a new instance of Sku. </summary>
        public Sku()
        {
        }

        /// <summary> Initializes a new instance of Sku. </summary>
        /// <param name="name"> The sku name. </param>
        /// <param name="tier"> Specifies the tier of virtual machines in a scale set.&lt;br /&gt;&lt;br /&gt; Possible Values:&lt;br /&gt;&lt;br /&gt; **Standard**&lt;br /&gt;&lt;br /&gt; **Basic**. </param>
        /// <param name="capacity"> Specifies the number of virtual machines in the scale set. </param>
        internal Sku(string name, string tier, long? capacity)
        {
            Name = name;
            Tier = tier;
            Capacity = capacity;
        }

        /// <summary> The sku name. </summary>
        public string Name { get; set; }
        /// <summary> Specifies the tier of virtual machines in a scale set.&lt;br /&gt;&lt;br /&gt; Possible Values:&lt;br /&gt;&lt;br /&gt; **Standard**&lt;br /&gt;&lt;br /&gt; **Basic**. </summary>
        public string Tier { get; set; }
        /// <summary> Specifies the number of virtual machines in the scale set. </summary>
        public long? Capacity { get; set; }
    }
}
