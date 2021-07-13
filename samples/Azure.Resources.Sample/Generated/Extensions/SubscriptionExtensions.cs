// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.Resources.Sample
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    public static partial class SubscriptionExtensions
    {
        #region DeploymentExtended
        /// <summary> Gets an object representing a DeploymentExtendedContainer along with the instance operations that can be performed on it. </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="DeploymentExtendedContainer" /> object. </returns>
        public static DeploymentExtendedContainer GetDeploymentExtendedContainer(this SubscriptionOperations subscription)
        {
            return new DeploymentExtendedContainer(subscription);
        }
        #endregion
    }
}
