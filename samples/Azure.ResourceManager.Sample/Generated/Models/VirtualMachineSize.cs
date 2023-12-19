// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes the properties of a VM size.
    /// Serialized Name: VirtualMachineSize
    /// </summary>
    public partial class VirtualMachineSize
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

        /// <summary> Initializes a new instance of <see cref="VirtualMachineSize"/>. </summary>
        internal VirtualMachineSize()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineSize"/>. </summary>
        /// <param name="name">
        /// The name of the virtual machine size.
        /// Serialized Name: VirtualMachineSize.name
        /// </param>
        /// <param name="numberOfCores">
        /// The number of cores supported by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.numberOfCores
        /// </param>
        /// <param name="osDiskSizeInMB">
        /// The OS disk size, in MB, allowed by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.osDiskSizeInMB
        /// </param>
        /// <param name="resourceDiskSizeInMB">
        /// The resource disk size, in MB, allowed by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.resourceDiskSizeInMB
        /// </param>
        /// <param name="memoryInMB">
        /// The amount of memory, in MB, supported by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.memoryInMB
        /// </param>
        /// <param name="maxDataDiskCount">
        /// The maximum number of data disks that can be attached to the virtual machine size.
        /// Serialized Name: VirtualMachineSize.maxDataDiskCount
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineSize(string name, int? numberOfCores, int? osDiskSizeInMB, int? resourceDiskSizeInMB, int? memoryInMB, int? maxDataDiskCount, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            NumberOfCores = numberOfCores;
            OSDiskSizeInMB = osDiskSizeInMB;
            ResourceDiskSizeInMB = resourceDiskSizeInMB;
            MemoryInMB = memoryInMB;
            MaxDataDiskCount = maxDataDiskCount;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The name of the virtual machine size.
        /// Serialized Name: VirtualMachineSize.name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The number of cores supported by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.numberOfCores
        /// </summary>
        public int? NumberOfCores { get; }
        /// <summary>
        /// The OS disk size, in MB, allowed by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.osDiskSizeInMB
        /// </summary>
        public int? OSDiskSizeInMB { get; }
        /// <summary>
        /// The resource disk size, in MB, allowed by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.resourceDiskSizeInMB
        /// </summary>
        public int? ResourceDiskSizeInMB { get; }
        /// <summary>
        /// The amount of memory, in MB, supported by the virtual machine size.
        /// Serialized Name: VirtualMachineSize.memoryInMB
        /// </summary>
        public int? MemoryInMB { get; }
        /// <summary>
        /// The maximum number of data disks that can be attached to the virtual machine size.
        /// Serialized Name: VirtualMachineSize.maxDataDiskCount
        /// </summary>
        public int? MaxDataDiskCount { get; }
    }
}
