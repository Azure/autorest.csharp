// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a virtual machine scale set sku. NOTE: If the new VM SKU is not supported on the hardware the scale set is currently on, you need to deallocate the VMs in the scale set before you modify the SKU name.
    /// Serialized Name: Sku
    /// </summary>
    public partial class SampleSku
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="SampleSku"/>. </summary>
        public SampleSku()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SampleSku"/>. </summary>
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
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SampleSku(string name, string tier, long? capacity, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Tier = tier;
            Capacity = capacity;
            _serializedAdditionalRawData = serializedAdditionalRawData;
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
