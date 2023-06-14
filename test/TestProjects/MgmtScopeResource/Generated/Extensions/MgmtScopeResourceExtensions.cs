// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using MgmtScopeResource.Models;

namespace MgmtScopeResource
{
    /// <summary> A class to add extension methods to MgmtScopeResource. </summary>
    public static partial class MgmtScopeResourceExtensions
    {
        private static ArmResourceExtensionClient GetArmResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new ArmResourceExtensionClient(client, resource.Id);
            });
        }

        private static ArmResourceExtensionClient GetArmResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ArmResourceExtensionClient(client, scope);
            });
        }

        private static ManagementGroupResourceExtensionClient GetManagementGroupResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new ManagementGroupResourceExtensionClient(client, resource.Id);
            });
        }

        private static ManagementGroupResourceExtensionClient GetManagementGroupResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ManagementGroupResourceExtensionClient(client, scope);
            });
        }

        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new ResourceGroupResourceExtensionClient(client, resource.Id);
            });
        }

        private static ResourceGroupResourceExtensionClient GetResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new ResourceGroupResourceExtensionClient(client, scope);
            });
        }

        private static SubscriptionResourceExtensionClient GetSubscriptionResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new SubscriptionResourceExtensionClient(client, resource.Id);
            });
        }

        private static SubscriptionResourceExtensionClient GetSubscriptionResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new SubscriptionResourceExtensionClient(client, scope);
            });
        }

        private static TenantResourceExtensionClient GetTenantResourceExtensionClient(ArmResource resource)
        {
            return resource.GetCachedClient(client =>
            {
                return new TenantResourceExtensionClient(client, resource.Id);
            });
        }

        private static TenantResourceExtensionClient GetTenantResourceExtensionClient(ArmClient client, ResourceIdentifier scope)
        {
            return client.GetResourceClient(() =>
            {
                return new TenantResourceExtensionClient(client, scope);
            });
        }
        #region FakePolicyAssignmentResource
        /// <summary>
        /// Gets an object representing a <see cref="FakePolicyAssignmentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FakePolicyAssignmentResource.CreateResourceIdentifier" /> to create a <see cref="FakePolicyAssignmentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FakePolicyAssignmentResource" /> object. </returns>
        public static FakePolicyAssignmentResource GetFakePolicyAssignmentResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FakePolicyAssignmentResource.ValidateResourceId(id);
                return new FakePolicyAssignmentResource(client, id);
            }
            );
        }
        #endregion

        #region DeploymentExtendedResource
        /// <summary>
        /// Gets an object representing a <see cref="DeploymentExtendedResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DeploymentExtendedResource.CreateResourceIdentifier" /> to create a <see cref="DeploymentExtendedResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DeploymentExtendedResource" /> object. </returns>
        public static DeploymentExtendedResource GetDeploymentExtendedResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DeploymentExtendedResource.ValidateResourceId(id);
                return new DeploymentExtendedResource(client, id);
            }
            );
        }
        #endregion

        #region ResourceLinkResource
        /// <summary>
        /// Gets an object representing a <see cref="ResourceLinkResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ResourceLinkResource.CreateResourceIdentifier" /> to create a <see cref="ResourceLinkResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ResourceLinkResource" /> object. </returns>
        public static ResourceLinkResource GetResourceLinkResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ResourceLinkResource.ValidateResourceId(id);
                return new ResourceLinkResource(client, id);
            }
            );
        }
        #endregion

        #region VMInsightsOnboardingStatusResource
        /// <summary>
        /// Gets an object representing a <see cref="VMInsightsOnboardingStatusResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VMInsightsOnboardingStatusResource.CreateResourceIdentifier" /> to create a <see cref="VMInsightsOnboardingStatusResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VMInsightsOnboardingStatusResource" /> object. </returns>
        public static VMInsightsOnboardingStatusResource GetVMInsightsOnboardingStatusResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VMInsightsOnboardingStatusResource.ValidateResourceId(id);
                return new VMInsightsOnboardingStatusResource(client, id);
            }
            );
        }
        #endregion

        #region GuestConfigurationAssignmentResource
        /// <summary>
        /// Gets an object representing a <see cref="GuestConfigurationAssignmentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="GuestConfigurationAssignmentResource.CreateResourceIdentifier" /> to create a <see cref="GuestConfigurationAssignmentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="GuestConfigurationAssignmentResource" /> object. </returns>
        public static GuestConfigurationAssignmentResource GetGuestConfigurationAssignmentResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                GuestConfigurationAssignmentResource.ValidateResourceId(id);
                return new GuestConfigurationAssignmentResource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of FakePolicyAssignmentResources in the ArmResource. </summary>
        /// <param name="armResource"> The <see cref="ArmResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of FakePolicyAssignmentResources and their operations over a FakePolicyAssignmentResource. </returns>
        public static FakePolicyAssignmentCollection GetFakePolicyAssignments(this ArmResource armResource)
        {
            return GetArmResourceExtensionClient(armResource).GetFakePolicyAssignments();
        }

        /// <summary> Gets a collection of FakePolicyAssignmentResources in the ArmResource. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <returns> An object representing collection of FakePolicyAssignmentResources and their operations over a FakePolicyAssignmentResource. </returns>
        public static FakePolicyAssignmentCollection GetFakePolicyAssignments(this ArmClient client, ResourceIdentifier scope)
        {
            return GetArmResourceExtensionClient(client, scope).GetFakePolicyAssignments();
        }

        /// <summary>
        /// This operation retrieves a single policy assignment, given its name and the scope it was created at.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="armResource"> The <see cref="ArmResource" /> instance the method will execute against. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<FakePolicyAssignmentResource>> GetFakePolicyAssignmentAsync(this ArmResource armResource, string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            return await armResource.GetFakePolicyAssignments().GetAsync(policyAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This operation retrieves a single policy assignment, given its name and the scope it was created at.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<FakePolicyAssignmentResource>> GetFakePolicyAssignmentAsync(this ArmClient client, ResourceIdentifier scope, string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            return await client.GetFakePolicyAssignments(scope).GetAsync(policyAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// This operation retrieves a single policy assignment, given its name and the scope it was created at.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="armResource"> The <see cref="ArmResource" /> instance the method will execute against. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<FakePolicyAssignmentResource> GetFakePolicyAssignment(this ArmResource armResource, string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            return armResource.GetFakePolicyAssignments().Get(policyAssignmentName, cancellationToken);
        }

        /// <summary>
        /// This operation retrieves a single policy assignment, given its name and the scope it was created at.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakePolicyAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="policyAssignmentName"> The name of the policy assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<FakePolicyAssignmentResource> GetFakePolicyAssignment(this ArmClient client, ResourceIdentifier scope, string policyAssignmentName, CancellationToken cancellationToken = default)
        {
            return client.GetFakePolicyAssignments(scope).Get(policyAssignmentName, cancellationToken);
        }

        /// <summary> Gets an object representing a VMInsightsOnboardingStatusResource along with the instance operations that can be performed on it in the ArmResource. </summary>
        /// <param name="armResource"> The <see cref="ArmResource" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="VMInsightsOnboardingStatusResource" /> object. </returns>
        public static VMInsightsOnboardingStatusResource GetVMInsightsOnboardingStatus(this ArmResource armResource)
        {
            return GetArmResourceExtensionClient(armResource).GetVMInsightsOnboardingStatus();
        }

        /// <summary> Gets an object representing a VMInsightsOnboardingStatusResource along with the instance operations that can be performed on it in the ArmResource. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <returns> Returns a <see cref="VMInsightsOnboardingStatusResource" /> object. </returns>
        public static VMInsightsOnboardingStatusResource GetVMInsightsOnboardingStatus(this ArmClient client, ResourceIdentifier scope)
        {
            return GetArmResourceExtensionClient(client, scope).GetVMInsightsOnboardingStatus();
        }

        /// <summary> Gets a collection of GuestConfigurationAssignmentResources in the ArmResource. </summary>
        /// <param name="armResource"> The <see cref="ArmResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of GuestConfigurationAssignmentResources and their operations over a GuestConfigurationAssignmentResource. </returns>
        public static GuestConfigurationAssignmentCollection GetGuestConfigurationAssignments(this ArmResource armResource)
        {
            return GetArmResourceExtensionClient(armResource).GetGuestConfigurationAssignments();
        }

        /// <summary> Gets a collection of GuestConfigurationAssignmentResources in the ArmResource. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. Expected resource type includes the following: Microsoft.Compute/virtualMachines. </param>
        /// <returns> An object representing collection of GuestConfigurationAssignmentResources and their operations over a GuestConfigurationAssignmentResource. </returns>
        public static GuestConfigurationAssignmentCollection GetGuestConfigurationAssignments(this ArmClient client, ResourceIdentifier scope)
        {
            if (!scope.ResourceType.Equals("Microsoft.Compute/virtualMachines"))
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected Microsoft.Compute/virtualMachines", scope.ResourceType));
            }
            return GetArmResourceExtensionClient(client, scope).GetGuestConfigurationAssignments();
        }

        /// <summary>
        /// Get information about a guest configuration assignment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="armResource"> The <see cref="ArmResource" /> instance the method will execute against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<GuestConfigurationAssignmentResource>> GetGuestConfigurationAssignmentAsync(this ArmResource armResource, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return await armResource.GetGuestConfigurationAssignments().GetAsync(guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get information about a guest configuration assignment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. Expected resource type includes the following: Microsoft.Compute/virtualMachines. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<GuestConfigurationAssignmentResource>> GetGuestConfigurationAssignmentAsync(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            if (!scope.ResourceType.Equals("Microsoft.Compute/virtualMachines"))
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected Microsoft.Compute/virtualMachines", scope.ResourceType));
            }
            return await client.GetGuestConfigurationAssignments(scope).GetAsync(guestConfigurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get information about a guest configuration assignment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="armResource"> The <see cref="ArmResource" /> instance the method will execute against. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<GuestConfigurationAssignmentResource> GetGuestConfigurationAssignment(this ArmResource armResource, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            return armResource.GetGuestConfigurationAssignments().Get(guestConfigurationAssignmentName, cancellationToken);
        }

        /// <summary>
        /// Get information about a guest configuration assignment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GuestConfigurationAssignments_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. Expected resource type includes the following: Microsoft.Compute/virtualMachines. </param>
        /// <param name="guestConfigurationAssignmentName"> The guest configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="guestConfigurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="guestConfigurationAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<GuestConfigurationAssignmentResource> GetGuestConfigurationAssignment(this ArmClient client, ResourceIdentifier scope, string guestConfigurationAssignmentName, CancellationToken cancellationToken = default)
        {
            if (!scope.ResourceType.Equals("Microsoft.Compute/virtualMachines"))
            {
                throw new ArgumentException(string.Format("Invalid resource type {0} expected Microsoft.Compute/virtualMachines", scope.ResourceType));
            }
            return client.GetGuestConfigurationAssignments(scope).Get(guestConfigurationAssignmentName, cancellationToken);
        }

        /// <summary>
        /// Gets a list of resource links at and below the specified source scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/links</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_ListAtSourceScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply when getting resource links. To get links only at the specified scope (not below the scope), use Filter.atScope(). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static AsyncPageable<ResourceLinkResource> GetAllAsync(this ArmClient client, ResourceIdentifier scope, Filter? filter = null, CancellationToken cancellationToken = default)
        {
            return GetArmResourceExtensionClient(client, scope).GetAllAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Gets a list of resource links at and below the specified source scope.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/links</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_ListAtSourceScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply when getting resource links. To get links only at the specified scope (not below the scope), use Filter.atScope(). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Pageable<ResourceLinkResource> GetAll(this ArmClient client, ResourceIdentifier scope, Filter? filter = null, CancellationToken cancellationToken = default)
        {
            return GetArmResourceExtensionClient(client, scope).GetAll(filter, cancellationToken);
        }

        /// <summary>
        /// Lists the marketplaces for a scope at the defined scope. Marketplaces are available via this API only for May 1, 2014 or later.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Consumption/marketplaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Marketplaces_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> May be used to filter marketplaces by properties/usageEnd (Utc time), properties/usageStart (Utc time), properties/resourceGroup, properties/instanceName or properties/instanceId. The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'. It does not currently support 'ne', 'or', or 'not'. </param>
        /// <param name="top"> May be used to limit the number of results to the most recent N marketplaces. </param>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static AsyncPageable<Marketplace> GetMarketplacesAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, int? top = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            return GetArmResourceExtensionClient(client, scope).GetMarketplacesAsync(filter, top, skiptoken, cancellationToken);
        }

        /// <summary>
        /// Lists the marketplaces for a scope at the defined scope. Marketplaces are available via this API only for May 1, 2014 or later.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Consumption/marketplaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Marketplaces_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> May be used to filter marketplaces by properties/usageEnd (Utc time), properties/usageStart (Utc time), properties/resourceGroup, properties/instanceName or properties/instanceId. The filter supports 'eq', 'lt', 'gt', 'le', 'ge', and 'and'. It does not currently support 'ne', 'or', or 'not'. </param>
        /// <param name="top"> May be used to limit the number of results to the most recent N marketplaces. </param>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Pageable<Marketplace> GetMarketplaces(this ArmClient client, ResourceIdentifier scope, string filter = null, int? top = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            return GetArmResourceExtensionClient(client, scope).GetMarketplaces(filter, top, skiptoken, cancellationToken);
        }

        /// <summary> Gets a collection of DeploymentExtendedResources in the ManagementGroupResource. </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DeploymentExtendedResources and their operations over a DeploymentExtendedResource. </returns>
        public static DeploymentExtendedCollection GetDeploymentExtendeds(this ManagementGroupResource managementGroupResource)
        {
            return GetManagementGroupResourceExtensionClient(managementGroupResource).GetDeploymentExtendeds();
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DeploymentExtendedResource>> GetDeploymentExtendedAsync(this ManagementGroupResource managementGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            return await managementGroupResource.GetDeploymentExtendeds().GetAsync(deploymentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="managementGroupResource"> The <see cref="ManagementGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DeploymentExtendedResource> GetDeploymentExtended(this ManagementGroupResource managementGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            return managementGroupResource.GetDeploymentExtendeds().Get(deploymentName, cancellationToken);
        }

        /// <summary> Gets a collection of DeploymentExtendedResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DeploymentExtendedResources and their operations over a DeploymentExtendedResource. </returns>
        public static DeploymentExtendedCollection GetDeploymentExtendeds(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetDeploymentExtendeds();
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DeploymentExtendedResource>> GetDeploymentExtendedAsync(this ResourceGroupResource resourceGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetDeploymentExtendeds().GetAsync(deploymentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DeploymentExtendedResource> GetDeploymentExtended(this ResourceGroupResource resourceGroupResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetDeploymentExtendeds().Get(deploymentName, cancellationToken);
        }

        /// <summary> Gets a collection of DeploymentExtendedResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DeploymentExtendedResources and their operations over a DeploymentExtendedResource. </returns>
        public static DeploymentExtendedCollection GetDeploymentExtendeds(this SubscriptionResource subscriptionResource)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDeploymentExtendeds();
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DeploymentExtendedResource>> GetDeploymentExtendedAsync(this SubscriptionResource subscriptionResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetDeploymentExtendeds().GetAsync(deploymentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DeploymentExtendedResource> GetDeploymentExtended(this SubscriptionResource subscriptionResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetDeploymentExtendeds().Get(deploymentName, cancellationToken);
        }

        /// <summary>
        /// Gets all the linked resources for the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Resources/links</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_ListAtSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the list resource links operation. The supported filter for list resource links is targetId. For example, $filter=targetId eq {value}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResourceLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ResourceLinkResource> GetResourceLinksAsync(this SubscriptionResource subscriptionResource, string filter = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResourceLinksAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Gets all the linked resources for the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Resources/links</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_ListAtSubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the list resource links operation. The supported filter for list resource links is targetId. For example, $filter=targetId eq {value}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceLinkResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ResourceLinkResource> GetResourceLinks(this SubscriptionResource subscriptionResource, string filter = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetResourceLinks(filter, cancellationToken);
        }

        /// <summary> Gets a collection of DeploymentExtendedResources in the TenantResource. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DeploymentExtendedResources and their operations over a DeploymentExtendedResource. </returns>
        public static DeploymentExtendedCollection GetDeploymentExtendeds(this TenantResource tenantResource)
        {
            return GetTenantResourceExtensionClient(tenantResource).GetDeploymentExtendeds();
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DeploymentExtendedResource>> GetDeploymentExtendedAsync(this TenantResource tenantResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            return await tenantResource.GetDeploymentExtendeds().GetAsync(deploymentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a deployment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Resources/deployments/{deploymentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_GetAtScope</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="deploymentName"> The name of the deployment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deploymentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DeploymentExtendedResource> GetDeploymentExtended(this TenantResource tenantResource, string deploymentName, CancellationToken cancellationToken = default)
        {
            return tenantResource.GetDeploymentExtendeds().Get(deploymentName, cancellationToken);
        }

        /// <summary> Gets a collection of ResourceLinkResources in the TenantResource. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="scope"> The fully qualified ID of the scope for getting the resource links. For example, to list resource links at and under a resource group, set the scope to /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myGroup. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        /// <returns> An object representing collection of ResourceLinkResources and their operations over a ResourceLinkResource. </returns>
        public static ResourceLinkCollection GetResourceLinks(this TenantResource tenantResource, string scope)
        {
            Argument.AssertNotNull(scope, nameof(scope));

            return GetTenantResourceExtensionClient(tenantResource).GetResourceLinks(scope);
        }

        /// <summary>
        /// Gets a resource link with the specified ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{linkId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="scope"> The fully qualified ID of the scope for getting the resource links. For example, to list resource links at and under a resource group, set the scope to /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ResourceLinkResource>> GetResourceLinkAsync(this TenantResource tenantResource, string scope, CancellationToken cancellationToken = default)
        {
            return await tenantResource.GetResourceLinks(scope).GetAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a resource link with the specified ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{linkId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResourceLinks_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="scope"> The fully qualified ID of the scope for getting the resource links. For example, to list resource links at and under a resource group, set the scope to /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myGroup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ResourceLinkResource> GetResourceLink(this TenantResource tenantResource, string scope, CancellationToken cancellationToken = default)
        {
            return tenantResource.GetResourceLinks(scope).Get(cancellationToken);
        }

        /// <summary>
        /// Calculate the hash of the given template.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Resources/calculateTemplateHash</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CalculateTemplateHash</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        public static async Task<Response<TemplateHashResult>> CalculateTemplateHashDeploymentAsync(this TenantResource tenantResource, BinaryData template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(template, nameof(template));

            return await GetTenantResourceExtensionClient(tenantResource).CalculateTemplateHashDeploymentAsync(template, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Calculate the hash of the given template.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Resources/calculateTemplateHash</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Deployments_CalculateTemplateHash</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        public static Response<TemplateHashResult> CalculateTemplateHashDeployment(this TenantResource tenantResource, BinaryData template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(template, nameof(template));

            return GetTenantResourceExtensionClient(tenantResource).CalculateTemplateHashDeployment(template, cancellationToken);
        }
    }
}
