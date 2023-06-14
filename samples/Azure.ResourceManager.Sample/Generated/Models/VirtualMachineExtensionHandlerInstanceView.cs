// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The instance view of a virtual machine extension handler.
    /// Serialized Name: VirtualMachineExtensionHandlerInstanceView
    /// </summary>
    public partial class VirtualMachineExtensionHandlerInstanceView
    {
        /// <summary> Initializes a new instance of VirtualMachineExtensionHandlerInstanceView. </summary>
        internal VirtualMachineExtensionHandlerInstanceView()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionHandlerInstanceView. </summary>
        /// <param name="virtualMachineExtensionHandlerInstanceViewType">
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtensionHandlerInstanceView.type
        /// </param>
        /// <param name="typeHandlerVersion">
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtensionHandlerInstanceView.typeHandlerVersion
        /// </param>
        /// <param name="status">
        /// The extension handler status.
        /// Serialized Name: VirtualMachineExtensionHandlerInstanceView.status
        /// </param>
        internal VirtualMachineExtensionHandlerInstanceView(string virtualMachineExtensionHandlerInstanceViewType, string typeHandlerVersion, InstanceViewStatus status)
        {
            VirtualMachineExtensionHandlerInstanceViewType = virtualMachineExtensionHandlerInstanceViewType;
            TypeHandlerVersion = typeHandlerVersion;
            Status = status;
        }

        /// <summary>
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// Serialized Name: VirtualMachineExtensionHandlerInstanceView.type
        /// </summary>
        public string VirtualMachineExtensionHandlerInstanceViewType { get; }
        /// <summary>
        /// Specifies the version of the script handler.
        /// Serialized Name: VirtualMachineExtensionHandlerInstanceView.typeHandlerVersion
        /// </summary>
        public string TypeHandlerVersion { get; }
        /// <summary>
        /// The extension handler status.
        /// Serialized Name: VirtualMachineExtensionHandlerInstanceView.status
        /// </summary>
        public InstanceViewStatus Status { get; }
    }
}
