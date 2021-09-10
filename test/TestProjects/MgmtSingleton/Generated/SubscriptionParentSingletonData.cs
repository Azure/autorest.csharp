// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager;
using Azure.ResourceManager.Models;

namespace MgmtSingleton
{
    /// <summary> A class representing the SubscriptionParentSingleton data model. </summary>
    public partial class SubscriptionParentSingletonData : Resource
    {
        /// <summary> Initializes a new instance of SubscriptionParentSingletonData. </summary>
        public SubscriptionParentSingletonData()
        {
        }

        /// <summary> Initializes a new instance of SubscriptionParentSingletonData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="new"> The New. </param>
        internal SubscriptionParentSingletonData(ResourceIdentifier id, string name, ResourceType type, string @new) : base(id, name, type)
        {
            New = @new;
        }

        /// <summary> The New. </summary>
        public string New { get; set; }
    }
}
