// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    /// <summary>
    /// A Class representing a RoleAssignment along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="RoleAssignmentResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetRoleAssignmentResource method.
    /// Otherwise you can get one from its parent resource <see cref="ArmResource" /> using the GetRoleAssignment method.
    /// </summary>
    public partial class RoleAssignmentResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="RoleAssignmentResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string scope, string roleAssignmentName)
        {
            var resourceId = $"{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _roleAssignmentClientDiagnostics;
        private readonly RoleAssignmentsRestOperations _roleAssignmentRestClient;
        private readonly RoleAssignmentData _data;

        /// <summary> Initializes a new instance of the <see cref="RoleAssignmentResource"/> class for mocking. </summary>
        protected RoleAssignmentResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "RoleAssignmentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal RoleAssignmentResource(ArmClient client, RoleAssignmentData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="RoleAssignmentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal RoleAssignmentResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _roleAssignmentClientDiagnostics = new ClientDiagnostics("MgmtMockAndSample", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string roleAssignmentApiVersion);
            _roleAssignmentRestClient = new RoleAssignmentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, roleAssignmentApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Authorization/roleAssignments";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual RoleAssignmentData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Get the specified role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RoleAssignmentResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentResource.Get");
            scope.Start();
            try
            {
                var response = await _roleAssignmentRestClient.GetAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RoleAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the specified role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RoleAssignmentResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentResource.Get");
            scope.Start();
            try
            {
                var response = _roleAssignmentRestClient.Get(Id.Parent, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new RoleAssignmentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<RoleAssignmentResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentResource.Delete");
            scope.Start();
            try
            {
                var response = await _roleAssignmentRestClient.DeleteAsync(Id.Parent, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtMockAndSampleArmOperation<RoleAssignmentResource>(Response.FromValue(new RoleAssignmentResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<RoleAssignmentResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentResource.Delete");
            scope.Start();
            try
            {
                var response = _roleAssignmentRestClient.Delete(Id.Parent, Id.Name, cancellationToken);
                var operation = new MgmtMockAndSampleArmOperation<RoleAssignmentResource>(Response.FromValue(new RoleAssignmentResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Parameters for the role assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<RoleAssignmentResource>> UpdateAsync(WaitUntil waitUntil, RoleAssignmentCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentResource.Update");
            scope.Start();
            try
            {
                var response = await _roleAssignmentRestClient.CreateAsync(Id.Parent, Id.Name, content, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtMockAndSampleArmOperation<RoleAssignmentResource>(Response.FromValue(new RoleAssignmentResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> Parameters for the role assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<RoleAssignmentResource> Update(WaitUntil waitUntil, RoleAssignmentCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentResource.Update");
            scope.Start();
            try
            {
                var response = _roleAssignmentRestClient.Create(Id.Parent, Id.Name, content, cancellationToken);
                var operation = new MgmtMockAndSampleArmOperation<RoleAssignmentResource>(Response.FromValue(new RoleAssignmentResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all role assignments for the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}/validate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Validate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ValidateAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentResource.Validate");
            scope.Start();
            try
            {
                var response = await _roleAssignmentRestClient.ValidateAsync(Id.SubscriptionId, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all role assignments for the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}/validate</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Validate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Validate(CancellationToken cancellationToken = default)
        {
            using var scope = _roleAssignmentClientDiagnostics.CreateScope("RoleAssignmentResource.Validate");
            scope.Start();
            try
            {
                var response = _roleAssignmentRestClient.Validate(Id.SubscriptionId, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
