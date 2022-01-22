// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Resources;

namespace MgmtNonStringPathVariable
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    public static partial class ResourceGroupExtensions
    {
        #region Fake
        /// <summary> Gets an object representing a FakeCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="FakeCollection" /> object. </returns>
        public static FakeCollection GetFakes(this ResourceGroup resourceGroup)
        {
            return new FakeCollection(resourceGroup);
        }
        #endregion

        #region Bar
        /// <summary> Gets an object representing a BarCollection along with the instance operations that can be performed on it. </summary>
        /// <param name="resourceGroup"> The <see cref="ResourceGroup" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="BarCollection" /> object. </returns>
        public static BarCollection GetBars(this ResourceGroup resourceGroup)
        {
            return new BarCollection(resourceGroup);
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
    }
}
