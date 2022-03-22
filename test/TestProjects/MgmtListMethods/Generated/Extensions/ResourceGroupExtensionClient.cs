// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtListMethods
{
    /// <summary> A class to add extension methods to ResourceGroup. </summary>
    internal partial class ResourceGroupExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class for mocking. </summary>
        protected ResourceGroupExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResourceGroupExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ResourceGroupExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorWithNonResChWithLocs in the ResourceGroup. </summary>
        /// <returns> An object representing collection of ResGrpParentWithAncestorWithNonResChWithLocs and their operations over a ResGrpParentWithAncestorWithNonResChWithLoc. </returns>
        public virtual ResGrpParentWithAncestorWithNonResChWithLocCollection GetResGrpParentWithAncestorWithNonResChWithLocs()
        {
            return GetCachedClient(Client => new ResGrpParentWithAncestorWithNonResChWithLocCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorWithNonResChes in the ResourceGroup. </summary>
        /// <returns> An object representing collection of ResGrpParentWithAncestorWithNonResChes and their operations over a ResGrpParentWithAncestorWithNonResCh. </returns>
        public virtual ResGrpParentWithAncestorWithNonResChCollection GetResGrpParentWithAncestorWithNonResChes()
        {
            return GetCachedClient(Client => new ResGrpParentWithAncestorWithNonResChCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestorWithLocs in the ResourceGroup. </summary>
        /// <returns> An object representing collection of ResGrpParentWithAncestorWithLocs and their operations over a ResGrpParentWithAncestorWithLoc. </returns>
        public virtual ResGrpParentWithAncestorWithLocCollection GetResGrpParentWithAncestorWithLocs()
        {
            return GetCachedClient(Client => new ResGrpParentWithAncestorWithLocCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResGrpParentWithAncestors in the ResourceGroup. </summary>
        /// <returns> An object representing collection of ResGrpParentWithAncestors and their operations over a ResGrpParentWithAncestor. </returns>
        public virtual ResGrpParentWithAncestorCollection GetResGrpParentWithAncestors()
        {
            return GetCachedClient(Client => new ResGrpParentWithAncestorCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResGrpParentWithNonResChes in the ResourceGroup. </summary>
        /// <returns> An object representing collection of ResGrpParentWithNonResChes and their operations over a ResGrpParentWithNonResCh. </returns>
        public virtual ResGrpParentWithNonResChCollection GetResGrpParentWithNonResChes()
        {
            return GetCachedClient(Client => new ResGrpParentWithNonResChCollection(Client, Id));
        }

        /// <summary> Gets a collection of ResGrpParents in the ResourceGroup. </summary>
        /// <returns> An object representing collection of ResGrpParents and their operations over a ResGrpParent. </returns>
        public virtual ResGrpParentCollection GetResGrpParents()
        {
            return GetCachedClient(Client => new ResGrpParentCollection(Client, Id));
        }
    }
}
