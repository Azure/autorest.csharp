// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using MgmtListMethods;

namespace MgmtListMethods.Mocking
{
    /// <summary> A class to add extension methods to ManagementGroupResource. </summary>
    public partial class MgmtListMethodsManagementGroupMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MgmtListMethodsManagementGroupMockingExtension"/> class for mocking. </summary>
        protected MgmtListMethodsManagementGroupMockingExtension()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MgmtListMethodsManagementGroupMockingExtension"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MgmtListMethodsManagementGroupMockingExtension(ArmClient client, ResourceIdentifier id) : base(client, id)
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
            return GetCachedClient(client => new MgmtGrpParentWithNonResChWithLocCollection(client, Id));
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs/{mgmtGrpParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<MgmtGrpParentWithNonResChWithLocResource>> GetMgmtGrpParentWithNonResChWithLocAsync(string mgmtGrpParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            return await GetMgmtGrpParentWithNonResChWithLocs().GetAsync(mgmtGrpParentWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChWithLocs/{mgmtGrpParentWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<MgmtGrpParentWithNonResChWithLocResource> GetMgmtGrpParentWithNonResChWithLoc(string mgmtGrpParentWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            return GetMgmtGrpParentWithNonResChWithLocs().Get(mgmtGrpParentWithNonResChWithLocName, cancellationToken);
        }

        /// <summary> Gets a collection of MgmtGrpParentWithNonResChResources in the ManagementGroupResource. </summary>
        /// <returns> An object representing collection of MgmtGrpParentWithNonResChResources and their operations over a MgmtGrpParentWithNonResChResource. </returns>
        public virtual MgmtGrpParentWithNonResChCollection GetMgmtGrpParentWithNonResChes()
        {
            return GetCachedClient(client => new MgmtGrpParentWithNonResChCollection(client, Id));
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes/{mgmtGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<MgmtGrpParentWithNonResChResource>> GetMgmtGrpParentWithNonResChAsync(string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            return await GetMgmtGrpParentWithNonResChes().GetAsync(mgmtGrpParentWithNonResChName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithNonResChes/{mgmtGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithNonResChName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<MgmtGrpParentWithNonResChResource> GetMgmtGrpParentWithNonResCh(string mgmtGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            return GetMgmtGrpParentWithNonResChes().Get(mgmtGrpParentWithNonResChName, cancellationToken);
        }

        /// <summary> Gets a collection of MgmtGrpParentWithLocResources in the ManagementGroupResource. </summary>
        /// <returns> An object representing collection of MgmtGrpParentWithLocResources and their operations over a MgmtGrpParentWithLocResource. </returns>
        public virtual MgmtGrpParentWithLocCollection GetMgmtGrpParentWithLocs()
        {
            return GetCachedClient(client => new MgmtGrpParentWithLocCollection(client, Id));
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<MgmtGrpParentWithLocResource>> GetMgmtGrpParentWithLocAsync(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            return await GetMgmtGrpParentWithLocs().GetAsync(mgmtGrpParentWithLocName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGrpParentWithLocs/{mgmtGrpParentWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGrpParentWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGrpParentWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGrpParentWithLocName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGrpParentWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<MgmtGrpParentWithLocResource> GetMgmtGrpParentWithLoc(string mgmtGrpParentWithLocName, CancellationToken cancellationToken = default)
        {
            return GetMgmtGrpParentWithLocs().Get(mgmtGrpParentWithLocName, cancellationToken);
        }

        /// <summary> Gets a collection of MgmtGroupParentResources in the ManagementGroupResource. </summary>
        /// <returns> An object representing collection of MgmtGroupParentResources and their operations over a MgmtGroupParentResource. </returns>
        public virtual MgmtGroupParentCollection GetMgmtGroupParents()
        {
            return GetCachedClient(client => new MgmtGroupParentCollection(client, Id));
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<MgmtGroupParentResource>> GetMgmtGroupParentAsync(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            return await GetMgmtGroupParents().GetAsync(mgmtGroupParentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Management/managementGroups/{groupId}/mgmtGroupParents/{mgmtGroupParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MgmtGroupParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="mgmtGroupParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mgmtGroupParentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="mgmtGroupParentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<MgmtGroupParentResource> GetMgmtGroupParent(string mgmtGroupParentName, CancellationToken cancellationToken = default)
        {
            return GetMgmtGroupParents().Get(mgmtGroupParentName, cancellationToken);
        }
    }
}
