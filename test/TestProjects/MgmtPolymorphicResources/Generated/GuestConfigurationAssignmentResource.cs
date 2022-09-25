// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtPolymorphicResources
{
    /// <summary> This is the base client representation of the following resources <see cref="VirtualMachineGuestConfigurationAssignmentResource" /> or <see cref="VirtualMachineScaleSetGuestConfigurationAssignmentResource" />. </summary>
    public abstract partial class GuestConfigurationAssignmentResource : ArmResource
    {
        internal static GuestConfigurationAssignmentResource GetResource(ArmClient client, GuestConfigurationAssignmentData data)
        {
            if (IsVirtualMachineGuestConfigurationAssignmentResource(data.Id))
            {
                return new VirtualMachineGuestConfigurationAssignmentResource(client, data);
            }
            if (IsVirtualMachineScaleSetGuestConfigurationAssignmentResource(data.Id))
            {
                return new VirtualMachineScaleSetGuestConfigurationAssignmentResource(client, data);
            }
            throw new InvalidOperationException($"The resource identifier {data.Id} cannot be recognized as one of the following resource candidates: VirtualMachineGuestConfigurationAssignmentResource or VirtualMachineScaleSetGuestConfigurationAssignmentResource");
        }

        private static bool IsVirtualMachineGuestConfigurationAssignmentResource(ResourceIdentifier id)
        {
            // checking the resource type
            if (id.ResourceType != VirtualMachineGuestConfigurationAssignmentResource.ResourceType)
            {
                return false;
            }
            // checking the resource scope
            if (id.Parent.ResourceType != VirtualMachineResource.ResourceType)
            {
                return false;
            }
            return true;
        }

        private static bool IsVirtualMachineScaleSetGuestConfigurationAssignmentResource(ResourceIdentifier id)
        {
            // checking the resource type
            if (id.ResourceType != VirtualMachineScaleSetGuestConfigurationAssignmentResource.ResourceType)
            {
                return false;
            }
            // checking the resource scope
            if (id.Parent.ResourceType != VirtualMachineScaleSetResource.ResourceType)
            {
                return false;
            }
            return true;
        }

        private readonly GuestConfigurationAssignmentData _data;

        /// <summary> Initializes a new instance of the <see cref="GuestConfigurationAssignmentResource"/> class for mocking. </summary>
        protected GuestConfigurationAssignmentResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "GuestConfigurationAssignmentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal GuestConfigurationAssignmentResource(ArmClient client, GuestConfigurationAssignmentData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="GuestConfigurationAssignmentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal GuestConfigurationAssignmentResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual GuestConfigurationAssignmentData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        /// <summary> The core implementation for operation Get. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        protected abstract Task<Response<GuestConfigurationAssignmentResource>> GetCoreAsync(CancellationToken cancellationToken = default);

        /// <summary> The default implementation for operation Get. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<GuestConfigurationAssignmentResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await GetCoreAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> The core implementation for operation Get. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        protected abstract Response<GuestConfigurationAssignmentResource> GetCore(CancellationToken cancellationToken = default);

        /// <summary> The default implementation for operation Get. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<GuestConfigurationAssignmentResource> Get(CancellationToken cancellationToken = default)
        {
            return GetCore(cancellationToken);
        }
    }
}
