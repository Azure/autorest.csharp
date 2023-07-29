// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using MgmtPartialResource;

namespace MgmtPartialResource.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    internal partial class MgmtPartialResourceArmClientMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MgmtPartialResourceArmClientMockingExtension"/> class for mocking. </summary>
        protected MgmtPartialResourceArmClientMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtPartialResourceArmClientMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtPartialResourceArmClientMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MgmtPartialResourceArmClientMockingExtension(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets an object representing a <see cref="PublicIPAddressResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PublicIPAddressResource.CreateResourceIdentifier" /> to create a <see cref="PublicIPAddressResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PublicIPAddressResource" /> object. </returns>
        public virtual PublicIPAddressResource GetPublicIPAddressResource(ResourceIdentifier id)
        {
            PublicIPAddressResource.ValidateResourceId(id);
            return new PublicIPAddressResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ConfigurationProfileAssignmentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ConfigurationProfileAssignmentResource.CreateResourceIdentifier" /> to create a <see cref="ConfigurationProfileAssignmentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ConfigurationProfileAssignmentResource" /> object. </returns>
        public virtual ConfigurationProfileAssignmentResource GetConfigurationProfileAssignmentResource(ResourceIdentifier id)
        {
            ConfigurationProfileAssignmentResource.ValidateResourceId(id);
            return new ConfigurationProfileAssignmentResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PartialVmssResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PartialVmssResource.CreateResourceIdentifier" /> to create a <see cref="PartialVmssResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PartialVmssResource" /> object. </returns>
        public virtual PartialVmssResource GetPartialVmssResource(ResourceIdentifier id)
        {
            PartialVmssResource.ValidateResourceId(id);
            return new PartialVmssResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineMgmtPartialResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineMgmtPartialResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineMgmtPartialResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineMgmtPartialResource" /> object. </returns>
        public virtual VirtualMachineMgmtPartialResource GetVirtualMachineMgmtPartialResource(ResourceIdentifier id)
        {
            VirtualMachineMgmtPartialResource.ValidateResourceId(id);
            return new VirtualMachineMgmtPartialResource(Client, id);
        }
    }
}
