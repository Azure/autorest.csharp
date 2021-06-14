// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace ResourceIdentifierChooser
{
    /// <summary> Extension methods for convenient access on SubscriptionOperations in a client. </summary>
    public static partial class SubscriptionExtensions
    {
        #region SubscriptionLevelResource
        /// <summary> Gets an object representing a SubscriptionLevelResourceContainer along with the instance operations that can be performed on it. </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        public static SubscriptionLevelResourceContainer GetSubscriptionLevelResourceContainer(this SubscriptionOperations subscription)
        {
            return new SubscriptionLevelResourceContainer(subscription);
        }
        #endregion

        #region SubResResource
        /// <summary> Gets an object representing a SubResResourceContainer along with the instance operations that can be performed on it. </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        public static SubResResourceContainer GetSubResResourceContainer(this SubscriptionOperations subscription)
        {
            return new SubResResourceContainer(subscription);
        }
        #endregion

        #region WritableSubResResource
        /// <summary> Gets an object representing a WritableSubResResourceContainer along with the instance operations that can be performed on it. </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        public static WritableSubResResourceContainer GetWritableSubResResourceContainer(this SubscriptionOperations subscription)
        {
            return new WritableSubResResourceContainer(subscription);
        }
        #endregion
    }
}
