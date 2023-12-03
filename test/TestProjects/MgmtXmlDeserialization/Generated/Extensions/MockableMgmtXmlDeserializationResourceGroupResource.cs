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
using MgmtXmlDeserialization;

namespace MgmtXmlDeserialization.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MockableMgmtXmlDeserializationResourceGroupResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableMgmtXmlDeserializationResourceGroupResource"/> class for mocking. </summary>
        protected MockableMgmtXmlDeserializationResourceGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtXmlDeserializationResourceGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtXmlDeserializationResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of XmlInstanceResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of XmlInstanceResources and their operations over a XmlInstanceResource. </returns>
        public virtual XmlInstanceCollection GetXmlInstances()
        {
            return GetCachedClient(client => new XmlInstanceCollection(client, Id));
        }

        /// <summary>
        /// Gets the details of the Xml specified by its identifier.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>XmlDeserialization_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<XmlInstanceResource>> GetXmlInstanceAsync(string xmlName, CancellationToken cancellationToken = default)
        {
            return await GetXmlInstances().GetAsync(xmlName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the details of the Xml specified by its identifier.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.XmlDeserialization/xmls/{xmlName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>XmlDeserialization_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="xmlName"> The name of the API Management service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="xmlName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="xmlName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<XmlInstanceResource> GetXmlInstance(string xmlName, CancellationToken cancellationToken = default)
        {
            return GetXmlInstances().Get(xmlName, cancellationToken);
        }
    }
}
