// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a virtual machine scale set sku. NOTE: If the new VM SKU is not supported on the hardware the scale set is currently on, you need to deallocate the VMs in the scale set before you modify the SKU name.
    /// Serialized Name: SampleSku
    /// </summary>
    public partial class SampleSku
    {
        /// <summary> Initializes a new instance of SampleSku. </summary>
        public SampleSku()
        {
        }

        /// <summary> Initializes a new instance of SampleSku. </summary>
        /// <param name="name">
        /// The sku name.
        /// Serialized Name: SampleSku.name
        /// </param>
        /// <param name="tier">
        /// Specifies the tier of virtual machines in a scale set.&lt;br /&gt;&lt;br /&gt; Possible Values:&lt;br /&gt;&lt;br /&gt; **Standard**&lt;br /&gt;&lt;br /&gt; **Basic**
        /// Serialized Name: SampleSku.tier
        /// </param>
        /// <param name="capacity">
        /// Specifies the number of virtual machines in the scale set.
        /// Serialized Name: SampleSku.capacity
        /// </param>
        internal SampleSku(string name, string tier, long? capacity)
        {
            Name = name;
            Tier = tier;
            Capacity = capacity;
        }

        /// <summary>
        /// The sku name.
        /// Serialized Name: SampleSku.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the tier of virtual machines in a scale set.&lt;br /&gt;&lt;br /&gt; Possible Values:&lt;br /&gt;&lt;br /&gt; **Standard**&lt;br /&gt;&lt;br /&gt; **Basic**
        /// Serialized Name: SampleSku.tier
        /// </summary>
        public string Tier { get; set; }
        /// <summary>
        /// Specifies the number of virtual machines in the scale set.
        /// Serialized Name: SampleSku.capacity
        /// </summary>
        public long? Capacity { get; set; }
    }
}
