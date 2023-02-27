// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager;
using MgmtHierarchicalNonResource;

namespace MgmtHierarchicalNonResource.Mock
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class SubscriptionResourceExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="SubscriptionResourceExtensionClient"/> class for mocking. </summary>
        protected SubscriptionResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of SharedGalleryResources in the SubscriptionResource. </summary>
        /// <param name="location"> Resource location. </param>
        /// <exception cref="ArgumentException"> <paramref name="location"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        /// <returns> An object representing collection of SharedGalleryResources and their operations over a SharedGalleryResource. </returns>
        public virtual SharedGalleryCollection GetSharedGalleries(string location)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));

            return new SharedGalleryCollection(Client, Id, location);
        }
    }
}
