// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using MgmtPagination;

namespace MgmtPagination.Mocking
{
    /// <summary> A class to add extension methods to ArmClient. </summary>
    internal partial class MgmtPaginationArmClientMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MgmtPaginationArmClientMockingExtension"/> class for mocking. </summary>
        protected MgmtPaginationArmClientMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtPaginationArmClientMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtPaginationArmClientMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        internal MgmtPaginationArmClientMockingExtension(ArmClient client) : this(client, ResourceIdentifier.Root)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Gets an object representing a <see cref="PageSizeIntegerModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeIntegerModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeIntegerModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeIntegerModelResource" /> object. </returns>
        public virtual PageSizeIntegerModelResource GetPageSizeIntegerModelResource(ResourceIdentifier id)
        {
            PageSizeIntegerModelResource.ValidateResourceId(id);
            return new PageSizeIntegerModelResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PageSizeInt64ModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeInt64ModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeInt64ModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeInt64ModelResource" /> object. </returns>
        public virtual PageSizeInt64ModelResource GetPageSizeInt64ModelResource(ResourceIdentifier id)
        {
            PageSizeInt64ModelResource.ValidateResourceId(id);
            return new PageSizeInt64ModelResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PageSizeInt32ModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeInt32ModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeInt32ModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeInt32ModelResource" /> object. </returns>
        public virtual PageSizeInt32ModelResource GetPageSizeInt32ModelResource(ResourceIdentifier id)
        {
            PageSizeInt32ModelResource.ValidateResourceId(id);
            return new PageSizeInt32ModelResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PageSizeNumericModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeNumericModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeNumericModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeNumericModelResource" /> object. </returns>
        public virtual PageSizeNumericModelResource GetPageSizeNumericModelResource(ResourceIdentifier id)
        {
            PageSizeNumericModelResource.ValidateResourceId(id);
            return new PageSizeNumericModelResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PageSizeFloatModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeFloatModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeFloatModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeFloatModelResource" /> object. </returns>
        public virtual PageSizeFloatModelResource GetPageSizeFloatModelResource(ResourceIdentifier id)
        {
            PageSizeFloatModelResource.ValidateResourceId(id);
            return new PageSizeFloatModelResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PageSizeDoubleModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeDoubleModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeDoubleModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeDoubleModelResource" /> object. </returns>
        public virtual PageSizeDoubleModelResource GetPageSizeDoubleModelResource(ResourceIdentifier id)
        {
            PageSizeDoubleModelResource.ValidateResourceId(id);
            return new PageSizeDoubleModelResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PageSizeDecimalModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeDecimalModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeDecimalModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeDecimalModelResource" /> object. </returns>
        public virtual PageSizeDecimalModelResource GetPageSizeDecimalModelResource(ResourceIdentifier id)
        {
            PageSizeDecimalModelResource.ValidateResourceId(id);
            return new PageSizeDecimalModelResource(Client, id);
        }

        /// <summary>
        /// Gets an object representing a <see cref="PageSizeStringModelResource" /> along with the instance operations that can be performed on it but with no data.
        /// You can use <see cref="PageSizeStringModelResource.CreateResourceIdentifier" /> to create a <see cref="PageSizeStringModelResource" /> <see cref="ResourceIdentifier" /> from its components.
        /// </summary>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="PageSizeStringModelResource" /> object. </returns>
        public virtual PageSizeStringModelResource GetPageSizeStringModelResource(ResourceIdentifier id)
        {
            PageSizeStringModelResource.ValidateResourceId(id);
            return new PageSizeStringModelResource(Client, id);
        }
    }
}
