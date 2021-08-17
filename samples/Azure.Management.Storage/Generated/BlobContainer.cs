// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A Class representing a BlobContainer along with the instance operations that can be performed on it. </summary>
    public partial class BlobContainer : ArmResource
    {
        private readonly BlobContainerData _data;

        /// <summary> Initializes a new instance of the <see cref="BlobContainer"/> class for mocking. </summary>
        protected BlobContainer()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "BlobContainer"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal BlobContainer(ArmResource options, BlobContainerData resource) : base(options, ResourceIdentifier.RootResourceIdentifier)
        {
            HasData = true;
            _data = resource;
        }

        /// <summary> Initializes a new instance of the <see cref="BlobContainer"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        internal BlobContainer(ArmResource options) : base(options, ResourceIdentifier.RootResourceIdentifier)
        {
        }

        /// <summary> Gets the parent resource of this resource. </summary>
        public ArmResource Parent { get; }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/blobServices/default/containers";

        /// <summary> Gets the valid resource type for the operations. </summary>
        protected override ResourceType ValidResourceType => ResourceType;

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual BlobContainerData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }
    }
}
