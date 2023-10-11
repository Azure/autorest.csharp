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
using MgmtExpandResourceTypes.Mocking;
using MgmtExpandResourceTypes.Models;

namespace MgmtExpandResourceTypes
{
    /// <summary> A class to add extension methods to MgmtExpandResourceTypes. </summary>
    public static partial class MgmtExpandResourceTypesExtensions
    {
        private static MgmtExpandResourceTypesArmClientMockingExtension GetMgmtExpandResourceTypesArmClientMockingExtension(ArmClient client)
        {
            return client.GetCachedClient(client0 => new MgmtExpandResourceTypesArmClientMockingExtension(client0));
        }

        private static MgmtExpandResourceTypesResourceGroupMockingExtension GetMgmtExpandResourceTypesResourceGroupMockingExtension(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MgmtExpandResourceTypesResourceGroupMockingExtension(client, resource.Id));
        }

        private static MgmtExpandResourceTypesSubscriptionMockingExtension GetMgmtExpandResourceTypesSubscriptionMockingExtension(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MgmtExpandResourceTypesSubscriptionMockingExtension(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="RecordSetAResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetAResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetAResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetAResource" /> object. </returns>
        public static RecordSetAResource GetRecordSetAResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetRecordSetAResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="RecordSetAaaaResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetAaaaResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetAaaaResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetAaaaResource" /> object. </returns>
        public static RecordSetAaaaResource GetRecordSetAaaaResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetRecordSetAaaaResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="RecordSetCaaResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetCaaResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetCaaResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetCaaResource" /> object. </returns>
        public static RecordSetCaaResource GetRecordSetCaaResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetRecordSetCaaResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="RecordSetCNameResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetCNameResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetCNameResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetCNameResource" /> object. </returns>
        public static RecordSetCNameResource GetRecordSetCNameResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetRecordSetCNameResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="RecordSetMxResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetMxResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetMxResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetMxResource" /> object. </returns>
        public static RecordSetMxResource GetRecordSetMxResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetRecordSetMxResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="RecordSetNsResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetNsResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetNsResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetNsResource" /> object. </returns>
        public static RecordSetNsResource GetRecordSetNsResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetRecordSetNsResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="RecordSetPtrResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetPtrResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetPtrResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetPtrResource" /> object. </returns>
        public static RecordSetPtrResource GetRecordSetPtrResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetRecordSetPtrResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="RecordSetSoaResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetSoaResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetSoaResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetSoaResource" /> object. </returns>
        public static RecordSetSoaResource GetRecordSetSoaResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetRecordSetSoaResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="RecordSetSrvResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetSrvResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetSrvResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetSrvResource" /> object. </returns>
        public static RecordSetSrvResource GetRecordSetSrvResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetRecordSetSrvResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="RecordSetTxtResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="RecordSetTxtResource.CreateResourceIdentifier" /> to create a <see cref="RecordSetTxtResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="RecordSetTxtResource" /> object. </returns>
        public static RecordSetTxtResource GetRecordSetTxtResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetRecordSetTxtResource(id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="ZoneResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ZoneResource.CreateResourceIdentifier" /> to create a <see cref="ZoneResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ZoneResource" /> object. </returns>
        public static ZoneResource GetZoneResource(this ArmClient client, ResourceIdentifier id)
        {
            return GetMgmtExpandResourceTypesArmClientMockingExtension(client).GetZoneResource(id);
        }

        /// <summary> Gets a collection of ZoneResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ZoneResources and their operations over a ZoneResource. </returns>
        public static ZoneCollection GetZones(this ResourceGroupResource resourceGroupResource)
        {
            return GetMgmtExpandResourceTypesResourceGroupMockingExtension(resourceGroupResource).GetZones();
        }

        /// <summary>
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ZoneResource>> GetZoneAsync(this ResourceGroupResource resourceGroupResource, string zoneName, CancellationToken cancellationToken = default)
        {
            return await GetMgmtExpandResourceTypesResourceGroupMockingExtension(resourceGroupResource).GetZoneAsync(zoneName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a DNS zone. Retrieves the zone properties, but not the record sets within the zone.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="zoneName"> The name of the DNS zone (without a terminating dot). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="zoneName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="zoneName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<ZoneResource> GetZone(this ResourceGroupResource resourceGroupResource, string zoneName, CancellationToken cancellationToken = default)
        {
            return GetMgmtExpandResourceTypesResourceGroupMockingExtension(resourceGroupResource).GetZone(zoneName, cancellationToken);
        }

        /// <summary>
        /// Lists the DNS zones in all resource groups in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/dnszones</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_List</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtExpandResourceTypesSubscriptionMockingExtension.GetZonesByDnszone(int?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> The maximum number of DNS zones to return. If not specified, returns up to 100 zones. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ZoneResource" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<ZoneResource> GetZonesByDnszoneAsync(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMgmtExpandResourceTypesSubscriptionMockingExtension(subscriptionResource).GetZonesByDnszoneAsync(top, cancellationToken);
        }

        /// <summary>
        /// Lists the DNS zones in all resource groups in a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/dnszones</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Zones_List</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtExpandResourceTypesSubscriptionMockingExtension.GetZonesByDnszone(int?,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="top"> The maximum number of DNS zones to return. If not specified, returns up to 100 zones. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ZoneResource" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<ZoneResource> GetZonesByDnszone(this SubscriptionResource subscriptionResource, int? top = null, CancellationToken cancellationToken = default)
        {
            return GetMgmtExpandResourceTypesSubscriptionMockingExtension(subscriptionResource).GetZonesByDnszone(top, cancellationToken);
        }

        /// <summary>
        /// Returns the DNS records specified by the referencing targetResourceIds.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/getDnsResourceReference</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DnsResourceReference_GetByTargetResources</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtExpandResourceTypesSubscriptionMockingExtension.GetByTargetResourcesDnsResourceReference(DnsResourceReferenceContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="content"> Properties for dns resource reference request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static async Task<Response<DnsResourceReferenceResult>> GetByTargetResourcesDnsResourceReferenceAsync(this SubscriptionResource subscriptionResource, DnsResourceReferenceContent content, CancellationToken cancellationToken = default)
        {
            return await GetMgmtExpandResourceTypesSubscriptionMockingExtension(subscriptionResource).GetByTargetResourcesDnsResourceReferenceAsync(content, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns the DNS records specified by the referencing targetResourceIds.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Network/getDnsResourceReference</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DnsResourceReference_GetByTargetResources</description>
        /// </item>
        /// </list>
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MgmtExpandResourceTypesSubscriptionMockingExtension.GetByTargetResourcesDnsResourceReference(DnsResourceReferenceContent,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="content"> Properties for dns resource reference request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public static Response<DnsResourceReferenceResult> GetByTargetResourcesDnsResourceReference(this SubscriptionResource subscriptionResource, DnsResourceReferenceContent content, CancellationToken cancellationToken = default)
        {
            return GetMgmtExpandResourceTypesSubscriptionMockingExtension(subscriptionResource).GetByTargetResourcesDnsResourceReference(content, cancellationToken);
        }
    }
}
