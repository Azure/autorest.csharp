// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using SupersetInheritance.Models;

namespace SupersetInheritance
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        #region SupersetModel1
        /// <summary> Gets an object representing a SupersetModel1Collection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="SupersetModel1Collection" /> object. </returns>
        public static SupersetModel1Collection GetSupersetModel1s(this ResourceGroup resourceGroup)
        {
            return new SupersetModel1Collection(resourceGroup);
        }
        #endregion

        #region SupersetModel4
        /// <summary> Gets an object representing a SupersetModel4Collection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="SupersetModel4Collection" /> object. </returns>
        public static SupersetModel4Collection GetSupersetModel4s(this ResourceGroup resourceGroup)
        {
            return new SupersetModel4Collection(resourceGroup);
        }
        #endregion

        private static ResourceGroupExtensionClient GetExtensionClient(ResourceGroup resourceGroup)
        {
            return resourceGroup.GetCachedClient((armClient) =>
            {
                return new ResourceGroupExtensionClient(armClient, resourceGroup.Id);
            }
            );
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel2s_Put
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentException"> <paramref name="supersetModel2SName"/> is null or empty. </exception>
        /// <exception cref="System.ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public static async Task<SupersetModel2> PutSupersetModel2Async(this ResourceGroup resourceGroup, string supersetModel2SName, SupersetModel2 parameters, CancellationToken cancellationToken = default)
        {
            return await GetExtensionClient(resourceGroup).PutSupersetModel2Async(supersetModel2SName, parameters, cancellationToken).ConfigureAwait(false);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel2s_Put
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel2 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentException"> <paramref name="supersetModel2SName"/> is null or empty. </exception>
        /// <exception cref="System.ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public static SupersetModel2 PutSupersetModel2(this ResourceGroup resourceGroup, string supersetModel2SName, SupersetModel2 parameters, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroup).PutSupersetModel2(supersetModel2SName, parameters, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel2s_Get
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentException"> <paramref name="supersetModel2SName"/> is null or empty. </exception>
        public static async Task<SupersetModel2> GetSupersetModel2Async(this ResourceGroup resourceGroup, string supersetModel2SName, CancellationToken cancellationToken = default)
        {
            return await GetExtensionClient(resourceGroup).GetSupersetModel2Async(supersetModel2SName, cancellationToken).ConfigureAwait(false);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel2s/{supersetModel2sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel2s_Get
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="supersetModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentException"> <paramref name="supersetModel2SName"/> is null or empty. </exception>
        public static SupersetModel2 GetSupersetModel2(this ResourceGroup resourceGroup, string supersetModel2SName, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroup).GetSupersetModel2(supersetModel2SName, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel3s_Put
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentException"> <paramref name="supersetModel3SName"/> is null or empty. </exception>
        /// <exception cref="System.ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public static async Task<SupersetModel3> PutSupersetModel3Async(this ResourceGroup resourceGroup, string supersetModel3SName, SupersetModel3 parameters, CancellationToken cancellationToken = default)
        {
            return await GetExtensionClient(resourceGroup).PutSupersetModel3Async(supersetModel3SName, parameters, cancellationToken).ConfigureAwait(false);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel3s_Put
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel3 to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentException"> <paramref name="supersetModel3SName"/> is null or empty. </exception>
        /// <exception cref="System.ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public static SupersetModel3 PutSupersetModel3(this ResourceGroup resourceGroup, string supersetModel3SName, SupersetModel3 parameters, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroup).PutSupersetModel3(supersetModel3SName, parameters, cancellationToken);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel3s_Get
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentException"> <paramref name="supersetModel3SName"/> is null or empty. </exception>
        public static async Task<SupersetModel3> GetSupersetModel3Async(this ResourceGroup resourceGroup, string supersetModel3SName, CancellationToken cancellationToken = default)
        {
            return await GetExtensionClient(resourceGroup).GetSupersetModel3Async(supersetModel3SName, cancellationToken).ConfigureAwait(false);
        }

        /// RequestPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel3s/{supersetModel3sName}
        /// ContextualPath: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
        /// OperationId: SupersetModel3s_Get
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <param name="supersetModel3SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="System.ArgumentException"> <paramref name="supersetModel3SName"/> is null or empty. </exception>
        public static SupersetModel3 GetSupersetModel3(this ResourceGroup resourceGroup, string supersetModel3SName, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(resourceGroup).GetSupersetModel3(supersetModel3SName, cancellationToken);
        }
    }
}
