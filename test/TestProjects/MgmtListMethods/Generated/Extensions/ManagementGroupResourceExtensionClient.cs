// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace MgmtListMethods
{
    /// <summary> A class to add extension methods to ManagementGroupResource. </summary>
    internal partial class ManagementGroupResourceExtensionClient : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="ManagementGroupResourceExtensionClient"/> class for mocking. </summary>
        protected ManagementGroupResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagementGroupResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ManagementGroupResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of MgmtGrpParentWithNonResChWithLocResources in the ManagementGroupResource. </summary>
        /// <returns> An object representing collection of MgmtGrpParentWithNonResChWithLocResources and their operations over a MgmtGrpParentWithNonResChWithLocResource. </returns>
        public virtual MgmtGrpParentWithNonResChWithLocCollection GetMgmtGrpParentWithNonResChWithLocs()
        {
            return GetCachedClient(Client => new MgmtGrpParentWithNonResChWithLocCollection(Client, Id));
        }

        /// <summary> Gets a collection of MgmtGrpParentWithNonResChResources in the ManagementGroupResource. </summary>
        /// <returns> An object representing collection of MgmtGrpParentWithNonResChResources and their operations over a MgmtGrpParentWithNonResChResource. </returns>
        public virtual MgmtGrpParentWithNonResChCollection GetMgmtGrpParentWithNonResChes()
        {
            return GetCachedClient(Client => new MgmtGrpParentWithNonResChCollection(Client, Id));
        }

        /// <summary> Gets a collection of MgmtGrpParentWithLocResources in the ManagementGroupResource. </summary>
        /// <returns> An object representing collection of MgmtGrpParentWithLocResources and their operations over a MgmtGrpParentWithLocResource. </returns>
        public virtual MgmtGrpParentWithLocCollection GetMgmtGrpParentWithLocs()
        {
            return GetCachedClient(Client => new MgmtGrpParentWithLocCollection(Client, Id));
        }

        /// <summary> Gets a collection of MgmtGroupParentResources in the ManagementGroupResource. </summary>
        /// <returns> An object representing collection of MgmtGroupParentResources and their operations over a MgmtGroupParentResource. </returns>
        public virtual MgmtGroupParentCollection GetMgmtGroupParents()
        {
            return GetCachedClient(Client => new MgmtGroupParentCollection(Client, Id));
        }
    }
}
