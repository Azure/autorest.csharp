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
        private static ResourceGroupExtensionClient GetExtensionClient(ResourceGroup resourceGroup)
        {
            return resourceGroup.GetCachedClient((client) =>
            {
                return new ResourceGroupExtensionClient(client, resourceGroup.Id);
            }
            );
        }

        /// <summary> Gets a collection of Cars in the ResourceGroup. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of Cars and their operations over a Car. </returns>
        public static CarCollection GetCars(this ResourceGroup resourceGroup)
        {
            return GetExtensionClient(resourceGroup).GetCars();
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public static async Task<Response<Car>> GetCarAsync(this ResourceGroup resourceGroup, string carName, CancellationToken cancellationToken = default)
        {
            return await resourceGroup.GetCars().GetAsync(carName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cars/{carName}
        /// Operation Id: Cars_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="carName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="carName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="carName"/> is null. </exception>
        public static Response<Car> GetCar(this ResourceGroup resourceGroup, string carName, CancellationToken cancellationToken = default)
        {
            return resourceGroup.GetCars().Get(carName, cancellationToken);
        }

        /// <summary> Gets a collection of ParentResources in the ResourceGroup. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of ParentResources and their operations over a ParentResource. </returns>
        public static ParentResourceCollection GetParentResources(this ResourceGroup resourceGroup)
        {
            return GetExtensionClient(resourceGroup).GetParentResources();
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public static async Task<Response<ParentResource>> GetParentResourceAsync(this ResourceGroup resourceGroup, string parentName, CancellationToken cancellationToken = default)
        {
            return await resourceGroup.GetParentResources().GetAsync(parentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Singleton Test Parent Example.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Billing/parentResources/{parentName}
        /// Operation Id: ParentResources_Get
        /// </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="parentName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="parentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="parentName"/> is null. </exception>
        public static Response<ParentResource> GetParentResource(this ResourceGroup resourceGroup, string parentName, CancellationToken cancellationToken = default)
        {
            return resourceGroup.GetParentResources().Get(parentName, cancellationToken);
        }

        #region Car
        /// <summary>
        /// Gets an object representing a <see cref="Car" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="Car.CreateResourceIdentifier" /> to create a <see cref="Car" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Car" /> object. </returns>
        public static Car GetCar(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                Car.ValidateResourceId(id);
                return new Car(client, id);
            }
            );
        }
        #endregion

        #region Ignition
        /// <summary>
        /// Gets an object representing an <see cref="Ignition" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="Ignition.CreateResourceIdentifier" /> to create an <see cref="Ignition" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient" /> instance the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="Ignition" /> object. </returns>
        public static Ignition GetIgnition(this ArmClient client, ResourceIdentifier id)
        {
            return client.GetResourceClient(() =>
            {
                Ignition.ValidateResourceId(id);
                return new Ignition(client, id);
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
