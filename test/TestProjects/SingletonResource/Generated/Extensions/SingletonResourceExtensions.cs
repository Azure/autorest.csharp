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

namespace SingletonResource
{
    /// <summary> A class to add extension methods to SingletonResource. </summary>
    public static partial class SingletonResourceExtensions
    {
        private static ResourceGroupResourceExtensionClient GetExtensionClient(ResourceGroupResource resourceGroupResource)
        {
            return resourceGroupResource.GetCachedClient((client) =>
            {
                return new ResourceGroupResourceExtensionClient(client, resourceGroupResource.Id);
            }
            );
        }

        /// <summary> Gets a collection of CarResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of CarResources and their operations over a CarResource. </returns>
        public static CarCollection GetCars(this ResourceGroupResource resourceGroupResource)
        {
            return GetExtensionClient(resourceGroupResource).GetCars();
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<CarResource>> GetCarAsync(this ResourceGroupResource resourceGroupResource, string carName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetCars().GetAsync(carName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<CarResource> GetCar(this ResourceGroupResource resourceGroupResource, string carName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetCars().Get(carName, cancellationToken);
        }

        /// <summary> Gets a collection of ParentResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ParentResources and their operations over a ParentResource. </returns>
        public static ParentResourceCollection GetParentResources(this ResourceGroupResource resourceGroupResource)
        {
            return GetExtensionClient(resourceGroupResource).GetParentResources();
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ParentResource>> GetParentResourceAsync(this ResourceGroupResource resourceGroupResource, string parentName, CancellationToken cancellationToken = default)
        {
            return await resourceGroupResource.GetParentResources().GetAsync(parentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_Get
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ParentResource> GetParentResource(this ResourceGroupResource resourceGroupResource, string parentName, CancellationToken cancellationToken = default)
        {
            return resourceGroupResource.GetParentResources().Get(parentName, cancellationToken);
        }

        #region CarResource
        /// <summary>
        /// Gets an object representing a <see cref="CarResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="CarResource.CreateResourceIdentifier" /> to create a <see cref="CarResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="CarResource" /> object. </returns>
        public static CarResource GetCarResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                CarResource.ValidateResourceId(id);
                return new CarResource(client, id);
            }
            );
        }
        #endregion

        #region IgnitionResource
        /// <summary>
        /// Gets an object representing an <see cref="IgnitionResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="IgnitionResource.CreateResourceIdentifier" /> to create an <see cref="IgnitionResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="IgnitionResource" /> object. </returns>
        public static IgnitionResource GetIgnitionResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                IgnitionResource.ValidateResourceId(id);
                return new IgnitionResource(client, id);
            }
            );
        }
        #endregion

        #region SingletonResource
        /// <summary>
        /// Gets an object representing a <see cref="SingletonResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="SingletonResource.CreateResourceIdentifier" /> to create a <see cref="SingletonResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="SingletonResource" /> object. </returns>
        public static SingletonResource GetSingletonResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                SingletonResource.ValidateResourceId(id);
                return new SingletonResource(client, id);
            }
            );
        }
        #endregion

        #region ParentResource
        /// <summary>
        /// Gets an object representing a <see cref="ParentResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="ParentResource.CreateResourceIdentifier" /> to create a <see cref="ParentResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="ParentResource" /> object. </returns>
        public static ParentResource GetParentResource(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                ParentResource.ValidateResourceId(id);
                return new ParentResource(client, id);
            }
            );
        }
        #endregion
    }
}
