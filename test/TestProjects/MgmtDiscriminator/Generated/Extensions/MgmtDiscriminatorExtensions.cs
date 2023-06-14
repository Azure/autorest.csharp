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

namespace MgmtDiscriminator
{
    /// <summary> A class to add extension methods to MgmtDiscriminator. </summary>
    public static partial class MgmtDiscriminatorExtensions
    {
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
        #region DeliveryRuleResource
        /// <summary>
        /// Gets an object representing a <see cref="DeliveryRuleResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="DeliveryRuleResource.CreateResourceIdentifier" /> to create a <see cref="DeliveryRuleResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="DeliveryRuleResource" /> object. </returns>
        public static DeliveryRuleResource GetDeliveryRuleResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                DeliveryRuleResource.ValidateResourceId(id);
                return new DeliveryRuleResource(client, id);
            }
            );
        }
        #endregion

        /// <summary> Gets a collection of DeliveryRuleResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of DeliveryRuleResources and their operations over a DeliveryRuleResource. </returns>
        public static DeliveryRuleCollection GetDeliveryRules(this ResourceGroupResource resourceGroupResource)
        {
            return GetResourceGroupResourceExtensionClient(resourceGroupResource).GetDeliveryRules();
        }

        /// <summary>
        /// Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeliveryRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<DeliveryRuleResource>> GetDeliveryRuleAsync(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetDeliveryRules().GetAsync(name, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets an existing CDN endpoint with the specified endpoint name under the specified subscription, resource group and profile.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/deliveryRules/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DeliveryRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="name"> Name of the endpoint under the profile which is unique globally. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<DeliveryRuleResource> GetDeliveryRule(this ResourceGroupResource resourceGroupResource, string name, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetDeliveryRules().Get(name, cancellationToken);
        }
    }
}
