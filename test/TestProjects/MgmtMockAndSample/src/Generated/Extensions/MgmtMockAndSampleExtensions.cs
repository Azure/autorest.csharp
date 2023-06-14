// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtMockAndSample.Models;

namespace MgmtMockAndSample
{
    /// <summary> A class to add extension methods to MgmtMockAndSample. </summary>
    public static partial class MgmtMockAndSampleExtensions
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
        #region VaultResource
        /// <summary>
        /// Gets an object representing a <see cref="VaultResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VaultResource.CreateResourceIdentifier" /> to create a <see cref="VaultResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VaultResource" /> object. </returns>
        public static VaultResource GetVaultResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VaultResource.ValidateResourceId(id);
                return new VaultResource(client, id);
            }
            );
        }
        #endregion

        #region DeletedVaultResource
        /// <summary>
        /// Gets an object representing a <see cref="DeletedVaultResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DeletedVaultResource.CreateResourceIdentifier" /> to create a <see cref="DeletedVaultResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DeletedVaultResource" /> object. </returns>
        public static DeletedVaultResource GetDeletedVaultResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DeletedVaultResource.ValidateResourceId(id);
                return new DeletedVaultResource(client, id);
            }
            );
        }
        #endregion

        #region MgmtMockAndSamplePrivateEndpointConnectionResource
        /// <summary>
        /// Gets an object representing a <see cref="MgmtMockAndSamplePrivateEndpointConnectionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="MgmtMockAndSamplePrivateEndpointConnectionResource.CreateResourceIdentifier" /> to create a <see cref="MgmtMockAndSamplePrivateEndpointConnectionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MgmtMockAndSamplePrivateEndpointConnectionResource" /> object. </returns>
        public static MgmtMockAndSamplePrivateEndpointConnectionResource GetMgmtMockAndSamplePrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                MgmtMockAndSamplePrivateEndpointConnectionResource.ValidateResourceId(id);
                return new MgmtMockAndSamplePrivateEndpointConnectionResource(client, id);
            }
            );
        }
        #endregion

        #region VirtualMachineExtensionImageResource
        /// <summary>
        /// Gets an object representing a <see cref="VirtualMachineExtensionImageResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="VirtualMachineExtensionImageResource.CreateResourceIdentifier" /> to create a <see cref="VirtualMachineExtensionImageResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="VirtualMachineExtensionImageResource" /> object. </returns>
        public static VirtualMachineExtensionImageResource GetVirtualMachineExtensionImageResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                VirtualMachineExtensionImageResource.ValidateResourceId(id);
                return new VirtualMachineExtensionImageResource(client, id);
            }
            );
        }
        #endregion

        #region DiskEncryptionSetResource
        /// <summary>
        /// Gets an object representing a <see cref="DiskEncryptionSetResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DiskEncryptionSetResource.CreateResourceIdentifier" /> to create a <see cref="DiskEncryptionSetResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DiskEncryptionSetResource" /> object. </returns>
        public static DiskEncryptionSetResource GetDiskEncryptionSetResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DiskEncryptionSetResource.ValidateResourceId(id);
                return new DiskEncryptionSetResource(client, id);
            }
            );
        }
        #endregion

        #region ManagedHsmResource
        /// <summary>
        /// Gets an object representing a <see cref="ManagedHsmResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ManagedHsmResource.CreateResourceIdentifier" /> to create a <see cref="ManagedHsmResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ManagedHsmResource" /> object. </returns>
        public static ManagedHsmResource GetManagedHsmResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ManagedHsmResource.ValidateResourceId(id);
                return new ManagedHsmResource(client, id);
            }
            );
        }
        #endregion

        #region DeletedManagedHsmResource
        /// <summary>
        /// Gets an object representing a <see cref="DeletedManagedHsmResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DeletedManagedHsmResource.CreateResourceIdentifier" /> to create a <see cref="DeletedManagedHsmResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DeletedManagedHsmResource" /> object. </returns>
        public static DeletedManagedHsmResource GetDeletedManagedHsmResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DeletedManagedHsmResource.ValidateResourceId(id);
                return new DeletedManagedHsmResource(client, id);
            }
            );
        }
        #endregion

        #region MhsmPrivateEndpointConnectionResource
        /// <summary>
        /// Gets an object representing a <see cref="MhsmPrivateEndpointConnectionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="MhsmPrivateEndpointConnectionResource.CreateResourceIdentifier" /> to create a <see cref="MhsmPrivateEndpointConnectionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MhsmPrivateEndpointConnectionResource" /> object. </returns>
        public static MhsmPrivateEndpointConnectionResource GetMhsmPrivateEndpointConnectionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                MhsmPrivateEndpointConnectionResource.ValidateResourceId(id);
                return new MhsmPrivateEndpointConnectionResource(client, id);
            }
            );
        }
        #endregion

        #region FirewallPolicyResource
        /// <summary>
        /// Gets an object representing a <see cref="FirewallPolicyResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FirewallPolicyResource.CreateResourceIdentifier" /> to create a <see cref="FirewallPolicyResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FirewallPolicyResource" /> object. </returns>
        public static FirewallPolicyResource GetFirewallPolicyResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FirewallPolicyResource.ValidateResourceId(id);
                return new FirewallPolicyResource(client, id);
            }
            );
        }
        #endregion

        #region FirewallPolicyRuleCollectionGroupResource
        /// <summary>
        /// Gets an object representing a <see cref="FirewallPolicyRuleCollectionGroupResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="FirewallPolicyRuleCollectionGroupResource.CreateResourceIdentifier" /> to create a <see cref="FirewallPolicyRuleCollectionGroupResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="FirewallPolicyRuleCollectionGroupResource" /> object. </returns>
        public static FirewallPolicyRuleCollectionGroupResource GetFirewallPolicyRuleCollectionGroupResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                FirewallPolicyRuleCollectionGroupResource.ValidateResourceId(id);
                return new FirewallPolicyRuleCollectionGroupResource(client, id);
            }
            );
        }
        #endregion

        #region RoleAssignmentResource
        /// <summary>
        /// Gets an object representing a <see cref="RoleAssignmentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RoleAssignmentResource.CreateResourceIdentifier" /> to create a <see cref="RoleAssignmentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RoleAssignmentResource" /> object. </returns>
        public static RoleAssignmentResource GetRoleAssignmentResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RoleAssignmentResource.ValidateResourceId(id);
                return new RoleAssignmentResource(client, id);
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

        /// <summary> Gets a collection of RoleAssignmentResources in the ArmResource. </summary>
        /// <param name="armResource"> The <see cref="ArmResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of RoleAssignmentResources and their operations over a RoleAssignmentResource. </returns>
        public static RoleAssignmentCollection GetRoleAssignments(this ArmResource armResource)
        {
            return GetArmResourceExtensionClient(armResource).GetRoleAssignments();
        }

        /// <summary> Gets a collection of RoleAssignmentResources in the ArmResource. </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <returns> An object representing collection of RoleAssignmentResources and their operations over a RoleAssignmentResource. </returns>
        public static RoleAssignmentCollection GetRoleAssignments(this ArmClient client, ResourceIdentifier scope)
        {
            return GetArmResourceExtensionClient(client, scope).GetRoleAssignments();
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
        /// <param name="armResource"> The <see cref="ArmResource" /> instance the method will execute against. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<RoleAssignmentResource>> GetRoleAssignmentAsync(this ArmResource armResource, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            return await armResource.GetRoleAssignments().GetAsync(roleAssignmentName, cancellationToken).ConfigureAwait(false);
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
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<RoleAssignmentResource>> GetRoleAssignmentAsync(this ArmClient client, ResourceIdentifier scope, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            return await client.GetRoleAssignments(scope).GetAsync(roleAssignmentName, cancellationToken).ConfigureAwait(false);
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
        /// <param name="armResource"> The <see cref="ArmResource" /> instance the method will execute against. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<RoleAssignmentResource> GetRoleAssignment(this ArmResource armResource, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            return armResource.GetRoleAssignments().Get(roleAssignmentName, cancellationToken);
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
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<RoleAssignmentResource> GetRoleAssignment(this ArmClient client, ResourceIdentifier scope, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            return client.GetRoleAssignments(scope).Get(roleAssignmentName, cancellationToken);
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

        /// <summary> Gets a collection of VaultResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of VaultResources and their operations over a VaultResource. </returns>
        public static VaultCollection GetVaults(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetVaults();
        }

        /// <summary>
        /// Gets the specified Azure key vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<VaultResource>> GetVaultAsync(this ResourceGroupResource resourceGroupResource, string vaultName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetVaults().GetAsync(vaultName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified Azure key vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<VaultResource> GetVault(this ResourceGroupResource resourceGroupResource, string vaultName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetVaults().Get(vaultName, cancellationToken);
        }

        /// <summary> Gets a collection of DiskEncryptionSetResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DiskEncryptionSetResources and their operations over a DiskEncryptionSetResource. </returns>
        public static DiskEncryptionSetCollection GetDiskEncryptionSets(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetDiskEncryptionSets();
        }

        /// <summary>
        /// Gets information about a disk encryption set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskEncryptionSets/{diskEncryptionSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DiskEncryptionSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="diskEncryptionSetName"> The name of the disk encryption set that is being created. The name can't be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskEncryptionSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskEncryptionSetName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DiskEncryptionSetResource>> GetDiskEncryptionSetAsync(this ResourceGroupResource resourceGroupResource, string diskEncryptionSetName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetDiskEncryptionSets().GetAsync(diskEncryptionSetName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information about a disk encryption set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/diskEncryptionSets/{diskEncryptionSetName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DiskEncryptionSets_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="diskEncryptionSetName"> The name of the disk encryption set that is being created. The name can't be changed after the disk encryption set is created. Supported characters for the name are a-z, A-Z, 0-9, _ and -. The maximum name length is 80 characters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="diskEncryptionSetName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="diskEncryptionSetName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DiskEncryptionSetResource> GetDiskEncryptionSet(this ResourceGroupResource resourceGroupResource, string diskEncryptionSetName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetDiskEncryptionSets().Get(diskEncryptionSetName, cancellationToken);
        }

        /// <summary> Gets a collection of ManagedHsmResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ManagedHsmResources and their operations over a ManagedHsmResource. </returns>
        public static ManagedHsmCollection GetManagedHsms(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetManagedHsms();
        }

        /// <summary>
        /// Gets the specified managed HSM Pool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ManagedHsmResource>> GetManagedHsmAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetManagedHsms().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified managed HSM Pool.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/managedHSMs/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> The name of the managed HSM Pool. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ManagedHsmResource> GetManagedHsm(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetManagedHsms().Get(name, cancellationToken);
        }

        /// <summary> Gets a collection of FirewallPolicyResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of FirewallPolicyResources and their operations over a FirewallPolicyResource. </returns>
        public static FirewallPolicyCollection GetFirewallPolicies(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetFirewallPolicies();
        }

        /// <summary>
        /// Gets the specified Firewall Policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="firewallPolicyName"> The name of the Firewall Policy. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="firewallPolicyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="firewallPolicyName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<FirewallPolicyResource>> GetFirewallPolicyAsync(this ResourceGroupResource resourceGroupResource, string firewallPolicyName, string expand = null, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetFirewallPolicies().GetAsync(firewallPolicyName, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified Firewall Policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/firewallPolicies/{firewallPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="firewallPolicyName"> The name of the Firewall Policy. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="firewallPolicyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="firewallPolicyName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<FirewallPolicyResource> GetFirewallPolicy(this ResourceGroupResource resourceGroupResource, string firewallPolicyName, string expand = null, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetFirewallPolicies().Get(firewallPolicyName, expand, cancellationToken);
        }

        /// <summary> Gets a collection of DeletedVaultResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DeletedVaultResources and their operations over a DeletedVaultResource. </returns>
        public static DeletedVaultCollection GetDeletedVaults(this SubscriptionResource subscriptionResource)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDeletedVaults();
        }

        /// <summary>
        /// Gets the deleted Azure key vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the deleted vault. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DeletedVaultResource>> GetDeletedVaultAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string vaultName, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetDeletedVaults().GetAsync(location, vaultName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the deleted Azure key vault.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the deleted vault. </param>
        /// <param name="vaultName"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="vaultName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DeletedVaultResource> GetDeletedVault(this SubscriptionResource subscriptionResource, AzureLocation location, string vaultName, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetDeletedVaults().Get(location, vaultName, cancellationToken);
        }

        /// <summary> Gets a collection of VirtualMachineExtensionImageResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/> is null. </exception>
        /// <returns> An object representing collection of VirtualMachineExtensionImageResources and their operations over a VirtualMachineExtensionImageResource. </returns>
        public static VirtualMachineExtensionImageCollection GetVirtualMachineExtensionImages(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName)
        {
            Argument.AssertNotNullOrEmpty(publisherName, nameof(publisherName));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVirtualMachineExtensionImages(location, publisherName);
        }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineExtensionImages_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<VirtualMachineExtensionImageResource>> GetVirtualMachineExtensionImageAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName).GetAsync(type, version, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a virtual machine extension image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/publishers/{publisherName}/artifacttypes/vmextension/types/{type}/versions/{version}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineExtensionImages_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> The String to use. </param>
        /// <param name="type"> The String to use. </param>
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="type"/> or <paramref name="version"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<VirtualMachineExtensionImageResource> GetVirtualMachineExtensionImage(this SubscriptionResource subscriptionResource, AzureLocation location, string publisherName, string type, string version, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetVirtualMachineExtensionImages(location, publisherName).Get(type, version, cancellationToken);
        }

        /// <summary> Gets a collection of DeletedManagedHsmResources in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DeletedManagedHsmResources and their operations over a DeletedManagedHsmResource. </returns>
        public static DeletedManagedHsmCollection GetDeletedManagedHsms(this SubscriptionResource subscriptionResource)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDeletedManagedHsms();
        }

        /// <summary>
        /// Gets the specified deleted managed HSM.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the deleted managed HSM. </param>
        /// <param name="name"> The name of the deleted managed HSM. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DeletedManagedHsmResource>> GetDeletedManagedHsmAsync(this SubscriptionResource subscriptionResource, AzureLocation location, string name, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetDeletedManagedHsms().GetAsync(location, name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the specified deleted managed HSM.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_GetDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="location"> The location of the deleted managed HSM. </param>
        /// <param name="name"> The name of the deleted managed HSM. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DeletedManagedHsmResource> GetDeletedManagedHsm(this SubscriptionResource subscriptionResource, AzureLocation location, string name, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetDeletedManagedHsms().Get(location, name, cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the vaults associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/vaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VaultResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VaultResource> GetVaultsAsync(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVaultsAsync(top, cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the vaults associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/vaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VaultResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<VaultResource> GetVaults(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetVaults(top, cancellationToken);
        }

        /// <summary>
        /// Gets information about the deleted vaults in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_ListDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeletedVaultResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<DeletedVaultResource> GetDeletedVaultsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDeletedVaultsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets information about the deleted vaults in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedVaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_ListDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedVaultResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<DeletedVaultResource> GetDeletedVaults(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDeletedVaults(cancellationToken);
        }

        /// <summary>
        /// Checks that the vault name is valid and is not already in use.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_CheckNameAvailability</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="content"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static async Task<Response<CheckNameAvailabilityResult>> CheckNameAvailabilityVaultAsync(this SubscriptionResource subscriptionResource, VaultCheckNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return await GetSubscriptionResourceExtensionClient(subscriptionResource).CheckNameAvailabilityVaultAsync(content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Checks that the vault name is valid and is not already in use.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/checkNameAvailability</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_CheckNameAvailability</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="content"> The name of the vault. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static Response<CheckNameAvailabilityResult> CheckNameAvailabilityVault(this SubscriptionResource subscriptionResource, VaultCheckNameAvailabilityContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return GetSubscriptionResourceExtensionClient(subscriptionResource).CheckNameAvailabilityVault(content, cancellationToken);
        }

        /// <summary>
        /// Lists all the disk encryption sets under a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/diskEncryptionSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DiskEncryptionSets_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DiskEncryptionSetResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<DiskEncryptionSetResource> GetDiskEncryptionSetsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDiskEncryptionSetsAsync(cancellationToken);
        }

        /// <summary>
        /// Lists all the disk encryption sets under a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/diskEncryptionSets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DiskEncryptionSets_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DiskEncryptionSetResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<DiskEncryptionSetResource> GetDiskEncryptionSets(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDiskEncryptionSets(cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the managed HSM Pools associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/managedHSMs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ManagedHsmResource> GetManagedHsmsAsync(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetManagedHsmsAsync(top, cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the managed HSM Pools associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/managedHSMs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_ListBySubscription</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> Maximum number of results to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ManagedHsmResource> GetManagedHsms(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetManagedHsms(top, cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the deleted managed HSMs associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedManagedHSMs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_ListDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeletedManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<DeletedManagedHsmResource> GetDeletedManagedHsmsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDeletedManagedHsmsAsync(cancellationToken);
        }

        /// <summary>
        /// The List operation gets information about the deleted managed HSMs associated with the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/deletedManagedHSMs</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ManagedHsms_ListDeleted</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedManagedHsmResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<DeletedManagedHsmResource> GetDeletedManagedHsms(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetDeletedManagedHsms(cancellationToken);
        }

        /// <summary>
        /// Gets all the Firewall Policies in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/firewallPolicies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FirewallPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<FirewallPolicyResource> GetFirewallPoliciesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFirewallPoliciesAsync(cancellationToken);
        }

        /// <summary>
        /// Gets all the Firewall Policies in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/firewallPolicies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FirewallPolicies_ListAll</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FirewallPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<FirewallPolicyResource> GetFirewallPolicies(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            return GetSubscriptionResourceExtensionClient(subscriptionResource).GetFirewallPolicies(cancellationToken);
        }

        /// <summary>
        /// Gets the Activity Logs for the Tenant.&lt;br&gt;Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).&lt;br&gt;One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Insights/eventtypes/management/values</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantActivityLogs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="filter"> Reduces the set of data collected. &lt;br&gt;The **$filter** is very restricted and allows only the following patterns.&lt;br&gt;- List events for a resource group: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceGroupName eq '&lt;ResourceGroupName&gt;'.&lt;br&gt;- List events for resource: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceUri eq '&lt;ResourceURI&gt;'.&lt;br&gt;- List events for a subscription: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation'.&lt;br&gt;- List events for a resource provider: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceProvider eq '&lt;ResourceProviderName&gt;'.&lt;br&gt;- List events for a correlation Id: api-version=2014-04-01&amp;$filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and eventChannels eq 'Admin, Operation' and correlationId eq '&lt;CorrelationID&gt;'.&lt;br&gt;**NOTE**: No other syntax is allowed. </param>
        /// <param name="select"> Used to fetch events with only the given properties.&lt;br&gt;The **$select** argument is a comma separated list of property names to be returned. Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="EventData" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<EventData> GetTenantActivityLogsAsync(this TenantResource tenantResource, string filter = null, string select = null, CancellationToken cancellationToken = default)
        {
            return GetTenantResourceExtensionClient(tenantResource).GetTenantActivityLogsAsync(filter, select, cancellationToken);
        }

        /// <summary>
        /// Gets the Activity Logs for the Tenant.&lt;br&gt;Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).&lt;br&gt;One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Insights/eventtypes/management/values</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>TenantActivityLogs_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="filter"> Reduces the set of data collected. &lt;br&gt;The **$filter** is very restricted and allows only the following patterns.&lt;br&gt;- List events for a resource group: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceGroupName eq '&lt;ResourceGroupName&gt;'.&lt;br&gt;- List events for resource: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceUri eq '&lt;ResourceURI&gt;'.&lt;br&gt;- List events for a subscription: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation'.&lt;br&gt;- List events for a resource provider: $filter=eventTimestamp ge '&lt;Start Time&gt;' and eventTimestamp le '&lt;End Time&gt;' and eventChannels eq 'Admin, Operation' and resourceProvider eq '&lt;ResourceProviderName&gt;'.&lt;br&gt;- List events for a correlation Id: api-version=2014-04-01&amp;$filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and eventChannels eq 'Admin, Operation' and correlationId eq '&lt;CorrelationID&gt;'.&lt;br&gt;**NOTE**: No other syntax is allowed. </param>
        /// <param name="select"> Used to fetch events with only the given properties.&lt;br&gt;The **$select** argument is a comma separated list of property names to be returned. Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="EventData" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<EventData> GetTenantActivityLogs(this TenantResource tenantResource, string filter = null, string select = null, CancellationToken cancellationToken = default)
        {
            return GetTenantResourceExtensionClient(tenantResource).GetTenantActivityLogs(filter, select, cancellationToken);
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
