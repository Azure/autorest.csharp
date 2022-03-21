// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace MgmtListMethods
{
    /// <summary> A class to add extension methods to ManagementGroup. </summary>
    internal partial class ManagementGroupExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ManagementGroupExtensionClient"/> class for mocking. </summary>
        protected ManagementGroupExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagementGroupExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ManagementGroupExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of MgmtGrpParentWithNonResChWithLocs in the ManagementGroup. </summary>
        /// <returns> An object representing collection of MgmtGrpParentWithNonResChWithLocs and their operations over a MgmtGrpParentWithNonResChWithLoc. </returns>
        public virtual MgmtGrpParentWithNonResChWithLocCollection GetMgmtGrpParentWithNonResChWithLocs()
        {
            return GetCachedClient(Client => new MgmtGrpParentWithNonResChWithLocCollection(Client, Id));
        }

        /// <summary> Gets a collection of MgmtGrpParentWithNonResChes in the ManagementGroup. </summary>
        /// <returns> An object representing collection of MgmtGrpParentWithNonResChes and their operations over a MgmtGrpParentWithNonResCh. </returns>
        public virtual MgmtGrpParentWithNonResChCollection GetMgmtGrpParentWithNonResChes()
        {
            return GetCachedClient(Client => new MgmtGrpParentWithNonResChCollection(Client, Id));
        }

        /// <summary> Gets a collection of MgmtGrpParentWithLocs in the ManagementGroup. </summary>
        /// <returns> An object representing collection of MgmtGrpParentWithLocs and their operations over a MgmtGrpParentWithLoc. </returns>
        public virtual MgmtGrpParentWithLocCollection GetMgmtGrpParentWithLocs()
        {
            return GetCachedClient(Client => new MgmtGrpParentWithLocCollection(Client, Id));
        }

        /// <summary> Gets a collection of MgmtGroupParents in the ManagementGroup. </summary>
        /// <returns> An object representing collection of MgmtGroupParents and their operations over a MgmtGroupParent. </returns>
        public virtual MgmtGroupParentCollection GetMgmtGroupParents()
        {
            return GetCachedClient(Client => new MgmtGroupParentCollection(Client, Id));
        }
    }
}
