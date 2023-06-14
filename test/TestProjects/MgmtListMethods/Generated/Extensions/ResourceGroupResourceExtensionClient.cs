// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtListMethods
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorWithNonResChWithLocResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ResGrpParentWithAncestorWithNonResChWithLocResources and their operations over a ResGrpParentWithAncestorWithNonResChWithLocResource. </returns>
        public virtual ResGrpParentWithAncestorWithNonResChWithLocCollection GetResGrpParentWithAncestorWithNonResChWithLocs()
        {
            return GetCachedClient(Client => new ResGrpParentWithAncestorWithNonResChWithLocCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorWithNonResChResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ResGrpParentWithAncestorWithNonResChResources and their operations over a ResGrpParentWithAncestorWithNonResChResource. </returns>
        public virtual ResGrpParentWithAncestorWithNonResChCollection GetResGrpParentWithAncestorWithNonResChes()
        {
            return GetCachedClient(Client => new ResGrpParentWithAncestorWithNonResChCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorWithLocResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ResGrpParentWithAncestorWithLocResources and their operations over a ResGrpParentWithAncestorWithLocResource. </returns>
        public virtual ResGrpParentWithAncestorWithLocCollection GetResGrpParentWithAncestorWithLocs()
        {
            return GetCachedClient(Client => new ResGrpParentWithAncestorWithLocCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ResGrpParentWithAncestorResources and their operations over a ResGrpParentWithAncestorResource. </returns>
        public virtual ResGrpParentWithAncestorCollection GetResGrpParentWithAncestors()
        {
            return GetCachedClient(Client => new ResGrpParentWithAncestorCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResGrpParentWithNonResChResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ResGrpParentWithNonResChResources and their operations over a ResGrpParentWithNonResChResource. </returns>
        public virtual ResGrpParentWithNonResChCollection GetResGrpParentWithNonResChes()
        {
            return GetCachedClient(Client => new ResGrpParentWithNonResChCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResGrpParentResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of ResGrpParentResources and their operations over a ResGrpParentResource. </returns>
        public virtual ResGrpParentCollection GetResGrpParents()
        {
            return GetCachedClient(Client => new ResGrpParentCollection(Client, Id));
        }
    }
}
