// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AzureSample.ResourceManager.Sample.Models
{
    /// <summary>
    /// Virtual machine image resource information.
    /// Serialized Name: VirtualMachineImageResource
    /// </summary>
    public partial class VirtualMachineImageResource : SubResource
    {
        /// <summary> Initializes a new instance of <see cref="VirtualMachineImageResource"/>. </summary>
        /// <param name="name">
        /// The name of the resource.
        /// Serialized Name: VirtualMachineImageResource.name
        /// </param>
        /// <param name="location">
        /// The supported Azure location of the resource.
        /// Serialized Name: VirtualMachineImageResource.location
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public VirtualMachineImageResource(string name, AzureLocation location)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineImageResource"/>. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="name">
        /// The name of the resource.
        /// Serialized Name: VirtualMachineImageResource.name
        /// </param>
        /// <param name="location">
        /// The supported Azure location of the resource.
        /// Serialized Name: VirtualMachineImageResource.location
        /// </param>
        /// <param name="tags">
        /// Specifies the tags that are assigned to the virtual machine. For more information about using tags, see [Using tags to organize your Azure resources](https://docs.microsoft.com/azure/azure-resource-manager/resource-group-using-tags.md).
        /// Serialized Name: VirtualMachineImageResource.tags
        /// </param>
        internal VirtualMachineImageResource(string id, IDictionary<string, BinaryData> serializedAdditionalRawData, string name, AzureLocation location, IDictionary<string, string> tags) : base(id, serializedAdditionalRawData)
        {
            Name = name;
            Location = location;
            Tags = tags;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineImageResource"/> for deserialization. </summary>
        internal VirtualMachineImageResource()
        {
        }

        /// <summary>
        /// The name of the resource.
        /// Serialized Name: VirtualMachineImageResource.name
        /// </summary>
        [WirePath("name")]
        public string Name { get; set; }
        /// <summary>
        /// The supported Azure location of the resource.
        /// Serialized Name: VirtualMachineImageResource.location
        /// </summary>
        [WirePath("location")]
        public AzureLocation Location { get; set; }
        /// <summary>
        /// Specifies the tags that are assigned to the virtual machine. For more information about using tags, see [Using tags to organize your Azure resources](https://docs.microsoft.com/azure/azure-resource-manager/resource-group-using-tags.md).
        /// Serialized Name: VirtualMachineImageResource.tags
        /// </summary>
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get; }
    }
}
