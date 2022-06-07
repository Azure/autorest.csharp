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
using Azure.ResourceManager.Resources;
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    /// <summary> A class to add extension methods to MgmtExpandResourceTypes. </summary>
    public static partial class MgmtExpandResourceTypesExtensions
    {
        private static SubscriptionResourceExtensionClient GetExtensionClient(SubscriptionResource subscriptionResource)
        {
            return subscriptionResource.GetCachedClient((client) =>
            {
                return new SubscriptionResourceExtensionClient(client, subscriptionResource.Id);
            }
            );
        }

        /// <summary>
        /// Lists the DNS zones in all resource groups in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/dnszones
        /// Operation Id: Zones_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> The maximum number of DNS zones to return. If not specified, returns up to 100 zones. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ZoneResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ZoneResource> GetZonesByDnszoneAsync(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetZonesByDnszoneAsync(top, cancellationToken);
        }

        /// <summary>
        /// Lists the DNS zones in all resource groups in a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/dnszones
        /// Operation Id: Zones_List
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> The maximum number of DNS zones to return. If not specified, returns up to 100 zones. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ZoneResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ZoneResource> GetZonesByDnszone(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionResource).GetZonesByDnszone(top, cancellationToken);
        }

        /// <summary>
        /// Returns the DNS records specified by the referencing targetResourceIds.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/getDnsResourceReference
        /// Operation Id: DnsResourceReference_GetByTargetResources
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="content"> Properties for dns resource reference request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static async Task<Response<DnsResourceReferenceResult>> GetByTargetResourcesDnsResourceReferenceAsync(this SubscriptionResource subscriptionResource, DnsResourceReferenceContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return await GetExtensionClient(subscriptionResource).GetByTargetResourcesDnsResourceReferenceAsync(content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the DNS records specified by the referencing targetResourceIds.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Network/getDnsResourceReference
        /// Operation Id: DnsResourceReference_GetByTargetResources
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="content"> Properties for dns resource reference request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static Response<DnsResourceReferenceResult> GetByTargetResourcesDnsResourceReference(this SubscriptionResource subscriptionResource, DnsResourceReferenceContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return GetExtensionClient(subscriptionResource).GetByTargetResourcesDnsResourceReference(content, cancellationToken);
        }

        private static ResourceGroupResourceExtensionClient GetExtensionClient(ResourceGroupResource resourceGroupResource)
        {
            return resourceGroupResource.GetCachedClient((client) =>
            {
                return new ResourceGroupResourceExtensionClient(client, resourceGroupResource.Id);
            }
            );
        }

        /// <summary> Gets a collection of ZoneResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ZoneResources and their operations over a ZoneResource. </returns>
        public static ZoneCollection GetZones(this ResourceGroupResource resourceGroupResource)
        {
            return GetExtensionClient(resourceGroupResource).GetZones();
        }

        /// <summary>
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ZoneResource>> GetZoneAsync(this ResourceGroupResource resourceGroupResource, string zoneName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetZones().GetAsync(zoneName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}
        /// Operation Id: Zones_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ZoneResource> GetZone(this ResourceGroupResource resourceGroupResource, string zoneName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetZones().Get(zoneName, cancellationToken);
        }

        #region RecordSetAResource
        /// <summary>
        /// Gets an object representing a <see cref="RecordSetAResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetAResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetAResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetAResource" /> object. </returns>
        public static RecordSetAResource GetRecordSetAResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RecordSetAResource.ValidateResourceId(id);
                return new RecordSetAResource(client, id);
            }
            );
        }
        #endregion

        #region RecordSetAaaaResource
        /// <summary>
        /// Gets an object representing a <see cref="RecordSetAaaaResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetAaaaResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetAaaaResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetAaaaResource" /> object. </returns>
        public static RecordSetAaaaResource GetRecordSetAaaaResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RecordSetAaaaResource.ValidateResourceId(id);
                return new RecordSetAaaaResource(client, id);
            }
            );
        }
        #endregion

        #region RecordSetCaaResource
        /// <summary>
        /// Gets an object representing a <see cref="RecordSetCaaResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetCaaResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetCaaResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetCaaResource" /> object. </returns>
        public static RecordSetCaaResource GetRecordSetCaaResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RecordSetCaaResource.ValidateResourceId(id);
                return new RecordSetCaaResource(client, id);
            }
            );
        }
        #endregion

        #region RecordSetCNameResource
        /// <summary>
        /// Gets an object representing a <see cref="RecordSetCNameResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetCNameResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetCNameResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetCNameResource" /> object. </returns>
        public static RecordSetCNameResource GetRecordSetCNameResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RecordSetCNameResource.ValidateResourceId(id);
                return new RecordSetCNameResource(client, id);
            }
            );
        }
        #endregion

        #region RecordSetMxResource
        /// <summary>
        /// Gets an object representing a <see cref="RecordSetMxResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetMxResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetMxResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetMxResource" /> object. </returns>
        public static RecordSetMxResource GetRecordSetMxResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RecordSetMxResource.ValidateResourceId(id);
                return new RecordSetMxResource(client, id);
            }
            );
        }
        #endregion

        #region RecordSetNsResource
        /// <summary>
        /// Gets an object representing a <see cref="RecordSetNsResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetNsResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetNsResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetNsResource" /> object. </returns>
        public static RecordSetNsResource GetRecordSetNsResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RecordSetNsResource.ValidateResourceId(id);
                return new RecordSetNsResource(client, id);
            }
            );
        }
        #endregion

        #region RecordSetPtrResource
        /// <summary>
        /// Gets an object representing a <see cref="RecordSetPtrResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetPtrResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetPtrResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetPtrResource" /> object. </returns>
        public static RecordSetPtrResource GetRecordSetPtrResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RecordSetPtrResource.ValidateResourceId(id);
                return new RecordSetPtrResource(client, id);
            }
            );
        }
        #endregion

        #region RecordSetSoaResource
        /// <summary>
        /// Gets an object representing a <see cref="RecordSetSoaResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetSoaResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetSoaResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetSoaResource" /> object. </returns>
        public static RecordSetSoaResource GetRecordSetSoaResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RecordSetSoaResource.ValidateResourceId(id);
                return new RecordSetSoaResource(client, id);
            }
            );
        }
        #endregion

        #region RecordSetSrvResource
        /// <summary>
        /// Gets an object representing a <see cref="RecordSetSrvResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetSrvResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetSrvResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetSrvResource" /> object. </returns>
        public static RecordSetSrvResource GetRecordSetSrvResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RecordSetSrvResource.ValidateResourceId(id);
                return new RecordSetSrvResource(client, id);
            }
            );
        }
        #endregion

        #region RecordSetTxtResource
        /// <summary>
        /// Gets an object representing a <see cref="RecordSetTxtResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetTxtResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetTxtResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetTxtResource" /> object. </returns>
        public static RecordSetTxtResource GetRecordSetTxtResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                RecordSetTxtResource.ValidateResourceId(id);
                return new RecordSetTxtResource(client, id);
            }
            );
        }
        #endregion

        #region ZoneResource
        /// <summary>
        /// Gets an object representing a <see cref="ZoneResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ZoneResource.CreateResourceIdentifier" /> to create a <see cref="ZoneResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ZoneResource" /> object. </returns>
        public static ZoneResource GetZoneResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ZoneResource.ValidateResourceId(id);
                return new ZoneResource(client, id);
            }
            );
        }
        #endregion
    }
}
