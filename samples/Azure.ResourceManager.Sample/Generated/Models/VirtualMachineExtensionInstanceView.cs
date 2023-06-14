// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The instance view of a virtual machine extension.
    /// Serialized Name: VirtualMachineExtensionInstanceView
    /// </summary>
    public partial class VirtualMachineExtensionInstanceView
    {
        /// <summary> Initializes a new instance of VirtualMachineExtensionInstanceView. </summary>
        public VirtualMachineExtensionInstanceView()
        {
            Substatuses = new ChangeTrackingList<InstanceViewStatus>();
            Statuses = new ChangeTrackingList<InstanceViewStatus>();
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionInstanceView. </summary>
        /// <param name="name">
        /// The virtual machine extension name.
        /// Serialized Name: VirtualMachineExtensionInstanceView.name
        /// </param>
        /// <param name="virtualMachineExtensionInstanceViewType">
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtensionInstanceView.type
        /// </param>
        /// <param name="typeHandlerVersion">
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtensionInstanceView.typeHandlerVersion
        /// </param>
        /// <param name="substatuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineExtensionInstanceView.substatuses
        /// </param>
        /// <param name="statuses">
        /// The resource status information.
        /// Serialized Name: VirtualMachineExtensionInstanceView.statuses
        /// </param>
        internal VirtualMachineExtensionInstanceView(string name, string virtualMachineExtensionInstanceViewType, string typeHandlerVersion, IList<InstanceViewStatus> substatuses, IList<InstanceViewStatus> statuses)
        {
            Name = name;
            VirtualMachineExtensionInstanceViewType = virtualMachineExtensionInstanceViewType;
            TypeHandlerVersion = typeHandlerVersion;
            Substatuses = substatuses;
            Statuses = statuses;
        }

        /// <summary>
        /// The virtual machine extension name.
        /// Serialized Name: VirtualMachineExtensionInstanceView.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtensionInstanceView.type
        /// </summary>
        public string VirtualMachineExtensionInstanceViewType { get; set; }
        /// <summary>
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtensionInstanceView.typeHandlerVersion
        /// </summary>
        public string TypeHandlerVersion { get; set; }
        /// <summary>
        /// The resource status information.
        /// Serialized Name: VirtualMachineExtensionInstanceView.substatuses
        /// </summary>
        public IList<InstanceViewStatus> Substatuses { get; }
        /// <summary>
        /// The resource status information.
        /// Serialized Name: VirtualMachineExtensionInstanceView.statuses
        /// </summary>
        public IList<InstanceViewStatus> Statuses { get; }
    }
}
