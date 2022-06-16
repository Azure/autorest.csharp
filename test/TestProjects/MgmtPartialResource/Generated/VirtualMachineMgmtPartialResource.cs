// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtPartialResource
{
    /// <summary>
    /// A Class representing a VirtualMachine along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="VirtualMachineMgmtPartialResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetVirtualMachineMgmtPartialResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetVirtualMachine method.
    /// </summary>
    public partial class VirtualMachineMgmtPartialResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="VirtualMachineMgmtPartialResource"/> instance. </summary>
        internal static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineMgmtPartialResource"/> class for mocking. </summary>
        protected VirtualMachineMgmtPartialResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineMgmtPartialResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineMgmtPartialResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/virtualMachines";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of ConfigurationProfileAssignmentResources in the VirtualMachine. </summary>
        /// <returns> An object representing collection of ConfigurationProfileAssignmentResources and their operations over a ConfigurationProfileAssignmentResource. </returns>
        public virtual ConfigurationProfileAssignmentCollection GetConfigurationProfileAssignments()
        {
            return GetCachedClient(Client => new ConfigurationProfileAssignmentCollection(Client, Id));
        }

        /// <summary>
        /// Get information about a configuration profile assignment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}
        /// Operation Id: ConfigurationProfileAssignments_Get
        /// </summary>
        /// <param name="configurationProfileAssignmentName"> The configuration profile assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationProfileAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationProfileAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ConfigurationProfileAssignmentResource>> GetConfigurationProfileAssignmentAsync(string configurationProfileAssignmentName, CancellationToken cancellationToken = default)
        {
            return await GetConfigurationProfileAssignments().GetAsync(configurationProfileAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get information about a configuration profile assignment
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}
        /// Operation Id: ConfigurationProfileAssignments_Get
        /// </summary>
        /// <param name="configurationProfileAssignmentName"> The configuration profile assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationProfileAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationProfileAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<ConfigurationProfileAssignmentResource> GetConfigurationProfileAssignment(string configurationProfileAssignmentName, CancellationToken cancellationToken = default)
        {
            return GetConfigurationProfileAssignments().Get(configurationProfileAssignmentName, cancellationToken);
        }
    }
}
