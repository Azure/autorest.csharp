// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtExtensionResource
{
    /// <summary>
    /// A class representing a collection of <see cref="BuiltInPolicyDefinitionResource" /> and their operations.
    /// Each <see cref="BuiltInPolicyDefinitionResource" /> in the collection will belong to the same instance of <see cref="TenantResource" />.
    /// To get a <see cref="BuiltInPolicyDefinitionCollection" /> instance call the GetBuiltInPolicyDefinitions method from an instance of <see cref="TenantResource" />.
    /// </summary>
    public partial class BuiltInPolicyDefinitionCollection : ArmCollection, IEnumerable<BuiltInPolicyDefinitionResource>, IAsyncEnumerable<BuiltInPolicyDefinitionResource>
    {
        private readonly ClientDiagnostics _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics;
        private readonly PolicyDefinitionsRestOperations _builtInPolicyDefinitionPolicyDefinitionsRestClient;

        /// <summary> Initializes a new instance of the <see cref="BuiltInPolicyDefinitionCollection"/> class for mocking. </summary>
        protected BuiltInPolicyDefinitionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BuiltInPolicyDefinitionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal BuiltInPolicyDefinitionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics = new ClientDiagnostics("MgmtExtensionResource", BuiltInPolicyDefinitionResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(BuiltInPolicyDefinitionResource.ResourceType, out string builtInPolicyDefinitionPolicyDefinitionsApiVersion);
            _builtInPolicyDefinitionPolicyDefinitionsRestClient = new PolicyDefinitionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, builtInPolicyDefinitionPolicyDefinitionsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != TenantResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, TenantResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// This operation retrieves the built-in policy definition with the given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyDefinitions_GetBuiltIn</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyDefinitionName"> The name of the built-in policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        public virtual async Task<Response<BuiltInPolicyDefinitionResource>> GetAsync(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));

            using var scope = _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("BuiltInPolicyDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = await _builtInPolicyDefinitionPolicyDefinitionsRestClient.GetBuiltInAsync(policyDefinitionName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BuiltInPolicyDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves the built-in policy definition with the given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyDefinitions_GetBuiltIn</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyDefinitionName"> The name of the built-in policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        public virtual Response<BuiltInPolicyDefinitionResource> Get(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));

            using var scope = _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("BuiltInPolicyDefinitionCollection.Get");
            scope.Start();
            try
            {
                var response = _builtInPolicyDefinitionPolicyDefinitionsRestClient.GetBuiltIn(policyDefinitionName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BuiltInPolicyDefinitionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This operation retrieves a list of all the built-in policy definitions that match the optional given $filter. If $filter='policyType -eq {value}' is provided, the returned list only includes all built-in policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter='category -eq {value}' is provided, the returned list only includes all built-in policy definitions whose category match the {value}.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policyDefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyDefinitions_ListBuiltIn</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atExactScope()', 'policyType -eq {value}' or 'category eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy definitions that at the given scope. If $filter='policyType -eq {value}' is provided, the returned list only includes all policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter='category -eq {value}' is provided, the returned list only includes all policy definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BuiltInPolicyDefinitionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BuiltInPolicyDefinitionResource> GetAllAsync(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _builtInPolicyDefinitionPolicyDefinitionsRestClient.CreateListBuiltInRequest(filter, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _builtInPolicyDefinitionPolicyDefinitionsRestClient.CreateListBuiltInNextPageRequest(nextLink, filter, top);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new BuiltInPolicyDefinitionResource(Client, PolicyDefinitionData.DeserializePolicyDefinitionData(e)), _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics, Pipeline, "BuiltInPolicyDefinitionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// This operation retrieves a list of all the built-in policy definitions that match the optional given $filter. If $filter='policyType -eq {value}' is provided, the returned list only includes all built-in policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter='category -eq {value}' is provided, the returned list only includes all built-in policy definitions whose category match the {value}.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policyDefinitions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyDefinitions_ListBuiltIn</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> The filter to apply on the operation. Valid values for $filter are: 'atExactScope()', 'policyType -eq {value}' or 'category eq '{value}''. If $filter is not provided, no filtering is performed. If $filter=atExactScope() is provided, the returned list only includes all policy definitions that at the given scope. If $filter='policyType -eq {value}' is provided, the returned list only includes all policy definitions whose type match the {value}. Possible policyType values are NotSpecified, BuiltIn, Custom, and Static. If $filter='category -eq {value}' is provided, the returned list only includes all policy definitions whose category match the {value}. </param>
        /// <param name="top"> Maximum number of records to return. When the $top filter is not provided, it will return 500 records. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BuiltInPolicyDefinitionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BuiltInPolicyDefinitionResource> GetAll(string filter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _builtInPolicyDefinitionPolicyDefinitionsRestClient.CreateListBuiltInRequest(filter, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _builtInPolicyDefinitionPolicyDefinitionsRestClient.CreateListBuiltInNextPageRequest(nextLink, filter, top);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new BuiltInPolicyDefinitionResource(Client, PolicyDefinitionData.DeserializePolicyDefinitionData(e)), _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics, Pipeline, "BuiltInPolicyDefinitionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyDefinitions_GetBuiltIn</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyDefinitionName"> The name of the built-in policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));

            using var scope = _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("BuiltInPolicyDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = await _builtInPolicyDefinitionPolicyDefinitionsRestClient.GetBuiltInAsync(policyDefinitionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PolicyDefinitions_GetBuiltIn</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyDefinitionName"> The name of the built-in policy definition to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="policyDefinitionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="policyDefinitionName"/> is null. </exception>
        public virtual Response<bool> Exists(string policyDefinitionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(policyDefinitionName, nameof(policyDefinitionName));

            using var scope = _builtInPolicyDefinitionPolicyDefinitionsClientDiagnostics.CreateScope("BuiltInPolicyDefinitionCollection.Exists");
            scope.Start();
            try
            {
                var response = _builtInPolicyDefinitionPolicyDefinitionsRestClient.GetBuiltIn(policyDefinitionName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<BuiltInPolicyDefinitionResource> IEnumerable<BuiltInPolicyDefinitionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<BuiltInPolicyDefinitionResource> IAsyncEnumerable<BuiltInPolicyDefinitionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
