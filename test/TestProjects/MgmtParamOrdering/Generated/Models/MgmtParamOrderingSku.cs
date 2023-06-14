// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtParamOrdering.Models
{
    /// <summary> Describes a virtual machine scale set sku. NOTE: If the new VM SKU is not supported on the hardware the scale set is currently on, you need to deallocate the VMs in the scale set before you modify the SKU name. </summary>
    public partial class MgmtParamOrderingSku
    {
        /// <summary> Initializes a new instance of MgmtParamOrderingSku. </summary>
        public MgmtParamOrderingSku()
        {
        }

        /// <summary> The sku name. </summary>
        public string Name { get; set; }
        /// <summary> Specifies the tier of virtual machines in a scale set.&lt;br /&gt;&lt;br /&gt; Possible Values:&lt;br /&gt;&lt;br /&gt; **Standard**&lt;br /&gt;&lt;br /&gt; **Basic**. </summary>
        public string Tier { get; set; }
        /// <summary> Specifies the number of virtual machines in the scale set. </summary>
        public long? Capacity { get; set; }
    }
}
